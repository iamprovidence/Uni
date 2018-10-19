using System.Windows.Forms.DataVisualization.Charting;

namespace Statistics.Controls
{
    public partial class ChartBox : System.Windows.Forms.UserControl, Interfaces.ICleanable
    {
        // FIELDS
        Models.DiscreteVariable discreteVariable;
        // PROPERTY
        public Models.DiscreteVariable DiscreteVariable
        {
            get
            {
                return discreteVariable;
            }
            set
            {
                discreteVariable = value;
                UpdateInterface();
            }
        }
        public bool IsDiscrete { get; set; }
        // CONSTRUCTORS
        public ChartBox()
        {
            InitializeComponent();
            InitializeFunctionChart();

            IsDiscrete = false;
        }
        public ChartBox(Models.DiscreteVariable dv)
        {
            InitializeComponent();
            InitializeFunctionChart();


            IsDiscrete = false;
            this.discreteVariable = dv;
        }
        // METHODS
        private void UpdateInterface()
        {
            CleanUp();
            if (discreteVariable != null)
            {
                polygonChart.BeginInit();
                diagramaChart.BeginInit();
                functionChart.BeginInit();
                sectorChart.BeginInit();

                diagramLbl.Text = IsDiscrete ? "Діаграма" : "Гістограма";

                System.Collections.Generic.KeyValuePair<double, int>[] table = DiscreteVariable.GetStatisticalTable();
                foreach (System.Collections.Generic.KeyValuePair<double, int> item in table)
                {
                    // polygon
                    polygonChart.Series[0].Points.AddXY(item.Key, item.Value);
                    // diagram
                    diagramaChart.Series[0].Points.AddXY(item.Key, item.Value);
                    // sector
                    sectorChart.Series[0].Points.AddXY(item.Key, (double)item.Value / discreteVariable.Size);
                }
                foreach (System.Collections.Generic.KeyValuePair<double, double> item in DiscreteVariable.GetCumulativeDistributionFunction())
                {
                    // function
                    functionChart.Series[0].Points.AddXY(item.Key, item.Value);
                }

                // hystogram settings
                if (!IsDiscrete)
                {
                    double h = table[1].Key - table[0].Key;
                    diagramaChart.ChartAreas[0].AxisX.Interval = h;
                    diagramaChart.ChartAreas[0].AxisX.IntervalOffset = 0;
                    diagramaChart.ChartAreas[0].AxisX.Minimum = table[0].Key - h;
                    diagramaChart.ChartAreas[0].AxisX.Maximum = table[table.Length - 1].Key + h;

                    diagramaChart.Series[0].Points.AddXY(table[table.Length - 1].Key + h, table[table.Length - 1].Value);
                    foreach (DataPoint point in diagramaChart.Series[0].Points)
                    {
                       point.XValue -= h / 2;
                    }
                }

                polygonChart.EndInit();
                diagramaChart.EndInit();
                functionChart.EndInit();
                sectorChart.EndInit();
            }
        }
        private void InitializeFunctionChart()
        {
            functionChart.BeginInit();

            functionChart.ChartAreas[0].AxisX.Crossing = 0;
            functionChart.ChartAreas[0].AxisY.Crossing = 0;

            functionChart.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
            functionChart.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;

            functionChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            functionChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            functionChart.EndInit();
        }
        public void CleanUp()
        {
            polygonChart.BeginInit();
            diagramaChart.BeginInit();
            sectorChart.BeginInit();
            functionChart.BeginInit();

            polygonChart.Series[0].Points.Clear();
            diagramaChart.Series[0].Points.Clear();
            sectorChart.Series[0].Points.Clear();
            functionChart.Series[0].Points.Clear();

            diagramaChart.ChartAreas[0].AxisX.Interval = 0;
            diagramaChart.ChartAreas[0].AxisX.IntervalOffset = 0;
            diagramaChart.ChartAreas[0].AxisX.Minimum = float.NaN;
            diagramaChart.ChartAreas[0].AxisX.Maximum = float.NaN;

            polygonChart.EndInit();
            diagramaChart.EndInit();
            sectorChart.EndInit();
            functionChart.EndInit();
        }
    }
}
