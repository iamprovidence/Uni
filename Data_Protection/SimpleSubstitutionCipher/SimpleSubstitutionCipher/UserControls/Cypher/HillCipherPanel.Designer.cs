namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    partial class HillCipherPanel
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
            this.okBtn = new System.Windows.Forms.Button();
            this.generateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keyLengthTb = new System.Windows.Forms.TextBox();
            this.keyTb = new System.Windows.Forms.TextBox();
            this.scaleTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.okBtn, 1, 2);
            this.scaleTbl.Controls.Add(this.generateBtn, 0, 2);
            this.scaleTbl.Controls.Add(this.label1, 0, 0);
            this.scaleTbl.Controls.Add(this.label2, 0, 1);
            this.scaleTbl.Controls.Add(this.keyLengthTb, 1, 0);
            this.scaleTbl.Controls.Add(this.keyTb, 1, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 3;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.Size = new System.Drawing.Size(246, 112);
            this.scaleTbl.TabIndex = 0;
            // 
            // okBtn
            // 
            this.okBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.okBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(126, 77);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(117, 32);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Підтвердити";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // generateBtn
            // 
            this.generateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.generateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.generateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateBtn.Location = new System.Drawing.Point(3, 77);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(117, 32);
            this.generateBtn.TabIndex = 5;
            this.generateBtn.Text = "Згенерувати";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "довжина ключа";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "ключ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyLengthTb
            // 
            this.keyLengthTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyLengthTb.Location = new System.Drawing.Point(126, 3);
            this.keyLengthTb.Multiline = true;
            this.keyLengthTb.Name = "keyLengthTb";
            this.keyLengthTb.Size = new System.Drawing.Size(117, 31);
            this.keyLengthTb.TabIndex = 9;
            // 
            // keyTb
            // 
            this.keyTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyTb.Location = new System.Drawing.Point(126, 40);
            this.keyTb.Multiline = true;
            this.keyTb.Name = "keyTb";
            this.keyTb.Size = new System.Drawing.Size(117, 31);
            this.keyTb.TabIndex = 10;
            // 
            // HillCipherPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "HillCipherPanel";
            this.Size = new System.Drawing.Size(246, 112);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyLengthTb;
        private System.Windows.Forms.TextBox keyTb;
    }
}
