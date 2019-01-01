namespace FunWithData
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
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.menuTbl = new System.Windows.Forms.TableLayoutPanel();
            this.dataDgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortBtn = new System.Windows.Forms.Button();
            this.filterBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.sortOptionCb = new System.Windows.Forms.ComboBox();
            this.filterOptionCb = new System.Windows.Forms.ComboBox();
            this.filterPnl = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.countLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.findFirstBtn = new System.Windows.Forms.Button();
            this.scaleTbl.SuspendLayout();
            this.menuTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDgv)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 1;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Controls.Add(this.menuTbl, 0, 0);
            this.scaleTbl.Controls.Add(this.dataDgv, 0, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Size = new System.Drawing.Size(784, 461);
            this.scaleTbl.TabIndex = 0;
            // 
            // menuTbl
            // 
            this.menuTbl.ColumnCount = 7;
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.menuTbl.Controls.Add(this.sortBtn, 0, 0);
            this.menuTbl.Controls.Add(this.filterBtn, 2, 0);
            this.menuTbl.Controls.Add(this.resetBtn, 5, 0);
            this.menuTbl.Controls.Add(this.sortOptionCb, 1, 0);
            this.menuTbl.Controls.Add(this.filterOptionCb, 3, 0);
            this.menuTbl.Controls.Add(this.filterPnl, 4, 0);
            this.menuTbl.Controls.Add(this.findFirstBtn, 6, 0);
            this.menuTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTbl.Location = new System.Drawing.Point(0, 0);
            this.menuTbl.Margin = new System.Windows.Forms.Padding(0);
            this.menuTbl.Name = "menuTbl";
            this.menuTbl.RowCount = 1;
            this.menuTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTbl.Size = new System.Drawing.Size(784, 47);
            this.menuTbl.TabIndex = 0;
            // 
            // dataDgv
            // 
            this.dataDgv.AllowUserToAddRows = false;
            this.dataDgv.AllowUserToDeleteRows = false;
            this.dataDgv.AllowUserToResizeColumns = false;
            this.dataDgv.AllowUserToResizeRows = false;
            this.dataDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataDgv.Location = new System.Drawing.Point(3, 50);
            this.dataDgv.Name = "dataDgv";
            this.dataDgv.ReadOnly = true;
            this.dataDgv.RowHeadersVisible = false;
            this.dataDgv.Size = new System.Drawing.Size(778, 408);
            this.dataDgv.TabIndex = 1;
            this.dataDgv.VirtualMode = true;
            this.dataDgv.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataDgv_CellValueNeeded);
            this.dataDgv.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataDgv_CellValuePushed);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Surname";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Age";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // sortBtn
            // 
            this.sortBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortBtn.Location = new System.Drawing.Point(3, 3);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(105, 41);
            this.sortBtn.TabIndex = 0;
            this.sortBtn.Text = "sort by";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // filterBtn
            // 
            this.filterBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterBtn.Location = new System.Drawing.Point(225, 3);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(105, 41);
            this.filterBtn.TabIndex = 1;
            this.filterBtn.Text = "filter by";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetBtn.Location = new System.Drawing.Point(558, 3);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(105, 41);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // sortOptionCb
            // 
            this.sortOptionCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortOptionCb.FormattingEnabled = true;
            this.sortOptionCb.Items.AddRange(new object[] {
            "Id",
            "Name",
            "Surname",
            "Age"});
            this.sortOptionCb.Location = new System.Drawing.Point(114, 3);
            this.sortOptionCb.Name = "sortOptionCb";
            this.sortOptionCb.Size = new System.Drawing.Size(105, 21);
            this.sortOptionCb.TabIndex = 3;
            // 
            // filterOptionCb
            // 
            this.filterOptionCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterOptionCb.FormattingEnabled = true;
            this.filterOptionCb.Items.AddRange(new object[] {
            "Id",
            "Name",
            "Surname",
            "Age"});
            this.filterOptionCb.Location = new System.Drawing.Point(336, 3);
            this.filterOptionCb.Name = "filterOptionCb";
            this.filterOptionCb.Size = new System.Drawing.Size(105, 21);
            this.filterOptionCb.TabIndex = 4;
            this.filterOptionCb.SelectedIndexChanged += new System.EventHandler(this.filterOptionCb_SelectedIndexChanged);
            // 
            // filterPnl
            // 
            this.filterPnl.Location = new System.Drawing.Point(447, 3);
            this.filterPnl.Name = "filterPnl";
            this.filterPnl.Size = new System.Drawing.Size(105, 41);
            this.filterPnl.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.countLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel1.Text = "Count";
            // 
            // countLbl
            // 
            this.countLbl.Name = "countLbl";
            this.countLbl.Size = new System.Drawing.Size(13, 17);
            this.countLbl.Text = "0";
            // 
            // findFirstBtn
            // 
            this.findFirstBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findFirstBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findFirstBtn.Location = new System.Drawing.Point(669, 3);
            this.findFirstBtn.Name = "findFirstBtn";
            this.findFirstBtn.Size = new System.Drawing.Size(112, 41);
            this.findFirstBtn.TabIndex = 6;
            this.findFirstBtn.Text = "Find first \r\nby name";
            this.findFirstBtn.UseVisualStyleBackColor = true;
            this.findFirstBtn.Click += new System.EventHandler(this.findFirstBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.scaleTbl);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fun With Data";
            this.scaleTbl.ResumeLayout(false);
            this.menuTbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataDgv)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.TableLayoutPanel menuTbl;
        private System.Windows.Forms.DataGridView dataDgv;
        private System.Windows.Forms.Button sortBtn;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ComboBox sortOptionCb;
        private System.Windows.Forms.ComboBox filterOptionCb;
        private System.Windows.Forms.Panel filterPnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel countLbl;
        private System.Windows.Forms.Button findFirstBtn;
    }
}

