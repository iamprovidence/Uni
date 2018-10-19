using System;
using System.Windows.Forms;

namespace Statistics.Controls
{
    public partial class DataBox : UserControl, Interfaces.ICleanable
    {
        public Models.DiscreteVariable DiscreteVariable { get; private set; }
        public event EventHandler Executed;
        public string DataText
        {
            set
            {
                dataTb.Text = value;
            }
            get
            {
                return dataTb.Text;
            }
        }
        public bool IsDiscrete => discreteRb.Checked;
        public DataBox()
        {
            InitializeComponent();

            DiscreteVariable = null;
        }
        private void executeData_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowRb.Checked == true)
                {
                    DiscreteVariable = Models.DiscreteVariable.OperateData(DataText);
                }
                else
                {
                    DiscreteVariable = Models.DiscreteVariable.OperateTableData(DataText.Split('\n'));
                }

                if (continuousRb.Checked == true)
                {
                    DiscreteVariable = Models.СontinuousToDiscrete.ContinuosToDiscrete(DiscreteVariable);
                }
                Executed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }
        public void CleanUp()
        {
            DataText = String.Empty;
            rowRb.Checked = true;
            discreteRb.Checked = true;
        }
    }
}
