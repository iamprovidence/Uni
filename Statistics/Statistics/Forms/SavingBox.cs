using System;
using System.Windows.Forms;

namespace Statistics.Forms
{
    public partial class SavingBox : Form
    {
        Models.DiscreteVariable dv;

        public SavingBox()
        {
            InitializeComponent();
        }
        public SavingBox(Models.DiscreteVariable dv)
        {
            InitializeComponent();
            this.dv = dv;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Models.DataGenerator.WriteToFileDataTable(dv.GetStatisticalTable(), saveFileDialog.FileName);
            }
            this.Close();
        }

        private void rowBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Models.DataGenerator.WriteToFileData(dv.GetVariationSeries(), saveFileDialog.FileName);
            }
            this.Close();
        }
    }
}
