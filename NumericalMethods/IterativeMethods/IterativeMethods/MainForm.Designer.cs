namespace IterativeMethods
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.scaleTblPage1 = new System.Windows.Forms.TableLayoutPanel();
            this.glGraph1 = new FancyControls.Data.glGraph();
            this.menuTbl1 = new System.Windows.Forms.TableLayoutPanel();
            this.resultTbl1 = new System.Windows.Forms.TableLayoutPanel();
            this.chordMethodLbl = new System.Windows.Forms.Label();
            this.newtonMethodLbl = new System.Windows.Forms.Label();
            this.combinedChordTangentMethodLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.calcBtn1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.aTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.epsTb1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.scaleTblPage2 = new System.Windows.Forms.TableLayoutPanel();
            this.glGraph2 = new FancyControls.Data.glGraph();
            this.menuTbl2 = new System.Windows.Forms.TableLayoutPanel();
            this.resultTbl2 = new System.Windows.Forms.TableLayoutPanel();
            this.iterativeMethodLbl = new System.Windows.Forms.Label();
            this.newtonMethodSystemLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calcBtn2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.xTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.yTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.epsTb2 = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.scaleTblPage1.SuspendLayout();
            this.menuTbl1.SuspendLayout();
            this.resultTbl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.scaleTblPage2.SuspendLayout();
            this.menuTbl2.SuspendLayout();
            this.resultTbl2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(644, 291);
            this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scaleTblPage1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(636, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Equation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // scaleTblPage1
            // 
            this.scaleTblPage1.ColumnCount = 2;
            this.scaleTblPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTblPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTblPage1.Controls.Add(this.glGraph1, 0, 0);
            this.scaleTblPage1.Controls.Add(this.menuTbl1, 1, 0);
            this.scaleTblPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTblPage1.Location = new System.Drawing.Point(0, 0);
            this.scaleTblPage1.Margin = new System.Windows.Forms.Padding(0);
            this.scaleTblPage1.Name = "scaleTblPage1";
            this.scaleTblPage1.RowCount = 1;
            this.scaleTblPage1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTblPage1.Size = new System.Drawing.Size(636, 262);
            this.scaleTblPage1.TabIndex = 0;
            // 
            // glGraph1
            // 
            this.glGraph1.BackColor = System.Drawing.Color.White;
            this.glGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glGraph1.Location = new System.Drawing.Point(3, 3);
            this.glGraph1.Name = "glGraph1";
            this.glGraph1.Size = new System.Drawing.Size(312, 256);
            this.glGraph1.TabIndex = 0;
            this.glGraph1.AxisX.TitleAlignment = FancyControls.Data.TitleAlignment.NearAxisArrow;
            this.glGraph1.AxisY.TitleAlignment = FancyControls.Data.TitleAlignment.NearAxisArrow;
            this.glGraph1.AxisX.Title = "X";
            this.glGraph1.AxisY.Title = "Y";
            this.glGraph1.AxisX.RoundAxisValues();
            // 
            // menuTbl1
            // 
            this.menuTbl1.ColumnCount = 1;
            this.menuTbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTbl1.Controls.Add(this.resultTbl1, 0, 3);
            this.menuTbl1.Controls.Add(this.label1, 0, 0);
            this.menuTbl1.Controls.Add(this.calcBtn1, 0, 2);
            this.menuTbl1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.menuTbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTbl1.Location = new System.Drawing.Point(318, 0);
            this.menuTbl1.Margin = new System.Windows.Forms.Padding(0);
            this.menuTbl1.Name = "menuTbl1";
            this.menuTbl1.RowCount = 4;
            this.menuTbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.menuTbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.menuTbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.menuTbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTbl1.Size = new System.Drawing.Size(318, 262);
            this.menuTbl1.TabIndex = 1;
            // 
            // resultTbl1
            // 
            this.resultTbl1.ColumnCount = 3;
            this.resultTbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.resultTbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.resultTbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.resultTbl1.Controls.Add(this.chordMethodLbl, 0, 0);
            this.resultTbl1.Controls.Add(this.newtonMethodLbl, 1, 0);
            this.resultTbl1.Controls.Add(this.combinedChordTangentMethodLbl, 2, 0);
            this.resultTbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTbl1.Location = new System.Drawing.Point(0, 120);
            this.resultTbl1.Margin = new System.Windows.Forms.Padding(0);
            this.resultTbl1.Name = "resultTbl1";
            this.resultTbl1.RowCount = 1;
            this.resultTbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultTbl1.Size = new System.Drawing.Size(318, 142);
            this.resultTbl1.TabIndex = 0;
            // 
            // chordMethodLbl
            // 
            this.chordMethodLbl.AutoSize = true;
            this.chordMethodLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chordMethodLbl.Location = new System.Drawing.Point(3, 0);
            this.chordMethodLbl.Name = "chordMethodLbl";
            this.chordMethodLbl.Size = new System.Drawing.Size(100, 142);
            this.chordMethodLbl.TabIndex = 0;
            // 
            // newtonMethodLbl
            // 
            this.newtonMethodLbl.AutoSize = true;
            this.newtonMethodLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtonMethodLbl.Location = new System.Drawing.Point(109, 0);
            this.newtonMethodLbl.Name = "newtonMethodLbl";
            this.newtonMethodLbl.Size = new System.Drawing.Size(100, 142);
            this.newtonMethodLbl.TabIndex = 1;
            // 
            // combinedChordTangentMethodLbl
            // 
            this.combinedChordTangentMethodLbl.AutoSize = true;
            this.combinedChordTangentMethodLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combinedChordTangentMethodLbl.Location = new System.Drawing.Point(215, 0);
            this.combinedChordTangentMethodLbl.Name = "combinedChordTangentMethodLbl";
            this.combinedChordTangentMethodLbl.Size = new System.Drawing.Size(100, 142);
            this.combinedChordTangentMethodLbl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ctg(x) - x/3 = 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calcBtn1
            // 
            this.calcBtn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calcBtn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcBtn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.calcBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.calcBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calcBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcBtn1.Location = new System.Drawing.Point(3, 78);
            this.calcBtn1.Name = "calcBtn1";
            this.calcBtn1.Size = new System.Drawing.Size(312, 39);
            this.calcBtn1.TabIndex = 2;
            this.calcBtn1.Text = "calculate";
            this.calcBtn1.UseVisualStyleBackColor = true;
            this.calcBtn1.Click += new System.EventHandler(this.calcBtn1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.aTb);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.bTb);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.epsTb1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(318, 55);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "A";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aTb
            // 
            this.aTb.Location = new System.Drawing.Point(37, 3);
            this.aTb.Name = "aTb";
            this.aTb.Size = new System.Drawing.Size(100, 20);
            this.aTb.TabIndex = 1;
            this.aTb.Text = "0,5";
            this.aTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "B";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bTb
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.bTb, true);
            this.bTb.Location = new System.Drawing.Point(163, 3);
            this.bTb.Name = "bTb";
            this.bTb.Size = new System.Drawing.Size(100, 20);
            this.bTb.TabIndex = 3;
            this.bTb.Text = "3";
            this.bTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "EPS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epsTb1
            // 
            this.epsTb1.Location = new System.Drawing.Point(37, 29);
            this.epsTb1.Name = "epsTb1";
            this.epsTb1.Size = new System.Drawing.Size(100, 20);
            this.epsTb1.TabIndex = 5;
            this.epsTb1.Text = "1e-6";
            this.epsTb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.scaleTblPage2);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(636, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "System Of Equations";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // scaleTblPage2
            // 
            this.scaleTblPage2.ColumnCount = 2;
            this.scaleTblPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTblPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTblPage2.Controls.Add(this.glGraph2, 0, 0);
            this.scaleTblPage2.Controls.Add(this.menuTbl2, 1, 0);
            this.scaleTblPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTblPage2.Location = new System.Drawing.Point(0, 0);
            this.scaleTblPage2.Margin = new System.Windows.Forms.Padding(0);
            this.scaleTblPage2.Name = "scaleTblPage2";
            this.scaleTblPage2.RowCount = 1;
            this.scaleTblPage2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTblPage2.Size = new System.Drawing.Size(636, 262);
            this.scaleTblPage2.TabIndex = 0;
            // 
            // glGraph2
            // 
            this.glGraph2.BackColor = System.Drawing.Color.White;
            this.glGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glGraph2.Location = new System.Drawing.Point(3, 3);
            this.glGraph2.Name = "glGraph2";
            this.glGraph2.Size = new System.Drawing.Size(312, 256);
            this.glGraph2.TabIndex = 0;
            this.glGraph2.AxisX.TitleAlignment = FancyControls.Data.TitleAlignment.NearAxisArrow;
            this.glGraph2.AxisY.TitleAlignment = FancyControls.Data.TitleAlignment.NearAxisArrow;
            this.glGraph2.AxisX.Title = "X";
            this.glGraph2.AxisY.Title = "Y";
            this.glGraph2.AxisX.RoundAxisValues();
            // 
            // menuTbl2
            // 
            this.menuTbl2.ColumnCount = 1;
            this.menuTbl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTbl2.Controls.Add(this.resultTbl2, 0, 3);
            this.menuTbl2.Controls.Add(this.label2, 0, 0);
            this.menuTbl2.Controls.Add(this.calcBtn2, 0, 2);
            this.menuTbl2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.menuTbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTbl2.Location = new System.Drawing.Point(318, 0);
            this.menuTbl2.Margin = new System.Windows.Forms.Padding(0);
            this.menuTbl2.Name = "menuTbl2";
            this.menuTbl2.RowCount = 4;
            this.menuTbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.menuTbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.menuTbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.menuTbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTbl2.Size = new System.Drawing.Size(318, 262);
            this.menuTbl2.TabIndex = 1;
            // 
            // resultTbl2
            // 
            this.resultTbl2.ColumnCount = 2;
            this.resultTbl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultTbl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.resultTbl2.Controls.Add(this.iterativeMethodLbl, 0, 0);
            this.resultTbl2.Controls.Add(this.newtonMethodSystemLbl, 1, 0);
            this.resultTbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTbl2.Location = new System.Drawing.Point(0, 140);
            this.resultTbl2.Margin = new System.Windows.Forms.Padding(0);
            this.resultTbl2.Name = "resultTbl2";
            this.resultTbl2.RowCount = 1;
            this.resultTbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultTbl2.Size = new System.Drawing.Size(318, 122);
            this.resultTbl2.TabIndex = 0;
            // 
            // iterativeMethodLbl
            // 
            this.iterativeMethodLbl.AutoSize = true;
            this.iterativeMethodLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iterativeMethodLbl.Location = new System.Drawing.Point(3, 0);
            this.iterativeMethodLbl.Name = "iterativeMethodLbl";
            this.iterativeMethodLbl.Size = new System.Drawing.Size(153, 122);
            this.iterativeMethodLbl.TabIndex = 0;
            // 
            // newtonMethodSystemLbl
            // 
            this.newtonMethodSystemLbl.AutoSize = true;
            this.newtonMethodSystemLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtonMethodSystemLbl.Location = new System.Drawing.Point(162, 0);
            this.newtonMethodSystemLbl.Name = "newtonMethodSystemLbl";
            this.newtonMethodSystemLbl.Size = new System.Drawing.Size(153, 122);
            this.newtonMethodSystemLbl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "2*y - cos(x + 1) = 0\r\nx + sin(y) = -0.4\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calcBtn2
            // 
            this.calcBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calcBtn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcBtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.calcBtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.calcBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calcBtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcBtn2.Location = new System.Drawing.Point(3, 98);
            this.calcBtn2.Name = "calcBtn2";
            this.calcBtn2.Size = new System.Drawing.Size(312, 39);
            this.calcBtn2.TabIndex = 2;
            this.calcBtn2.Text = "calculate";
            this.calcBtn2.UseVisualStyleBackColor = true;
            this.calcBtn2.Click += new System.EventHandler(this.calcBtn2_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.xTb);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.yTb);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.epsTb2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 40);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(318, 55);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "X";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xTb
            // 
            this.xTb.Location = new System.Drawing.Point(37, 3);
            this.xTb.Name = "xTb";
            this.xTb.Size = new System.Drawing.Size(100, 20);
            this.xTb.TabIndex = 1;
            this.xTb.Text = "1";
            this.xTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Y";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yTb
            // 
            this.flowLayoutPanel2.SetFlowBreak(this.yTb, true);
            this.yTb.Location = new System.Drawing.Point(163, 3);
            this.yTb.Name = "yTb";
            this.yTb.Size = new System.Drawing.Size(100, 20);
            this.yTb.TabIndex = 3;
            this.yTb.Text = "-1";
            this.yTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "EPS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epsTb2
            // 
            this.epsTb2.Location = new System.Drawing.Point(37, 29);
            this.epsTb2.Name = "epsTb2";
            this.epsTb2.Size = new System.Drawing.Size(100, 20);
            this.epsTb2.TabIndex = 5;
            this.epsTb2.Text = "1e-6";
            this.epsTb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 292);
            this.Controls.Add(this.tabs);
            this.Name = "MainForm";
            this.MinimumSize = new System.Drawing.Size(660, 330);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IterativeMethods";
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.scaleTblPage1.ResumeLayout(false);
            this.menuTbl1.ResumeLayout(false);
            this.menuTbl1.PerformLayout();
            this.resultTbl1.ResumeLayout(false);
            this.resultTbl1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.scaleTblPage2.ResumeLayout(false);
            this.menuTbl2.ResumeLayout(false);
            this.menuTbl2.PerformLayout();
            this.resultTbl2.ResumeLayout(false);
            this.resultTbl2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel scaleTblPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel scaleTblPage2;
        private FancyControls.Data.glGraph glGraph1;
        private FancyControls.Data.glGraph glGraph2;
        private System.Windows.Forms.TableLayoutPanel menuTbl1;
        private System.Windows.Forms.TableLayoutPanel resultTbl1;
        private System.Windows.Forms.TableLayoutPanel menuTbl2;
        private System.Windows.Forms.TableLayoutPanel resultTbl2;
        private System.Windows.Forms.Label chordMethodLbl;
        private System.Windows.Forms.Label newtonMethodLbl;
        private System.Windows.Forms.Label combinedChordTangentMethodLbl;
        private System.Windows.Forms.Label iterativeMethodLbl;
        private System.Windows.Forms.Label newtonMethodSystemLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button calcBtn1;
        private System.Windows.Forms.Button calcBtn2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox epsTb1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox xTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox yTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox epsTb2;
    }
}

