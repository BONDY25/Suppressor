using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suppressor
{
    public partial class CustomMessageBox : Form
    {
        //====================================================================================================================================//
        //-- Initialization --//
        //====================================================================================================================================//

        private const string connectionString = SessionMaintenance.connectionString; // Connection String from SessionMaintenance

        public CustomMessageBox()
        {
            InitializeComponent();
        }


        //====================================================================================================================================//
        //-- Operation Methods --//
        //====================================================================================================================================//

        private string GetError(string code)
        {
            string query = "SELECT RTRIM(Error) as [Error] FROM Appz_Errors WHERE code = @Code";
            string error = "Unknown Error!";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open SQL Connection

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", code);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                error = reader["Error"].ToString(); // Populate variable
                            }
                        }
                    }

                    conn.Close(); // Close SQL Connection
                }
            }
            catch (Exception ex)
            {
                Application.Exit();
            }
            return error;
        }

        // Show An Error
        public void ShowError(string error)
        {
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Error!";
            Text = "Error!";
            lblDescription.Text = error;
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show An Error
        public void ShowDefError(string code, string additional)
        {
            string error = GetError(code);

            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Error!";
            Text = "Error!";
            lblDescription.Text = $"Error {code}: \n{error} {additional}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show Disclaimer
        public bool ShowDisclaimer()
        {
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "WARNING!";
            Text = "WARNING!";
            lblDescription.Text = "This application cannot be used for RTBF (Right To Be Forgotten). \n\nThis application can only be used for customer suppressions, no mails and mailing preference updates. \n\nDo you understand?";
            btnNo.Visible = true;
            btnYesOk.Text = "Yes";
            btnYesOk.Click += btnYesOk_Click;
            btnNo.Click += btnNo_Click;
            this.ShowDialog();

            return DialogResult == DialogResult.Yes;
        }

        // Show A Warning
        public void ShowWarning(string Warning)
        {
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Warning!";
            Text = "Warning!";
            lblDescription.Text = Warning;
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show Exit
        public bool ShowExitDialog()
        {
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "Exit?";
            Text = "Exit?";
            lblDescription.Text = "Are you sure you want to Exit the application?";
            btnNo.Visible = true;
            btnYesOk.Text = "Yes";
            btnYesOk.Click += btnYesOk_Click;
            btnNo.Click += btnNo_Click;
            this.ShowDialog();

            return DialogResult == DialogResult.Yes;
        }

        // Show LogBook
        public void ShowLogBook(string message)
        {
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = "LogBook";
            Text = "LogBook";
            lblDescription.Text = $"Last LogBook Activity Recorded: \n{message}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        // Show Message
        public void ShowMessage(string message, string summary)
        {
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblSummary.Text = $"{summary}";
            Text = $"{summary}";
            lblDescription.Text = $"{message}";
            btnNo.Visible = false;
            btnYesOk.Text = "Ok";
            this.ShowDialog();
        }

        //====================================================================================================================================//
        //-- Enviroment Events --//
        //====================================================================================================================================//

        private void btnYesOk_MouseEnter(object sender, EventArgs e)
        {
            btnYesOk.BackColor = Color.FromArgb(152, 179, 194);
            btnYesOk.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnYesOk_MouseLeave(object sender, EventArgs e)
        {
            btnYesOk.BackColor = Color.FromArgb(46, 72, 89);
            btnYesOk.ForeColor = Color.FromArgb(152, 179, 194);
        }

        private void btnNo_MouseEnter(object sender, EventArgs e)
        {
            btnNo.BackColor = Color.FromArgb(152, 179, 194);
            btnNo.ForeColor = Color.FromArgb(46, 72, 89);
        }

        private void btnNo_MouseLeave(object sender, EventArgs e)
        {
            btnNo.BackColor = Color.FromArgb(46, 72, 89);
            btnNo.ForeColor = Color.FromArgb(152, 179, 194);
        }

        //====================================================================================================================================//
        //-- Button Click Events --//
        //====================================================================================================================================//

        // No Button Click Event
        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        // Yes/Ok Button Click Event
        private void btnYesOk_Click(object sender, EventArgs e)
        {
            if (btnYesOk.Text == "Ok")
            {
                this.Close();
            }
            else if (btnYesOk.Text == "Yes")
            {
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }


    }
}
