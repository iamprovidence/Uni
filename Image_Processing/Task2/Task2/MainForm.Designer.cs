namespace Task2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.loadImgBtn = new System.Windows.Forms.Button();
            this.saveImgBtn = new System.Windows.Forms.Button();
            this.filtersCb = new System.Windows.Forms.ComboBox();
            this.imagePb = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.imagePb, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.loadImgBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.saveImgBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.filtersCb, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 511);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 50);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // loadImgBtn
            // 
            this.loadImgBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadImgBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadImgBtn.Location = new System.Drawing.Point(6, 6);
            this.loadImgBtn.Margin = new System.Windows.Forms.Padding(6);
            this.loadImgBtn.Name = "loadImgBtn";
            this.loadImgBtn.Size = new System.Drawing.Size(182, 38);
            this.loadImgBtn.TabIndex = 0;
            this.loadImgBtn.Text = "load";
            this.loadImgBtn.UseVisualStyleBackColor = true;
            this.loadImgBtn.Click += new System.EventHandler(this.loadImgBtn_Click);
            // 
            // saveImgBtn
            // 
            this.saveImgBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveImgBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveImgBtn.Location = new System.Drawing.Point(394, 6);
            this.saveImgBtn.Margin = new System.Windows.Forms.Padding(6);
            this.saveImgBtn.Name = "saveImgBtn";
            this.saveImgBtn.Size = new System.Drawing.Size(184, 38);
            this.saveImgBtn.TabIndex = 1;
            this.saveImgBtn.Text = "save";
            this.saveImgBtn.UseVisualStyleBackColor = true;
            this.saveImgBtn.Click += new System.EventHandler(this.saveImgBtn_Click);
            // 
            // filtersCb
            // 
            this.filtersCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersCb.DropDownHeight = 108;
            this.filtersCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filtersCb.FormattingEnabled = true;
            this.filtersCb.IntegralHeight = false;
            this.filtersCb.Location = new System.Drawing.Point(200, 6);
            this.filtersCb.Margin = new System.Windows.Forms.Padding(6);
            this.filtersCb.Name = "filtersCb";
            this.filtersCb.Size = new System.Drawing.Size(182, 32);
            this.filtersCb.TabIndex = 2;
            this.filtersCb.SelectedIndexChanged += new System.EventHandler(this.filtersCb_SelectedIndexChanged);
            // 
            // imagePb
            // 
            this.imagePb.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.imagePb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePb.Location = new System.Drawing.Point(3, 3);
            this.imagePb.Name = "imagePb";
            this.imagePb.Size = new System.Drawing.Size(578, 505);
            this.imagePb.TabIndex = 1;
            this.imagePb.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Image |*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task 2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button loadImgBtn;
        private System.Windows.Forms.Button saveImgBtn;
        private System.Windows.Forms.ComboBox filtersCb;
        private System.Windows.Forms.PictureBox imagePb;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

