namespace Statistics.Controls
{
    public partial class PearsonsTestBox : System.Windows.Forms.UserControl, Interfaces.ICleanable
    {
        Models.DiscreteVariable discreteVariable;
        Models.PearsonsTest pearsonsTest;

        public PearsonsTestBox()
        {
            InitializeComponent();

            discreteVariable = null;
            pearsonsTest = null;
        }
        public Models.DiscreteVariable DiscreteVariable
        {
            get
            {
                return discreteVariable;
            }
            set
            {
                discreteVariable = value;
                try
                {
                    if (value != null) pearsonsTest = new Models.PearsonsTest(discreteVariable);
                }
                catch (System.Exception ex)
                {
                    DialogService.ShowErrorMessage(ex.Message);
                }
                CleanUp();
            }
        }

        public void CleanUp()
        {
            probabilityTb.Clear();
            resLbl.Text = string.Empty;
            xeLbl.Text = "0";
            xkrLbl.Text = "0";
            rLb.Text = "0";
        }

        private void probabilityTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                double Xe = pearsonsTest.XiE;
                double Xc = pearsonsTest.XiC(double.Parse(probabilityTb.Text));

                xeLbl.Text = System.Math.Round(Xe, 4).ToString();
                xkrLbl.Text = System.Math.Round(Xc, 4).ToString();
                rLb.Text = discreteVariable.d_f.ToString();

                if (pearsonsTest.CheckH0(Xe, Xc))
                {
                    resLbl.Text = "Приймаємо гіпотезу";
                    resLbl.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    resLbl.Text = "Відхиляємо гіпотезу";
                    resLbl.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
