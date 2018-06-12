namespace Task3
{
    partial class Option
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Option));
            this.SaveOP = new System.Windows.Forms.GroupBox();
            this.Exit_chbox = new System.Windows.Forms.CheckBox();
            this.askDelete_chbox = new System.Windows.Forms.CheckBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.Apply_btn = new System.Windows.Forms.Button();
            this.Style_gb = new System.Windows.Forms.GroupBox();
            this.Opacity_level = new System.Windows.Forms.TrackBar();
            this.Opacity_Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveOP.SuspendLayout();
            this.Style_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opacity_level)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveOP
            // 
            this.SaveOP.Controls.Add(this.Exit_chbox);
            this.SaveOP.Controls.Add(this.askDelete_chbox);
            this.SaveOP.Location = new System.Drawing.Point(12, 35);
            this.SaveOP.Name = "SaveOP";
            this.SaveOP.Size = new System.Drawing.Size(260, 100);
            this.SaveOP.TabIndex = 0;
            this.SaveOP.TabStop = false;
            this.SaveOP.Text = "Save Operation";
            // 
            // Exit_chbox
            // 
            this.Exit_chbox.AutoSize = true;
            this.Exit_chbox.Location = new System.Drawing.Point(17, 64);
            this.Exit_chbox.Name = "Exit_chbox";
            this.Exit_chbox.Size = new System.Drawing.Size(112, 17);
            this.Exit_chbox.TabIndex = 1;
            this.Exit_chbox.Text = "Ask Before Exiting";
            this.Exit_chbox.UseVisualStyleBackColor = true;
            this.Exit_chbox.CheckedChanged += new System.EventHandler(this.chbox_CheckedChanged);
            // 
            // askDelete_chbox
            // 
            this.askDelete_chbox.AutoSize = true;
            this.askDelete_chbox.Location = new System.Drawing.Point(17, 31);
            this.askDelete_chbox.Name = "askDelete_chbox";
            this.askDelete_chbox.Size = new System.Drawing.Size(150, 17);
            this.askDelete_chbox.TabIndex = 0;
            this.askDelete_chbox.Text = "Ask Before Deleting Rows";
            this.askDelete_chbox.UseVisualStyleBackColor = true;
            this.askDelete_chbox.CheckedChanged += new System.EventHandler(this.chbox_CheckedChanged);
            // 
            // ok_btn
            // 
            this.ok_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok_btn.Location = new System.Drawing.Point(35, 227);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 1;
            this.ok_btn.Text = "Ok";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel_btn.Location = new System.Drawing.Point(197, 227);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // Apply_btn
            // 
            this.Apply_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Apply_btn.Location = new System.Drawing.Point(116, 227);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(75, 23);
            this.Apply_btn.TabIndex = 3;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.UseVisualStyleBackColor = true;
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Style_gb
            // 
            this.Style_gb.Controls.Add(this.Opacity_level);
            this.Style_gb.Controls.Add(this.Opacity_Lbl);
            this.Style_gb.Location = new System.Drawing.Point(13, 142);
            this.Style_gb.Name = "Style_gb";
            this.Style_gb.Size = new System.Drawing.Size(259, 79);
            this.Style_gb.TabIndex = 4;
            this.Style_gb.TabStop = false;
            this.Style_gb.Text = "Style";
            // 
            // Opacity_level
            // 
            this.Opacity_level.Location = new System.Drawing.Point(76, 19);
            this.Opacity_level.Maximum = 100;
            this.Opacity_level.Name = "Opacity_level";
            this.Opacity_level.Size = new System.Drawing.Size(177, 45);
            this.Opacity_level.TabIndex = 1;
            this.Opacity_level.Value = 100;
            this.Opacity_level.ValueChanged += new System.EventHandler(this.Opacity_level_ValueChanged);
            // 
            // Opacity_Lbl
            // 
            this.Opacity_Lbl.AutoSize = true;
            this.Opacity_Lbl.Location = new System.Drawing.Point(13, 29);
            this.Opacity_Lbl.Name = "Opacity_Lbl";
            this.Opacity_Lbl.Size = new System.Drawing.Size(43, 13);
            this.Opacity_Lbl.TabIndex = 0;
            this.Opacity_Lbl.Text = "Opacity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Option";
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Style_gb);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.SaveOP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Option_FormClosing);
            this.Load += new System.EventHandler(this.Option_Load);
            this.SaveOP.ResumeLayout(false);
            this.SaveOP.PerformLayout();
            this.Style_gb.ResumeLayout(false);
            this.Style_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opacity_level)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SaveOP;
        private System.Windows.Forms.CheckBox Exit_chbox;
        private System.Windows.Forms.CheckBox askDelete_chbox;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button Apply_btn;
        private System.Windows.Forms.GroupBox Style_gb;
        private System.Windows.Forms.TrackBar Opacity_level;
        private System.Windows.Forms.Label Opacity_Lbl;
        private System.Windows.Forms.Label label1;
    }
}