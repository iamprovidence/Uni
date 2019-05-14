namespace FiniteElementMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.scaleTbl = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsTbl = new System.Windows.Forms.TableLayoutPanel();
            this.contentPnl = new System.Windows.Forms.Panel();
            this.matricesBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.scaleTbl.SuspendLayout();
            this.buttonsTbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 2;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Controls.Add(this.buttonsTbl, 0, 0);
            this.scaleTbl.Controls.Add(this.contentPnl, 1, 0);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 1;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.scaleTbl.Size = new System.Drawing.Size(784, 536);
            this.scaleTbl.TabIndex = 0;
            // 
            // buttonsTbl
            // 
            this.buttonsTbl.ColumnCount = 1;
            this.buttonsTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonsTbl.Controls.Add(this.matricesBtn, 0, 1);
            this.buttonsTbl.Controls.Add(this.exitBtn, 0, 4);
            this.buttonsTbl.Controls.Add(this.settingBtn, 0, 0);
            this.buttonsTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsTbl.Location = new System.Drawing.Point(0, 0);
            this.buttonsTbl.Margin = new System.Windows.Forms.Padding(0);
            this.buttonsTbl.Name = "buttonsTbl";
            this.buttonsTbl.RowCount = 5;
            this.buttonsTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttonsTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttonsTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttonsTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttonsTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.buttonsTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buttonsTbl.Size = new System.Drawing.Size(200, 536);
            this.buttonsTbl.TabIndex = 0;
            // 
            // contentPnl
            // 
            this.contentPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPnl.Location = new System.Drawing.Point(203, 3);
            this.contentPnl.Name = "contentPnl";
            this.contentPnl.Size = new System.Drawing.Size(578, 530);
            this.contentPnl.TabIndex = 1;
            // 
            // matricesBtn
            // 
            this.matricesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.matricesBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matricesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.matricesBtn.Image = global::FiniteElementMethod.Properties.Resources.matrix1;
            this.matricesBtn.Location = new System.Drawing.Point(3, 110);
            this.matricesBtn.Name = "matricesBtn";
            this.matricesBtn.Size = new System.Drawing.Size(194, 101);
            this.matricesBtn.TabIndex = 3;
            this.matricesBtn.Text = "Matrices";
            this.matricesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.matricesBtn.UseVisualStyleBackColor = true;
            this.matricesBtn.Click += new System.EventHandler(this.matricesBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitBtn.Image = global::FiniteElementMethod.Properties.Resources.exit;
            this.exitBtn.Location = new System.Drawing.Point(3, 431);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(194, 102);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Exit";
            this.exitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingBtn.Image = global::FiniteElementMethod.Properties.Resources.setting;
            this.settingBtn.Location = new System.Drawing.Point(3, 3);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(194, 101);
            this.settingBtn.TabIndex = 0;
            this.settingBtn.Text = "Setting";
            this.settingBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingBtn.UseVisualStyleBackColor = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 536);
            this.Controls.Add(this.scaleTbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 575);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finite Element Method";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.scaleTbl.ResumeLayout(false);
            this.buttonsTbl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private System.Windows.Forms.TableLayoutPanel buttonsTbl;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Panel contentPnl;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button matricesBtn;
    }
}

