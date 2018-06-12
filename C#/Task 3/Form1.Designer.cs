namespace Task3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.name_Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer_Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Edit_Selected_butt = new System.Windows.Forms.Button();
            this.Add_New_butt = new System.Windows.Forms.Button();
            this.Opportunities_label = new System.Windows.Forms.Label();
            this.CalcStatButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Delete_butt = new System.Windows.Forms.Button();
            this.CancelStat_but = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.YellowGreen;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name_Column1,
            this.producer_Column2,
            this.price_Column3});
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView.Location = new System.Drawing.Point(13, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(354, 224);
            this.dataGridView.TabIndex = 1;
            // 
            // name_Column1
            // 
            this.name_Column1.HeaderText = "name";
            this.name_Column1.Name = "name_Column1";
            this.name_Column1.ReadOnly = true;
            // 
            // producer_Column2
            // 
            this.producer_Column2.HeaderText = "producer";
            this.producer_Column2.Name = "producer_Column2";
            this.producer_Column2.ReadOnly = true;
            // 
            // price_Column3
            // 
            this.price_Column3.HeaderText = "price";
            this.price_Column3.Name = "price_Column3";
            this.price_Column3.ReadOnly = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "CSV Files (*.csv) | *.csv";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV Files (*.csv) | *.csv|XML files (*.xml)|*.xml";
            // 
            // Edit_Selected_butt
            // 
            this.Edit_Selected_butt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Selected_butt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit_Selected_butt.Location = new System.Drawing.Point(395, 59);
            this.Edit_Selected_butt.Name = "Edit_Selected_butt";
            this.Edit_Selected_butt.Size = new System.Drawing.Size(147, 29);
            this.Edit_Selected_butt.TabIndex = 2;
            this.Edit_Selected_butt.Text = "Edit Selected";
            this.Edit_Selected_butt.UseVisualStyleBackColor = true;
            this.Edit_Selected_butt.Click += new System.EventHandler(this.Edit_Selected_butt_Click);
            // 
            // Add_New_butt
            // 
            this.Add_New_butt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_New_butt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_New_butt.Location = new System.Drawing.Point(395, 94);
            this.Add_New_butt.Name = "Add_New_butt";
            this.Add_New_butt.Size = new System.Drawing.Size(147, 31);
            this.Add_New_butt.TabIndex = 3;
            this.Add_New_butt.Text = "Add New";
            this.Add_New_butt.UseVisualStyleBackColor = true;
            this.Add_New_butt.Click += new System.EventHandler(this.Add_New_butt_Click);
            // 
            // Opportunities_label
            // 
            this.Opportunities_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Opportunities_label.AutoSize = true;
            this.Opportunities_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Opportunities_label.Location = new System.Drawing.Point(405, 28);
            this.Opportunities_label.Name = "Opportunities_label";
            this.Opportunities_label.Size = new System.Drawing.Size(128, 25);
            this.Opportunities_label.TabIndex = 4;
            this.Opportunities_label.Text = "Opportunities";
            // 
            // CalcStatButton
            // 
            this.CalcStatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CalcStatButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CalcStatButton.Location = new System.Drawing.Point(395, 168);
            this.CalcStatButton.Name = "CalcStatButton";
            this.CalcStatButton.Size = new System.Drawing.Size(147, 31);
            this.CalcStatButton.TabIndex = 3;
            this.CalcStatButton.Text = "Calculate Statistics";
            this.CalcStatButton.UseVisualStyleBackColor = true;
            this.CalcStatButton.Click += new System.EventHandler(this.Calc_Stat_butt_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(367, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(187, 23);
            this.progressBar.TabIndex = 5;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Delete_butt
            // 
            this.Delete_butt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_butt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_butt.Location = new System.Drawing.Point(395, 131);
            this.Delete_butt.Name = "Delete_butt";
            this.Delete_butt.Size = new System.Drawing.Size(147, 31);
            this.Delete_butt.TabIndex = 6;
            this.Delete_butt.Text = "Delete Selected";
            this.Delete_butt.UseVisualStyleBackColor = true;
            this.Delete_butt.Click += new System.EventHandler(this.Delete_butt_Click);
            // 
            // CancelStat_but
            // 
            this.CancelStat_but.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelStat_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelStat_but.Enabled = false;
            this.CancelStat_but.Location = new System.Drawing.Point(395, 205);
            this.CancelStat_but.Name = "CancelStat_but";
            this.CancelStat_but.Size = new System.Drawing.Size(147, 31);
            this.CancelStat_but.TabIndex = 7;
            this.CancelStat_but.Text = "Cancel";
            this.CancelStat_but.UseVisualStyleBackColor = true;
            this.CancelStat_but.Click += new System.EventHandler(this.Cancel_stat_butt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 262);
            this.Controls.Add(this.CancelStat_but);
            this.Controls.Add(this.Delete_butt);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Opportunities_label);
            this.Controls.Add(this.CalcStatButton);
            this.Controls.Add(this.Add_New_butt);
            this.Controls.Add(this.Edit_Selected_butt);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(570, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change your CSV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button Edit_Selected_butt;
        private System.Windows.Forms.Button Add_New_butt;
        private System.Windows.Forms.Label Opportunities_label;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer_Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_Column3;
        private System.Windows.Forms.Button CalcStatButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button Delete_butt;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button CancelStat_but;
    }
}

