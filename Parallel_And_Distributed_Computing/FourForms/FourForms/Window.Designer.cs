namespace FourForms
{
    partial class Window
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
            this.bttonTbl = new System.Windows.Forms.TableLayoutPanel();
            this.suspendBtn = new System.Windows.Forms.Button();
            this.resumeBtn = new System.Windows.Forms.Button();
            this.graphicPanel = new System.Windows.Forms.Panel();
            this.scaleTbl.SuspendLayout();
            this.bttonTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 1;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Controls.Add(this.bttonTbl, 0, 1);
            this.scaleTbl.Controls.Add(this.graphicPanel, 0, 0);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Margin = new System.Windows.Forms.Padding(0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.scaleTbl.Size = new System.Drawing.Size(240, 233);
            this.scaleTbl.TabIndex = 0;
            // 
            // bttonTbl
            // 
            this.bttonTbl.ColumnCount = 2;
            this.bttonTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bttonTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bttonTbl.Controls.Add(this.suspendBtn, 0, 0);
            this.bttonTbl.Controls.Add(this.resumeBtn, 1, 0);
            this.bttonTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttonTbl.Location = new System.Drawing.Point(0, 186);
            this.bttonTbl.Margin = new System.Windows.Forms.Padding(0);
            this.bttonTbl.Name = "bttonTbl";
            this.bttonTbl.RowCount = 1;
            this.bttonTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bttonTbl.Size = new System.Drawing.Size(240, 47);
            this.bttonTbl.TabIndex = 0;
            // 
            // suspendBtn
            // 
            this.suspendBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.suspendBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suspendBtn.FlatAppearance.BorderSize = 0;
            this.suspendBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.suspendBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.suspendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suspendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.suspendBtn.Location = new System.Drawing.Point(0, 0);
            this.suspendBtn.Margin = new System.Windows.Forms.Padding(0);
            this.suspendBtn.Name = "suspendBtn";
            this.suspendBtn.Size = new System.Drawing.Size(120, 47);
            this.suspendBtn.TabIndex = 0;
            this.suspendBtn.Text = "SUSPEND";
            this.suspendBtn.UseVisualStyleBackColor = true;
            this.suspendBtn.Click += new System.EventHandler(this.suspendBtn_Click);
            // 
            // resumeBtn
            // 
            this.resumeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resumeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resumeBtn.Enabled = false;
            this.resumeBtn.FlatAppearance.BorderSize = 0;
            this.resumeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resumeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.resumeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resumeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resumeBtn.Location = new System.Drawing.Point(120, 0);
            this.resumeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.resumeBtn.Name = "resumeBtn";
            this.resumeBtn.Size = new System.Drawing.Size(120, 47);
            this.resumeBtn.TabIndex = 1;
            this.resumeBtn.Text = "RESUME";
            this.resumeBtn.UseVisualStyleBackColor = true;
            this.resumeBtn.Click += new System.EventHandler(this.resumeBtn_Click);
            // 
            // graphicPanel
            // 
            this.graphicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicPanel.Location = new System.Drawing.Point(0, 0);
            this.graphicPanel.Margin = new System.Windows.Forms.Padding(0);
            this.graphicPanel.Name = "graphicPanel";
            this.graphicPanel.Size = new System.Drawing.Size(240, 186);
            this.graphicPanel.TabIndex = 1;
            this.graphicPanel.SizeChanged += new System.EventHandler(this.graphicPanel_SizeChanged);
            this.graphicPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicPanel_Paint);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.scaleTbl);
            this.Name = "Window";
            this.Size = new System.Drawing.Size(240, 233);
            this.scaleTbl.ResumeLayout(false);
            this.bttonTbl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.TableLayoutPanel bttonTbl;
        private System.Windows.Forms.Button suspendBtn;
        private System.Windows.Forms.Button resumeBtn;
        private System.Windows.Forms.Panel graphicPanel;
    }
}
