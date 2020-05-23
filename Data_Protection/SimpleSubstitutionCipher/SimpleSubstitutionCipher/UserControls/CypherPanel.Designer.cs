namespace SimpleSubstitutionCipher.UserControls
{
    partial class CypherPanel
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
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.readFileBtn = new System.Windows.Forms.Button();
            this.encodeBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.saveToFileBtn = new System.Windows.Forms.Button();
            this.decodeBtn = new System.Windows.Forms.Button();
            this.saveToFileBtn2 = new System.Windows.Forms.Button();
            this.textTb = new System.Windows.Forms.RichTextBox();
            this.encryptedTextTb = new System.Windows.Forms.RichTextBox();
            this.decodedTextTb = new System.Windows.Forms.RichTextBox();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 3;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.scaleTbl.Controls.Add(this.label1, 0, 0);
            this.scaleTbl.Controls.Add(this.label2, 1, 0);
            this.scaleTbl.Controls.Add(this.label3, 2, 0);
            this.scaleTbl.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.scaleTbl.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.scaleTbl.Controls.Add(this.saveToFileBtn2, 2, 2);
            this.scaleTbl.Controls.Add(this.textTb, 0, 1);
            this.scaleTbl.Controls.Add(this.encryptedTextTb, 1, 1);
            this.scaleTbl.Controls.Add(this.decodedTextTb, 2, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 3;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.scaleTbl.Size = new System.Drawing.Size(689, 329);
            this.scaleTbl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текст";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(229, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Зашифрований текст";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(458, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "Розшифрований текст";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.readFileBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.encodeBtn, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 279);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 50);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // readFileBtn
            // 
            this.readFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.readFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readFileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.readFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.readFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readFileBtn.Location = new System.Drawing.Point(0, 0);
            this.readFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.readFileBtn.Name = "readFileBtn";
            this.readFileBtn.Size = new System.Drawing.Size(114, 50);
            this.readFileBtn.TabIndex = 0;
            this.readFileBtn.Text = "Відкрити файл";
            this.readFileBtn.UseVisualStyleBackColor = true;
            this.readFileBtn.Click += new System.EventHandler(this.readFileBtn_Click);
            // 
            // encodeBtn
            // 
            this.encodeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.encodeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encodeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.encodeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.encodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.encodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encodeBtn.Location = new System.Drawing.Point(114, 0);
            this.encodeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(115, 50);
            this.encodeBtn.TabIndex = 1;
            this.encodeBtn.Text = "Зашифрувати";
            this.encodeBtn.UseVisualStyleBackColor = true;
            this.encodeBtn.Click += new System.EventHandler(this.encodeBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.saveToFileBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.decodeBtn, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(229, 279);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(229, 50);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // saveToFileBtn
            // 
            this.saveToFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveToFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveToFileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveToFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.saveToFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveToFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveToFileBtn.Location = new System.Drawing.Point(0, 0);
            this.saveToFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.saveToFileBtn.Name = "saveToFileBtn";
            this.saveToFileBtn.Size = new System.Drawing.Size(114, 50);
            this.saveToFileBtn.TabIndex = 0;
            this.saveToFileBtn.Text = "Зберегти у файл";
            this.saveToFileBtn.UseVisualStyleBackColor = true;
            this.saveToFileBtn.Click += new System.EventHandler(this.saveToFileBtn_Click);
            // 
            // decodeBtn
            // 
            this.decodeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decodeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decodeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.decodeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.decodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decodeBtn.Location = new System.Drawing.Point(114, 0);
            this.decodeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(115, 50);
            this.decodeBtn.TabIndex = 1;
            this.decodeBtn.Text = "Розшифрувати";
            this.decodeBtn.UseVisualStyleBackColor = true;
            this.decodeBtn.Click += new System.EventHandler(this.decodeBtn_Click);
            // 
            // saveToFileBtn2
            // 
            this.saveToFileBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveToFileBtn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveToFileBtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveToFileBtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.saveToFileBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveToFileBtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveToFileBtn2.Location = new System.Drawing.Point(458, 279);
            this.saveToFileBtn2.Margin = new System.Windows.Forms.Padding(0);
            this.saveToFileBtn2.Name = "saveToFileBtn2";
            this.saveToFileBtn2.Size = new System.Drawing.Size(231, 50);
            this.saveToFileBtn2.TabIndex = 8;
            this.saveToFileBtn2.Text = "Зберегти у файл";
            this.saveToFileBtn2.UseVisualStyleBackColor = true;
            this.saveToFileBtn2.Click += new System.EventHandler(this.saveToFileBtn2_Click);
            // 
            // textTb
            // 
            this.textTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTb.Location = new System.Drawing.Point(3, 53);
            this.textTb.Name = "textTb";
            this.textTb.Size = new System.Drawing.Size(223, 223);
            this.textTb.TabIndex = 9;
            this.textTb.Text = "";
            // 
            // encryptedTextTb
            // 
            this.encryptedTextTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encryptedTextTb.Location = new System.Drawing.Point(232, 53);
            this.encryptedTextTb.Name = "encryptedTextTb";
            this.encryptedTextTb.Size = new System.Drawing.Size(223, 223);
            this.encryptedTextTb.TabIndex = 10;
            this.encryptedTextTb.Text = "";
            // 
            // decodedTextTb
            // 
            this.decodedTextTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decodedTextTb.Location = new System.Drawing.Point(461, 53);
            this.decodedTextTb.Name = "decodedTextTb";
            this.decodedTextTb.Size = new System.Drawing.Size(225, 223);
            this.decodedTextTb.TabIndex = 11;
            this.decodedTextTb.Text = "";
            // 
            // CypherPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "CypherPanel";
            this.Size = new System.Drawing.Size(689, 329);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button readFileBtn;
        private System.Windows.Forms.Button encodeBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button saveToFileBtn;
        private System.Windows.Forms.Button decodeBtn;
        private System.Windows.Forms.Button saveToFileBtn2;
        private System.Windows.Forms.RichTextBox textTb;
        private System.Windows.Forms.RichTextBox encryptedTextTb;
        private System.Windows.Forms.RichTextBox decodedTextTb;
    }
}
