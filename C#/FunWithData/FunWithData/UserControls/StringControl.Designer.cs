namespace FunWithData.UserControls
{
    partial class StringControl
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
            this.dataTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dataTb
            // 
            this.dataTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTb.Location = new System.Drawing.Point(0, 0);
            this.dataTb.Multiline = true;
            this.dataTb.Name = "dataTb";
            this.dataTb.Size = new System.Drawing.Size(156, 57);
            this.dataTb.TabIndex = 0;
            // 
            // StringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataTb);
            this.Name = "StringControl";
            this.Size = new System.Drawing.Size(156, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dataTb;
    }
}
