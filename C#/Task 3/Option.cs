using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Task3
{
    public partial class Option : Form
    {
        private bool isSaved;

        public bool AskBeforeDel;
        public bool AskBeforeExit;
        public double opacityLevel;

        public event EventHandler<OptionArg> styleChanged;

        private void Option_Load(object sender, EventArgs e)
        {

            AskBeforeDel = false;
            AskBeforeExit = true;
            opacityLevel = (double) Opacity_level.Value / 100;

            Exit_chbox.Checked = true;

            IsSaved(true);
        }
        public Option()
        {
            InitializeComponent();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Apply_btn.PerformClick();
            Hide();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            AskBeforeExit = Exit_chbox.Checked;
            AskBeforeDel = askDelete_chbox.Checked;
            opacityLevel = (double)Opacity_level.Value / 100;
            this.Opacity = opacityLevel;
            styleChanged?.Invoke(this, new OptionArg(opacityLevel));

            IsSaved(true);
        }
        private void IsSaved(bool isSaved)
        {
            bool hasStar = Text.Contains('*');
            if (isSaved && hasStar) this.Text = this.Text.Remove(this.Text.Length - 1, 1);
            else if (!isSaved && !hasStar) this.Text += '*';

            this.isSaved = isSaved;
        }

        private void chbox_CheckedChanged(object sender, EventArgs e)
        {
            IsSaved(false);
        }

        private void Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true; // не закривати форму
        }

        private void Opacity_level_ValueChanged(object sender, EventArgs e)
        {
            IsSaved(false);
        }
    }
    public class OptionArg: EventArgs
    {
        public double Opacity { get; }
        public OptionArg(double op)
        {
            Opacity = op;
        }
    }
}
