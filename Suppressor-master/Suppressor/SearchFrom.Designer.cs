namespace Suppressor
{
    partial class SearchFrom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchFrom));
            txbTerm = new TextBox();
            dgResults = new DataGridView();
            btnExit = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgResults).BeginInit();
            SuspendLayout();
            // 
            // txbTerm
            // 
            txbTerm.BackColor = Color.White;
            txbTerm.ForeColor = Color.FromArgb(46, 72, 89);
            txbTerm.Location = new Point(12, 12);
            txbTerm.Name = "txbTerm";
            txbTerm.Size = new Size(575, 21);
            txbTerm.TabIndex = 3;
            txbTerm.TextChanged += txbTerm_TextChanged;
            txbTerm.Enter += txbTerm_Enter;
            txbTerm.Leave += txbTerm_Leave;
            // 
            // dgResults
            // 
            dgResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgResults.BackgroundColor = Color.White;
            dgResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 7F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgResults.DefaultCellStyle = dataGridViewCellStyle1;
            dgResults.Location = new Point(12, 39);
            dgResults.Name = "dgResults";
            dgResults.ReadOnly = true;
            dgResults.RowHeadersVisible = false;
            dgResults.RowTemplate.Height = 25;
            dgResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgResults.Size = new Size(678, 232);
            dgResults.TabIndex = 6;
            dgResults.CellClick += dgResults_CellClick;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(46, 72, 89);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.FromArgb(152, 179, 194);
            btnExit.Location = new Point(12, 277);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(93, 38);
            btnExit.TabIndex = 5;
            btnExit.Text = "Close";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(46, 72, 89);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.FromArgb(152, 179, 194);
            btnSearch.Location = new Point(599, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(93, 21);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += btnSearch_MouseEnter;
            btnSearch.MouseLeave += btnSearch_MouseLeave;
            // 
            // SearchFrom
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(250, 236, 207);
            ClientSize = new Size(704, 327);
            ControlBox = false;
            Controls.Add(btnSearch);
            Controls.Add(btnExit);
            Controls.Add(dgResults);
            Controls.Add(txbTerm);
            Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SearchFrom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search";
            Load += SearchFrom_Load;
            ((System.ComponentModel.ISupportInitialize)dgResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txbTerm;
        private DataGridView dgResults;
        private Button btnExit;
        private Button btnSearch;
    }
}