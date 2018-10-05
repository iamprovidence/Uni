using System.Windows.Forms;
using static System.Math;
using static System.Environment;

namespace IterativeMethods
{
    public partial class MainForm : Form
    {
        Equation equation;
        SystemOfEquations equationSystem;

        public MainForm()
        {
            InitializeComponent();            

            equation = new Equation(a: 0.5d, b: 3d)
            {
                EPS = 1e-6,
                Function = (x) => 1 / Tan(x) - x / 3,
                Derivetive = (x) => -1 / Pow(Sin(x), 2) - 1 / 3,
                DoubleDerivetive = (x) => 2 * Cos(x) / Pow(Sin(x), 3)
            };
            equationSystem = new SystemOfEquations(startX: 1, startY: -1)
            {
                EPS = 1e-6,

                F = (x, y) => x + Sin(y) + 0.4,
                G = (x, y) => 2 * y - Cos(x + 1),

                Fx = (y) => -Sin(y) - 0.4,
                Fdx = (x) => 1,
                Fdy = (y) => Cos(y),

                Gy = (x) => Cos(x + 1) / 2,
                Gdx = (x) => Sin(x + 1),
                Gdy = (y) => 2
            };
        }

        static void EquationMethodTest(EquationDelegate iterativeMethod, Label label)
        {
            uint iteration;

            label.Text = string.Concat(iterativeMethod.Method.Name,
                                       NewLine,
                                        $"X = {iterativeMethod(out iteration)}",
                                       NewLine,
                                        $"Iteration count = {iteration}");
        }
        static void EquationSystemMethodTest(EquationSystemDelegate iterativeMethod, Label label)
        {
            uint iteration;
            SystemOfEquations.XYPair xyPair = iterativeMethod(out iteration);

            label.Text = string.Concat(iterativeMethod.Method.Name,
                                       NewLine,
                                        $"X = {xyPair.X}",
                                       NewLine,
                                        $"Y = {xyPair.Y}",
                                       NewLine,
                                        $"Iteration count = {iteration}");
        }

        private void calcBtn1_Click(object sender, System.EventArgs e)
        {
            try
            {
                equation.A = double.Parse(aTb.Text);
                equation.B = double.Parse(bTb.Text);
                equation.EPS = double.Parse(epsTb1.Text);

                EquationMethodTest(equation.ChordMethod, chordMethodLbl);
                EquationMethodTest(equation.NewtonMethod, newtonMethodLbl);
                EquationMethodTest(equation.CombinedMethod, combinedChordTangentMethodLbl);

                glGraph1.Clear();
                glGraph1.ShowGraphs(new FancyControls.Data.Graph("ctg(x) - x/3").AddFunction(x => 1 / Tan(x) - x / 3, equation.A, equation.B));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void calcBtn2_Click(object sender, System.EventArgs e)
        {
            try
            {
                equationSystem.StartX = double.Parse(xTb.Text);
                equationSystem.StartY = double.Parse(yTb.Text);
                equationSystem.EPS = double.Parse(epsTb2.Text);

                EquationSystemMethodTest(equationSystem.IterativeMethod, iterativeMethodLbl);
                EquationSystemMethodTest(equationSystem.NewtonMethod, newtonMethodSystemLbl);

                glGraph2.Clear();
                glGraph2.ShowGraphs(new FancyControls.Data.Graph("cos(x + 1)/2").AddFunction(x => Cos(x + 1) / 2, -1.5, 1),
                                    new FancyControls.Data.Graph("arcSin(-0.4 - x)").AddFunction(x => Asin(-0.4 - x), -2, 1));

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
