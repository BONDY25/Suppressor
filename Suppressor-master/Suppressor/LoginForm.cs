using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Suppressor
{
    public partial class LoginForm : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        public string sessionId = SessionMaintenance.GetSessionID();

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
            txbUsername.KeyPress += txbUsername_KeyPress;
            txbUsername.KeyDown += txbUsername_KeyDown;
            Text = $"Login - {Environment.UserName.ToUpper()}";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SessionMaintenance.sessionId = sessionId;
            SessionMaintenance.userName = "UNDEFINED";
            SessionMaintenance.LogBook("", "[LoginForm]", "[FormLoad]", $"Initialization");
            SessionMaintenance.CheckVersion();
            SessionMaintenance.CheckSessionID(sessionId);
            lblVersion.Text = $"Build: v{SessionMaintenance.currentVersion}";
        }

        // Exit Application Method
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
                if (result == true)
                {
                    SessionMaintenance.LogBook("", "[LoginForm]", "[FormClosing]", $"Termination");
                    SessionMaintenance.ClearSessionID(sessionId);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        // Check Username ------------------------------------------------------------------------------------------------------------------------
        private bool CheckUser()
        {
            string username = txbUsername.Text;
            string query = "SELECT COUNT(*) FROM APP_USERS WHERE Username = @Username";
            bool checkUser = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();

                        if (count != 1)
                        {
                            checkUser = false;
                        }
                        else
                        {
                            checkUser = true;
                        }
                    }
                    conn.Close();
                }
            }
            // Catch Errors
            catch (Exception ex)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("123", $"{ex.Message}");
                SessionMaintenance.LogBook("ERROR", "[LoginForm]", "[CheckUser]", $"FAILED: Code 123 ( {ex.Message} )");
            }

            return checkUser;
        }


        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        // Change Textbox Colours When Focused
        private void txbUsername_Enter(object sender, EventArgs e)
        {
            txbUsername.BackColor = Color.FromArgb(253, 122, 115);
        }

        private void txbUsername_Leave(object sender, EventArgs e)
        {
            txbUsername.BackColor = Color.White;
        }

        // Change Button Colors
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(152, 179, 194);
            btnLogin.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(46, 72, 89);
            btnLogin.ForeColor = Color.FromArgb(152, 179, 194);
        }

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

        // Set Character Limit for Username
        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            int usernameLength = username.Length;

            if (usernameLength > 100)
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("173", "");
                txbUsername.Text = username.Substring(0, Math.Min(username.Length, 100));
                txbUsername.SelectAll();
                return;
            }
        }

        private void pbLogo_MouseEnter(object sender, EventArgs e)
        {
            ttEgg.SetToolTip(pbLogo, "???");
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//


        // Login Button Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text.ToUpper();

            if (string.IsNullOrEmpty(userName))
            {
                CustomMessageBox messageBoxA = new CustomMessageBox();
                messageBoxA.ShowDefError("158", "");
                return;
            }
            else
            {
                if (CheckUser())
                {
                    // Display T&Cs
                    CustomMessageBox messageBoxB = new CustomMessageBox();
                    bool result = messageBoxB.ShowDisclaimer();
                    if (result == true)
                    {
                        MenuForm menuForm = new MenuForm();
                        menuForm.userName = userName;
                        menuForm.sessionId = sessionId;
                        SessionMaintenance.sessionId = sessionId;
                        SessionMaintenance.userName = userName;
                        menuForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    CustomMessageBox messageBox = new CustomMessageBox();
                    messageBox.ShowDefError("171", "");
                    return;
                }

            }
        }

        //Exit Button Event

        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox();
            bool result = messageBox.ShowExitDialog(); // Ask user if they want to exit
            if (result == true)
            {
                SessionMaintenance.LogBook("", "[LoginForm]", "[FormClosing]", $"Termination");
                SessionMaintenance.ClearSessionID(sessionId);
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            SessionMaintenance.ShowFact();                
        }

        //====================================================================================================================================//
        //-- Key Down Events --//
        //====================================================================================================================================//

        // ctrl + V Event (txbUsername)
        private void txbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the text from the clipboard
                string clipboardText = Clipboard.GetText();

                // Filter out invalid characters and set the filtered text to the TextBox
                txbUsername.Text = new string(clipboardText.Where(c => char.IsLetterOrDigit(c) || char.IsControl(c)).ToArray());

                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
        }

        // Prevent Special Characters (txbUsername)
        private void txbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                CustomMessageBox messageBox = new CustomMessageBox();
                messageBox.ShowDefError("127", $"'{e.KeyChar}'");
                e.Handled = true;
            }
        }

        // Keyboard Shortcuts
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ctrl + G
            if (e.Control && e.KeyCode == Keys.G)
            {
                txbUsername.Text = "";
            }

            // Esc
            if (e.KeyCode == Keys.Escape)
            {
                btnExit_Click(sender, e);
            }
        }
    }
}
