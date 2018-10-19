namespace Statistics.Controls
{
    partial class PearsonsTestBox
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
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.probabilityTb = new System.Windows.Forms.TextBox();
            this.resLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.xeLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.xkrLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rLb = new System.Windows.Forms.Label();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 1;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Controls.Add(this.label1, 0, 0);
            this.scaleTbl.Controls.Add(this.resLbl, 0, 3);
            this.scaleTbl.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 4;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.36364F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.Size = new System.Drawing.Size(245, 128);
            this.scaleTbl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Критерій узгодженості Пірсона";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "α";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // probabilityTb
            // 
            this.probabilityTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.probabilityTb.Location = new System.Drawing.Point(64, 3);
            this.probabilityTb.Multiline = true;
            this.probabilityTb.Name = "probabilityTb";
            this.probabilityTb.Size = new System.Drawing.Size(55, 18);
            this.probabilityTb.TabIndex = 1;
            this.probabilityTb.Validated += new System.EventHandler(this.probabilityTb_TextChanged);
            // 
            // resLbl
            // 
            this.resLbl.AutoSize = true;
            this.resLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resLbl.Location = new System.Drawing.Point(3, 98);
            this.resLbl.Name = "resLbl";
            this.resLbl.Size = new System.Drawing.Size(239, 30);
            this.resLbl.TabIndex = 2;
            this.resLbl.Text = "Результат";
            this.resLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.probabilityTb, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.xeLbl, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.xkrLbl, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rLb, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(245, 48);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "X е";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xeLbl
            // 
            this.xeLbl.AutoSize = true;
            this.xeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xeLbl.Location = new System.Drawing.Point(64, 24);
            this.xeLbl.Name = "xeLbl";
            this.xeLbl.Size = new System.Drawing.Size(55, 24);
            this.xeLbl.TabIndex = 1;
            this.xeLbl.Text = "0";
            this.xeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(125, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "Х кр";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xkrLbl
            // 
            this.xkrLbl.AutoSize = true;
            this.xkrLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xkrLbl.Location = new System.Drawing.Point(186, 24);
            this.xkrLbl.Name = "xkrLbl";
            this.xkrLbl.Size = new System.Drawing.Size(56, 24);
            this.xkrLbl.TabIndex = 3;
            this.xkrLbl.Text = "0";
            this.xkrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(125, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "r";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rLb
            // 
            this.rLb.AutoSize = true;
            this.rLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rLb.Location = new System.Drawing.Point(186, 0);
            this.rLb.Name = "rLb";
            this.rLb.Size = new System.Drawing.Size(56, 24);
            this.rLb.TabIndex = 5;
            this.rLb.Text = "0";
            this.rLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PearsonsTestBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "PearsonsTestBox";
            this.Size = new System.Drawing.Size(245, 128);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox probabilityTb;
        private System.Windows.Forms.Label resLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label xeLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label xkrLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label rLb;
    }
}
