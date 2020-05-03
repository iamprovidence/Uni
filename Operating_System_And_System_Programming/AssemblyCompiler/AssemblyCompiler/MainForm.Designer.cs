namespace AssemblyCompiler
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
            this.compileBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.assemblyTb = new System.Windows.Forms.RichTextBox();
            this.outputPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.binaryResultTb = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hexResultTb = new System.Windows.Forms.RichTextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.compileBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.saveBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.outputPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 611);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // compileBtn
            // 
            this.compileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compileBtn.Location = new System.Drawing.Point(3, 534);
            this.compileBtn.Name = "compileBtn";
            this.compileBtn.Size = new System.Drawing.Size(361, 74);
            this.compileBtn.TabIndex = 0;
            this.compileBtn.Text = "Compile";
            this.compileBtn.UseVisualStyleBackColor = true;
            this.compileBtn.Click += new System.EventHandler(this.compileBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveBtn.Location = new System.Drawing.Point(370, 534);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(361, 74);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // assemblyTb
            // 
            this.assemblyTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyTb.Location = new System.Drawing.Point(3, 3);
            this.assemblyTb.Name = "assemblyTb";
            this.assemblyTb.Size = new System.Drawing.Size(347, 482);
            this.assemblyTb.TabIndex = 2;
            this.assemblyTb.Text = "MOV AX,BX\nADD CX,AX";
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.tabPage1);
            this.outputPanel.Controls.Add(this.tabPage2);
            this.outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputPanel.Location = new System.Drawing.Point(370, 3);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.SelectedIndex = 0;
            this.outputPanel.Size = new System.Drawing.Size(361, 525);
            this.outputPanel.TabIndex = 3;
            this.outputPanel.SelectedIndexChanged += new System.EventHandler(this.outputPanel_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.binaryResultTb);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(353, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Binary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // binaryResultTb
            // 
            this.binaryResultTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binaryResultTb.Location = new System.Drawing.Point(3, 3);
            this.binaryResultTb.Name = "binaryResultTb";
            this.binaryResultTb.ReadOnly = true;
            this.binaryResultTb.Size = new System.Drawing.Size(347, 482);
            this.binaryResultTb.TabIndex = 0;
            this.binaryResultTb.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.hexResultTb);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(353, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hexadecimal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // hexResultTb
            // 
            this.hexResultTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexResultTb.Location = new System.Drawing.Point(3, 3);
            this.hexResultTb.Name = "hexResultTb";
            this.hexResultTb.ReadOnly = true;
            this.hexResultTb.Size = new System.Drawing.Size(347, 482);
            this.hexResultTb.TabIndex = 0;
            this.hexResultTb.Text = "";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(361, 525);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.assemblyTb);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(353, 488);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "COM File (*.com)|*.com";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(750, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.outputPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button compileBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.RichTextBox assemblyTb;
        private System.Windows.Forms.TabControl outputPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox binaryResultTb;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox hexResultTb;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

