using Microsoft.Data.SqlClient;

namespace Suppressor
{
    public partial class MenuForm : Form
    {
        public string userName { get; set; }
        public string sessionId { get; set; }

        // Set SQL Connection String
        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public MenuForm()
        {
            InitializeComponent();
            this.MaximizeBox = false; // Disable Maximize window option
            this.KeyPreview = true;
            this.KeyDown += MainFrom_KeyDown;
            this.FormClosing += MainForm_FormClosing;
            Text = $"Menu - {Environment.UserName.ToUpper()}";
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = userName; // Show Username
            SessionMaintenance.LogBook("", "[MenuForm]", "[FormLoad]", "Application Started");

            sessionTimer.Start();
        }

        // Exit Application Method --------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
                if (result == true)
                {
                    SessionMaintenance.LogBook("", "[MenuForm]", "[FormClosing]", "Application Finished");
                    SessionMaintenance.ClearSessionID(sessionId);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }        

        // Check Timer ---------------------------------------------------------------------------------------------------------------------
        private void CheckTimer()
        {
            string query = "SELECT TOP 1 DT_Created FROM Suppressor_LogBook WHERE Session_Id = @Session_Id ORDER BY DT_Created DESC";
            DateTime? lastUpdated = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Session_Id", sessionId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            lastUpdated = (DateTime)result;
                        }
                    }

                    conn.Close();
                }

                if (lastUpdated.HasValue && DateTime.Now - lastUpdated.Value >= TimeSpan.FromHours(2.5))
                {
                    // Show popup to indicate session will expire in 30 minutes
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowWarning($"Session will expire in <30 minutes due to inactivity! \n{DateTime.Now}");
                }
            }
            catch (Exception ex) // Catch any errors
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowError($"An error occurred checking session timeout: \n{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[HomeForm]", "[CheckTimer]", $"FAILED ( {ex.Message} )");
            }
        }

        // Change Button Colours ----------------------------------------------------------------------------------------------------------------------
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

        // Suppress Button ----------------------------------------------------------------------------------------------------------------------
        private void btnSuppress_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnter(btnSuppress);
        }

        private void btnSuppress_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnSuppress);
        }

        // Mailing Preferences Button ----------------------------------------------------------------------------------------------------------------------
        private void btnMailPref_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnter(btnMailPref);
        }

        private void btnMailPref_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnMailPref);
        }

        // Exit Button ----------------------------------------------------------------------------------------------------------------------
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnter(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeave(btnExit);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // Exit Button Click ----------------------------------------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
            if (result == true)
            {
                SessionMaintenance.LogBook("", "[MenuForm]", "[FormClosing]", "Application Finished");
                SessionMaintenance.ClearSessionID(sessionId);
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        // Suppression Button Click ----------------------------------------------------------------------------------------------------------------------
        private void btnSuppress_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.userName = userName;
            MainForm.sessionId = sessionId;
            MainForm.Show();
        }

        // Mailing Preference Button Click ----------------------------------------------------------------------------------------------------------------------
        private void btnMailPref_Click(object sender, EventArgs e)
        {
            MailingPreference mailingPreferences = new MailingPreference();
            mailingPreferences.userName = userName;
            mailingPreferences.sessionId = sessionId;
            mailingPreferences.Show();
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // Keyboard Shortcuts ----------------------------------------------------------------------------------------------------------------------
        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // F1
            if (e.KeyCode == Keys.F1)
            {
                btnSuppress_Click(sender, e);
            }

            // F2
            if (e.KeyCode == Keys.F2)
            {
                btnMailPref_Click(sender, e);
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }

        private void sessionTimer_Tick(object sender, EventArgs e)
        {
            CheckTimer();
        }
    }
}
