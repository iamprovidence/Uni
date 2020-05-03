using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

using TextFiles.Extensions;

namespace TextFiles
{
    public partial class MainForm : Form
    {
        private string filePath;
        private Encoding encoding;

        public MainForm()
        {
            InitializeComponent();
            InitializeFields();
            UpdateInterface();
        }

        private void InitializeFields()
        {
            filePath = null;
            encoding = Encoding.ASCII;
        }

        private void UpdateInterface()
        {
            formatBtn.Text = encoding.ToPrettyString();

            if (string.IsNullOrWhiteSpace(filePath)) return;

            this.Text = Path.GetFileName(filePath);
            this.fileOutputTb.Text = File.ReadAllText(filePath, encoding);
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePath = openFileDialog.FileName;

                UpdateInterface();
            }
        }

        private void formatBtn_Click(object sender, EventArgs e)
        {
            encoding = (encoding == Encoding.ASCII) ? Encoding.Unicode : Encoding.ASCII;

            UpdateInterface();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePath = saveFileDialog.FileName;

                File.WriteAllText(filePath, fileOutputTb.Text, encoding);

                UpdateInterface();
            }
        }
    }
}
