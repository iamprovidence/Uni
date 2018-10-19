namespace Statistics.Forms
{
    partial class GenerateBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateBox));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.dataTabPabe = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataBtnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.aTb = new System.Windows.Forms.TextBox();
            this.bTb = new System.Windows.Forms.TextBox();
            this.sizeTb = new System.Windows.Forms.TextBox();
            this.tableTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataTableBtnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.a2Tb = new System.Windows.Forms.TextBox();
            this.b2Tb = new System.Windows.Forms.TextBox();
            this.frTb = new System.Windows.Forms.TextBox();
            this.gaussianTabPage = new System.Windows.Forms.TabPage();
            this.triangleTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.gaussianBtnSave = new System.Windows.Forms.Button();
            this.triangleBtnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.muTb = new System.Windows.Forms.TextBox();
            this.sigmaTb = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.a3Tb = new System.Windows.Forms.TextBox();
            this.b3Tb = new System.Windows.Forms.TextBox();
            this.c3Tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.size3Tb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.size2Tb = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.dataTabPabe.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.gaussianTabPage.SuspendLayout();
            this.triangleTabPage.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV file *.csv | *.csv";
            this.saveFileDialog.Title = "Generating";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.dataTabPabe);
            this.tabControl.Controls.Add(this.tableTabPage);
            this.tabControl.Controls.Add(this.gaussianTabPage);
            this.tabControl.Controls.Add(this.triangleTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(428, 176);
            this.tabControl.TabIndex = 0;
            // 
            // dataTabPabe
            // 
            this.dataTabPabe.Controls.Add(this.tableLayoutPanel1);
            this.dataTabPabe.Location = new System.Drawing.Point(4, 22);
            this.dataTabPabe.Name = "dataTabPabe";
            this.dataTabPabe.Padding = new System.Windows.Forms.Padding(3);
            this.dataTabPabe.Size = new System.Drawing.Size(420, 115);
            this.dataTabPabe.TabIndex = 0;
            this.dataTabPabe.Text = "Випадкові дані";
            this.dataTabPabe.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataBtnSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 109);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataBtnSave
            // 
            this.dataBtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBtnSave.Location = new System.Drawing.Point(3, 72);
            this.dataBtnSave.Name = "dataBtnSave";
            this.dataBtnSave.Size = new System.Drawing.Size(408, 34);
            this.dataBtnSave.TabIndex = 0;
            this.dataBtnSave.Text = "Зберегти";
            this.dataBtnSave.UseVisualStyleBackColor = true;
            this.dataBtnSave.Click += new System.EventHandler(this.dataBtnSave_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.aTb, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.bTb, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.sizeTb, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(414, 69);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "a";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "b";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "розмір";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aTb
            // 
            this.aTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aTb.Location = new System.Drawing.Point(210, 3);
            this.aTb.Multiline = true;
            this.aTb.Name = "aTb";
            this.aTb.Size = new System.Drawing.Size(201, 17);
            this.aTb.TabIndex = 3;
            // 
            // bTb
            // 
            this.bTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bTb.Location = new System.Drawing.Point(210, 26);
            this.bTb.Multiline = true;
            this.bTb.Name = "bTb";
            this.bTb.Size = new System.Drawing.Size(201, 17);
            this.bTb.TabIndex = 4;
            // 
            // sizeTb
            // 
            this.sizeTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeTb.Location = new System.Drawing.Point(210, 49);
            this.sizeTb.Multiline = true;
            this.sizeTb.Name = "sizeTb";
            this.sizeTb.Size = new System.Drawing.Size(201, 17);
            this.sizeTb.TabIndex = 5;
            // 
            // tableTabPage
            // 
            this.tableTabPage.Controls.Add(this.tableLayoutPanel2);
            this.tableTabPage.Location = new System.Drawing.Point(4, 22);
            this.tableTabPage.Name = "tableTabPage";
            this.tableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tableTabPage.Size = new System.Drawing.Size(420, 150);
            this.tableTabPage.TabIndex = 1;
            this.tableTabPage.Text = "Частотна таблиця";
            this.tableTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dataTableBtnSave, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(414, 144);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataTableBtnSave
            // 
            this.dataTableBtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableBtnSave.Location = new System.Drawing.Point(3, 72);
            this.dataTableBtnSave.Name = "dataTableBtnSave";
            this.dataTableBtnSave.Size = new System.Drawing.Size(408, 34);
            this.dataTableBtnSave.TabIndex = 0;
            this.dataTableBtnSave.Text = "Зберегти";
            this.dataTableBtnSave.UseVisualStyleBackColor = true;
            this.dataTableBtnSave.Click += new System.EventHandler(this.dataTableBtnSave_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.a2Tb, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.b2Tb, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.frTb, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(414, 69);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "a";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "b";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "максимальна частота появи";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // a2Tb
            // 
            this.a2Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a2Tb.Location = new System.Drawing.Point(210, 3);
            this.a2Tb.Multiline = true;
            this.a2Tb.Name = "a2Tb";
            this.a2Tb.Size = new System.Drawing.Size(201, 17);
            this.a2Tb.TabIndex = 3;
            // 
            // b2Tb
            // 
            this.b2Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.b2Tb.Location = new System.Drawing.Point(210, 26);
            this.b2Tb.Multiline = true;
            this.b2Tb.Name = "b2Tb";
            this.b2Tb.Size = new System.Drawing.Size(201, 17);
            this.b2Tb.TabIndex = 4;
            // 
            // frTb
            // 
            this.frTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frTb.Location = new System.Drawing.Point(210, 49);
            this.frTb.Multiline = true;
            this.frTb.Name = "frTb";
            this.frTb.Size = new System.Drawing.Size(201, 17);
            this.frTb.TabIndex = 5;
            // 
            // gaussianTabPage
            // 
            this.gaussianTabPage.Controls.Add(this.tableLayoutPanel5);
            this.gaussianTabPage.Location = new System.Drawing.Point(4, 22);
            this.gaussianTabPage.Name = "gaussianTabPage";
            this.gaussianTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.gaussianTabPage.Size = new System.Drawing.Size(420, 150);
            this.gaussianTabPage.TabIndex = 2;
            this.gaussianTabPage.Text = "Нормальний розподіл";
            this.gaussianTabPage.UseVisualStyleBackColor = true;
            // 
            // triangleTabPage
            // 
            this.triangleTabPage.Controls.Add(this.tableLayoutPanel6);
            this.triangleTabPage.Location = new System.Drawing.Point(4, 22);
            this.triangleTabPage.Name = "triangleTabPage";
            this.triangleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.triangleTabPage.Size = new System.Drawing.Size(420, 150);
            this.triangleTabPage.TabIndex = 3;
            this.triangleTabPage.Text = "Трикутний розподіл";
            this.triangleTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.gaussianBtnSave, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(414, 144);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.triangleBtnSave, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(414, 144);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // gaussianBtnSave
            // 
            this.gaussianBtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaussianBtnSave.Location = new System.Drawing.Point(3, 72);
            this.gaussianBtnSave.Name = "gaussianBtnSave";
            this.gaussianBtnSave.Size = new System.Drawing.Size(408, 34);
            this.gaussianBtnSave.TabIndex = 1;
            this.gaussianBtnSave.Text = "Зберегти";
            this.gaussianBtnSave.UseVisualStyleBackColor = true;
            this.gaussianBtnSave.Click += new System.EventHandler(this.gaussianBtnSave_Click);
            // 
            // triangleBtnSave
            // 
            this.triangleBtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleBtnSave.Location = new System.Drawing.Point(3, 107);
            this.triangleBtnSave.Name = "triangleBtnSave";
            this.triangleBtnSave.Size = new System.Drawing.Size(408, 34);
            this.triangleBtnSave.TabIndex = 2;
            this.triangleBtnSave.Text = "Зберегти";
            this.triangleBtnSave.UseVisualStyleBackColor = true;
            this.triangleBtnSave.Click += new System.EventHandler(this.triangleBtnSave_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.size2Tb, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.sigmaTb, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.muTb, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(414, 69);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "μ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ϭ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // muTb
            // 
            this.muTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muTb.Location = new System.Drawing.Point(210, 3);
            this.muTb.Multiline = true;
            this.muTb.Name = "muTb";
            this.muTb.Size = new System.Drawing.Size(201, 16);
            this.muTb.TabIndex = 5;
            this.muTb.Text = "0";
            // 
            // sigmaTb
            // 
            this.sigmaTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sigmaTb.Location = new System.Drawing.Point(210, 25);
            this.sigmaTb.Multiline = true;
            this.sigmaTb.Name = "sigmaTb";
            this.sigmaTb.Size = new System.Drawing.Size(201, 16);
            this.sigmaTb.TabIndex = 6;
            this.sigmaTb.Text = "1";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.size3Tb, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.c3Tb, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.b3Tb, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.a3Tb, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(414, 104);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 26);
            this.label9.TabIndex = 2;
            this.label9.Text = "a";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 26);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(201, 26);
            this.label10.TabIndex = 3;
            this.label10.Text = "b";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 26);
            this.label11.TabIndex = 4;
            this.label11.Text = "с";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // a3Tb
            // 
            this.a3Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a3Tb.Location = new System.Drawing.Point(210, 3);
            this.a3Tb.Multiline = true;
            this.a3Tb.Name = "a3Tb";
            this.a3Tb.Size = new System.Drawing.Size(201, 20);
            this.a3Tb.TabIndex = 6;
            // 
            // b3Tb
            // 
            this.b3Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.b3Tb.Location = new System.Drawing.Point(210, 29);
            this.b3Tb.Multiline = true;
            this.b3Tb.Name = "b3Tb";
            this.b3Tb.Size = new System.Drawing.Size(201, 20);
            this.b3Tb.TabIndex = 7;
            // 
            // c3Tb
            // 
            this.c3Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c3Tb.Location = new System.Drawing.Point(210, 55);
            this.c3Tb.Multiline = true;
            this.c3Tb.Name = "c3Tb";
            this.c3Tb.Size = new System.Drawing.Size(201, 20);
            this.c3Tb.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(201, 26);
            this.label12.TabIndex = 9;
            this.label12.Text = "розмір";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // size3Tb
            // 
            this.size3Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.size3Tb.Location = new System.Drawing.Point(210, 81);
            this.size3Tb.Multiline = true;
            this.size3Tb.Name = "size3Tb";
            this.size3Tb.Size = new System.Drawing.Size(201, 20);
            this.size3Tb.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(201, 25);
            this.label13.TabIndex = 7;
            this.label13.Text = "розмір";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // size2Tb
            // 
            this.size2Tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.size2Tb.Location = new System.Drawing.Point(210, 47);
            this.size2Tb.Multiline = true;
            this.size2Tb.Name = "size2Tb";
            this.size2Tb.Size = new System.Drawing.Size(201, 19);
            this.size2Tb.TabIndex = 8;
            // 
            // GenerateBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 176);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 180);
            this.Name = "GenerateBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GenerateBox";
            this.tabControl.ResumeLayout(false);
            this.dataTabPabe.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableTabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.gaussianTabPage.ResumeLayout(false);
            this.triangleTabPage.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage dataTabPabe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tableTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button dataBtnSave;
        private System.Windows.Forms.Button dataTableBtnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aTb;
        private System.Windows.Forms.TextBox bTb;
        private System.Windows.Forms.TextBox sizeTb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox a2Tb;
        private System.Windows.Forms.TextBox b2Tb;
        private System.Windows.Forms.TextBox frTb;
        private System.Windows.Forms.TabPage gaussianTabPage;
        private System.Windows.Forms.TabPage triangleTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button gaussianBtnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button triangleBtnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TextBox sigmaTb;
        private System.Windows.Forms.TextBox muTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox c3Tb;
        private System.Windows.Forms.TextBox b3Tb;
        private System.Windows.Forms.TextBox a3Tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox size3Tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox size2Tb;
        private System.Windows.Forms.Label label13;
    }
}