using System.IO;
using _9_10.Models;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Drawing.Color;
using System.Windows.Forms.DataVisualization.Charting;
using ProectionMethod = System.Func<_9_10.Models.Matrix>;

namespace _9_10
{
    public partial class MainForm : Form
    {
        // FIELDS
        System.Drawing.Color nodeColor;
        System.Drawing.Color parabolaColor;
        Proection proectionOption;
        ProectionMethod proection;
        Point[] nodes;
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            // initialize fields
            nodeColor = Red;
            parabolaColor = Green;
            proectionOption = new Proection();
            proection = proectionOption.Ortogonal;
            nodes = null;

            // config graphic
            graphicChart.ChartAreas[0].AxisX.Crossing = 0;
            graphicChart.ChartAreas[0].AxisY.Crossing = 0;

            graphicChart.ChartAreas[0].AxisX.RoundAxisValues();
            // config view
            tLb.SelectedIndex = 0;

            // add default point
            AddPoint(-3, -1, -1);
            AddPoint(-2, 1, 2);
            AddPoint(0, -2, 2);
            AddPoint(1, 3, 0);
            AddPoint(2, 1, -5);
            AddPoint(3, 0, 2);
            AddPoint(4, 2, 1);
            AddPoint(5, -2, 3);
        }
        // METHODS
        private void pointLb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // get derivative
            int selectedIndex = pointLb.SelectedIndex;
            if (selectedIndex  != -1 && nodes != null)
            {
                // get 4 point for interpolation
                List<Point> interpol = new List<Point>(4);

                // move left
                int i = selectedIndex;
                while (i > 0 && interpol.Count < 4) interpol.Add(nodes[i--]);
                // move right
                i = selectedIndex;
                while (i < nodes.Length && interpol.Count < 4) interpol.Add(nodes[i++]);

                interpol.Sort();

                // get 3 point for parabola
                List<Point> parab = new List<Point>(3);

                // move right
                i = selectedIndex;
                while (i < nodes.Length && parab.Count < 3) parab.Add(nodes[i++]);
                // move left
                i = selectedIndex;
                while (i > 0 && parab.Count < 3) parab.Add(nodes[i--]);

                parab.Sort();


                int qPointIndex = interpol.IndexOf(nodes[selectedIndex]);
                Matrix qDeriv = InterpolateBase.CalcDerivative(interpol);
                qLbl.Text = string.Concat('(', string.Join(" , ", qDeriv[qPointIndex, 0], qDeriv[qPointIndex, 1], qDeriv[qPointIndex, 2]), ')');

                int pPointIndex = parab.IndexOf(nodes[selectedIndex]);
                Matrix pDeriv = InterpolateBase.CalcDerivative(parab);
                pLbl.Text = string.Concat('(', string.Join(" , ", pDeriv[pPointIndex, 0], pDeriv[pPointIndex, 1], pDeriv[pPointIndex, 2]), ')');

            }
            else
            {
                ClearDerivativeLabel();
            }

        }
        private void addPointBtn_Click(object sender, System.EventArgs e)
        {
            try
            {            
                AddPoint(
                    X: double.Parse(xTb.Text), 
                    Y: double.Parse(yTb.Text),
                    Z: double.Parse(zTb.Text));
            }
            catch (System.Exception ex)
            {
                OnError(ex.Message);
            }
        }
        private void AddPoint(double X, double Y, double Z)
        {
            pointDgv.Rows.Add(X, Y, Z);
            pointLb.Items.Add(pointDgv.RowCount);
        }
        private void removePointBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (pointDgv.CurrentRow != null)
                {
                    pointDgv.Rows.Remove(pointDgv.CurrentRow);
                    pointLb.Items.RemoveAt(pointLb.Items.Count - 1);
                }
            }
            catch (System.Exception ex)
            {
                OnError(ex.Message);
            }
        }

        private void drawBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (pointDgv.RowCount < 4)
                {
                    OnError("Should be at least 4 point");
                    return;
                }
                
                SetUpInputsPoint();
                DrawGraphic();
            }
            catch (System.Exception ex)
            {
                OnError(ex.Message);
            }

        }
        private void SetUpInputsPoint()
        {
            pointDgv.Sort(pointDgv.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            nodes = pointDgv.Rows
                .OfType<DataGridViewRow>()
                .Select(row => new Point
                (
                    x: double.Parse(row.Cells[0].Value.ToString()),
                    y: double.Parse(row.Cells[1].Value.ToString()),
                    z: double.Parse(row.Cells[2].Value.ToString())
                ))
                .ToArray();
        }
        // drawing method
        private void DrawGraphic()
        {
            // drawing graphic
            graphicChart.BeginInit();
            graphicChart.Series.Clear();


            // show parabolas
            // DrawParabolasByPointMyVersion();
            DrawParabolasByPoint();
            // showing parabolic interpolation
            DrawParabolicInterpolation(parabolaColor);
            // show nodes
            DrawNodes(nodeColor);


            // graphic drawing ended
            graphicChart.EndInit();
        }
        private void DrawNodes(System.Drawing.Color color)
        {
            Series nodesGraph = new Series("nodes")
            {
                ChartType = SeriesChartType.Point,
                Color = color
            };

            for (int i = 0; i < this.nodes.Length; ++i)
            {
                Point node = (nodes[i] * proection()).Normalize();
                nodesGraph.Points.AddXY(node.X, node.Y);
            }
            graphicChart.Series.Add(nodesGraph);
        }
        private void DrawParabolasByPointMyVersion()
        {
            for (int i = 2; i < nodes.Length; ++i)
            {
                // config parabold
                MyParabola parabola = new MyParabola(nodes[i - 2], nodes[i - 1], nodes[i]);
                Series parabolaGraphic = new Series(i.ToString())
                {
                    ChartType = SeriesChartType.Line
                };
                // searching points between 3 point
                // to create parabola
                for (double x = nodes[i - 2].X; x < nodes[i].X; x += 0.01)
                {
                    parabolaGraphic.Points.AddXY(x, parabola.GetY(x));
                }
                graphicChart.Series.Add(parabolaGraphic);
            }
        }
        private void DrawParabolasByPoint()
        {
            for (int i = 2; i < nodes.Length; ++i)
            {
                // config parabold
                Parabola parabola = new Parabola(nodes[i - 2], nodes[i - 1], nodes[i]);
                Series parabolaGraphic = new Series(i.ToString() + 'p')
                {
                    ChartType = SeriesChartType.Line
                };
                // searching points between 3 point
                // to create parabola
                for (double s = 0; s <= 1; s += 0.01)
                {
                    Point p = (parabola.GetPoint(s) * proection()).Normalize();
                    parabolaGraphic.Points.AddXY(p.X, p.Y);
                }
                graphicChart.Series.Add(parabolaGraphic);
            }
        }
        private void DrawParabolicInterpolation(System.Drawing.Color color)
        {
            Series parabolicInterpolationGraphic = new Series("Interpolation")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = color
            };
            for (int i = 3; i < nodes.Length; ++i)
            {
                // config parabolic interpolation
                ParabolicInterpolation parabolicInterpolation
                    = new ParabolicInterpolation(nodes[i - 3], nodes[i - 2], nodes[i - 1], nodes[i]);

                for (double t = 0; t <= 1; t += 0.01)
                {
                    Point p = (parabolicInterpolation.CalcPolynomial(t) * proection()).Normalize();
                    parabolicInterpolationGraphic.Points.AddXY(
                        xValue: p.X,
                        yValue: p.Y);
                }              
            }

            graphicChart.Series.Add(parabolicInterpolationGraphic);
        }

        // menu
        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clear();
        }

        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Clear();
                foreach (Point point in File.ReadAllLines(openFileDialog.FileName).Select(Point.Parse))
                {
                    AddPoint(point.X, point.Y, point.Z);
                } 
            }
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetUpInputsPoint();
                File.WriteAllLines(saveFileDialog.FileName, nodes.Select(point => point.ToString()));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void nodeColorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                nodeColor = colorDialog.Color;
                DrawGraphic();
            }
        }

        private void parabolaColorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                parabolaColor = colorDialog.Color;
                DrawGraphic();
            }
        }
        // additional methods
        private void OnError(string message, string header = "Error")
        {
            MessageBox.Show(message, header,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }
        private void Clear()
        {
            pointDgv.Rows.Clear();
            pointLb.Items.Clear();
            graphicChart.Series.Clear();
            xTb.Text = string.Empty;
            yTb.Text = string.Empty;
            tLb.SelectedIndex = -1;
            ClearDerivativeLabel();
        }
        private void ClearDerivativeLabel()
        {
            qLbl.Text = "0";
            pLbl.Text = "0";
        }
        // proection changed
        private void ortogonalToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Ortogonal;
            drawBtn.PerformClick();
        }

        private void perspectiveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Perspective;
            drawBtn.PerformClick();
        }

        private void izometrical453526ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Izometrical;
            drawBtn.PerformClick();
        }

        private void diametrical12926ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Dimetrical1;
            drawBtn.PerformClick();
        }

        private void diametrical22926ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Dimetrical2;
            drawBtn.PerformClick();
        }

        private void diametrical32926ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Dimetrical3;
            drawBtn.PerformClick();
        }

        private void diametrical42926ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            proection = proectionOption.Dimetrical4;
            drawBtn.PerformClick();
        }

    }
}
