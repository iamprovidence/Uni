namespace FunWithData.UserControls
{
    partial class NumberControl
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
            this.minLbl = new System.Windows.Forms.Label();
            this.maxLbl = new System.Windows.Forms.Label();
            this.minNud = new System.Windows.Forms.NumericUpDown();
            this.maxNud = new System.Windows.Forms.NumericUpDown();
            this.scaleTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNud)).BeginInit();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.minLbl, 0, 0);
            this.scaleTbl.Controls.Add(this.maxLbl, 0, 1);
            this.scaleTbl.Controls.Add(this.minNud, 1, 0);
            this.scaleTbl.Controls.Add(this.maxNud, 1, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Size = new System.Drawing.Size(150, 56);
            this.scaleTbl.TabIndex = 0;
            // 
            // minLbl
            // 
            this.minLbl.AutoSize = true;
            this.minLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minLbl.Location = new System.Drawing.Point(3, 0);
            this.minLbl.Name = "minLbl";
            this.minLbl.Size = new System.Drawing.Size(69, 28);
            this.minLbl.TabIndex = 0;
            this.minLbl.Text = "min";
            this.minLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxLbl
            // 
            this.maxLbl.AutoSize = true;
            this.maxLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxLbl.Location = new System.Drawing.Point(3, 28);
            this.maxLbl.Name = "maxLbl";
            this.maxLbl.Size = new System.Drawing.Size(69, 28);
            this.maxLbl.TabIndex = 1;
            this.maxLbl.Text = "max";
            this.maxLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minNud
            // 
            this.minNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minNud.Location = new System.Drawing.Point(78, 3);
            this.minNud.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minNud.Name = "minNud";
            this.minNud.Size = new System.Drawing.Size(69, 20);
            this.minNud.TabIndex = 2;
            this.minNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // maxNud
            // 
            this.maxNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxNud.Location = new System.Drawing.Point(78, 31);
            this.maxNud.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxNud.Name = "maxNud";
            this.maxNud.Size = new System.Drawing.Size(69, 20);
            this.maxNud.TabIndex = 3;
            this.maxNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NumberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleTbl);
            this.Name = "NumberControl";
            this.Size = new System.Drawing.Size(150, 56);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.Label minLbl;
        private System.Windows.Forms.Label maxLbl;
        private System.Windows.Forms.NumericUpDown minNud;
        private System.Windows.Forms.NumericUpDown maxNud;
    }
}
