using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AssemblyCompiler.Models;

namespace AssemblyCompiler
{
    public partial class MainForm : Form
    {
        VirtualMachine virtualMachine;
        string[] codeToTranslate;

        public MainForm()
        {
            InitializeComponent();
            InitializeFields();
        }

        private void InitializeFields()
        {
            this.virtualMachine = new VirtualMachine();
            this.codeToTranslate = Enumerable.Empty<string>().ToArray();
        }

        private void outputPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInterface(this.codeToTranslate);
        }

        private void compileBtn_Click(object sender, EventArgs e)
        {
            this.codeToTranslate = assemblyTb.Lines;

            UpdateInterface(this.codeToTranslate);
        }

        private void UpdateInterface(string[] codeLines)
        {
            if (!codeLines.Any()) return;

            string[] output = TryTranslate(codeLines);

            if (outputPanel.SelectedIndex == 0)
            {
                binaryResultTb.Lines = output;
            }
            else
            {
                hexResultTb.Lines = output.Select(ConvertToHex).ToArray();
            }
        }

        private string ConvertToHex(string line)
        {
            string combinedLine = line.Replace(" ", string.Empty);
            string[] hex = Enumerable
                .Range(0, combinedLine.Length / 8)
                .Select(i => combinedLine.Substring(8 * i, 8))
                .Select(s => Convert.ToByte(s, 2))
                .Select(b => b.ToString("X2"))
                .ToArray();

            return string.Join(" ", hex);
        }


        private string[] TryTranslate(string[] codeLines)
        {
            try
            {
                return virtualMachine.Translate(codeLines);
            }
            catch (Exception ex)
            {
                string errorMessage = GetErrorMessage(ex);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            return Enumerable.Empty<string>().ToArray();
        }

        private string GetErrorMessage(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (Exception ex = exception; ex != null; ex = ex.InnerException)
            {
                stringBuilder.AppendLine(ex.Message);
            }
            return stringBuilder.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!this.codeToTranslate.Any())
            {
                MessageBox.Show("Code is required", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate)))
                {
                    string[] output = TryTranslate(codeToTranslate);
                    
                    byte[] byteArr = output
                        .Select(ConvertToHex)
                        .SelectMany(hexLine => hexLine.Split())
                        .Select(c => byte.Parse(c, System.Globalization.NumberStyles.HexNumber))
                        .ToArray();

                    writer.Write(byteArr);
                }
            }
        }
    }
}
