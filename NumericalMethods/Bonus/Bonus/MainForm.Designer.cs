namespace Bonus
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
            this.components = new System.ComponentModel.Container();
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.polygonTbl = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.squareLbl = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.polygonPanel1 = new Bonus.Controls.PolygonPanel();
            this.polygonPanel2 = new Bonus.Controls.PolygonPanel();
            this.displayPb = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.scaleTbl.SuspendLayout();
            this.buttonTbl.SuspendLayout();
            this.polygonTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.scaleTbl.Controls.Add(this.buttonTbl, 1, 0);
            this.scaleTbl.Controls.Add(this.displayPb, 0, 0);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 1;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Size = new System.Drawing.Size(874, 471);
            this.scaleTbl.TabIndex = 0;
            // 
            // buttonTbl
            // 
            this.buttonTbl.ColumnCount = 1;
            this.buttonTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTbl.Controls.Add(this.label1, 0, 0);
            this.buttonTbl.Controls.Add(this.polygonTbl, 0, 1);
            this.buttonTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTbl.Location = new System.Drawing.Point(474, 0);
            this.buttonTbl.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTbl.Name = "buttonTbl";
            this.buttonTbl.RowCount = 2;
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTbl.Size = new System.Drawing.Size(400, 471);
            this.buttonTbl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bonus Task";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // polygonTbl
            // 
            this.polygonTbl.ColumnCount = 2;
            this.polygonTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.polygonTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.polygonTbl.Controls.Add(this.label2, 0, 0);
            this.polygonTbl.Controls.Add(this.label3, 0, 1);
            this.polygonTbl.Controls.Add(this.squareLbl, 1, 0);
            this.polygonTbl.Controls.Add(this.timeLbl, 1, 1);
            this.polygonTbl.Controls.Add(this.polygonPanel1, 0, 2);
            this.polygonTbl.Controls.Add(this.polygonPanel2, 1, 2);
            this.polygonTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonTbl.Location = new System.Drawing.Point(3, 83);
            this.polygonTbl.Name = "polygonTbl";
            this.polygonTbl.RowCount = 3;
            this.polygonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.polygonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.polygonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.polygonTbl.Size = new System.Drawing.Size(394, 385);
            this.polygonTbl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Max Square";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Time";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // squareLbl
            // 
            this.squareLbl.AutoSize = true;
            this.squareLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squareLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.squareLbl.Location = new System.Drawing.Point(200, 0);
            this.squareLbl.Name = "squareLbl";
            this.squareLbl.Size = new System.Drawing.Size(191, 20);
            this.squareLbl.TabIndex = 2;
            this.squareLbl.Text = "0.0";
            this.squareLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLbl.Location = new System.Drawing.Point(200, 20);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(191, 20);
            this.timeLbl.TabIndex = 3;
            this.timeLbl.Text = "0";
            this.timeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // polygonPanel1
            // 
            this.polygonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.polygonPanel1.Location = new System.Drawing.Point(3, 43);
            this.polygonPanel1.Name = "polygonPanel1";
            this.polygonPanel1.Size = new System.Drawing.Size(191, 337);
            this.polygonPanel1.TabIndex = 4;
            // 
            // polygonPanel2
            // 
            this.polygonPanel2.BackColor = System.Drawing.Color.Transparent;
            this.polygonPanel2.Location = new System.Drawing.Point(200, 43);
            this.polygonPanel2.Name = "polygonPanel2";
            this.polygonPanel2.Size = new System.Drawing.Size(191, 337);
            this.polygonPanel2.TabIndex = 5;
            // 
            // displayPb
            // 
            this.displayPb.BackColor = System.Drawing.Color.LightGray;
            this.displayPb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayPb.Location = new System.Drawing.Point(3, 3);
            this.displayPb.Name = "displayPb";
            this.displayPb.Size = new System.Drawing.Size(468, 465);
            this.displayPb.TabIndex = 2;
            this.displayPb.SizeChanged += new System.EventHandler(this.displayPb_SizeChanged);
            this.displayPb.Paint += new System.Windows.Forms.PaintEventHandler(this.displayPb_Paint);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 471);
            this.Controls.Add(this.scaleTbl);
            this.MinimumSize = new System.Drawing.Size(890, 510);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bonus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.scaleTbl.ResumeLayout(false);
            this.buttonTbl.ResumeLayout(false);
            this.buttonTbl.PerformLayout();
            this.polygonTbl.ResumeLayout(false);
            this.polygonTbl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.TableLayoutPanel buttonTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel polygonTbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label squareLbl;
        private System.Windows.Forms.Label timeLbl;
        private Controls.PolygonPanel polygonPanel1;
        private Controls.PolygonPanel polygonPanel2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel displayPb;
    }
}

