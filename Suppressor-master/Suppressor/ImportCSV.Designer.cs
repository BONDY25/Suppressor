namespace Suppressor
{
    partial class ImportCSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportCSV));
            btnFun = new Button();
            pBarImport = new ProgressBar();
            lblProgress = new Label();
            label10 = new Label();
            lblrps = new Label();
            lblStatus = new Label();
            lblError = new Label();
            SuspendLayout();
            // 
            // btnFun
            // 
            btnFun.BackColor = Color.FromArgb(46, 72, 89);
            btnFun.Cursor = Cursors.Hand;
            btnFun.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnFun.FlatStyle = FlatStyle.Flat;
            btnFun.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnFun.ForeColor = Color.FromArgb(152, 179, 194);
            btnFun.Location = new Point(14, 193);
            btnFun.Name = "btnFun";
            btnFun.Size = new Size(583, 33);
            btnFun.TabIndex = 19;
            btnFun.Text = "Close";
            btnFun.UseVisualStyleBackColor = true;
            btnFun.Click += btnFun_Click;
            // 
            // pBarImport
            // 
            pBarImport.ForeColor = Color.FromArgb(252, 85, 79);
            pBarImport.Location = new Point(14, 114);
            pBarImport.Name = "pBarImport";
            pBarImport.Size = new Size(583, 43);
            pBarImport.Step = 1;
            pBarImport.Style = ProgressBarStyle.Continuous;
            pBarImport.TabIndex = 20;
            pBarImport.UseWaitCursor = true;
            // 
            // lblProgress
            // 
            lblProgress.Location = new Point(442, 97);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(155, 14);
            lblProgress.TabIndex = 21;
            lblProgress.Text = "Imported XXXX of XXXX";
            lblProgress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(46, 72, 89);
            label10.Location = new Point(14, 9);
            label10.Name = "label10";
            label10.Size = new Size(583, 42);
            label10.TabIndex = 22;
            label10.Text = "Suppressor - Import CSV";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblrps
            // 
            lblrps.Location = new Point(443, 160);
            lblrps.Name = "lblrps";
            lblrps.Size = new Size(155, 14);
            lblrps.TabIndex = 21;
            lblrps.Text = "XXX Rows/s";
            lblrps.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.FromArgb(46, 72, 89);
            lblStatus.Location = new Point(12, 51);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(583, 42);
            lblStatus.TabIndex = 22;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblError
            // 
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblError.ForeColor = Color.FromArgb(46, 72, 89);
            lblError.Location = new Point(14, 115);
            lblError.Name = "lblError";
            lblError.Size = new Size(584, 42);
            lblError.TabIndex = 22;
            lblError.Text = "Error";
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImportCSV
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(610, 237);
            ControlBox = false;
            Controls.Add(lblrps);
            Controls.Add(lblProgress);
            Controls.Add(pBarImport);
            Controls.Add(btnFun);
            Controls.Add(lblError);
            Controls.Add(lblStatus);
            Controls.Add(label10);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(46, 72, 89);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ImportCSV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImportCSV";
            Load += ImportCSV_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnFun;
        private ProgressBar pBarImport;
        private Label lblProgress;
        private Label label10;
        private Label lblrps;
        private Label lblStatus;
        private Label lblError;
    }
}