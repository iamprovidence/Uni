namespace NumericalIntegration
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
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.glGraph = new FancyControls.Data.glGraph();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.epsTb = new System.Windows.Forms.TextBox();
            this.calcBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gauss5IterLbl = new System.Windows.Forms.Label();
            this.gauss5CallLbl = new System.Windows.Forms.Label();
            this.gauss5ResLbl = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.gauss4Iterlbl = new System.Windows.Forms.Label();
            this.gauss4CallLbl = new System.Windows.Forms.Label();
            this.gauss4ResLbl = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.parabIterLbl = new System.Windows.Forms.Label();
            this.parabCallLbl = new System.Windows.Forms.Label();
            this.parabResLbl = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.trapezeIterLbl = new System.Windows.Forms.Label();
            this.trapezeCallLbl = new System.Windows.Forms.Label();
            this.trapezeResLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rectResLbl = new System.Windows.Forms.Label();
            this.rectCallLbl = new System.Windows.Forms.Label();
            this.rectIterLbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.scaleTbl.Controls.Add(this.glGraph, 0, 0);
            this.scaleTbl.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 1;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Size = new System.Drawing.Size(644, 371);
            this.scaleTbl.TabIndex = 0;
            // 
            // glGraph
            // 
            this.glGraph.BackColor = System.Drawing.Color.White;
            this.glGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glGraph.Location = new System.Drawing.Point(3, 3);
            this.glGraph.Name = "glGraph";
            this.glGraph.Size = new System.Drawing.Size(380, 365);
            this.glGraph.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.calcBtn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(386, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 371);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x) = x*3^x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.epsTb, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(258, 60);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "a = -1.0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(132, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "b = 1.0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "eps";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epsTb
            // 
            this.epsTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.epsTb.Location = new System.Drawing.Point(132, 33);
            this.epsTb.Multiline = true;
            this.epsTb.Name = "epsTb";
            this.epsTb.Size = new System.Drawing.Size(123, 24);
            this.epsTb.TabIndex = 3;
            this.epsTb.Text = "1e-5";
            // 
            // calcBtn
            // 
            this.calcBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calcBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calcBtn.Location = new System.Drawing.Point(3, 88);
            this.calcBtn.Name = "calcBtn";
            this.calcBtn.Size = new System.Drawing.Size(252, 34);
            this.calcBtn.TabIndex = 2;
            this.calcBtn.Text = "calculate";
            this.calcBtn.UseVisualStyleBackColor = true;
            this.calcBtn.Click += new System.EventHandler(this.calcBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.gauss5IterLbl, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.gauss5CallLbl, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.gauss5ResLbl, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label25, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.gauss4Iterlbl, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.gauss4CallLbl, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.gauss4ResLbl, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.parabIterLbl, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.parabCallLbl, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.parabResLbl, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.trapezeIterLbl, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.trapezeCallLbl, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.trapezeResLbl, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.rectResLbl, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.rectCallLbl, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.rectIterLbl, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 125);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(258, 246);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // gauss5IterLbl
            // 
            this.gauss5IterLbl.AutoSize = true;
            this.gauss5IterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gauss5IterLbl.Location = new System.Drawing.Point(195, 200);
            this.gauss5IterLbl.Name = "gauss5IterLbl";
            this.gauss5IterLbl.Size = new System.Drawing.Size(60, 46);
            this.gauss5IterLbl.TabIndex = 39;
            this.gauss5IterLbl.Text = "0";
            this.gauss5IterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gauss5CallLbl
            // 
            this.gauss5CallLbl.AutoSize = true;
            this.gauss5CallLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gauss5CallLbl.Location = new System.Drawing.Point(131, 200);
            this.gauss5CallLbl.Name = "gauss5CallLbl";
            this.gauss5CallLbl.Size = new System.Drawing.Size(58, 46);
            this.gauss5CallLbl.TabIndex = 37;
            this.gauss5CallLbl.Text = "0";
            this.gauss5CallLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gauss5ResLbl
            // 
            this.gauss5ResLbl.AutoSize = true;
            this.gauss5ResLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gauss5ResLbl.Location = new System.Drawing.Point(67, 200);
            this.gauss5ResLbl.Name = "gauss5ResLbl";
            this.gauss5ResLbl.Size = new System.Drawing.Size(58, 46);
            this.gauss5ResLbl.TabIndex = 35;
            this.gauss5ResLbl.Text = "0";
            this.gauss5ResLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(3, 200);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 46);
            this.label25.TabIndex = 33;
            this.label25.Text = "5 Gauss";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gauss4Iterlbl
            // 
            this.gauss4Iterlbl.AutoSize = true;
            this.gauss4Iterlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gauss4Iterlbl.Location = new System.Drawing.Point(195, 160);
            this.gauss4Iterlbl.Name = "gauss4Iterlbl";
            this.gauss4Iterlbl.Size = new System.Drawing.Size(60, 40);
            this.gauss4Iterlbl.TabIndex = 31;
            this.gauss4Iterlbl.Text = "0";
            this.gauss4Iterlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gauss4CallLbl
            // 
            this.gauss4CallLbl.AutoSize = true;
            this.gauss4CallLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gauss4CallLbl.Location = new System.Drawing.Point(131, 160);
            this.gauss4CallLbl.Name = "gauss4CallLbl";
            this.gauss4CallLbl.Size = new System.Drawing.Size(58, 40);
            this.gauss4CallLbl.TabIndex = 29;
            this.gauss4CallLbl.Text = "0";
            this.gauss4CallLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gauss4ResLbl
            // 
            this.gauss4ResLbl.AutoSize = true;
            this.gauss4ResLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gauss4ResLbl.Location = new System.Drawing.Point(67, 160);
            this.gauss4ResLbl.Name = "gauss4ResLbl";
            this.gauss4ResLbl.Size = new System.Drawing.Size(58, 40);
            this.gauss4ResLbl.TabIndex = 27;
            this.gauss4ResLbl.Text = "0";
            this.gauss4ResLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(3, 160);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 40);
            this.label21.TabIndex = 25;
            this.label21.Text = "4 Gauss";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parabIterLbl
            // 
            this.parabIterLbl.AutoSize = true;
            this.parabIterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parabIterLbl.Location = new System.Drawing.Point(195, 120);
            this.parabIterLbl.Name = "parabIterLbl";
            this.parabIterLbl.Size = new System.Drawing.Size(60, 40);
            this.parabIterLbl.TabIndex = 23;
            this.parabIterLbl.Text = "0";
            this.parabIterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parabCallLbl
            // 
            this.parabCallLbl.AutoSize = true;
            this.parabCallLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parabCallLbl.Location = new System.Drawing.Point(131, 120);
            this.parabCallLbl.Name = "parabCallLbl";
            this.parabCallLbl.Size = new System.Drawing.Size(58, 40);
            this.parabCallLbl.TabIndex = 21;
            this.parabCallLbl.Text = "0";
            this.parabCallLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parabResLbl
            // 
            this.parabResLbl.AutoSize = true;
            this.parabResLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parabResLbl.Location = new System.Drawing.Point(67, 120);
            this.parabResLbl.Name = "parabResLbl";
            this.parabResLbl.Size = new System.Drawing.Size(58, 40);
            this.parabResLbl.TabIndex = 19;
            this.parabResLbl.Text = "0";
            this.parabResLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(3, 120);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 40);
            this.label17.TabIndex = 17;
            this.label17.Text = "Parabola";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trapezeIterLbl
            // 
            this.trapezeIterLbl.AutoSize = true;
            this.trapezeIterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trapezeIterLbl.Location = new System.Drawing.Point(195, 80);
            this.trapezeIterLbl.Name = "trapezeIterLbl";
            this.trapezeIterLbl.Size = new System.Drawing.Size(60, 40);
            this.trapezeIterLbl.TabIndex = 15;
            this.trapezeIterLbl.Text = "0";
            this.trapezeIterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trapezeCallLbl
            // 
            this.trapezeCallLbl.AutoSize = true;
            this.trapezeCallLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trapezeCallLbl.Location = new System.Drawing.Point(131, 80);
            this.trapezeCallLbl.Name = "trapezeCallLbl";
            this.trapezeCallLbl.Size = new System.Drawing.Size(58, 40);
            this.trapezeCallLbl.TabIndex = 13;
            this.trapezeCallLbl.Text = "0";
            this.trapezeCallLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trapezeResLbl
            // 
            this.trapezeResLbl.AutoSize = true;
            this.trapezeResLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trapezeResLbl.Location = new System.Drawing.Point(67, 80);
            this.trapezeResLbl.Name = "trapezeResLbl";
            this.trapezeResLbl.Size = new System.Drawing.Size(58, 40);
            this.trapezeResLbl.TabIndex = 11;
            this.trapezeResLbl.Text = "0";
            this.trapezeResLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(67, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 40);
            this.label5.TabIndex = 0;
            this.label5.Text = "S";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(131, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 40);
            this.label6.TabIndex = 1;
            this.label6.Text = "Call Amount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(195, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 40);
            this.label7.TabIndex = 2;
            this.label7.Text = "Iteration Amount";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 40);
            this.label8.TabIndex = 3;
            this.label8.Text = "Rectangle";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rectResLbl
            // 
            this.rectResLbl.AutoSize = true;
            this.rectResLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectResLbl.Location = new System.Drawing.Point(67, 40);
            this.rectResLbl.Name = "rectResLbl";
            this.rectResLbl.Size = new System.Drawing.Size(58, 40);
            this.rectResLbl.TabIndex = 4;
            this.rectResLbl.Text = "0";
            this.rectResLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rectCallLbl
            // 
            this.rectCallLbl.AutoSize = true;
            this.rectCallLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectCallLbl.Location = new System.Drawing.Point(131, 40);
            this.rectCallLbl.Name = "rectCallLbl";
            this.rectCallLbl.Size = new System.Drawing.Size(58, 40);
            this.rectCallLbl.TabIndex = 5;
            this.rectCallLbl.Text = "0";
            this.rectCallLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rectIterLbl
            // 
            this.rectIterLbl.AutoSize = true;
            this.rectIterLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectIterLbl.Location = new System.Drawing.Point(195, 40);
            this.rectIterLbl.Name = "rectIterLbl";
            this.rectIterLbl.Size = new System.Drawing.Size(60, 40);
            this.rectIterLbl.TabIndex = 6;
            this.rectIterLbl.Text = "0";
            this.rectIterLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 40);
            this.label12.TabIndex = 7;
            this.label12.Text = "Trapeze";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 371);
            this.Controls.Add(this.scaleTbl);
            this.MinimumSize = new System.Drawing.Size(660, 410);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numerical Integration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.scaleTbl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private FancyControls.Data.glGraph glGraph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox epsTb;
        private System.Windows.Forms.Button calcBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label gauss5IterLbl;
        private System.Windows.Forms.Label gauss5CallLbl;
        private System.Windows.Forms.Label gauss5ResLbl;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label gauss4Iterlbl;
        private System.Windows.Forms.Label gauss4CallLbl;
        private System.Windows.Forms.Label gauss4ResLbl;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label parabIterLbl;
        private System.Windows.Forms.Label parabCallLbl;
        private System.Windows.Forms.Label parabResLbl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label trapezeIterLbl;
        private System.Windows.Forms.Label trapezeCallLbl;
        private System.Windows.Forms.Label trapezeResLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label rectResLbl;
        private System.Windows.Forms.Label rectCallLbl;
        private System.Windows.Forms.Label rectIterLbl;
        private System.Windows.Forms.Label label12;
    }
}

