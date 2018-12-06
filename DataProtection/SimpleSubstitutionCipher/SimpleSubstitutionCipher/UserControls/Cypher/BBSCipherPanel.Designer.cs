namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    partial class BBSCipherPanel
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
            this.generateBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pNud = new System.Windows.Forms.NumericUpDown();
            this.qNud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.xNud = new System.Windows.Forms.NumericUpDown();
            this.scaleTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNud)).BeginInit();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.label3, 0, 2);
            this.scaleTbl.Controls.Add(this.label1, 0, 1);
            this.scaleTbl.Controls.Add(this.label2, 0, 0);
            this.scaleTbl.Controls.Add(this.okBtn, 1, 3);
            this.scaleTbl.Controls.Add(this.generateBtn, 0, 3);
            this.scaleTbl.Controls.Add(this.pNud, 1, 0);
            this.scaleTbl.Controls.Add(this.qNud, 1, 1);
            this.scaleTbl.Controls.Add(this.xNud, 1, 2);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 4;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.scaleTbl.Size = new System.Drawing.Size(256, 114);
            this.scaleTbl.TabIndex = 0;
            // 
            // generateBtn
            // 
            this.generateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.generateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.generateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateBtn.Location = new System.Drawing.Point(3, 87);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(122, 24);
            this.generateBtn.TabIndex = 5;
            this.generateBtn.Text = "Згенерувати";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.okBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(131, 87);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(122, 24);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Підтвердити";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "p";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "q";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pNud
            // 
            this.pNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pNud.Location = new System.Drawing.Point(131, 3);
            this.pNud.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.pNud.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pNud.Name = "pNud";
            this.pNud.Size = new System.Drawing.Size(122, 20);
            this.pNud.TabIndex = 9;
            this.pNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // qNud
            // 
            this.qNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qNud.Location = new System.Drawing.Point(131, 31);
            this.qNud.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.qNud.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.qNud.Name = "qNud";
            this.qNud.Size = new System.Drawing.Size(122, 20);
            this.qNud.TabIndex = 10;
            this.qNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xNud
            // 
            this.xNud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xNud.Location = new System.Drawing.Point(131, 59);
            this.xNud.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.xNud.Name = "xNud";
            this.xNud.Size = new System.Drawing.Size(122, 20);
            this.xNud.TabIndex = 12;
            this.xNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BBSCipherPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "BBSCipherPanel";
            this.Size = new System.Drawing.Size(256, 114);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pNud;
        private System.Windows.Forms.NumericUpDown qNud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown xNud;
    }
}
