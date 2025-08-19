namespace Suppressor
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            btnExit = new Button();
            lblUsername = new Label();
            label10 = new Label();
            btnSuppress = new Button();
            btnMailPref = new Button();
            sessionTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
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
            btnExit.Location = new Point(12, 356);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 35);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsername.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(46, 72, 89);
            lblUsername.Location = new Point(0, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(281, 14);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(46, 72, 89);
            label10.Location = new Point(12, 33);
            label10.Name = "label10";
            label10.Size = new Size(259, 62);
            label10.TabIndex = 22;
            label10.Text = "Suppressor - Menu";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSuppress
            // 
            btnSuppress.BackColor = Color.FromArgb(46, 72, 89);
            btnSuppress.CausesValidation = false;
            btnSuppress.Cursor = Cursors.Hand;
            btnSuppress.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnSuppress.FlatStyle = FlatStyle.Flat;
            btnSuppress.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnSuppress.ForeColor = Color.FromArgb(152, 179, 194);
            btnSuppress.Location = new Point(12, 98);
            btnSuppress.Name = "btnSuppress";
            btnSuppress.Size = new Size(259, 88);
            btnSuppress.TabIndex = 1;
            btnSuppress.Text = "Suppress Customers";
            btnSuppress.UseVisualStyleBackColor = true;
            btnSuppress.Click += btnSuppress_Click;
            btnSuppress.MouseEnter += btnSuppress_MouseEnter;
            btnSuppress.MouseLeave += btnSuppress_MouseLeave;
            // 
            // btnMailPref
            // 
            btnMailPref.BackColor = Color.FromArgb(46, 72, 89);
            btnMailPref.CausesValidation = false;
            btnMailPref.Cursor = Cursors.Hand;
            btnMailPref.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnMailPref.FlatStyle = FlatStyle.Flat;
            btnMailPref.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnMailPref.ForeColor = Color.FromArgb(152, 179, 194);
            btnMailPref.Location = new Point(12, 192);
            btnMailPref.Name = "btnMailPref";
            btnMailPref.Size = new Size(259, 88);
            btnMailPref.TabIndex = 2;
            btnMailPref.Text = "Update Customer Mailing Preferences";
            btnMailPref.UseVisualStyleBackColor = true;
            btnMailPref.Click += btnMailPref_Click;
            btnMailPref.MouseEnter += btnMailPref_MouseEnter;
            btnMailPref.MouseLeave += btnMailPref_MouseLeave;
            // 
            // sessionTimer
            // 
            sessionTimer.Interval = 600000;
            sessionTimer.Tick += sessionTimer_Tick;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(283, 403);
            Controls.Add(btnMailPref);
            Controls.Add(btnSuppress);
            Controls.Add(btnExit);
            Controls.Add(lblUsername);
            Controls.Add(label10);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            Load += MenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
        private Label lblUsername;
        private Label label10;
        private Button btnSuppress;
        private Button btnMailPref;
        private System.Windows.Forms.Timer sessionTimer;
    }
}