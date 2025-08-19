namespace Suppressor
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            btnYesOk = new Button();
            btnNo = new Button();
            lblSummary = new Label();
            lblDescription = new Label();
            SuspendLayout();
            // 
            // btnYesOk
            // 
            btnYesOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnYesOk.BackColor = Color.FromArgb(46, 72, 89);
            btnYesOk.Cursor = Cursors.Hand;
            btnYesOk.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnYesOk.FlatStyle = FlatStyle.Flat;
            btnYesOk.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnYesOk.ForeColor = Color.FromArgb(152, 179, 194);
            btnYesOk.Location = new Point(318, 177);
            btnYesOk.Name = "btnYesOk";
            btnYesOk.Size = new Size(95, 47);
            btnYesOk.TabIndex = 6;
            btnYesOk.Text = "Yes/Ok";
            btnYesOk.UseVisualStyleBackColor = false;
            btnYesOk.Click += btnYesOk_Click;
            btnYesOk.MouseEnter += btnYesOk_MouseEnter;
            btnYesOk.MouseLeave += btnYesOk_MouseLeave;
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNo.BackColor = Color.FromArgb(46, 72, 89);
            btnNo.Cursor = Cursors.Hand;
            btnNo.FlatAppearance.BorderColor = Color.FromArgb(152, 179, 194);
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnNo.ForeColor = Color.FromArgb(152, 179, 194);
            btnNo.Location = new Point(12, 177);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(95, 47);
            btnNo.TabIndex = 7;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            btnNo.MouseEnter += btnNo_MouseEnter;
            btnNo.MouseLeave += btnNo_MouseLeave;
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblSummary.ForeColor = Color.FromArgb(46, 72, 89);
            lblSummary.Location = new Point(12, 9);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(401, 51);
            lblSummary.TabIndex = 8;
            lblSummary.Text = "Summary";
            lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.BackColor = Color.FromArgb(46, 72, 89);
            lblDescription.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.ForeColor = Color.FromArgb(250, 236, 207);
            lblDescription.Location = new Point(12, 60);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(401, 114);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(425, 234);
            ControlBox = false;
            Controls.Add(lblDescription);
            Controls.Add(lblSummary);
            Controls.Add(btnNo);
            Controls.Add(btnYesOk);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CustomMessageBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomMessageBox";
            ResumeLayout(false);
        }

        #endregion

        private Button btnYesOk;
        private Button btnNo;
        private Label lblSummary;
        private Label lblDescription;
    }
}