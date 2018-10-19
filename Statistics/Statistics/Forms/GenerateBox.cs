using System;
using System.Windows.Forms;

namespace Statistics.Forms
{
    public partial class GenerateBox : Form
    {
        public GenerateBox()
        {
            InitializeComponent();
        }
        private void dataBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(aTb.Text);
                int b = int.Parse(bTb.Text);
                uint size = uint.Parse(sizeTb.Text);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Models.DataGenerator.WriteToFileData(a, b, size, saveFileDialog.FileName);
                }
            }
            catch (Exception ex) 
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void dataTableBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(a2Tb.Text);
                int b = int.Parse(b2Tb.Text);
                uint maxFrequency = uint.Parse(frTb.Text);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Models.DataGenerator.WriteToFileDataTable(a, b, maxFrequency, saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void gaussianBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double mu = double.Parse(muTb.Text);
                double sigma = double.Parse(sigmaTb.Text);
                uint size = uint.Parse(size2Tb.Text);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Models.DataGenerator.WriteGaussianToFileData(mu, sigma, size, saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void triangleBtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double a = int.Parse(a3Tb.Text);
                double b = int.Parse(b3Tb.Text);
                double c = int.Parse(c3Tb.Text);
                uint size = uint.Parse(size3Tb.Text);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Models.DataGenerator.WriteTriangleToFileData(a, b, c, size, saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
