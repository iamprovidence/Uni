namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    partial class AffineCipherPanel
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
            this.aTb = new System.Windows.Forms.TextBox();
            this.bTb = new System.Windows.Forms.TextBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.scaleTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.label1, 0, 0);
            this.scaleTbl.Controls.Add(this.label2, 0, 1);
            this.scaleTbl.Controls.Add(this.aTb, 1, 0);
            this.scaleTbl.Controls.Add(this.bTb, 1, 1);
            this.scaleTbl.Controls.Add(this.generateBtn, 0, 2);
            this.scaleTbl.Controls.Add(this.okBtn, 1, 2);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 3;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.Size = new System.Drawing.Size(246, 102);
            this.scaleTbl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "a";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "b";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aTb
            // 
            this.aTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aTb.Location = new System.Drawing.Point(126, 3);
            this.aTb.Name = "aTb";
            this.aTb.Size = new System.Drawing.Size(117, 20);
            this.aTb.TabIndex = 2;
            this.aTb.Text = "1";
            this.aTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bTb
            // 
            this.bTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bTb.Location = new System.Drawing.Point(126, 37);
            this.bTb.Name = "bTb";
            this.bTb.Size = new System.Drawing.Size(117, 20);
            this.bTb.TabIndex = 3;
            this.bTb.Text = "1";
            this.bTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // generateBtn
            // 
            this.generateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.generateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.generateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateBtn.Location = new System.Drawing.Point(3, 71);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(117, 28);
            this.generateBtn.TabIndex = 4;
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
            this.okBtn.Location = new System.Drawing.Point(126, 71);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(117, 28);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "Підтвердити";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // AffineCipherPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "AffineCipherPanel";
            this.Size = new System.Drawing.Size(246, 102);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox aTb;
        private System.Windows.Forms.TextBox bTb;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button okBtn;
    }
}
