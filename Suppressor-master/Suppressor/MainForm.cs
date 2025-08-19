using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Suppressor
{

    public partial class MainForm : Form
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

        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Diasble Maximize window option
            this.KeyPreview = true;
            this.KeyDown += MainFrom_KeyDown;
            btnClear.CausesValidation = false;
            btnExit.CausesValidation = false;
            Text = $"Home - {Environment.UserName.ToUpper()}";
        }

        // Load Form Method -------------------------------------------------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = userName; // Show Username
            SessionMaintenance.LogBook("", "[MainFrom]", "[FormLoad]", "Application Started", lblLogBook);
            SessionMaintenance.UpdateStatusLabel(lblLogBook);
            PopulateComboBoxes(cbClient, "CLIENT"); // Populate the dropdown menus
            PopulateComboBoxes(cbReason, "REASON");

            msMain.BackColor = Color.FromArgb(250, 236, 207);
            msMain.ForeColor = Color.FromArgb(46, 72, 89);
        }

        // Populate Client Options -------------------------------------------------------------------------------------------------------------
        private void PopulateComboBoxes(ComboBox comboBox, string field)
        {
            // Declare Variables
            string query = "";

            if (field == "CLIENT")
            {
                query = "SELECT [Description] FROM Suppressor_Clients WHERE [Active] = '1' ORDER BY [ID]";
            }
            else if (field == "REASON")
            {
                query = "SELECT [Description] FROM Suppressor_Reasons WHERE [Active] = '1' ORDER BY [ID]";
            }

            try
            {
                // Execute SQL Command 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open(); // Open SQL Connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox.Items.Clear();

                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["Description"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("112", $"\n{ex.Message}");
                Application.Exit();
            }
        }

        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        // Get Customer Method -------------------------------------------------------------------------------------------------------------
        public void GetCustomer()
        {
            // Declare Variables
            string customer = txbCustomer.Text;
            string client = cbClient.Text;
            string query = "[Suppressor_Get_Details] @Customer, @Client";
            string isCustomer = null;

            lblCustExist.Visible = false; // Hide Label

            Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

            try
            {
                // Execute SQL Command
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Customer", customer);
                        cmd.Parameters.AddWithValue("@Client", client);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                {
                                    isCustomer = reader["Customer"].ToString();
                                    txbName.Text = reader["Name"].ToString();
                                    txbAddress.Text = reader["Address"].ToString();
                                    txbCity.Text = reader["City"].ToString();
                                    txbPostcode.Text = reader["Postcode"].ToString();
                                    txbEmail.Text = reader["Email"].ToString();
                                    txbTelephone.Text = reader["Telephone"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("114", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainFrom]", "[GetDetails]", $"FAILED: Code 114 ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Set Cursor to Default
            }

            // Check if customer exists
            if (string.IsNullOrEmpty(isCustomer) && !string.IsNullOrEmpty(customer))
            {
                lblCustExist.Visible = true;
                lblCustExist.Text = "Customer Not Found!";
                cust = 0;
                txbCustomer.Focus();
                txbCustomer.SelectAll();
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("137", $"");
                return;
            }
            else
            {
                lblCustExist.Visible = false;
                lblCustExist.Text = "";
                cust = 1;
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

        // Duplicate Checker -------------------------------------------------------------------------------------------------------------
        private void DupeChecker(string tKey)
        {
            // Declare Variables
            string dupeCheck = $"SELECT COUNT(*) FROM Suppressor_Details WHERE Customer = @Customer AND Client = @Client AND Reason <> 'MAILCHANGE'";
            string customer = txbCustomer.Text;
            string client = cbClient.SelectedItem.ToString();
            string name = txbName.Text;

            // Execute SQL Command
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open SQL Connection

                using (SqlCommand cmd = new SqlCommand(dupeCheck, conn))
                {
                    // Count Number of Customers the same as Parameter
                    cmd.Parameters.AddWithValue("@Customer", customer);
                    cmd.Parameters.AddWithValue("@Client", client);
                    int count = (int)cmd.ExecuteScalar();

                    // Evalute Results
                    if (count > 0)
                    {
                        lblDetails.Visible = true;
                        lblDetails.ForeColor = Color.FromArgb(252, 85, 79);
                        lblDetails.Text = $"Warning! Duplicate Record - {customer} @ {DateTime.Now}";
                        SessionMaintenance.LogBook(tKey, "[MainFrom]", "[InsertDetails]", $"Warning! Duplicate Record - ({client} - {customer})", lblLogBook);
                        SessionMaintenance.UpdateStatusLabel(lblLogBook);
                    }
                    else
                    {
                        lblDetails.Visible = true;
                        lblDetails.ForeColor = Color.FromArgb(46, 72, 89);
                        lblDetails.Text = $"Record Accepted - {name} @ {DateTime.Now}";
                        SessionMaintenance.LogBook(tKey, "[MainForm]", "[InsertDetails]", $"Record Accepted - ({client} - {name})", lblLogBook);
                        SessionMaintenance.UpdateStatusLabel(lblLogBook);
                    }
                }
            }
        }

        // Create tKey -------------------------------------------------------------------------------------------------------------
        private string CreateTKey()
        {
            string name = txbName.Text;
            string tKeySufix = name.Length >= 2 ? name.Substring(0, 2).ToUpper() : name.ToUpper();
            string tKeyTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string tKey = tKeyTimeStamp + tKeySufix;
            return tKey;
        }

        // 1/5 UpdateElucidGDPR (Get Database Info) -------------------------------------------------------------------------------------------------------------
        private (string server, string database) GetDatabaseAndServerInfo(SqlConnection conn, string query, string client)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Client", client);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (reader["Server"].ToString(), reader["Database"].ToString());
                    }
                    else
                    {
                        throw new Exception("No server and database information found for the client.");
                    }
                }
            }
        }

        // 2/5 UpdateElucidGDPR (Get Database Info) -------------------------------------------------------------------------------------------------------------
        private (string queryUpdate, string queryGDPRUpdate) GetUpdateQueries(SqlConnection conn, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (reader["String_1"].ToString(), reader["String_2"].ToString());
                    }
                    else
                    {
                        throw new Exception("No update queries found.");
                    }
                }
            }
        }

        // 3/5 UpdateElucidGDPR (Execute Update Queries) -------------------------------------------------------------------------------------------------------------
        private void ExecuteUpdateQueries(string connectionString, string queryUpdate, string queryGDPRUpdate, string customer, string user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                ExecuteNonQuery(conn, queryUpdate, customer, user);
                SessionMaintenance.LogBook("", "[MainForm]", "[UpdateElucidGDPR]", $"Update Cust Executed ({customer})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);

                ExecuteNonQuery(conn, queryGDPRUpdate, customer, user);
                SessionMaintenance.LogBook("", "[MainForm]", "[UpdateElucidGDPR]", $"Update GDPR Executed ({customer})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
        }

        // 4/5 UpdateElucidGDPR (Get Update Queries) -------------------------------------------------------------------------------------------------------------
        private void ExecuteNonQuery(SqlConnection conn, string query, string customer, string user)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Customer", customer);
                cmd.Parameters.AddWithValue("@User", user);
                cmd.ExecuteNonQuery();
            }
        }

        // 5/5 UpdateElucidGDPR (Update Elucid GDPR Flags) -------------------------------------------------------------------------------------------------------------
        public void UpdateElucidGDPR(string customer, string client)
        {
            SessionMaintenance.LogBook("", "[MainForm]", "[UpdateElucidGDPR]", "Started", lblLogBook);

            string getDatabaseQuery = "SELECT RTRIM([Server]) as [Server], RTRIM([Database]) as [Database] FROM Suppressor_Clients WHERE [Description] = @Client";
            string getQueryParameters = "SELECT String_1, String_2 FROM Suppressor_Parameters WHERE ID = '001'";
           // string client = cbClient.SelectedItem?.ToString();            
            string updateConnectionString = null;
            string queryUpdate = null;
            string queryGDPRUpdate = null;
            string server = null;
            string database = null;

            //if (string.IsNullOrEmpty(client))
            //{
            //    CustomMessageBox messageBox = new CustomMessageBox();
            //    messageBox.ShowDefError("130", $"");
            //    return;
            //}

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch database and server information
                    (server, database) = GetDatabaseAndServerInfo(conn, getDatabaseQuery, client);

                    // Fetch update queries
                    (queryUpdate, queryGDPRUpdate) = GetUpdateQueries(conn, getQueryParameters);

                    // Build the new connection string
                    updateConnectionString = $"Server={server};Database={database};Integrated Security=True;Encrypt=False;";
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainFrom]", "[UpdateElucidGDPR]", $"FAILED! Error retrieving database info: ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
                return;
            }

            try
            {
                // Update customer tables
                ExecuteUpdateQueries(updateConnectionString, queryUpdate, queryGDPRUpdate, customer, SessionMaintenance.userName);
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainFrom]", "[UpdateElucidGDPR]", $"FAILED! Error Updating Elucid tables ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            SessionMaintenance.LogBook("", "[MainForm]", "[UpdateElucidGDPR]", "Finished", lblLogBook);
        }

        // Get Non Customers ***(NOT CURRENTLY IN USE)*** ----------------------------------------------------------------------------------
        private void GetNonCustomer()
        {
            string getDatabase = "SELECT RTRIM([Server]) as [Server],RTRIM([Database]) as [Database], RTRIM(Site) as [Site] FROM Suppressor_Clients WHERE [Description] = @Client";
            string query = "SELECT COUNT(customer) FROM cust WHERE postcode = @Postcode AND level_1 = @Site";
            string client = null;
            string customer = txbCustomer.Text;
            string user = userName;
            string database = null;
            string server = null;
            string postcode = txbPostcode.Text;
            string site = null;

            client = cbClient.SelectedItem.ToString();

            try
            {
                // Get Database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(getDatabase, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", client);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                server = reader["Server"].ToString();
                                database = reader["Database"].ToString();
                                site = reader["Site"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainFrom]", "[GetNonCustomer]", $"FAILED! Error retrieving database info: ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

            // Populate new connection string
            string updateConnectionString = $"Server={server};Database={database};Integrated Security=True;Encrypt=False;";

            try
            {
                // Update cust tables
                using (SqlConnection conn = new SqlConnection(updateConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Postcode", postcode);
                        cmd.Parameters.AddWithValue("@Site", site);
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0 && string.IsNullOrEmpty(customer) && !string.IsNullOrEmpty(postcode))
                        {
                            CustomMessageBox messageBox = new CustomMessageBox();
                            messageBox.ShowWarning($"{count.ToString()} Customer(s) were found with this postcode. \nPlease check if this customer exists on elucid.");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[MainFrom]", "[GetNonCustomer]", $"FAILED! Error searching Elucid tables ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
        }

        // Insert Details Method -------------------------------------------------------------------------------------------------------------
        public void InsertDetails(string tKey, string client, string customer,string name, string address, string city, string postcode, string email, string telephone, string reason)
        {

            // Declare Variables
            string query = "[Suppressor_Insert_Details] @tKey, @Client, @Customer, @Name, @Address, @City, @Postcode, @Email, @Telephone, @Reason, @User";

            // Update customer string
            if (cust == 1)
            {
                customer = txbCustomer.Text;
            }
            else if (cust == 0 || string.IsNullOrEmpty(customer))
            {
                customer = "";
            }


            DupeChecker(tKey); // Set detail label & Check for Duplicates

            // Execute SQL Query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Open SQL Connection
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tKey", tKey);
                    cmd.Parameters.AddWithValue("@Client", client);
                    cmd.Parameters.AddWithValue("@Customer", customer);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Postcode", postcode);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telephone", telephone);
                    cmd.Parameters.AddWithValue("@Reason", reason);
                    cmd.Parameters.AddWithValue("@User", userName);
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(customer) || customer != "")
                    {
                        UpdateElucidGDPR(customer, client); // Update Elucid GDPR Flags
                    }

                    ClearFields(); // Clear input fields
                }
                conn.Close(); // Close SQL Connection
            }
        }

        // Clear field method -------------------------------------------------------------------------------------------------------------
        private void ClearFields()
        {
            // Clear all fields
            cbReason.Text = "";
            cbReason.SelectedItem = null;
            txbCustomer.Text = "";
            txbName.Text = "";
            txbAddress.Text = "";
            txbCity.Text = "";
            txbPostcode.Text = "";
            txbEmail.Text = "";
            txbTelephone.Text = "";
        }

        // Run Reports  -----------------------------------------------------------------------------------------------------------------------
        private void RunReport(string ID)
        {
            string url = "";
            string query = $"SELECT String_1 FROM [Suppressor_Parameters] WHERE ID = '{ID}'";

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
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[RunReport]", $"FAILED: Code 119 (  {ex.Message}  )", lblLogBook);
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

                SessionMaintenance.LogBook($"", "[MainForm]", "[RunReport]", $"Process Executed With Parameter: {ID}", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            catch (Exception ex)  // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("121", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"ERROR", "[MainForm]", "[RunReport]", $"FAILED: Code 121 (  {ex.Message}  )", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }

        }

        // Validate Inputs -----------------------------------------------------------------------------------------------------------------------
        private bool ValidateInputs()
        {
            if (cbClient.SelectedItem == null)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("129", $"");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("148", $"");
                return false;
            }

            if (string.IsNullOrEmpty(txbEmail.Text) && string.IsNullOrEmpty(txbAddress.Text))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("142", $"");
                return false;
            }

            if (!string.IsNullOrEmpty(txbAddress.Text) && (string.IsNullOrEmpty(txbCity.Text) || string.IsNullOrEmpty(txbPostcode.Text)))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("145", $"");
                return false;
            }

            if (!string.IsNullOrEmpty(txbEmail.Text) && (!txbEmail.Text.Contains("@") || !txbEmail.Text.Contains(".")))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("140", $"");
                txbEmail.SelectAll();
                return false;
            }

            if (cbReason.SelectedItem == null)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("162", $"");
                return false;
            }

            return true;
        }

        // Set Character Limits -----------------------------------------------------------------------------------------------------------------------
        private void SetCharacterLimit(TextBox textBox, string field, int limit)
        {
            string fieldString = textBox.Text;
            int fieldLength = fieldString.Length;
            string code = "";

            switch (field)
            {
                case "Customer": code = "136"; break;
                case "Name": code = "149"; break;
                case "Address": code = "103"; break;
                case "City": code = "128"; break;
                case "PostCode": code = "160"; break;
                case "Email": code = "141"; break;
                case "Telephone": code = "170"; break;
            }

            if (fieldLength > limit)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError(code, $"");
                textBox.Text = fieldString.Substring(0, Math.Min(fieldString.Length, limit));
                textBox.SelectAll();
                return;
            }
        }

        

        // Change Button Colours ------------------------------------------------------------------------------------------------------------
        private void ButtonEnter(Button button)
        {
            button.BackColor = Color.FromArgb(152, 179, 194);
            button.ForeColor = Color.FromArgb(46, 72, 89);
        }
        private void ButtonLeave(Button button)
        {
            button.BackColor = Color.FromArgb(46, 72, 89);
            button.ForeColor = Color.FromArgb(152, 179, 194);
        }

        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Change fields when focused
        private void cbClient_Enter(object sender, EventArgs e)
        {
            cbClient.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            cbClient.BackColor = Color.White;
        }

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
                    messageBox.ShowDefError("129", $"");
                    cbClient.Focus();
                    return;
                }
                else
                {
                    if (CheckCust() > 1 || CheckCust() == 0)
                    {
                        SearchFrom searchFrom = new SearchFrom(this, null);
                        searchFrom.search = search;
                        searchFrom.sessionId = sessionId;
                        searchFrom.client = client;
                        searchFrom.userName = userName;
                        searchFrom.openedBy = 1;
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

        private void txbName_Enter(object sender, EventArgs e)
        {
            txbName.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbName_Leave(object sender, EventArgs e)
        {
            txbName.BackColor = Color.White;
        }

        private void txbAddress_Enter(object sender, EventArgs e)
        {
            txbAddress.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbAddress_Leave(object sender, EventArgs e)
        {
            txbAddress.BackColor = Color.White;
        }

        private void txbCity_Enter(object sender, EventArgs e)
        {
            txbCity.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbCity_Leave(object sender, EventArgs e)
        {
            txbCity.BackColor = Color.White;
        }

        private void txbPostcode_Enter(object sender, EventArgs e)
        {
            txbPostcode.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbPostcode_Leave(object sender, EventArgs e)
        {
            txbPostcode.BackColor = Color.White;
            //GetNonCustomer();
        }

        private void txbEmail_Enter(object sender, EventArgs e)
        {
            txbEmail.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            txbEmail.BackColor = Color.White;
        }

        private void txbTelephone_Enter(object sender, EventArgs e)
        {
            txbTelephone.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbTelephone_Leave(object sender, EventArgs e)
        {
            txbTelephone.BackColor = Color.White;
        }

        private void cbReason_Enter(object sender, EventArgs e)
        {
            cbReason.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void cbReason_Leave(object sender, EventArgs e)
        {
            cbReason.BackColor = Color.White;
            txbName.BackColor = Color.White;
        }

        // Change Button Colors --------------------------------------------------------------------------------------------------------
        private void btnAccept_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnter(btnAccept);
        }

        private void btnAccept_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnAccept);
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnter(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnClear);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnExit);
        }

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

        // Set Character Limit for Customer --------------------------------------------------------------------------------------------------------
        private void txbCustomer_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbCustomer, "Customer", 12);
        }

        // Set Character Limit for Name --------------------------------------------------------------------------------------------------------
        private void txbName_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbName, "Name", 255);
        }

        // Set Character Limit for Address --------------------------------------------------------------------------------------------------------
        private void txbAddress_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbAddress, "Address", 255);
        }

        // Set Character Limit for City --------------------------------------------------------------------------------------------------------
        private void txbCity_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbCity, "City", 48);
        }

        // Set Character Limit for Postcode --------------------------------------------------------------------------------------------------------
        private void txbPostcode_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbPostcode, "PostCode", 10);
        }

        // Set Character Limit for Email --------------------------------------------------------------------------------------------------------
        private void txbEmail_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbEmail, "Email", 48);
        }

        // Set Character Limit for Telephone --------------------------------------------------------------------------------------------------------
        private void txbTelephone_TextChanged(object sender, EventArgs e)
        {
            SetCharacterLimit(txbTelephone, "Telephone", 14);
        }

        // Text Changed --------------------------------------------------------------------------------------------------------
        private void cbClient_TextChanged(object sender, EventArgs e)
        {
            ClearFields();
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Exit Button Event --------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            SessionMaintenance.LogBook("", "[MainForm]", "[FormClosing]", "Application Closed", lblLogBook);
            SessionMaintenance.UpdateStatusLabel(lblLogBook);
            this.Close();
        }

        // Clear Button Event --------------------------------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all fields
            txbName.Text = "";
            ClearFields();
            cbClient.Focus();
            cbClient.Text = "";
            cbClient.SelectedItem = null;
            lblCustExist.Visible = false;
        }

        // Accept Button Event --------------------------------------------------------------------------------------------------------
        private void btnAccept_Click(object sender, EventArgs e)
        {
            string tKey = CreateTKey();

            lblCustExist.Visible = false; // Hide Label

            if (!ValidateInputs())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor; // Set Cursor to Eggtimer

            try
            {
                string client = null;
                string customer = null;
                string name = txbName.Text;
                string address = txbAddress.Text;
                string city = txbCity.Text;
                string postcode = txbPostcode.Text;
                string email = txbEmail.Text;
                string telephone = txbTelephone.Text;
                string reason = null;

                // Update customer string
                if (cust == 1)
                {
                    customer = txbCustomer.Text;
                }
                else if (cust == 0 || string.IsNullOrEmpty(customer))
                {
                    customer = "";
                }

                // Set combo box variables
                if (cbReason.SelectedItem != null)
                {
                    reason = cbReason.SelectedItem.ToString();
                }
                else
                {
                    Cursor.Current = Cursors.Default; // Set Cursor to Default
                    return;
                }
                if (cbClient.SelectedItem != null)
                {
                    client = cbClient.SelectedItem.ToString();
                }
                else
                {
                    Cursor.Current = Cursors.Default; // Set Cursor to Default
                    return;
                }

                InsertDetails(tKey, client, customer, name, address, city, postcode, email, telephone, reason); // Invoke InsertDetails Method
                txbCustomer.Focus(); // Return Focus to customer Text Box
            }
            catch (Exception ex) // Catch Errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("124", $"\n{ex.Message}");
                SessionMaintenance.LogBook($"{tKey}-ER", "[MainForm]", "[InsertDetails]", $"FAILED: Code 124 ({ex.Message})", lblLogBook);
                SessionMaintenance.UpdateStatusLabel(lblLogBook);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Set Cursor to Default
            }
        }

        // Accept Button Event --------------------------------------------------------------------------------------------------------
        private void txbCustomer_DoubleClick(object sender, EventArgs e)
        {
            string client = "";

            if (cbClient.SelectedItem != null)
            {
                client = cbClient.SelectedItem.ToString();
            }
            else
            {
                return;
            }

            SearchFrom searchFrom = new SearchFrom(this, null);
            searchFrom.search = "";
            searchFrom.sessionId = sessionId;
            searchFrom.client = client;
            searchFrom.userName = userName;
            searchFrom.openedBy = 1;
            searchFrom.Show();
        }

        // Menu Strip Items --------------------------------------------------------------------------------------------------------
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("003");
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("002");
        }
        private void rdPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunReport("004");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportCSV importCSV = new ImportCSV();
            importCSV.userName = userName;
            importCSV.sessionId = sessionId;
            importCSV.Show();
        }

        // LogBook Lable Click Event --------------------------------------------------------------------------------------------------------
        private void lblLogBook_Click(object sender, EventArgs e)
        {
            string Message = lblLogBook.Text;
            CustomMessageBox messageBox = new CustomMessageBox();
            messageBox.ShowLogBook($"LogBook Activity Recorded For '{Environment.MachineName}.{Environment.UserName}: {Message}");
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts--------------------------------------------------------------------------------------------------------
        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbName.Text = "";
                btnClear_Click(sender, e);
            }

            // ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnAccept_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }

        // Check Values in Telephone Text Box --------------------------------------------------------------------------------------------------------
        private void txbTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here. \nOnly numerical values accepted for Telephone.");
                e.Handled = true;
            }
        }
        private void txbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' || e.KeyChar == '"' || e.KeyChar == '\'' || e.KeyChar == '\n' || e.KeyChar == '\t')
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here.");
                e.Handled = true;
            }
        }

        private void txbCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ' ' && !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"Character: '{e.KeyChar}' Not Accepted Here");
                e.Handled = true;
            }
        }
    }
}
