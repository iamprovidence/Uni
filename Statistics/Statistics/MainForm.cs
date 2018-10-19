using System;
using System.IO;
using System.Windows.Forms;

namespace Statistics
{
    public partial class MainForm : Form
    {
        // FIELDS
        Models.DiscreteVariable discreteVariable;
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            this.dataBox.Executed += DataBox_Executed;
        }
        private void DataBox_Executed(object sender, EventArgs e)
        {
            Reset();
            discreteVariable = dataBox.DiscreteVariable;
            // charting
            dataChartBox.IsDiscrete = dataBox.IsDiscrete;
            dataChartBox.DiscreteVariable = dataBox.DiscreteVariable;

            // statistics
            statisticsBox.DiscreteVariable = dataBox.DiscreteVariable;

            // pearsons test
            pearsonsTestBox.DiscreteVariable = dataBox.DiscreteVariable;
        }
        // METHODS
        // MENU
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discreteVariable = null;
            CleanUp();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CleanUp();
                dataBox.DataText = File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (discreteVariable == null)
            {
                DialogService.ShowErrorMessage("Дані відсутні");
                return;
            }

            using (Form saving = new Forms.SavingBox(discreteVariable))
            {
                saving.ShowDialog();
            }
        }
        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form generate = new Forms.GenerateBox())
            {
                generate.ShowDialog();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form about = new Forms.AboutBox())
            {
                about.ShowDialog();
            }
        }
        // OTHER METHODS     
        private void CleanUp()
        {
            dataBox.CleanUp();
            Reset();
        }
        private void Reset()
        {
            dataChartBox.CleanUp();
            statisticsBox.CleanUp();
            pearsonsTestBox.CleanUp();
        }
    }
}
