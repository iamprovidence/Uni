namespace FiniteElementMethod.View.UserControls
{
    partial class Matrices
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.matrixTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.connectivityDgv = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.coordinateDgv = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.boundaryValueDgv = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matrixTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectivityDgv)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordinateDgv)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boundaryValueDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // matrixTabs
            // 
            this.matrixTabs.Controls.Add(this.tabPage1);
            this.matrixTabs.Controls.Add(this.tabPage2);
            this.matrixTabs.Controls.Add(this.tabPage3);
            this.matrixTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matrixTabs.ItemSize = new System.Drawing.Size(100, 25);
            this.matrixTabs.Location = new System.Drawing.Point(0, 0);
            this.matrixTabs.Name = "matrixTabs";
            this.matrixTabs.SelectedIndex = 0;
            this.matrixTabs.Size = new System.Drawing.Size(517, 492);
            this.matrixTabs.TabIndex = 0;
            this.matrixTabs.SelectedIndexChanged += new System.EventHandler(this.matrixTabs_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.connectivityDgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "connectivity";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // connectivityDgv
            // 
            this.connectivityDgv.AllowUserToAddRows = false;
            this.connectivityDgv.AllowUserToDeleteRows = false;
            this.connectivityDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.connectivityDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectivityDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.connectivityDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectivityDgv.Location = new System.Drawing.Point(3, 3);
            this.connectivityDgv.Name = "connectivityDgv";
            this.connectivityDgv.ReadOnly = true;
            this.connectivityDgv.RowHeadersVisible = false;
            this.connectivityDgv.Size = new System.Drawing.Size(503, 453);
            this.connectivityDgv.TabIndex = 0;
            this.connectivityDgv.VirtualMode = true;
            this.connectivityDgv.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.connectivityDgv_CellValueNeeded);
            // 
            // Column6
            // 
            this.Column6.FillWeight = 228.4264F;
            this.Column6.HeaderText = "Finite Element Index";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 83.9467F;
            this.Column7.HeaderText = "1";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 83.9467F;
            this.Column8.HeaderText = "2";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 83.9467F;
            this.Column9.HeaderText = "3";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 83.9467F;
            this.Column10.HeaderText = "4";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 83.9467F;
            this.Column11.HeaderText = "5";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 83.9467F;
            this.Column12.HeaderText = "6";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.FillWeight = 83.9467F;
            this.Column13.HeaderText = "7";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.FillWeight = 83.9467F;
            this.Column14.HeaderText = "8";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.coordinateDgv);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "coordinate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // coordinateDgv
            // 
            this.coordinateDgv.AllowUserToAddRows = false;
            this.coordinateDgv.AllowUserToDeleteRows = false;
            this.coordinateDgv.AllowUserToResizeColumns = false;
            this.coordinateDgv.AllowUserToResizeRows = false;
            this.coordinateDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.coordinateDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coordinateDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            this.coordinateDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordinateDgv.Location = new System.Drawing.Point(3, 3);
            this.coordinateDgv.Name = "coordinateDgv";
            this.coordinateDgv.ReadOnly = true;
            this.coordinateDgv.RowHeadersVisible = false;
            this.coordinateDgv.Size = new System.Drawing.Size(503, 453);
            this.coordinateDgv.TabIndex = 0;
            this.coordinateDgv.VirtualMode = true;
            this.coordinateDgv.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.coordinateDgv_CellValueNeeded);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Node Index";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "alpha1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "alpha 2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.boundaryValueDgv);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(509, 459);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "border nodes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // boundaryValueDgv
            // 
            this.boundaryValueDgv.AllowUserToAddRows = false;
            this.boundaryValueDgv.AllowUserToDeleteRows = false;
            this.boundaryValueDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.boundaryValueDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.boundaryValueDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5});
            this.boundaryValueDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boundaryValueDgv.Location = new System.Drawing.Point(3, 3);
            this.boundaryValueDgv.Name = "boundaryValueDgv";
            this.boundaryValueDgv.ReadOnly = true;
            this.boundaryValueDgv.RowHeadersVisible = false;
            this.boundaryValueDgv.Size = new System.Drawing.Size(503, 453);
            this.boundaryValueDgv.TabIndex = 0;
            this.boundaryValueDgv.VirtualMode = true;
            this.boundaryValueDgv.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.boundaryValueDgv_CellValueNeeded);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Node Index";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Boundary Value";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Matrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.matrixTabs);
            this.Name = "Matrices";
            this.Size = new System.Drawing.Size(517, 492);
            this.Load += new System.EventHandler(this.Matrices_Load);
            this.matrixTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectivityDgv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coordinateDgv)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boundaryValueDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl matrixTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView connectivityDgv;
        private System.Windows.Forms.DataGridView coordinateDgv;
        private System.Windows.Forms.DataGridView boundaryValueDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}
