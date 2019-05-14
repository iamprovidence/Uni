using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using FiniteElementMethod.Models;
using FiniteElementMethod.Models.Structs;

namespace FiniteElementMethod.View.UserControls
{
    internal partial class InputData : System.Windows.Forms.UserControl
    {
        // FIELDS
        Reference<CoordinateSystemConfig> systemConfig;

        // CONSTRUCTORS
        public InputData(Reference<CoordinateSystemConfig> coordinateSystemConfig)
        {
            InitializeComponent();

            // configurate chart
            finiteElementChart.BeginInit();

            finiteElementChart.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
            finiteElementChart.ChartAreas[0].AxisX.Crossing = 0;
            finiteElementChart.ChartAreas[0].AxisX.LineWidth = 2;
            finiteElementChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;

            finiteElementChart.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;
            finiteElementChart.ChartAreas[0].AxisY.Crossing = 0;
            finiteElementChart.ChartAreas[0].AxisY.LineWidth = 2;
            finiteElementChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

            finiteElementChart.EndInit();

            // initialize fields
            systemConfig = coordinateSystemConfig;
        }

        // PROPERTIES
        public CoordinateSystemConfig CoordinateSystemConfig => systemConfig.Value;
               
        // METHODS
        private void saveChangesBtn_Click(object sender, System.EventArgs e)
        {
            // initialize system config
            try
            {
                systemConfig.Value = new CoordinateSystemConfig(
                    a: (double)aNumeric.Value,
                    b: (double)bNumeric.Value,
                    c: (double)cNumeric.Value,
                    d: (double)dNumeric.Value,
                    n: (int)nNumeric.Value,
                    m: (int)mNumeric.Value);
            }
            catch (System.ArithmeticException ex)
            {
                finiteElementChart.Series.Clear();

                System.Windows.Forms.MessageBox.Show(ex.Message);
                return;
            }

            // draw chart
            DrawFiniteElement();
        }
        private void DrawFiniteElement()
        {
            finiteElementChart.BeginInit();

            // clear chart
            finiteElementChart.Series.Clear();
            finiteElementChart.ResetAutoValues();
            
            // add horizontal lines
            for (double a = systemConfig.Value.A; a <= systemConfig.Value.B + systemConfig.Value.H1/2; a += systemConfig.Value.H1)
            {
                Series line = new Series()
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = Color.FromArgb(120, 240, 0) // green-ish
                };
                line.Points.AddXY(xValue: a, yValue: systemConfig.Value.C);
                line.Points.AddXY(xValue: a, yValue: systemConfig.Value.D);

                finiteElementChart.Series.Add(line);
            }
            // add vertical lines
            for (double c = systemConfig.Value.C; c <= systemConfig.Value.D + systemConfig.Value.H2/2; c += systemConfig.Value.H2)
            {
                Series line = new Series()
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = Color.FromArgb(120, 240, 0) // green-ish
                };
                line.Points.AddXY(xValue: systemConfig.Value.A, yValue: c);
                line.Points.AddXY(xValue: systemConfig.Value.B, yValue: c);

                finiteElementChart.Series.Add(line);
            }
            
            finiteElementChart.EndInit();
        }
    }
}
