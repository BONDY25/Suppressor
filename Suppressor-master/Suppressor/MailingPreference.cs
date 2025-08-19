using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace Suppressor
{
    public partial class MailingPreference : Form
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

        public MailingPreference()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
            this.KeyDown += MainFrom_KeyDown;
            Text = $"Mailing Preference - {Environment.UserName.ToUpper()}";
        }

        // Form Load ---------------------------------------------------------------------------------------------------------------------
        private void MailingPreference_Load(object sender, EventArgs e)
        {
            lblUsername.Text = userName; // Show Username
            SessionMaintenance.LogBook("", "[MailingPreference]", "[FormLoad]", "Form Started", lblLogBook);
            SessionMaintenance.UpdateStatusLabel(lblLogBook);
            PopulateComboBox(); // Populate the dropdown menu
            lblDetails.Visible = false;
            lblCustDetails.Text = "";

            msMain.BackColor = Color.FromArgb(250, 236, 207);
            msMain.ForeColor = Color.FromArgb(46, 72, 89);
        }

        // Populate Combo Box Options ---------------------------------------------------------------------------------------------------------------------
        private void PopulateComboBox()
        {
            // Declare Variables
            string ClientQuery = "SELECT [Description] FROM Suppressor_Clients WHERE [Active] = '1' ORDER BY [ID]";

            try
            {
                // Execute SQL Command 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    // Execute Query
                    using (SqlCommand cmdClient = new SqlCommand(ClientQuery, conn))
                    {

                        // Execute Data Reader
                        using (SqlDataReader reader = cmdClient.ExecuteReader())
                        {
                            cbClient.Items.Clear(); // Clear Existing Items


                            while (reader.Read())
                            {
                                cbClient.Items.Add(reader["Description"].ToString());
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("112", $"\n{ex.Message}");
                Application.Exit();
            }
        } 

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Get Customer Method ----------------------------------------------------------------------------------------------------------------
        public void GetCustomer()
        {
            // Declare Variables
            string customer = txbCustomer.Text;
            string client = cbClient.Text;
            string queryDetail = "EXECUTE [Suppressor_Get_Details] @Customer, @Client";
            string queryPref = "EXECUTE [Suppressor_Get_Pref] @Client, @Customer";
            string isCustomer = null;
            string name = null;
            string address = null;
            string city = null;
            string postCode = null;
            string emailFlag = null;
            string part3rdMail = null;


            lblCustExist.Visible = false; // Hide Label

            Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

            try
            {
                // Execute SQL Command
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    // Get Details
                    using (SqlCommand cmd = new SqlCommand(queryDetail, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Customer", customer);
                        cmd.Parameters.AddWithValue("@Client", client);

                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            // Populate Variables From Reader
                            while (reader.Read())
                            {
                                {
                                    isCustomer = reader["Customer"].ToString();
                                    name = reader["Name"].ToString();
                                    address = reader["Address"].ToString();
                                    city = reader["City"].ToString();
                                    postCode = reader["Postcode"].ToString();
                                }
                            }
                        }
                    }

                    // Get Preferences
                    using (SqlCommand cmd = new SqlCommand(queryPref, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Customer", customer);
                        cmd.Parameters.AddWithValue("@Client", client);

                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            // Populate Variables From Reader
                            while (reader.Read())
                            {
                                {
                                    emailFlag = reader["C"].ToString();
                                    part3rdMail = reader["G"].ToString();
                                }
                            }
                        }
                    }

                    conn.Close(); // Close SQL Conncetion

                }
            }
            catch (Exception ex) // Catch Errros
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("114", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MailingPreference]", "[GetDetails]", $"FAILED: Code 114 ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Set Cursor to Default
            }

            // If customer does not exists show error
            if (string.IsNullOrEmpty(isCustomer) && !string.IsNullOrEmpty(customer))
            {
                lblCustExist.Visible = true;
                lblCustExist.Text = "Customer Not Found!";
                cust = 0;
                txbCustomer.Focus();
                txbCustomer.SelectAll();
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("137", $"");
                lblCustDetails.Text = "";
                lblDetails.Visible = false;
                return;
            }

            // If customer exists Show customer details
            else
            {
                lblCustExist.Visible = false;
                lblCustExist.Text = "";
                cust = 1;

                // Show Customer Details
                lblCustDetails.Text =
                    $"{name}\n" +
                    $"{address}\n" +
                    $"{city}\n" +
                    $"{postCode}";

                // Update UI Flags
                if (emailFlag == "1")
                {
                    ckbEmail.Checked = true;
                }
                else
                {
                    ckbEmail.Checked = false;
                }

                if (part3rdMail == "1")
                {
                    ckb3rdPartMail.Checked = true;
                }
                else
                {
                    ckb3rdPartMail.Checked = false;
                }
            }
        }

        // Check Part -----------------------------------------------------------------------------------------------------------------------
        private int CheckCust()
        {
            string client = null;
            string search = txbCustomer.Text;
            string query = "EXECUTE [Suppressor_Check_Cust] @Client, @Search";
            int count = 0;
            // Check Client Field
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Search", search);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                count = (int)reader["Result"]; // Populate variable
                            }
                        }
                    }

                    conn.Close();
                }

            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("116", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainForm]", "[CheckPart]", $"FAILED: Code 116 ( {ex.Message} )", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            return count;
        }

        // Create tKey ------------------------------------------------------------------------------------------------------------------------
        private string CreateTKey()
        {
            string name = Environment.UserDomainName;
            string tKeySufix = name.Length >= 2 ? name.Substring(0, 2).ToUpper() : name.ToUpper();
            string tKeyTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string tKey = tKeyTimeStamp + tKeySufix;
            return tKey;
        }

        // Update Elucid GDPR Flags -----------------------------------------------------------------------------------------------------
        private void UpdateElucidGDPR()
        {

            SessionMaintenance.LogBook("", "[MailingPreference]", "[UpdateElucidGDPR]", "Started", lblLogBook); // Log Event
            SessionMaintenance.UpdateStatusLabel(lblLogBook);

            // Declare Variables
            string getDatabase = "SELECT RTRIM([Server]) as [Server],RTRIM([Database]) as [Database] FROM Suppressor_Clients WHERE [Description] = @Client";
            string getQuery = "SELECT String_1, String_3 FROM Suppressor_Parameters WHERE ID = '001'";
            string client = null;
            string customer = txbCustomer.Text;
            string user = userName;
            string database = null;
            string server = null;
            string queryUpdate = null;
            string queryGDPRUpdate = null;
            string party3rdFlag = null;
            string emailFlag = null;

            // Get Email Flag
            if (ckbEmail.Checked)
            {
                emailFlag = "1";
            }
            else if (!ckbEmail.Checked)
            {
                emailFlag = "0";
            }

            // Get 3rd Party Mail Flag
            if (ckb3rdPartMail.Checked)
            {
                party3rdFlag = "1";
            }
            else if (!ckb3rdPartMail.Checked)
            {
                party3rdFlag = "0";
            }

            // Get Client
            client = cbClient.SelectedItem.ToString();

            try
            {
                // Get Database & Query Info
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    // Get Database info
                    using (SqlCommand cmd = new SqlCommand(getDatabase, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Client", client);

                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                server = reader["Server"].ToString();
                                database = reader["Database"].ToString();
                            }
                        }
                    }

                    // Get SQL Query
                    using (SqlCommand cmd = new SqlCommand(getQuery, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Client", client);

                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                queryUpdate = reader["String_1"].ToString();
                                queryGDPRUpdate = reader["String_3"].ToString();
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MailingPreference]", "[UpdateElucidGDPR]", $"FAILED! Error retrieving database info: ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            // Populate new connection string
            string updateConnectionString = $"Server={server};Database={database};Integrated Security=True;Encrypt=False;";

            try
            {
                // Update cust tables
                using (SqlConnection conn = new SqlConnection(updateConnectionString))
                {

                    conn.Open(); // Open SQL Connection

                    // Update cust table
                    using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Customer", customer);
                        cmd.Parameters.AddWithValue("@User", userName);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    SessionMaintenance.LogBook("", "[MailingPreference]", "[UpdateElucidGDPR]", $"Update Cust Executed ({customer})", lblLogBook);
                    SessionMaintenance.UpdateStatusLabel(lblLogBook);

                    // Update custGDPR table
                    using (SqlCommand cmd = new SqlCommand(queryGDPRUpdate, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Customer", customer);
                        cmd.Parameters.AddWithValue("@Email_Flag", emailFlag);
                        cmd.Parameters.AddWithValue("@3rd_Party_Flag", party3rdFlag);
                        cmd.Parameters.AddWithValue("@User", userName);

                        // Execute Query
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection

                    SessionMaintenance.LogBook("", "[MailingPreference]", "[UpdateElucidGDPR]", $"Update GDPR Executed ({customer})", lblLogBook);
                    SessionMaintenance.UpdateStatusLabel(lblLogBook);

                    // Show Results
                    lblDetails.Visible = true;
                    lblDetails.Text = $"Customer GDPR Records Updated @ {DateTime.Now}";

                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowMessage($"The GDPR Preferences for customer {customer} have been updated.", "Record Updated!");
                    SessionMaintenance.UpdateStatusLabel(lblLogBook);
                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MailingPreference]", "[UpdateElucidGDPR]", $"FAILED! Error Updating Elucid tables ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            SessionMaintenance.LogBook("", "[MailingPreference]", "[UpdateElucidGDPR]", "Finished", lblLogBook); // Log Event
            SessionMaintenance.UpdateStatusLabel(lblLogBook);

        }

        // Insert Details ---------------------------------------------------------------------------------------------------------------
        private void InsertDetails(string tKey)
        {
            // Declare Variables
            string query = "EXECUTE [Suppressor_Upate_Mailing_Pref] @tkey, @Client, @Customer, @3rd_Party_Flag, @Email_Flag, @User";
            string user = userName;
            string client = null;
            string customer = txbCustomer.Text;
            string party3rdFlag = null;
            string emailFlag = null;

            // Get Email Flag
            if (ckbEmail.Checked)
            {
                emailFlag = "1";
            }
            else if (!ckbEmail.Checked)
            {
                emailFlag = "0";
            }

            // Get 3rd Party Mail Flag
            if (ckb3rdPartMail.Checked)
            {
                party3rdFlag = "1";
            }
            else if (!ckb3rdPartMail.Checked)
            {
                party3rdFlag = "0";
            }

            // Check Client Field
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }
            else
            {
                Cursor.Current = Cursors.Default; // Set Cursor to Default
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("129", $"");
                cbClient.Focus();
                return;
            }

            // Check Customer Field
            if (string.IsNullOrEmpty(customer))
            {
                Cursor.Current = Cursors.Default; // Set Cursor to Default
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("135", $"");
                txbCustomer.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@tKey", tKey);
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Customer", customer);
                        cmd.Parameters.AddWithValue("@Email_Flag", emailFlag);
                        cmd.Parameters.AddWithValue("@3rd_Party_Flag", party3rdFlag);
                        cmd.Parameters.AddWithValue("@User", user);

                        // Execute Query
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(customer) || customer != "")
                        {
                            UpdateElucidGDPR(); // Update Elucid GDPR Flags
                        }

                    }

                    conn.Close(); // Close SQL Connection

                    SessionMaintenance.LogBook("", "[MailingPreference]", "[InsertDetails]", "Record Inserted", lblLogBook);
                    SessionMaintenance.UpdateStatusLabel(lblLogBook);

                }
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MailingPreference]", "[UpdateElucidGDPR]", $"FAILED! Error Updating Elucid tables ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Set Cursor to Default
            }
        }

        // Clear Fields ----------------------------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            txbCustomer.Text = null;
            lblCustDetails.Text = null;
            ckb3rdPartMail.Checked = false;
            ckbEmail.Checked = false;
            lblDetails.Text = null;
            lblDetails.Visible = false;
        }

        // Run Details Report ----------------------------------------------------------------------------------------------------------------------
        private void RunDetailsReport()
        {
            string url = "";
            string query = "SELECT String_1 FROM Suppressor_Parameters WHERE ID = '002'";

            // Get URL
            try
            {
                // Execute SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                url = reader["String_1"].ToString();
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection

                }
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("119", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[RunDetailsReport]", $"FAILED: Code 119 (  {ex.Message}  )", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            // Open URL
            try
            {
                // Open the URL in the default web browser
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);

                SessionMaintenance.LogBook($"", "[MainForm]", "[RunDetailsReport]", "Process Executed", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("121", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MailingPreference]", "[RunDetailsReport]", $"FAILED: Code 121 (  {ex.Message}  )", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
        }

        // Run Summary Report ----------------------------------------------------------------------------------------------------------------------
        private void RunSummaryReport()
        {
            string url = "";
            string query = "SELECT String_1 FROM Suppressor_Parameters WHERE ID = '003'";

            // Get URL
            try
            {
                // Execute SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Execute Data Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Populate variables from reader
                            while (reader.Read())
                            {
                                url = reader["String_1"].ToString();
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection

                }
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("119", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MailingPreference]", "[RunSummaryReport]", $"FAILED: Code 119 (  {ex.Message}  )", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            // Open URL
            try
            {
                // Open the URL in the default web browser
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };

                Process.Start(processStartInfo);

                SessionMaintenance.LogBook($"", "[MainForm]", "[RunSummaryReport]", "Process Executed", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MailingPreference]", "[RunSummaryReport]", $"FAILED: Code 124 (  {ex.Message}  )", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
        }

        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Client Field ----------------------------------------------------------------------------------------------------------------------
        private void cbClient_TextChanged(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void cbClient_Enter(object sender, EventArgs e)
        {
            cbClient.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            cbClient.BackColor = Color.White;
        }

        // Customer Text Box ----------------------------------------------------------------------------------------------------------------------
        private void txbCustomer_Enter(object sender, EventArgs e)
        {
            txbCustomer.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbCustomer_Leave(object sender, EventArgs e)
        {
            txbCustomer.BackColor = Color.White;

            string search = txbCustomer.Text;
            string client = null;
            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }
            else
            {
                return;
            }

            if (!string.IsNullOrEmpty(search))
            {
                if (string.IsNullOrEmpty(client))
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("130", $"");
                    cbClient.Focus();
                    return;
                }
                else
                {
                    if (CheckCust() > 1 || CheckCust() == 0)
                    {
                        SearchFrom searchFrom = new SearchFrom(null, this);
                        searchFrom.search = search;
                        searchFrom.sessionId = sessionId;
                        searchFrom.client = client;
                        searchFrom.userName = userName;
                        searchFrom.openedBy = 2;
                        searchFrom.Show();
                        txbCustomer.Text = "";
                    }
                    else
                    {
                        GetCustomer();
                    }
                }
            }

        }
        // Save Button ----------------------------------------------------------------------------------------------------------------------
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(152, 179, 194);
            btnSave.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(46, 72, 89);
            btnSave.ForeColor = Color.FromArgb(152, 179, 194);
        }

        // Clear Button ----------------------------------------------------------------------------------------------------------------------
        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.FromArgb(152, 179, 194);
            btnClear.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.FromArgb(46, 72, 89);
            btnClear.ForeColor = Color.FromArgb(152, 179, 194);
        }

        // Close Button ----------------------------------------------------------------------------------------------------------------------
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(152, 179, 194);
            btnExit.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(46, 72, 89);
            btnExit.ForeColor = Color.FromArgb(152, 179, 194);
        }

        //LogBook Label ----------------------------------------------------------------------------------------------------------------------
        private void lblLogBook_MouseEnter(object sender, EventArgs e)
        {
            lblLogBook.BackColor = Color.FromArgb(46, 72, 89);
            lblLogBook.ForeColor = Color.FromArgb(152, 179, 194);
        }

        private void lblLogBook_MouseLeave(object sender, EventArgs e)
        {
            lblLogBook.BackColor = Color.FromArgb(250, 236, 207);
            lblLogBook.ForeColor = Color.FromArgb(152, 179, 194);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Close Button Click Event ----------------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Clear Button Click Event ----------------------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all fields
            ClearFields();
            cbClient.Focus();
            cbClient.Text = "";
            cbClient.SelectedItem = null;
            lblCustExist.Visible = false;
        }

        // Save button Click Event ----------------------------------------------------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            string tKey = CreateTKey();
            InsertDetails(tKey);
        }

        // LogBook Click Event ----------------------------------------------------------------------------------------------------------------------
        private void lblLogBook_Click(object sender, EventArgs e)
        {
            string Message = lblLogBook.Text;
            CustomMessageBox messageBox = new CustomMessageBox();
            messageBox.ShowLogBook($"LogBook Activity Recorded For '{Environment.MachineName}.{Environment.UserName}: {Message}");
        }

        // Clear Menu Strip ----------------------------------------------------------------------------------------------------------------------
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
        }

        // Close Menu Strip ----------------------------------------------------------------------------------------------------------------------
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        // Summary Menu Strip ----------------------------------------------------------------------------------------------------------------------
        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSummaryReport();
        }

        // Details Menu Strip ----------------------------------------------------------------------------------------------------------------------
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunDetailsReport();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts ----------------------------------------------------------------------------------------------------------------------
        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                btnClear_Click(sender, e);
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}
