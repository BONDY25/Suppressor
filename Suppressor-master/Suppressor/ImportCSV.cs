using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Suppressor
{
    public partial class ImportCSV : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        // Declare Global Variables
        public string userName { get; set; }
        public string sessionId { get; set; }
        public int cust = 0;

        // Set SQL Connection String
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public ImportCSV()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
            //this.KeyDown += MainFrom_KeyDown;
            Text = $"Import - {Environment.UserName.ToUpper()}";
        }

        private void ImportCSV_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[ImportCSV]", "[FormLoad]", "Application Started");
            OpenFileDialog();
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Create tKey -------------------------------------------------------------------------------------------------------------
        private string CreateTKey(string name)
        {
            string tKeySufix = name.Length >= 2 ? name.Substring(0, 2).ToUpper() : name.ToUpper();
            string tKeyTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string tKey = tKeyTimeStamp + tKeySufix;
            return tKey;
        }

        private void OpenFileDialog()
        {
            // Create an OpenFileDialog to choose the CSV file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            // Show the dialog and get the file path
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string csvFilePath = openFileDialog.FileName;
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Read the CSV data
                    DataTable dataTable = ReadCsv(csvFilePath);

                    // Insert data into the database
                    if (dataTable != null)
                    {
                        ImportData(dataTable);
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        // Read CSV ----------------------------------------------------------------------------------------------------------------------------
        private DataTable ReadCsv(string filePath)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    bool isFirstLine = true;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');

                        if (isFirstLine)
                        {
                            // Add columns to DataTable based on the first line (header)
                            foreach (string header in values)
                            {
                                dataTable.Columns.Add(header);
                            }
                            isFirstLine = false;
                        }
                        else
                        {
                            // Add rows to DataTable
                            dataTable.Rows.Add(values);
                        }
                    }
                }
                SessionMaintenance.LogBook("", "[ImportCSV]", "[ReadCsv]", $"CSV File accepted");
                return dataTable;


            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error Reading CSV";
                lblProgress.Text = "";
                lblrps.Text = "";
                lblError.Text = ex.Message;
                lblError.Visible = true;
                pBarImport.Visible = false;
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Error Reading CSV: {ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[ImportCSV]", "[ReadCsv]", $"FAILED (  {ex.Message}  )");
                return null;

            }
        }

        // Import Data ----------------------------------------------------------------------------------------------------------------------------
        private async void ImportData(DataTable dataTable)
        {
            int maxRows = dataTable.Rows.Count;
            int currentRows = 0;
            int batchSize = 1;

            Stopwatch stopwatch = Stopwatch.StartNew();
            SessionMaintenance.LogBook("", "[ImportCSV]", "[ImportData]", $"Method Started");

            try
            {
                pBarImport.Visible = true;
                lblProgress.Visible = true;
                lblError.Visible = false;
                btnFun.Enabled = false;
                pBarImport.Visible = true;
                lblStatus.Text = "Importing...";
                lblProgress.Text = $"{currentRows}/{maxRows}";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    pBarImport.Invoke((MethodInvoker)(() =>
                    {
                        pBarImport.Maximum = maxRows;
                        pBarImport.Value = 0;
                    }));

                    // ** Parallel Execution with Task List ** //
                    List<Task> insertTasks = new List<Task>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create task for each insert //
                        insertTasks.Add(Task.Run(async () =>
                        {
                            // Check Name Field //
                            string name = row["Name"].ToString();
                            if (string.IsNullOrEmpty(name))
                            {
                                throw new Exception("Name Field Cannot be blank");
                            }

                            // Do SQL Stuff //
                            string query = "EXECUTE [Suppressor_Insert_Details] @tKey, @Client, @Customer, @Name, @Address, @City, @Postcode, @Email, @Telephone, @Reason, @User";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@tKey", CreateTKey(name));
                                cmd.Parameters.AddWithValue("@Client", row["Client"]);
                                cmd.Parameters.AddWithValue("@Customer", row["Customer"]);
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Address", row["Address"]);
                                cmd.Parameters.AddWithValue("@City", row["City"]);
                                cmd.Parameters.AddWithValue("@Postcode", row["Postcode"]);
                                cmd.Parameters.AddWithValue("@Email", row["Email"]);
                                cmd.Parameters.AddWithValue("@Telephone", row["Telephone"]);
                                cmd.Parameters.AddWithValue("@Reason", row["Reason"]);
                                cmd.Parameters.AddWithValue("@User", userName);

                                await cmd.ExecuteNonQueryAsync();
                            }

                            // Do GDPR Stuff //
                            if (!string.IsNullOrEmpty(row["Customer"].ToString()))
                            {
                                MainForm mainForm = new MainForm();
                                mainForm.UpdateElucidGDPR(row["Customer"].ToString(), row["Client"].ToString());
                            }

                            // Increment row count in a thread-safe way //
                            Interlocked.Increment(ref currentRows);

                            // Log Import Attempt //
                            SessionMaintenance.LogBook("", "[ImportCSV]", "[ImportData]", $"Record Insert Attempt: {row["Client"]},{row["Customer"]},{row["Name"]},{row["Reason"]}");

                            // UI Update - Only update every 'batchSize' rows //
                            if (currentRows % batchSize == 0 || currentRows == maxRows)
                            {
                                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                                double rps = elapsedSeconds > 0 ? currentRows / elapsedSeconds : 0;

                                pBarImport.Invoke((MethodInvoker)(() =>
                                {
                                    pBarImport.Value = currentRows;
                                }));

                                lblProgress.Invoke((MethodInvoker)(() =>
                                {
                                    lblProgress.Text = $"Imported: {currentRows}/{maxRows} Rows";
                                }));
                                lblrps.Invoke((MethodInvoker)(() =>
                                {
                                    lblrps.Text = $"{rps:F2} Rows/s";
                                }));
                            }
                        }));

                        // ** Wait for batch of tasks to finish before continuing (prevents overload) ** //
                        if (insertTasks.Count >= batchSize)
                        {
                            await Task.WhenAll(insertTasks);
                            insertTasks.Clear();
                        }

                    }

                    // ** Ensure all remaining tasks complete ** //
                    await Task.WhenAll(insertTasks);

                    stopwatch.Stop();
                    double finalRps = stopwatch.Elapsed.TotalSeconds > 0 ? maxRows / stopwatch.Elapsed.TotalSeconds : 0;

                    // Final UI update after completion //
                    pBarImport.Invoke((MethodInvoker)(() => pBarImport.Value = maxRows));

                    lblProgress.Invoke((MethodInvoker)(() =>
                    {
                        lblProgress.Text = $"Completed: {maxRows}/{maxRows} Rows";
                    }));

                    lblrps.Invoke((MethodInvoker)(() =>
                    {
                        lblrps.Text = $"{finalRps:F2} Rows/s";
                    }));

                    lblStatus.Text = "Import Successful";
                    CustomMessageBox messageBox = new CustomMessageBox();
                    //messageBox.ShowMisc($"Data imported successfully.", "Data Imported", 380, 276);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Import Failed!";
                lblProgress.Text = "";
                lblrps.Text = "";
                lblError.Text = ex.Message;
                lblError.Visible = true;
                pBarImport.Visible = false;
                SessionMaintenance.LogBook("ERROR", "[ImportCSV]", "[ImportData]", $"FAILED ({ex.Message})");
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Error Importing Data: {ex.Message}");
            }
            finally
            {
                btnFun.Enabled = true;
                pBarImport.Invoke((MethodInvoker)(() => pBarImport.Value = pBarImport.Maximum));
                SessionMaintenance.LogBook("", "[ImportCSV]", "[ImportData]", $"Method Finished");
            }
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        private void btnFun_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
