namespace FiniteElementMethod.View.UserControls
{
    partial class InputData
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.finiteElementChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inputTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.aNumeric = new System.Windows.Forms.NumericUpDown();
            this.cNumeric = new System.Windows.Forms.NumericUpDown();
            this.dNumeric = new System.Windows.Forms.NumericUpDown();
            this.bNumeric = new System.Windows.Forms.NumericUpDown();
            this.nNumeric = new System.Windows.Forms.NumericUpDown();
            this.mNumeric = new System.Windows.Forms.NumericUpDown();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finiteElementChart)).BeginInit();
            this.inputTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 1;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.scaleTbl.Controls.Add(this.inputTbl, 0, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Size = new System.Drawing.Size(602, 502);
            this.scaleTbl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.finiteElementChart, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 245);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(292, 40);
            this.label10.TabIndex = 3;
            this.label10.Text = "example";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::FiniteElementMethod.Properties.Resources.coordinate_system1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(301, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(292, 40);
            this.label9.TabIndex = 2;
            this.label9.Text = "current";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finiteElementChart
            // 
            chartArea1.Name = "ChartArea1";
            this.finiteElementChart.ChartAreas.Add(chartArea1);
            this.finiteElementChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finiteElementChart.Location = new System.Drawing.Point(301, 43);
            this.finiteElementChart.Name = "finiteElementChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.finiteElementChart.Series.Add(series1);
            this.finiteElementChart.Size = new System.Drawing.Size(292, 199);
            this.finiteElementChart.TabIndex = 4;
            this.finiteElementChart.Text = "chart3";
            // 
            // inputTbl
            // 
            this.inputTbl.ColumnCount = 5;
            this.inputTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.inputTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.inputTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.inputTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.inputTbl.Controls.Add(this.label1, 0, 0);
            this.inputTbl.Controls.Add(this.label2, 1, 1);
            this.inputTbl.Controls.Add(this.label3, 1, 2);
            this.inputTbl.Controls.Add(this.label4, 3, 1);
            this.inputTbl.Controls.Add(this.label5, 3, 2);
            this.inputTbl.Controls.Add(this.label6, 0, 3);
            this.inputTbl.Controls.Add(this.label7, 1, 4);
            this.inputTbl.Controls.Add(this.label8, 1, 5);
            this.inputTbl.Controls.Add(this.saveChangesBtn, 2, 6);
            this.inputTbl.Controls.Add(this.aNumeric, 2, 1);
            this.inputTbl.Controls.Add(this.cNumeric, 2, 2);
            this.inputTbl.Controls.Add(this.dNumeric, 4, 2);
            this.inputTbl.Controls.Add(this.bNumeric, 4, 1);
            this.inputTbl.Controls.Add(this.nNumeric, 3, 4);
            this.inputTbl.Controls.Add(this.mNumeric, 3, 5);
            this.inputTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTbl.Location = new System.Drawing.Point(3, 254);
            this.inputTbl.Name = "inputTbl";
            this.inputTbl.RowCount = 7;
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.inputTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.inputTbl.Size = new System.Drawing.Size(596, 245);
            this.inputTbl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sets coordinate values:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(301, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "a =";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(301, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "c =";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(449, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "b =";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(449, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "d =";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sets number of elements:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.inputTbl.SetColumnSpan(this.label7, 2);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(301, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 35);
            this.label7.TabIndex = 6;
            this.label7.Text = "n = ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.inputTbl.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(301, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 35);
            this.label8.TabIndex = 7;
            this.label8.Text = "m =";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveChangesBtn
            // 
            this.inputTbl.SetColumnSpan(this.saveChangesBtn, 3);
            this.saveChangesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveChangesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChangesBtn.Location = new System.Drawing.Point(375, 213);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(218, 29);
            this.saveChangesBtn.TabIndex = 9;
            this.saveChangesBtn.Text = "Save Changes";
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // aNumeric
            // 
            this.aNumeric.DecimalPlaces = 2;
            this.aNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aNumeric.Location = new System.Drawing.Point(375, 38);
            this.aNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.aNumeric.Name = "aNumeric";
            this.aNumeric.Size = new System.Drawing.Size(68, 26);
            this.aNumeric.TabIndex = 10;
            this.aNumeric.ThousandsSeparator = true;
            // 
            // cNumeric
            // 
            this.cNumeric.AutoSize = true;
            this.cNumeric.DecimalPlaces = 2;
            this.cNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cNumeric.Location = new System.Drawing.Point(375, 73);
            this.cNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.cNumeric.Name = "cNumeric";
            this.cNumeric.Size = new System.Drawing.Size(68, 26);
            this.cNumeric.TabIndex = 11;
            this.cNumeric.ThousandsSeparator = true;
            // 
            // dNumeric
            // 
            this.dNumeric.DecimalPlaces = 2;
            this.dNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.dNumeric.Location = new System.Drawing.Point(523, 73);
            this.dNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.dNumeric.Name = "dNumeric";
            this.dNumeric.Size = new System.Drawing.Size(70, 26);
            this.dNumeric.TabIndex = 12;
            this.dNumeric.ThousandsSeparator = true;
            this.dNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bNumeric
            // 
            this.bNumeric.DecimalPlaces = 2;
            this.bNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.bNumeric.Location = new System.Drawing.Point(523, 38);
            this.bNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bNumeric.Name = "bNumeric";
            this.bNumeric.Size = new System.Drawing.Size(70, 26);
            this.bNumeric.TabIndex = 13;
            this.bNumeric.ThousandsSeparator = true;
            this.bNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nNumeric
            // 
            this.inputTbl.SetColumnSpan(this.nNumeric, 2);
            this.nNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.nNumeric.Location = new System.Drawing.Point(449, 143);
            this.nNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nNumeric.Name = "nNumeric";
            this.nNumeric.Size = new System.Drawing.Size(144, 26);
            this.nNumeric.TabIndex = 14;
            this.nNumeric.ThousandsSeparator = true;
            this.nNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mNumeric
            // 
            this.inputTbl.SetColumnSpan(this.mNumeric, 2);
            this.mNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.mNumeric.Location = new System.Drawing.Point(449, 178);
            this.mNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mNumeric.Name = "mNumeric";
            this.mNumeric.Size = new System.Drawing.Size(144, 26);
            this.mNumeric.TabIndex = 15;
            this.mNumeric.ThousandsSeparator = true;
            this.mNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // InputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleTbl);
            this.Name = "InputData";
            this.Size = new System.Drawing.Size(602, 502);
            this.scaleTbl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finiteElementChart)).EndInit();
            this.inputTbl.ResumeLayout(false);
            this.inputTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel inputTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button saveChangesBtn;
        private System.Windows.Forms.NumericUpDown aNumeric;
        private System.Windows.Forms.NumericUpDown cNumeric;
        private System.Windows.Forms.NumericUpDown dNumeric;
        private System.Windows.Forms.NumericUpDown bNumeric;
        private System.Windows.Forms.NumericUpDown nNumeric;
        private System.Windows.Forms.NumericUpDown mNumeric;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart finiteElementChart;
    }
}
