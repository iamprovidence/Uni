namespace Statistics.Controls
{
    public partial class StatisticsBox : System.Windows.Forms.UserControl, Interfaces.ICleanable
    {
        // FIELDS
        private Models.DiscreteVariable discreteVariable;
        private bool isCalculated;
        // CONSTRUCTORS
        public StatisticsBox()
        {
            InitializeComponent();
            isCalculated = false;
            discreteVariable = null;
        }
        // PROPERTIES
        public Models.DiscreteVariable DiscreteVariable
        {
            get
            {
                return discreteVariable;
            }
            set
            {
                discreteVariable = value;
                isCalculated = false;
                CleanUp();
                UpdateInterface();
            }
        }
        // METHODS
        public void CleanUp()
        {
            // 1 tab
            volumeLbl.Text = "0";
            rowTb.Clear();
            statTableDgv.Rows.Clear();
            statTableDgv.Columns.Clear();
            this.statTableDgv.Columns.Add(this.cl1);
            // 2 tab
            medianaLbl.Text = "0";
            modaLbl.Text = "0";
            averageLbl.Text = "0";
            // 3 tab
            devLbl.Text = "0";
            dfLbl.Text = "0";
            variansaLbl.Text = "0";
            standartLbl.Text = "0";
            spreadLbl.Text = "0";
            variationLbl.Text = "0";
            // 4 tab
            xTb.Clear();
            qTb.Clear();
            bigQTb.Clear();
            OTb.Clear();
            DTb.Clear();
            CTb.Clear();
            MTb.Clear();
            xToQLbl.Text = "0";
            qLbl.Text = "0";
            bigQLbl.Text = "0";
            OLbl.Text = "0";
            DLbl.Text = "0";
            CLbl.Text = "0";
            MLbl.Text = "0";

            // 5 tab
            momentATb.Clear();
            momentHTb.Clear();
            momentMHTb.Clear();
            moment_mHTb.Clear();

            momentMLbl.Text = "0";
            moment_mLbl.Text = "0";
            momentCenterMLbl.Text = "0";

            m1Lbl.Text = "0";
            m2Lbl.Text = "0";
            m3Lbl.Text = "0";
            m4Lbl.Text = "0";
            Moment1Lbl.Text = "0";
            Moment2Lbl.Text = "0";
            Moment3Lbl.Text = "0";
            Moment4Lbl.Text = "0";
            // 6 tab
            assymetricLbl.Text = "0";
            eksLbl.Text = "0";

        }

        public void UpdateInterface()
        {
            if (discreteVariable != null && !isCalculated)
            {
                // calc 1 tab
                volumeLbl.Text = discreteVariable.Size.ToString();
                rowTb.Text = string.Join(" ", discreteVariable.GetVariationSeries());
                System.Collections.Generic.KeyValuePair<double, int>[] table = discreteVariable.GetStatisticalTable();

                statTableDgv.Rows.Add();
                statTableDgv.Rows.Add();
                statTableDgv[statTableDgv.ColumnCount - 1, 0].Value = "x";
                statTableDgv[statTableDgv.ColumnCount - 1, 1].Value = "n";
                foreach (var item in table)
                {
                    statTableDgv.ColumnCount += 1;
                    statTableDgv[statTableDgv.ColumnCount - 1, 0].Value = item.Key.ToString();
                    statTableDgv[statTableDgv.ColumnCount - 1, 1].Value = item.Value.ToString();
                }
                // calc 2 tab
                medianaLbl.Text = discreteVariable.Me.ToString();
                modaLbl.Text = string.Join(" ", discreteVariable.Mo);
                averageLbl.Text = discreteVariable._x.ToString();

                // calc 3 tab
                devLbl.Text = discreteVariable.Dev.ToString();
                dfLbl.Text = discreteVariable.d_f.ToString();
                variansaLbl.Text = discreteVariable.s2.ToString();
                standartLbl.Text = discreteVariable.s.ToString();
                spreadLbl.Text = discreteVariable.p.ToString();
                variationLbl.Text = discreteVariable.V.ToString();

                // calc 4 tab
                // nothing to calc
                // its interquantility latitudes, that are calculated dynamicly

                // calc 5 tab
                m1Lbl.Text = discreteVariable.mh(1).ToString();
                m2Lbl.Text = discreteVariable.mh(2).ToString();
                m3Lbl.Text = discreteVariable.mh(3).ToString();
                m4Lbl.Text = discreteVariable.mh(4).ToString();

                Moment1Lbl.Text = discreteVariable.Mh(1).ToString();
                Moment2Lbl.Text = discreteVariable.Mh(2).ToString();
                Moment3Lbl.Text = discreteVariable.Mh(3).ToString();
                Moment4Lbl.Text = discreteVariable.Mh(4).ToString();

                // calc 6 tab
                assymetricLbl.Text = discreteVariable.As.ToString();
                eksLbl.Text = discreteVariable.Ek.ToString();

                isCalculated = true;
            }
        }
        
        // interquantility latitudes
        private void xTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                xToQLbl.Text = discreteVariable.x(int.Parse(xTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void qTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                qLbl.Text = discreteVariable.q(int.Parse(qTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void bigQTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                bigQLbl.Text = discreteVariable.Q(int.Parse(bigQTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void OTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                OLbl.Text = discreteVariable.O(int.Parse(OLbl.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void DTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                DLbl.Text = discreteVariable.D(int.Parse(DTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void CTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                CLbl.Text = discreteVariable.C(int.Parse(CTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void MTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                MLbl.Text = discreteVariable.M(int.Parse(MTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }
        // moments
        private void calcMomentBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                momentMLbl.Text = discreteVariable.Mh(int.Parse(momentHTb.Text), double.Parse(momentATb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void moment_mHTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                moment_mLbl.Text = discreteVariable.mh(int.Parse(moment_mHTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }

        private void momentMHTb_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                momentCenterMLbl.Text = discreteVariable.Mh(int.Parse(momentMHTb.Text)).ToString();
            }
            catch (System.Exception ex)
            {
                DialogService.ShowErrorMessage(ex.Message);
            }
        }
    }
}
