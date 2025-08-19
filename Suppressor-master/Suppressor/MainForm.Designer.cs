namespace Suppressor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblUsername = new Label();
            cbClient = new ComboBox();
            txbCustomer = new TextBox();
            txbName = new TextBox();
            txbAddress = new TextBox();
            txbCity = new TextBox();
            txbPostcode = new TextBox();
            txbEmail = new TextBox();
            txbTelephone = new TextBox();
            cbReason = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnExit = new Button();
            btnClear = new Button();
            btnAccept = new Button();
            label10 = new Label();
            lblCustExist = new Label();
            lblDetails = new Label();
            lblLogBook = new Label();
            msMain = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            summaryToolStripMenuItem = new ToolStripMenuItem();
            detailsToolStripMenuItem = new ToolStripMenuItem();
            rdPartyToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsername.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(46, 72, 89);
            lblUsername.Location = new Point(0, 24);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(373, 14);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopRight;
            // 
            // cbClient
            // 
            cbClient.BackColor = Color.White;
            cbClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClient.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbClient.ForeColor = Color.FromArgb(46, 72, 89);
            cbClient.FormattingEnabled = true;
            cbClient.Location = new Point(12, 104);
            cbClient.Name = "cbClient";
            cbClient.Size = new Size(349, 23);
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
            txbCustomer.Location = new Point(11, 148);
            txbCustomer.Name = "txbCustomer";
            txbCustomer.Size = new Size(192, 21);
            txbCustomer.TabIndex = 2;
            txbCustomer.TextChanged += txbCustomer_TextChanged;
            txbCustomer.DoubleClick += txbCustomer_DoubleClick;
            txbCustomer.Enter += txbCustomer_Enter;
            txbCustomer.KeyPress += txbCustomer_KeyPress;
            txbCustomer.Leave += txbCustomer_Leave;
            // 
            // txbName
            // 
            txbName.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbName.ForeColor = Color.FromArgb(46, 72, 89);
            txbName.Location = new Point(11, 190);
            txbName.Name = "txbName";
            txbName.Size = new Size(348, 21);
            txbName.TabIndex = 3;
            txbName.TextChanged += txbName_TextChanged;
            txbName.Enter += txbName_Enter;
            txbName.Leave += txbName_Leave;
            // 
            // txbAddress
            // 
            txbAddress.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbAddress.ForeColor = Color.FromArgb(46, 72, 89);
            txbAddress.Location = new Point(11, 232);
            txbAddress.Name = "txbAddress";
            txbAddress.Size = new Size(348, 21);
            txbAddress.TabIndex = 4;
            txbAddress.TextChanged += txbAddress_TextChanged;
            txbAddress.Enter += txbAddress_Enter;
            txbAddress.Leave += txbAddress_Leave;
            // 
            // txbCity
            // 
            txbCity.CharacterCasing = CharacterCasing.Upper;
            txbCity.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbCity.ForeColor = Color.FromArgb(46, 72, 89);
            txbCity.Location = new Point(11, 274);
            txbCity.Name = "txbCity";
            txbCity.Size = new Size(192, 21);
            txbCity.TabIndex = 5;
            txbCity.TextChanged += txbCity_TextChanged;
            txbCity.Enter += txbCity_Enter;
            txbCity.Leave += txbCity_Leave;
            // 
            // txbPostcode
            // 
            txbPostcode.CharacterCasing = CharacterCasing.Upper;
            txbPostcode.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbPostcode.ForeColor = Color.FromArgb(46, 72, 89);
            txbPostcode.Location = new Point(211, 274);
            txbPostcode.Name = "txbPostcode";
            txbPostcode.Size = new Size(150, 21);
            txbPostcode.TabIndex = 6;
            txbPostcode.TextChanged += txbPostcode_TextChanged;
            txbPostcode.Enter += txbPostcode_Enter;
            txbPostcode.Leave += txbPostcode_Leave;
            // 
            // txbEmail
            // 
            txbEmail.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbEmail.ForeColor = Color.FromArgb(46, 72, 89);
            txbEmail.Location = new Point(11, 316);
            txbEmail.Name = "txbEmail";
            txbEmail.Size = new Size(192, 21);
            txbEmail.TabIndex = 7;
            txbEmail.TextChanged += txbEmail_TextChanged;
            txbEmail.Enter += txbEmail_Enter;
            txbEmail.KeyPress += txbEmail_KeyPress;
            txbEmail.Leave += txbEmail_Leave;
            // 
            // txbTelephone
            // 
            txbTelephone.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbTelephone.ForeColor = Color.FromArgb(46, 72, 89);
            txbTelephone.Location = new Point(211, 316);
            txbTelephone.Name = "txbTelephone";
            txbTelephone.Size = new Size(150, 21);
            txbTelephone.TabIndex = 8;
            txbTelephone.TextChanged += txbTelephone_TextChanged;
            txbTelephone.Enter += txbTelephone_Enter;
            txbTelephone.KeyPress += txbTelephone_KeyPress;
            txbTelephone.Leave += txbTelephone_Leave;
            // 
            // cbReason
            // 
            cbReason.BackColor = Color.White;
            cbReason.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReason.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbReason.ForeColor = Color.FromArgb(46, 72, 89);
            cbReason.FormattingEnabled = true;
            cbReason.Location = new Point(12, 358);
            cbReason.Name = "cbReason";
            cbReason.Size = new Size(193, 23);
            cbReason.TabIndex = 9;
            cbReason.Enter += cbReason_Enter;
            cbReason.Leave += cbReason_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(46, 72, 89);
            label1.Location = new Point(10, 86);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 10;
            label1.Text = "Client*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(46, 72, 89);
            label2.Location = new Point(10, 130);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 11;
            label2.Text = "Customer/Search";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(46, 72, 89);
            label3.Location = new Point(10, 172);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 12;
            label3.Text = "Name*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(46, 72, 89);
            label4.Location = new Point(10, 214);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 13;
            label4.Text = "Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(46, 72, 89);
            label5.Location = new Point(10, 256);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 14;
            label5.Text = "City";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(46, 72, 89);
            label6.Location = new Point(211, 256);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 15;
            label6.Text = "Postcode";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(46, 72, 89);
            label7.Location = new Point(10, 298);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 16;
            label7.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(46, 72, 89);
            label8.Location = new Point(211, 298);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 17;
            label8.Text = "Telephone";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.FromArgb(46, 72, 89);
            label9.Location = new Point(10, 340);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 18;
            label9.Text = "Reason*";
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
            btnExit.Location = new Point(11, 425);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 35);
            btnExit.TabIndex = 21;
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
            btnClear.Location = new Point(107, 425);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(96, 35);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            btnClear.MouseEnter += btnClear_MouseEnter;
            btnClear.MouseLeave += btnClear_MouseLeave;
            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.FromArgb(46, 72, 89);
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAccept.ForeColor = Color.FromArgb(152, 179, 194);
            btnAccept.Location = new Point(209, 425);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(150, 35);
            btnAccept.TabIndex = 19;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            btnAccept.MouseEnter += btnAccept_MouseEnter;
            btnAccept.MouseLeave += btnAccept_MouseLeave;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(46, 72, 89);
            label10.Location = new Point(11, 44);
            label10.Name = "label10";
            label10.Size = new Size(349, 42);
            label10.TabIndex = 22;
            label10.Text = "Suppressor - Home";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCustExist
            // 
            lblCustExist.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCustExist.ForeColor = Color.FromArgb(252, 85, 79);
            lblCustExist.Location = new Point(212, 151);
            lblCustExist.Name = "lblCustExist";
            lblCustExist.Size = new Size(147, 15);
            lblCustExist.TabIndex = 23;
            lblCustExist.Text = "Customer Exists False?";
            lblCustExist.Visible = false;
            // 
            // lblDetails
            // 
            lblDetails.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDetails.ForeColor = Color.FromArgb(46, 72, 89);
            lblDetails.Location = new Point(12, 395);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(349, 15);
            lblDetails.TabIndex = 24;
            lblDetails.Text = "Details";
            lblDetails.TextAlign = ContentAlignment.MiddleLeft;
            lblDetails.Visible = false;
            // 
            // lblLogBook
            // 
            lblLogBook.BackColor = Color.FromArgb(250, 236, 207);
            lblLogBook.Cursor = Cursors.Hand;
            lblLogBook.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogBook.ForeColor = Color.FromArgb(152, 179, 194);
            lblLogBook.Location = new Point(10, 464);
            lblLogBook.Name = "lblLogBook";
            lblLogBook.Size = new Size(349, 15);
            lblLogBook.TabIndex = 25;
            lblLogBook.Text = "LogBook";
            lblLogBook.TextAlign = ContentAlignment.MiddleLeft;
            lblLogBook.Click += lblLogBook_Click;
            lblLogBook.MouseEnter += lblLogBook_MouseEnter;
            lblLogBook.MouseLeave += lblLogBook_MouseLeave;
            // 
            // msMain
            // 
            msMain.BackgroundImageLayout = ImageLayout.None;
            msMain.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Size = new Size(373, 24);
            msMain.TabIndex = 26;
            msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportToolStripMenuItem, clearToolStripMenuItem, importToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(39, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { summaryToolStripMenuItem, detailsToolStripMenuItem, rdPartyToolStripMenuItem });
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(180, 22);
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
            // rdPartyToolStripMenuItem
            // 
            rdPartyToolStripMenuItem.Name = "rdPartyToolStripMenuItem";
            rdPartyToolStripMenuItem.Size = new Size(130, 22);
            rdPartyToolStripMenuItem.Text = "3rd Party";
            rdPartyToolStripMenuItem.Click += rdPartyToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(180, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(180, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(180, 22);
            quitToolStripMenuItem.Text = "Close";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(373, 483);
            ControlBox = false;
            Controls.Add(lblLogBook);
            Controls.Add(lblDetails);
            Controls.Add(lblCustExist);
            Controls.Add(label10);
            Controls.Add(btnAccept);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbReason);
            Controls.Add(txbTelephone);
            Controls.Add(txbEmail);
            Controls.Add(txbPostcode);
            Controls.Add(txbCity);
            Controls.Add(txbAddress);
            Controls.Add(txbName);
            Controls.Add(txbCustomer);
            Controls.Add(cbClient);
            Controls.Add(lblUsername);
            Controls.Add(msMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += MainForm_Load;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private ComboBox cbClient;
        private TextBox txbName;
        private TextBox txbAddress;
        private TextBox txbCity;
        private TextBox txbPostcode;
        private TextBox txbEmail;
        private TextBox txbTelephone;
        private ComboBox cbReason;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnExit;
        private Button btnClear;
        private Button btnAccept;
        private Label label10;
        private Label lblCustExist;
        private Label lblDetails;
        private Label lblLogBook;
        private MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem summaryToolStripMenuItem;
        private ToolStripMenuItem detailsToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem rdPartyToolStripMenuItem;
        public TextBox txbCustomer;
        private ToolStripMenuItem importToolStripMenuItem;
    }
}