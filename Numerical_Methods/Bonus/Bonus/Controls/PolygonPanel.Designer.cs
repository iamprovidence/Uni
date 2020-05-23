namespace Bonus.Controls
{
    partial class PolygonPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pointDgv = new System.Windows.Forms.DataGridView();
            this.xCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonTbl = new System.Windows.Forms.TableLayoutPanel();
            this.insertBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.commitBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.xTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yTb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.sxTb = new System.Windows.Forms.TextBox();
            this.syTb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.exTb = new System.Windows.Forms.TextBox();
            this.eyTb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.stepsTb = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.colorPnl = new System.Windows.Forms.Panel();
            this.textLbl = new System.Windows.Forms.Label();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointDgv)).BeginInit();
            this.buttonTbl.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 1;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.scaleTbl.Controls.Add(this.textLbl, 0, 0);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.scaleTbl.Size = new System.Drawing.Size(243, 359);
            this.scaleTbl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.Controls.Add(this.pointDgv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTbl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pointDgv
            // 
            this.pointDgv.AllowUserToAddRows = false;
            this.pointDgv.AllowUserToDeleteRows = false;
            this.pointDgv.AllowUserToResizeColumns = false;
            this.pointDgv.AllowUserToResizeRows = false;
            this.pointDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pointDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pointDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xCln,
            this.yCln});
            this.pointDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pointDgv.Location = new System.Drawing.Point(3, 3);
            this.pointDgv.Name = "pointDgv";
            this.pointDgv.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pointDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.pointDgv.RowHeadersVisible = false;
            this.pointDgv.Size = new System.Drawing.Size(128, 300);
            this.pointDgv.TabIndex = 0;
            // 
            // xCln
            // 
            this.xCln.HeaderText = "X";
            this.xCln.Name = "xCln";
            this.xCln.ReadOnly = true;
            // 
            // yCln
            // 
            this.yCln.HeaderText = "Y";
            this.yCln.Name = "yCln";
            this.yCln.ReadOnly = true;
            // 
            // buttonTbl
            // 
            this.buttonTbl.ColumnCount = 1;
            this.buttonTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTbl.Controls.Add(this.insertBtn, 0, 1);
            this.buttonTbl.Controls.Add(this.deleteBtn, 0, 2);
            this.buttonTbl.Controls.Add(this.commitBtn, 0, 7);
            this.buttonTbl.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.buttonTbl.Controls.Add(this.flowLayoutPanel2, 0, 3);
            this.buttonTbl.Controls.Add(this.flowLayoutPanel3, 0, 4);
            this.buttonTbl.Controls.Add(this.flowLayoutPanel4, 0, 5);
            this.buttonTbl.Controls.Add(this.flowLayoutPanel5, 0, 6);
            this.buttonTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTbl.Location = new System.Drawing.Point(134, 0);
            this.buttonTbl.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTbl.Name = "buttonTbl";
            this.buttonTbl.RowCount = 8;
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.46903F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.50443F));
            this.buttonTbl.Size = new System.Drawing.Size(109, 306);
            this.buttonTbl.TabIndex = 1;
            // 
            // insertBtn
            // 
            this.insertBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertBtn.Location = new System.Drawing.Point(3, 62);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(103, 29);
            this.insertBtn.TabIndex = 0;
            this.insertBtn.Text = "insert";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteBtn.Location = new System.Drawing.Point(3, 97);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(103, 29);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // commitBtn
            // 
            this.commitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commitBtn.Location = new System.Drawing.Point(3, 272);
            this.commitBtn.Name = "commitBtn";
            this.commitBtn.Size = new System.Drawing.Size(103, 31);
            this.commitBtn.TabIndex = 2;
            this.commitBtn.Text = "commit";
            this.commitBtn.UseVisualStyleBackColor = true;
            this.commitBtn.Click += new System.EventHandler(this.commitBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.xTb);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.yTb);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(109, 59);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xTb
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.xTb, true);
            this.xTb.Location = new System.Drawing.Point(23, 3);
            this.xTb.Name = "xTb";
            this.xTb.Size = new System.Drawing.Size(74, 20);
            this.xTb.TabIndex = 1;
            this.xTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yTb
            // 
            this.yTb.Location = new System.Drawing.Point(23, 29);
            this.yTb.Name = "yTb";
            this.yTb.Size = new System.Drawing.Size(74, 20);
            this.yTb.TabIndex = 3;
            this.yTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.sxTb);
            this.flowLayoutPanel2.Controls.Add(this.syTb);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 129);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(109, 35);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.MinimumSize = new System.Drawing.Size(40, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "start";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sxTb
            // 
            this.sxTb.Location = new System.Drawing.Point(49, 3);
            this.sxTb.Name = "sxTb";
            this.sxTb.Size = new System.Drawing.Size(25, 20);
            this.sxTb.TabIndex = 3;
            this.sxTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // syTb
            // 
            this.syTb.Location = new System.Drawing.Point(80, 3);
            this.syTb.Name = "syTb";
            this.syTb.Size = new System.Drawing.Size(25, 20);
            this.syTb.TabIndex = 4;
            this.syTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.exTb);
            this.flowLayoutPanel3.Controls.Add(this.eyTb);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 164);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(109, 35);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.MinimumSize = new System.Drawing.Size(40, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "end";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exTb
            // 
            this.exTb.Location = new System.Drawing.Point(49, 3);
            this.exTb.Name = "exTb";
            this.exTb.Size = new System.Drawing.Size(25, 20);
            this.exTb.TabIndex = 1;
            this.exTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // eyTb
            // 
            this.eyTb.Location = new System.Drawing.Point(80, 3);
            this.eyTb.Name = "eyTb";
            this.eyTb.Size = new System.Drawing.Size(25, 20);
            this.eyTb.TabIndex = 2;
            this.eyTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.stepsTb);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 199);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(109, 35);
            this.flowLayoutPanel4.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.MinimumSize = new System.Drawing.Size(40, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "steps";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stepsTb
            // 
            this.stepsTb.Location = new System.Drawing.Point(49, 3);
            this.stepsTb.Name = "stepsTb";
            this.stepsTb.Size = new System.Drawing.Size(25, 20);
            this.stepsTb.TabIndex = 1;
            this.stepsTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label6);
            this.flowLayoutPanel5.Controls.Add(this.colorPnl);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 234);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(109, 35);
            this.flowLayoutPanel5.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.MinimumSize = new System.Drawing.Size(40, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 33);
            this.label6.TabIndex = 0;
            this.label6.Text = "color";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorPnl
            // 
            this.colorPnl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.colorPnl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPnl.Location = new System.Drawing.Point(49, 3);
            this.colorPnl.Name = "colorPnl";
            this.colorPnl.Size = new System.Drawing.Size(32, 27);
            this.colorPnl.TabIndex = 1;
            this.colorPnl.Click += new System.EventHandler(this.colorPnl_Click);
            // 
            // textLbl
            // 
            this.textLbl.AutoSize = true;
            this.textLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLbl.Location = new System.Drawing.Point(3, 0);
            this.textLbl.Name = "textLbl";
            this.textLbl.Size = new System.Drawing.Size(237, 53);
            this.textLbl.TabIndex = 1;
            this.textLbl.Text = "polygon";
            this.textLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PolygonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "PolygonPanel";
            this.Size = new System.Drawing.Size(243, 359);
            this.scaleTbl.ResumeLayout(false);
            this.scaleTbl.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pointDgv)).EndInit();
            this.buttonTbl.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView pointDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCln;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCln;
        private System.Windows.Forms.TableLayoutPanel buttonTbl;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button commitBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yTb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label textLbl;
        private System.Windows.Forms.TextBox sxTb;
        private System.Windows.Forms.TextBox syTb;
        private System.Windows.Forms.TextBox exTb;
        private System.Windows.Forms.TextBox eyTb;
        private System.Windows.Forms.TextBox stepsTb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel colorPnl;
    }
}
