namespace SimpleSubstitutionCipher
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.algoithmLb = new System.Windows.Forms.ListBox();
            this.algorithmConfig = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cypherPanel = new SimpleSubstitutionCipher.UserControls.CypherPanel();
            this.frequencyPanel = new SimpleSubstitutionCipher.UserControls.FrequencyPanel();
            this.scaleTbl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scaleTbl
            // 
            this.scaleTbl.ColumnCount = 1;
            this.scaleTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.Controls.Add(this.cypherPanel, 0, 0);
            this.scaleTbl.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.scaleTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scaleTbl.Location = new System.Drawing.Point(0, 0);
            this.scaleTbl.Name = "scaleTbl";
            this.scaleTbl.RowCount = 2;
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.scaleTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.scaleTbl.Size = new System.Drawing.Size(804, 537);
            this.scaleTbl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98995F));
            this.tableLayoutPanel1.Controls.Add(this.frequencyPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 282);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 255);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.algoithmLb, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.algorithmConfig, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(217, 255);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // algoithmLb
            // 
            this.algoithmLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algoithmLb.FormattingEnabled = true;
            this.algoithmLb.Location = new System.Drawing.Point(3, 43);
            this.algoithmLb.Name = "algoithmLb";
            this.algoithmLb.Size = new System.Drawing.Size(211, 101);
            this.algoithmLb.TabIndex = 0;
            this.algoithmLb.SelectedIndexChanged += new System.EventHandler(this.algoithmLb_SelectedIndexChanged);
            // 
            // algorithmConfig
            // 
            this.algorithmConfig.BackColor = System.Drawing.Color.White;
            this.algorithmConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algorithmConfig.Location = new System.Drawing.Point(3, 150);
            this.algorithmConfig.Name = "algorithmConfig";
            this.algorithmConfig.Size = new System.Drawing.Size(211, 102);
            this.algorithmConfig.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Алгорит шифрування";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cypherPanel
            // 
            this.cypherPanel.BackColor = System.Drawing.Color.Transparent;
            this.cypherPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cypherPanel.Cypher = null;
            this.cypherPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cypherPanel.Location = new System.Drawing.Point(3, 3);
            this.cypherPanel.Name = "cypherPanel";
            this.cypherPanel.OpenFileDialog = null;
            this.cypherPanel.SaveFileDialog = null;
            this.cypherPanel.Size = new System.Drawing.Size(798, 276);
            this.cypherPanel.TabIndex = 0;
            // 
            // frequencyPanel
            // 
            this.frequencyPanel.BackColor = System.Drawing.Color.Transparent;
            this.frequencyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frequencyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frequencyPanel.FrequencyAnalyzer = null;
            this.frequencyPanel.Location = new System.Drawing.Point(220, 3);
            this.frequencyPanel.Name = "frequencyPanel";
            this.frequencyPanel.OpenFileDialog = null;
            this.frequencyPanel.SaveFileDialog = null;
            this.frequencyPanel.Size = new System.Drawing.Size(581, 249);
            this.frequencyPanel.TabIndex = 0;
            this.frequencyPanel.TextBlockToDecode = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(804, 537);
            this.Controls.Add(this.scaleTbl);
            this.MinimumSize = new System.Drawing.Size(820, 575);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Substitution Cipher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.scaleTbl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel scaleTbl;
        private UserControls.CypherPanel cypherPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserControls.FrequencyPanel frequencyPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox algoithmLb;
        private System.Windows.Forms.Panel algorithmConfig;
        private System.Windows.Forms.Label label1;
    }
}

