namespace FourForms
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
            this.window1 = new FourForms.Window();
            this.window2 = new FourForms.Window();
            this.window3 = new FourForms.Window();
            this.window4 = new FourForms.Window();
            this.scaleTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.window1, 0, 0);
            this.scaleTbl.Controls.Add(this.window2, 1, 0);
            this.scaleTbl.Controls.Add(this.window3, 0, 1);
            this.scaleTbl.Controls.Add(this.window4, 1, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Size = new System.Drawing.Size(554, 462);
            this.scaleTbl.TabIndex = 0;
            // 
            // window1
            // 
            this.window1.BackColor = System.Drawing.Color.Transparent;
            this.window1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window1.Location = new System.Drawing.Point(0, 0);
            this.window1.Margin = new System.Windows.Forms.Padding(0);
            this.window1.Name = "window1";
            this.window1.Size = new System.Drawing.Size(277, 231);
            this.window1.TabIndex = 0;
            // 
            // window2
            // 
            this.window2.BackColor = System.Drawing.Color.Transparent;
            this.window2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window2.Location = new System.Drawing.Point(277, 0);
            this.window2.Margin = new System.Windows.Forms.Padding(0);
            this.window2.Name = "window2";
            this.window2.Size = new System.Drawing.Size(277, 231);
            this.window2.TabIndex = 1;
            // 
            // window3
            // 
            this.window3.BackColor = System.Drawing.Color.Transparent;
            this.window3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window3.Location = new System.Drawing.Point(0, 231);
            this.window3.Margin = new System.Windows.Forms.Padding(0);
            this.window3.Name = "window3";
            this.window3.Size = new System.Drawing.Size(277, 231);
            this.window3.TabIndex = 2;
            // 
            // window4
            // 
            this.window4.BackColor = System.Drawing.Color.Transparent;
            this.window4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.window4.Location = new System.Drawing.Point(277, 231);
            this.window4.Margin = new System.Windows.Forms.Padding(0);
            this.window4.Name = "window4";
            this.window4.Size = new System.Drawing.Size(277, 231);
            this.window4.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(554, 462);
            this.Controls.Add(this.scaleTbl);
            this.MinimumSize = new System.Drawing.Size(570, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FourForms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.scaleTbl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private FourForms.Window window1;
        private FourForms.Window window2;
        private FourForms.Window window3;
        private FourForms.Window window4;
    }
}

