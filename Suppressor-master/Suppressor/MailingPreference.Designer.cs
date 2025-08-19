namespace Suppressor
{
    partial class MailingPreference
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailingPreference));
            lblUsername = new Label();
            btnMailPref = new Label();
            cbClient = new ComboBox();
            txbCustomer = new TextBox();
            lblCustExist = new Label();
            label2 = new Label();
            label1 = new Label();
            lblLogBook = new Label();
            lblDetails = new Label();
            btnExit = new Button();
            btnClear = new Button();
            btnSave = new Button();
            lblCustDetails = new Label();
            ckbEmail = new CheckBox();
            ckb3rdPartMail = new CheckBox();
            msMain = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            summaryToolStripMenuItem = new ToolStripMenuItem();
            detailsToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsername.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(46, 72, 89);
            lblUsername.Location = new Point(0, 26);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(315, 14);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopRight;
            // 
            // btnMailPref
            // 
            btnMailPref.BackColor = Color.Transparent;
            btnMailPref.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnMailPref.ForeColor = Color.FromArgb(46, 72, 89);
            btnMailPref.Location = new Point(12, 58);
            btnMailPref.Name = "btnMailPref";
            btnMailPref.Size = new Size(291, 62);
            btnMailPref.TabIndex = 22;
            btnMailPref.Text = "Suppressor - Mailing Preferences";
            btnMailPref.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbClient
            // 
            cbClient.BackColor = Color.White;
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbClient.ForeColor = Color.FromArgb(46, 72, 89);
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(12, 138);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(291, 23);
            cbClient.TabIndex = 1;
            cbClient.TextChanged += cbClient_TextChanged;
            cbClient.Enter += cbClient_Enter;
            cbClient.Leave += cbClient_Leave;
            // 
            // txbCustomer
            // 
            txbCustomer.CharacterCasing = CharacterCasing.Upper;
            txbCustomer.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbCustomer.ForeColor = Color.FromArgb(46, 72, 89);
            txbCustomer.Location = new Point(12, 183);
            txbCustomer.Name = "txbCustomer";
            txbCustomer.Size = new Size(192, 21);
            txbCustomer.TabIndex = 2;
            txbCustomer.Enter += txbCustomer_Enter;
            txbCustomer.Leave += txbCustomer_Leave;
            // 
            // lblCustExist
            // 
            lblCustExist.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCustExist.ForeColor = Color.FromArgb(252, 85, 79);
            lblCustExist.Location = new Point(12, 225);
            lblCustExist.Name = "lblCustExist";
            lblCustExist.Size = new Size(291, 44);
            lblCustExist.TabIndex = 23;
            lblCustExist.Text = "Customer Exists False?";
            lblCustExist.TextAlign = ContentAlignment.MiddleCenter;
            lblCustExist.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(46, 72, 89);
            label2.Location = new Point(12, 165);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 11;
            label2.Text = "Customer/Search*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(46, 72, 89);
            label1.Location = new Point(12, 120);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 10;
            label1.Text = "Client*";
            // 
            // lblLogBook
            // 
            lblLogBook.BackColor = Color.FromArgb(250, 236, 207);
            lblLogBook.Cursor = Cursors.Hand;
            lblLogBook.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogBook.ForeColor = Color.FromArgb(152, 179, 194);
            lblLogBook.Location = new Point(12, 425);
            lblLogBook.Name = "lblLogBook";
            lblLogBook.Size = new Size(291, 15);
            lblLogBook.TabIndex = 25;
            lblLogBook.Text = "LogBook";
            lblLogBook.TextAlign = ContentAlignment.MiddleLeft;
            lblLogBook.Click += lblLogBook_Click;
            lblLogBook.MouseEnter += lblLogBook_MouseEnter;
            lblLogBook.MouseLeave += lblLogBook_MouseLeave;
            // 
            // lblDetails
            // 
            lblDetails.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetails.ForeColor = Color.FromArgb(46, 72, 89);
            lblDetails.Location = new Point(12, 369);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(291, 15);
            lblDetails.TabIndex = 24;
            lblDetails.Text = "Details";
            lblDetails.TextAlign = ContentAlignment.MiddleLeft;
            lblDetails.Visible = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(46, 72, 89);
            btnExit.CausesValidation = false;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.FromArgb(152, 179, 194);
            btnExit.Location = new Point(12, 387);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 35);
            btnExit.TabIndex = 7;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(46, 72, 89);
            btnClear.CausesValidation = false;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = Color.FromArgb(152, 179, 194);
            btnClear.Location = new Point(108, 387);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(96, 35);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 72, 89);
            btnSave.CausesValidation = false;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.FromArgb(152, 179, 194);
            btnSave.Location = new Point(210, 387);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 35);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += btnSave_MouseEnter;
            btnSave.MouseLeave += btnSave_MouseLeave;
            // 
            // lblCustDetails
            // 
            lblCustDetails.BackColor = Color.FromArgb(46, 72, 89);
            lblCustDetails.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCustDetails.ForeColor = Color.FromArgb(250, 236, 207);
            lblCustDetails.Location = new Point(12, 207);
            lblCustDetails.Name = "lblCustDetails";
            lblCustDetails.Size = new Size(291, 82);
            lblCustDetails.TabIndex = 27;
            lblCustDetails.Text = "Customer";
            // 
            // ckbEmail
            // 
            ckbEmail.AutoSize = true;
            ckbEmail.FlatStyle = FlatStyle.Flat;
            ckbEmail.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ckbEmail.ForeColor = Color.FromArgb(46, 72, 89);
            ckbEmail.Location = new Point(12, 331);
            ckbEmail.Name = "ckbEmail";
            ckbEmail.Size = new Size(77, 26);
            ckbEmail.TabIndex = 3;
            ckbEmail.Text = "Email";
            ckbEmail.UseVisualStyleBackColor = true;
            // 
            // ckb3rdPartMail
            // 
            ckb3rdPartMail.AutoSize = true;
            ckb3rdPartMail.FlatStyle = FlatStyle.Flat;
            ckb3rdPartMail.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ckb3rdPartMail.ForeColor = Color.FromArgb(46, 72, 89);
            ckb3rdPartMail.Location = new Point(122, 331);
            ckb3rdPartMail.Name = "ckb3rdPartMail";
            ckb3rdPartMail.Size = new Size(181, 26);
            ckb3rdPartMail.TabIndex = 4;
            ckb3rdPartMail.Text = "3rd Party Mailing";
            ckb3rdPartMail.UseVisualStyleBackColor = true;
            // 
            // msMain
            // 
            msMain.BackgroundImageLayout = ImageLayout.None;
            msMain.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Size = new Size(315, 24);
            msMain.TabIndex = 30;
            msMain.Text = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportToolStripMenuItem, clearToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { summaryToolStripMenuItem, detailsToolStripMenuItem });
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(114, 22);
            reportToolStripMenuItem.Text = "Report";
            // 
            // summaryToolStripMenuItem
            // 
            summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            summaryToolStripMenuItem.Size = new Size(130, 22);
            summaryToolStripMenuItem.Text = "Summary";
            summaryToolStripMenuItem.Click += summaryToolStripMenuItem_Click;
            // 
            // detailsToolStripMenuItem
            // 
            detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            detailsToolStripMenuItem.Size = new Size(130, 22);
            detailsToolStripMenuItem.Text = "Details";
            detailsToolStripMenuItem.Click += detailsToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(114, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(114, 22);
            quitToolStripMenuItem.Text = "Close";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // MailingPreference
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(315, 451);
            ControlBox = false;
            Controls.Add(ckb3rdPartMail);
            Controls.Add(ckbEmail);
            Controls.Add(btnSave);
            Controls.Add(lblLogBook);
            Controls.Add(lblDetails);
            Controls.Add(lblUsername);
            Controls.Add(btnMailPref);
            Controls.Add(lblCustExist);
            Controls.Add(btnClear);
            Controls.Add(cbClient);
            Controls.Add(btnExit);
            Controls.Add(txbCustomer);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(msMain);
            Controls.Add(lblCustDetails);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Name = "MailingPreference";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MailingPreference";
            Load += MailingPreference_Load;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label btnMailPref;
        private ComboBox cbClient;
        private Label lblCustExist;
        private Label label2;
        private Label label1;
        private Label lblLogBook;
        private Label lblDetails;
        private Button btnExit;
        private Button btnClear;
        private Button btnSave;
        private Label lblCustDetails;
        private CheckBox ckbEmail;
        private CheckBox ckb3rdPartMail;
        private MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem summaryToolStripMenuItem;
        private ToolStripMenuItem detailsToolStripMenuItem;
        public TextBox txbCustomer;
    }
}