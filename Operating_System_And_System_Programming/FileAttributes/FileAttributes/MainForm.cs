using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using FileAttributes.Controls;
using FileAttributes.DataModels;

namespace FileAttributes
{
    public partial class MainForm : Form
    {
        private double defaultValue;

        public MainForm()
        {
            InitializeComponent();
            InitializeFields();
        }

        private void InitializeFields()
        {
            this.defaultValue = 0;
        }

        private void setDefaultValueBtn_Click(object sender, EventArgs e)
        {
            defaultValue = (double)numericUpDown.Value;
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            UpdateInterface();
        }

        private void UpdateInterface()
        {
            string[] filePathes = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dat", SearchOption.AllDirectories);
            FileAttributesPanel[] fileAttributes = filePathes
                .Select(path => new FileAttributesModel(path, defaultValue))
                .Select((model, index) => new FileAttributesPanel(model)
                {
                    Width = this.fileAttributesPanel.Width - 20,
                    Height = 250,
                    Top = index * 250
                })
                .ToArray();

            fileAttributesPanel.Controls.Clear();
            fileAttributesPanel.Controls.AddRange(fileAttributes);
        }
    }
}
