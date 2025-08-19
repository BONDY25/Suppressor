using Microsoft.Data.SqlClient;
using System.Data;

namespace Suppressor
{
    public partial class SearchFrom : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        public string sessionId { get; set; }
        public string search { get; set; }
        public string client { get; set; }
        public string userName { get; set; }
        public int openedBy { get; set; }

        private MainForm mainForm;
        private MailingPreference mailingPreference;

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public SearchFrom(MainForm mainForm, MailingPreference mailingPreference)
        {
            InitializeComponent();
            Text = $"Search - {Environment.UserName.ToUpper()}";
            this.KeyPreview = true;
            // this.FormClosing += MainForm_FormClosing;
            this.KeyDown += MainForm_KeyDown;
            this.mainForm = mainForm;
            this.mailingPreference = mailingPreference;
        }

        private void SearchFrom_Load(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[SearchForm]", "[FormLoad]", $"Form Opened");
            txbTerm.Text = search;
            DoSearch();
            PopulateDataGrid();
        }

        // Exit Application Method --------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //LogBook("", "[SearchForm]", "[FormClosing]", $"Form Closed", sessionId);
                this.Close();
            }
        } 

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Do A Search -----------------------------------------------------------------------------------------------------------------------
        private void DoSearch()
        {
            string query = "EXECUTE [SearchApp_GetCustomer] @Client, @Session_Id, @Term";

            string term = txbTerm.Text;


            SessionMaintenance.LogBook("", "[SearchForm]", "[DoSearch]", $"Method Started: {term}, {client}");

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Execute SQL Command 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        cmd.Parameters.AddWithValue("@Term", term);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close(); // Close SQL Connection
                }

                SessionMaintenance.LogBook("", "[SearchForm]", "[DoSearch]", $"Search Complete: {term}, {client}");
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("114", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[SearchForm]", "[DoSearch]", $"FAILED: Code 114 ( {ex.Message} )");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // Populate DataGrid -----------------------------------------------------------------------------------------------------------------------
        private void PopulateDataGrid()
        {
            string query = "SELECT [Customer],[Name],[Address],[Orders],[Last_Order] " +
                    "FROM SearchApp_Cust_Results " +
                    "WHERE Session_Id = @Session_Id";

            DataTable dataTable = new DataTable();

            try
            {
                // Start SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Set Parameters
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);

                        // Execute Query
                        cmd.ExecuteNonQuery();

                        // Execute Data Reader
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Populate DataTable From Reader
                        dataTable.Load(reader);
                    }

                    conn.Close(); // Close SQL Connection

                    // Populate Data Grid
                    dgResults.DataSource = dataTable;
                    dgResults.Refresh();
                }

                SessionMaintenance.LogBook("", "[SearchForm]", "[PopulateDataGrid]", $"DataGrid Populated");
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("117", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[SearchForm]", "[PopulateDataGrid]", $"FAILED: Code 117 (  {ex.Message}  )");
            }
        }


        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Exit Button --------------------------------------------------------------------------------------------------------------
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

        // Search Button --------------------------------------------------------------------------------------------------------------
        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(152, 179, 194);
            btnSearch.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(46, 72, 89);
            btnSearch.ForeColor = Color.FromArgb(152, 179, 194);
        }

        // Term Field --------------------------------------------------------------------------------------------------------------
        private void txbTerm_Enter(object sender, EventArgs e)
        {
            txbTerm.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbTerm_Leave(object sender, EventArgs e)
        {
            txbTerm.BackColor = Color.White;
        }

        private void txbTerm_TextChanged(object sender, EventArgs e)
        {

        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Exit Button --------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
           // LogBook("", "[SearchForm]", "[FormClosing]", $"Form Closed", sessionId);
            this.Close();
        }

        // Search Button --------------------------------------------------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txbTerm.Text;
            DoSearch();
            PopulateDataGrid();
        }

        // Results Table Click --------------------------------------------------------------------------------------------------------------
        private void dgResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                
                // Check if mainForm and the first cell value are not null
                if (dgResults.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    string customer = dgResults.Rows[e.RowIndex].Cells[0].Value.ToString();
                    SessionMaintenance.LogBook("", "[SearchForm]", "[dgResults_CellClick]", $"Cell Clicked C {customer}");
                    
                    if (openedBy == 1 && mainForm != null)
                    {
                        mainForm.txbCustomer.Text = customer;
                        mainForm.GetCustomer();
                    }
                    else if (openedBy == 2 && mailingPreference != null)
                    {                        
                        mailingPreference.txbCustomer.Text = customer;
                        mailingPreference.GetCustomer();
                    }
                    else
                    {
                        MessageBox.Show("The no form is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }
                else if (dgResults.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    // Handle the case where mainForm or cell value is null
                    MessageBox.Show("part number cell is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else if (mainForm == null && mailingPreference == null)
                {
                    MessageBox.Show("The no form is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }


        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts ------------------------------------------------------------------------------------------------------
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbTerm.Text = null;
                dgResults.DataSource = null;
                dgResults.Refresh();

                txbTerm.Focus();
            }

            // ctrl + R
            if (e.Control && e.KeyCode == Keys.R)
            {
                btnSearch_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }


    }
}