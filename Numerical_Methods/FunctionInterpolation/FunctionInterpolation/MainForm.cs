using FancyControls.Data;
using static System.Math;
using System.Collections.Generic;
using static System.Drawing.Color;
using MathFunc = System.Func<double, double>;

namespace FunctionInterpolation
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        // FIELDS
        double a;
        double b;
        int N;
        double eps;
        MathFunc f;
        InterpolationMethods methods;
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            // configure the graphic
            glGraph.AxisX.TitleAlignment = TitleAlignment.NearAxisArrow;
            glGraph.AxisX.Title = "X";
            glGraph.AxisY.TitleAlignment = TitleAlignment.NearAxisArrow;
            glGraph.AxisY.Title = "Y";

            // initialize fields
            a = -1D;
            b = 1D;
            N = 20;
            eps = 1e-15;
            f = (x) => x * Pow(3, x);
            methods = new InterpolationMethods(a, b, N, f);

            DrawGraphics();
        }

        private void calcBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                double x = double.Parse(xTb.Text);
                if (x < a || x > b)
                {
                    ErrorMessage("x є [a, b]");
                    return;
                }

                eps = double.Parse(epsTb.Text);
                double fRes = f(x);

                // finite difference
                List<string> finiteDifferenceOrder = new List<string>();
                (double y, int n) newtonRes = methods.NewtonForward(x, eps, finiteDifferenceOrder);
                SetFiniteDifferenceOrder(newtonFiniteOrderTb, finiteDifferenceOrder);

                (double y, int n) gaussRes = methods.GaussForward(x, eps, finiteDifferenceOrder);
                SetFiniteDifferenceOrder(gaussFiniteOrderTb, finiteDifferenceOrder);
                finiteDifferenceOrder = null;

                // res
                functionResLbl.Text = fRes.ToString();
                newtonResultLbl.Text = newtonRes.y.ToString();
                gaussResultLbl.Text = gaussRes.y.ToString();

                // members number
                newtonMemberCountLbl.Text = newtonRes.n.ToString();
                gaussMemberCountLbl.Text = gaussRes.n.ToString();

                // mistake
                newtonMistakeLbl.Text = Abs(fRes - newtonRes.y).ToString();
                gaussMistakeLbl.Text = Abs(fRes - gaussRes.y).ToString();

                DrawGraphics();
            }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void DrawGraphics()
        {
            glGraph.Clear();
            // nodes
            Graph nodes = new Graph("x*3^x", GraphType.Point)
            {
                LineWidth = 4,
                LineColor = FromArgb(65, 140, 240) // blue-ish
            };

            for (double x = methods.A; x < methods.B; x += methods.H)
            {
                nodes.AddPoint(x, methods.F(x));
            }
            // newton
            Graph newton = new Graph("Newton Forward", GraphType.Line)
            {
                LineWidth = 6,
                LineColor = FromArgb(173, 210, 96) // green-ish
            };
            for (double x = this.a; x < this.b; x += 0.01)
            {
                newton.AddPoint(x, methods.NewtonForward(x, eps).y);
            }
            // gauss
            Graph gauss = new Graph("Gauss Forward", GraphType.Line)
            {
                LineWidth = 2,
                LineColor = FromArgb(239, 89, 62) // red-ish                
            };
            for (double x = this.a; x < this.b; x += 0.01)
            {
                gauss.AddPoint(x, methods.GaussForward(x, eps).y);
            }

            glGraph.ShowGraphs(newton, gauss, nodes);
        }
        private void ErrorMessage(string message, string header = "Error")
        {
            System.Windows.Forms.MessageBox.Show(message, header,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
        private void SetFiniteDifferenceOrder(System.Windows.Forms.TextBox textBox, ICollection<string> finiteDifference)
        {
            textBox.Text = string.Join(" , ", finiteDifference);
            finiteDifference.Clear();
        }
    }
}
