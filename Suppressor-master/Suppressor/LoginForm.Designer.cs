namespace Suppressor
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txbUsername = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblUsername = new Label();
            lblTitle = new Label();
            pbLogo = new PictureBox();
            lblVersion = new Label();
            ttEgg = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // txbUsername
            // 
            txbUsername.CharacterCasing = CharacterCasing.Upper;
            txbUsername.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbUsername.ForeColor = Color.FromArgb(46, 72, 89);
            txbUsername.Location = new Point(65, 397);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(200, 21);
            txbUsername.TabIndex = 0;
            txbUsername.TextChanged += txbUsername_TextChanged;
            txbUsername.Enter += txbUsername_Enter;
            txbUsername.Leave += txbUsername_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 72, 89);
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.FromArgb(152, 179, 194);
            btnLogin.Location = new Point(166, 424);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(99, 47);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(46, 72, 89);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.FromArgb(152, 179, 194);
            btnExit.Location = new Point(65, 424);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(95, 47);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(46, 72, 89);
            lblUsername.Location = new Point(65, 379);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(66, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(46, 72, 89);
            lblTitle.Location = new Point(12, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 51);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Suppressor - Login";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(12, 76);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(300, 300);
            pbLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            pbLogo.TabIndex = 3;
            pbLogo.TabStop = false;
            pbLogo.Click += pbLogo_Click;
            pbLogo.MouseEnter += pbLogo_MouseEnter;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Arial", 7F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersion.ForeColor = Color.FromArgb(46, 72, 89);
            lblVersion.Location = new Point(12, 484);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(38, 13);
            lblVersion.TabIndex = 6;
            lblVersion.Text = "Build: ";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(326, 506);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(pbLogo);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txbUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbUsername;
        private Button btnLogin;
        private Button btnExit;
        private Label lblUsername;
        private Label lblTitle;
        private PictureBox pbLogo;
        private Label lblVersion;
        private ToolTip ttEgg;
    }
}