namespace Statistics.Controls
{
    partial class DataBox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataTb = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RepresentationGb = new System.Windows.Forms.GroupBox();
            this.tableRb = new System.Windows.Forms.RadioButton();
            this.rowRb = new System.Windows.Forms.RadioButton();
            this.TypeGb = new System.Windows.Forms.GroupBox();
            this.continuousRb = new System.Windows.Forms.RadioButton();
            this.discreteRb = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.executeData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.RepresentationGb.SuspendLayout();
            this.TypeGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.dataTb, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 148);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataTb
            // 
            this.dataTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTb.Location = new System.Drawing.Point(3, 3);
            this.dataTb.Name = "dataTb";
            this.dataTb.Size = new System.Drawing.Size(324, 142);
            this.dataTb.TabIndex = 0;
            this.dataTb.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.executeData, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(330, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(221, 148);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.RepresentationGb, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TypeGb, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(221, 78);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // RepresentationGb
            // 
            this.RepresentationGb.Controls.Add(this.tableRb);
            this.RepresentationGb.Controls.Add(this.rowRb);
            this.RepresentationGb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RepresentationGb.Location = new System.Drawing.Point(3, 3);
            this.RepresentationGb.Name = "RepresentationGb";
            this.RepresentationGb.Size = new System.Drawing.Size(104, 72);
            this.RepresentationGb.TabIndex = 0;
            this.RepresentationGb.TabStop = false;
            this.RepresentationGb.Text = "Представлення";
            // 
            // tableRb
            // 
            this.tableRb.AutoSize = true;
            this.tableRb.Location = new System.Drawing.Point(6, 43);
            this.tableRb.Name = "tableRb";
            this.tableRb.Size = new System.Drawing.Size(66, 17);
            this.tableRb.TabIndex = 1;
            this.tableRb.TabStop = true;
            this.tableRb.Text = "таблиця";
            this.tableRb.UseVisualStyleBackColor = true;
            // 
            // rowRb
            // 
            this.rowRb.AutoSize = true;
            this.rowRb.Checked = true;
            this.rowRb.Location = new System.Drawing.Point(6, 19);
            this.rowRb.Name = "rowRb";
            this.rowRb.Size = new System.Drawing.Size(43, 17);
            this.rowRb.TabIndex = 0;
            this.rowRb.TabStop = true;
            this.rowRb.Text = "ряд";
            this.rowRb.UseVisualStyleBackColor = true;
            // 
            // TypeGb
            // 
            this.TypeGb.Controls.Add(this.continuousRb);
            this.TypeGb.Controls.Add(this.discreteRb);
            this.TypeGb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeGb.Location = new System.Drawing.Point(113, 3);
            this.TypeGb.Name = "TypeGb";
            this.TypeGb.Size = new System.Drawing.Size(105, 72);
            this.TypeGb.TabIndex = 1;
            this.TypeGb.TabStop = false;
            this.TypeGb.Text = "Тип";
            // 
            // continuousRb
            // 
            this.continuousRb.AutoSize = true;
            this.continuousRb.Location = new System.Drawing.Point(7, 43);
            this.continuousRb.Name = "continuousRb";
            this.continuousRb.Size = new System.Drawing.Size(91, 17);
            this.continuousRb.TabIndex = 1;
            this.continuousRb.TabStop = true;
            this.continuousRb.Text = "неперервний";
            this.continuousRb.UseVisualStyleBackColor = true;
            // 
            // discreteRb
            // 
            this.discreteRb.AutoSize = true;
            this.discreteRb.Checked = true;
            this.discreteRb.Location = new System.Drawing.Point(7, 20);
            this.discreteRb.Name = "discreteRb";
            this.discreteRb.Size = new System.Drawing.Size(84, 17);
            this.discreteRb.TabIndex = 0;
            this.discreteRb.TabStop = true;
            this.discreteRb.Text = "дискретний";
            this.discreteRb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дані";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // executeData
            // 
            this.executeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executeData.Location = new System.Drawing.Point(3, 116);
            this.executeData.Name = "executeData";
            this.executeData.Size = new System.Drawing.Size(215, 29);
            this.executeData.TabIndex = 2;
            this.executeData.Text = "Опрацювати";
            this.executeData.UseVisualStyleBackColor = true;
            this.executeData.Click += new System.EventHandler(this.executeData_Click);
            // 
            // DataBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DataBox";
            this.Size = new System.Drawing.Size(551, 148);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.RepresentationGb.ResumeLayout(false);
            this.RepresentationGb.PerformLayout();
            this.TypeGb.ResumeLayout(false);
            this.TypeGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox dataTb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox RepresentationGb;
        private System.Windows.Forms.RadioButton tableRb;
        private System.Windows.Forms.RadioButton rowRb;
        private System.Windows.Forms.GroupBox TypeGb;
        private System.Windows.Forms.RadioButton continuousRb;
        private System.Windows.Forms.RadioButton discreteRb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button executeData;
    }
}
