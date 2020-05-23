namespace Task1
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
            this.label1 = new System.Windows.Forms.Label();
            this.imageNameTb = new System.Windows.Forms.TextBox();
            this.loadImgBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.originalImg = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.formattersCb = new System.Windows.Forms.ComboBox();
            this.formatImgBtn = new System.Windows.Forms.Button();
            this.writingTimeLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.readingTimeLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decodingTimeLbl = new System.Windows.Forms.Label();
            this.encodingTimeLbl = new System.Windows.Forms.Label();
            this.formattedImage = new System.Windows.Forms.PictureBox();
            this.originalImgSizeLbl = new System.Windows.Forms.Label();
            this.formattedImgSizeLbl = new System.Windows.Forms.Label();
            this.colorDifferenceImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.colorDifferencesCb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rDiffLbl = new System.Windows.Forms.Label();
            this.gDiffLbl = new System.Windows.Forms.Label();
            this.bDiffLbl = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImg)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formattedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorDifferenceImage)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.imageNameTb, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.loadImgBtn, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1184, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Зображення";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageNameTb
            // 
            this.imageNameTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageNameTb.Location = new System.Drawing.Point(229, 5);
            this.imageNameTb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageNameTb.Multiline = true;
            this.imageNameTb.Name = "imageNameTb";
            this.imageNameTb.ReadOnly = true;
            this.imageNameTb.Size = new System.Drawing.Size(726, 30);
            this.imageNameTb.TabIndex = 1;
            // 
            // loadImgBtn
            // 
            this.loadImgBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadImgBtn.Location = new System.Drawing.Point(963, 5);
            this.loadImgBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadImgBtn.Name = "loadImgBtn";
            this.loadImgBtn.Size = new System.Drawing.Size(217, 30);
            this.loadImgBtn.TabIndex = 2;
            this.loadImgBtn.Text = "Вибрати файл";
            this.loadImgBtn.UseVisualStyleBackColor = true;
            this.loadImgBtn.Click += new System.EventHandler(this.loadImgBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.44481F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.44482F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.11037F));
            this.tableLayoutPanel3.Controls.Add(this.originalImg, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.formattedImage, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.originalImgSizeLbl, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.formattedImgSizeLbl, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.colorDifferenceImage, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1178, 415);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // originalImg
            // 
            this.originalImg.BackColor = System.Drawing.Color.Gray;
            this.originalImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImg.Location = new System.Drawing.Point(3, 3);
            this.originalImg.Name = "originalImg";
            this.originalImg.Size = new System.Drawing.Size(287, 379);
            this.originalImg.TabIndex = 0;
            this.originalImg.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.formattersCb, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.formatImgBtn, 0, 9);
            this.tableLayoutPanel4.Controls.Add(this.writingTimeLbl, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.readingTimeLbl, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.decodingTimeLbl, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.encodingTimeLbl, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(296, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(144, 379);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // formattersCb
            // 
            this.formattersCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formattersCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formattersCb.FormattingEnabled = true;
            this.formattersCb.Location = new System.Drawing.Point(3, 3);
            this.formattersCb.Name = "formattersCb";
            this.formattersCb.Size = new System.Drawing.Size(138, 28);
            this.formattersCb.TabIndex = 0;
            // 
            // formatImgBtn
            // 
            this.formatImgBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatImgBtn.Location = new System.Drawing.Point(3, 336);
            this.formatImgBtn.Name = "formatImgBtn";
            this.formatImgBtn.Size = new System.Drawing.Size(138, 40);
            this.formatImgBtn.TabIndex = 1;
            this.formatImgBtn.Text = "Зберегти";
            this.formatImgBtn.UseVisualStyleBackColor = true;
            this.formatImgBtn.Click += new System.EventHandler(this.formatImgBtn_Click);
            // 
            // writingTimeLbl
            // 
            this.writingTimeLbl.AutoSize = true;
            this.writingTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writingTimeLbl.Location = new System.Drawing.Point(3, 148);
            this.writingTimeLbl.Name = "writingTimeLbl";
            this.writingTimeLbl.Size = new System.Drawing.Size(138, 37);
            this.writingTimeLbl.TabIndex = 2;
            this.writingTimeLbl.Text = "0 ms";
            this.writingTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 37);
            this.label5.TabIndex = 6;
            this.label5.Text = "Запис";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Читання";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // readingTimeLbl
            // 
            this.readingTimeLbl.AutoSize = true;
            this.readingTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readingTimeLbl.Location = new System.Drawing.Point(3, 222);
            this.readingTimeLbl.Name = "readingTimeLbl";
            this.readingTimeLbl.Size = new System.Drawing.Size(138, 37);
            this.readingTimeLbl.TabIndex = 7;
            this.readingTimeLbl.Text = "0 ms";
            this.readingTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Декодування";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кодування";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decodingTimeLbl
            // 
            this.decodingTimeLbl.AutoSize = true;
            this.decodingTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decodingTimeLbl.Location = new System.Drawing.Point(3, 296);
            this.decodingTimeLbl.Name = "decodingTimeLbl";
            this.decodingTimeLbl.Size = new System.Drawing.Size(138, 37);
            this.decodingTimeLbl.TabIndex = 8;
            this.decodingTimeLbl.Text = "0 ms";
            this.decodingTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // encodingTimeLbl
            // 
            this.encodingTimeLbl.AutoSize = true;
            this.encodingTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encodingTimeLbl.Location = new System.Drawing.Point(3, 74);
            this.encodingTimeLbl.Name = "encodingTimeLbl";
            this.encodingTimeLbl.Size = new System.Drawing.Size(138, 37);
            this.encodingTimeLbl.TabIndex = 9;
            this.encodingTimeLbl.Text = "0 ms";
            this.encodingTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formattedImage
            // 
            this.formattedImage.BackColor = System.Drawing.Color.Gray;
            this.formattedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formattedImage.Location = new System.Drawing.Point(446, 3);
            this.formattedImage.Name = "formattedImage";
            this.formattedImage.Size = new System.Drawing.Size(287, 379);
            this.formattedImage.TabIndex = 2;
            this.formattedImage.TabStop = false;
            // 
            // originalImgSizeLbl
            // 
            this.originalImgSizeLbl.AutoSize = true;
            this.originalImgSizeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImgSizeLbl.Location = new System.Drawing.Point(3, 385);
            this.originalImgSizeLbl.Name = "originalImgSizeLbl";
            this.originalImgSizeLbl.Size = new System.Drawing.Size(287, 30);
            this.originalImgSizeLbl.TabIndex = 3;
            this.originalImgSizeLbl.Text = "Original Img Size";
            this.originalImgSizeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formattedImgSizeLbl
            // 
            this.formattedImgSizeLbl.AutoSize = true;
            this.formattedImgSizeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formattedImgSizeLbl.Location = new System.Drawing.Point(446, 385);
            this.formattedImgSizeLbl.Name = "formattedImgSizeLbl";
            this.formattedImgSizeLbl.Size = new System.Drawing.Size(287, 30);
            this.formattedImgSizeLbl.TabIndex = 4;
            this.formattedImgSizeLbl.Text = "Formatted Img Size";
            this.formattedImgSizeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorDifferenceImage
            // 
            this.colorDifferenceImage.BackColor = System.Drawing.Color.Gray;
            this.colorDifferenceImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorDifferenceImage.Location = new System.Drawing.Point(889, 3);
            this.colorDifferenceImage.Name = "colorDifferenceImage";
            this.colorDifferenceImage.Size = new System.Drawing.Size(286, 379);
            this.colorDifferenceImage.TabIndex = 5;
            this.colorDifferenceImage.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.colorDifferencesCb, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.rDiffLbl, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.gDiffLbl, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.bDiffLbl, 0, 6);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(739, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(144, 379);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // colorDifferencesCb
            // 
            this.colorDifferencesCb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorDifferencesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorDifferencesCb.FormattingEnabled = true;
            this.colorDifferencesCb.Location = new System.Drawing.Point(3, 3);
            this.colorDifferencesCb.Name = "colorDifferencesCb";
            this.colorDifferencesCb.Size = new System.Drawing.Size(138, 28);
            this.colorDifferencesCb.TabIndex = 0;
            this.colorDifferencesCb.SelectedIndexChanged += new System.EventHandler(this.colorDifferencesCb_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 54);
            this.label6.TabIndex = 1;
            this.label6.Text = "R";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 54);
            this.label7.TabIndex = 2;
            this.label7.Text = "G";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 54);
            this.label8.TabIndex = 3;
            this.label8.Text = "B";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rDiffLbl
            // 
            this.rDiffLbl.AutoSize = true;
            this.rDiffLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rDiffLbl.Location = new System.Drawing.Point(3, 108);
            this.rDiffLbl.Name = "rDiffLbl";
            this.rDiffLbl.Size = new System.Drawing.Size(138, 54);
            this.rDiffLbl.TabIndex = 4;
            this.rDiffLbl.Text = "0";
            this.rDiffLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gDiffLbl
            // 
            this.gDiffLbl.AutoSize = true;
            this.gDiffLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gDiffLbl.Location = new System.Drawing.Point(3, 216);
            this.gDiffLbl.Name = "gDiffLbl";
            this.gDiffLbl.Size = new System.Drawing.Size(138, 54);
            this.gDiffLbl.TabIndex = 5;
            this.gDiffLbl.Text = "0";
            this.gDiffLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bDiffLbl
            // 
            this.bDiffLbl.AutoSize = true;
            this.bDiffLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bDiffLbl.Location = new System.Drawing.Point(3, 324);
            this.bDiffLbl.Name = "bDiffLbl";
            this.bDiffLbl.Size = new System.Drawing.Size(138, 55);
            this.bDiffLbl.TabIndex = 6;
            this.bDiffLbl.Text = "0";
            this.bDiffLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Image file";
            this.openFileDialog.Filter = "BMP file *.bmp | *.bmp";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1200, 500);
            this.MinimumSize = new System.Drawing.Size(1200, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task 1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImg)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formattedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorDifferenceImage)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imageNameTb;
        private System.Windows.Forms.Button loadImgBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox originalImg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox formattersCb;
        private System.Windows.Forms.Button formatImgBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox formattedImage;
        private System.Windows.Forms.Label writingTimeLbl;
        private System.Windows.Forms.Label originalImgSizeLbl;
        private System.Windows.Forms.Label formattedImgSizeLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label readingTimeLbl;
        private System.Windows.Forms.Label decodingTimeLbl;
        private System.Windows.Forms.Label encodingTimeLbl;
        private System.Windows.Forms.PictureBox colorDifferenceImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox colorDifferencesCb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label rDiffLbl;
        private System.Windows.Forms.Label gDiffLbl;
        private System.Windows.Forms.Label bDiffLbl;
    }
}

