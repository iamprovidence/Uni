using System.Threading;
using static System.Math;
using NumericalIntegration.Models;
using MathFunc = System.Func<double, double>;

namespace NumericalIntegration
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        // CONST
        readonly static string CLEAR_VALUE_LBL = "0";
        // FIELDS
        readonly double a;
        readonly double b;
        readonly double eps;
        readonly MathFunc f;
        NumericalIntegrationMethods methods;
        Thread[] threads;
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            // initialize fields
            a = -1D;
            b = 1D;
            eps = 1e-5;
            f = (x) => x * Pow(3, x);
            methods = new NumericalIntegrationMethods(a, b)
            {
                F = f,
                EPS = eps
            };

            // draw graphic
            glGraph.ShowGraphs(new FancyControls.Data.Graph("x * 3 ^ x") { LineWidth = 5 }.AddFunction(f, a, b),
                new FancyControls.Data.Graph("square", FancyControls.Data.GraphType.Area).AddFunction(f, a, b));
        }
        private void InitializeThreads()
        {
            AbortThread();

            threads = new Thread[5];
            threads[0] = new Thread(CalcRectangle);
            threads[1] = new Thread(CalcTrapeze);
            threads[2] = new Thread(CalcSimpson);
            threads[3] = new Thread(CalcGaussFour);
            threads[4] = new Thread(CalcGaussFifth);
        }
        private void AbortThread()
        {
            if (threads != null)
            {
                foreach (Thread thread in threads)
                {
                    if (thread.ThreadState == ThreadState.Running)
                    {
                        thread.Abort();
                    }
                }
            }
        }
        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.AbortThread();
        }
        // METHODS
        private void calcBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                methods.EPS = double.Parse(epsTb.Text);
                this.Clear();
                this.InitializeThreads();

                foreach (Thread method in threads)
                {
                    method.Start();
                }          
            }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void CalcRectangle()
        {
            try
            {
                NumericMethodResult rectRes = methods.TestMethod(methods.Rectangle);

                Invoke((System.Action)delegate
                {
                    rectResLbl.Text = rectRes.S.ToString();
                    rectCallLbl.Text = rectRes.CallAmount.ToString();
                    rectIterLbl.Text = rectRes.IterationAmount.ToString();
                });
            }
            catch (ThreadAbortException) { }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void CalcTrapeze()
        {
            try
            {
                NumericMethodResult trapezeRes = methods.TestMethod(methods.Trapeze);

                Invoke((System.Action)delegate
                {
                    trapezeResLbl.Text = trapezeRes.S.ToString();
                    trapezeCallLbl.Text = trapezeRes.CallAmount.ToString();
                    trapezeIterLbl.Text = trapezeRes.IterationAmount.ToString();
                });
            }
            catch (ThreadAbortException) { }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void CalcSimpson()
        {
            try
            {
                NumericMethodResult parabolaRes = methods.TestMethod(methods.Parabola);

                Invoke((System.Action)delegate
                {
                    parabResLbl.Text = parabolaRes.S.ToString();
                    parabCallLbl.Text = parabolaRes.CallAmount.ToString();
                    parabIterLbl.Text = parabolaRes.IterationAmount.ToString();
                });
            }
            catch (ThreadAbortException) { }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void CalcGaussFour()
        {
            try
            {
                NumericMethodResult gauss4Res = methods.TestMethod(methods.GaussFour);

                Invoke((System.Action)delegate
                {
                    gauss4ResLbl.Text = gauss4Res.S.ToString();
                    gauss4CallLbl.Text = gauss4Res.CallAmount.ToString();
                    gauss4Iterlbl.Text = gauss4Res.IterationAmount.ToString();
                });
            }
            catch (ThreadAbortException) { }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        private void CalcGaussFifth()
        {
            try
            {
                NumericMethodResult gauss5Res = methods.TestMethod(methods.GaussFifth);

                Invoke((System.Action)delegate
                {
                    gauss5ResLbl.Text = gauss5Res.S.ToString();
                    gauss5CallLbl.Text = gauss5Res.CallAmount.ToString();
                    gauss5IterLbl.Text = gauss5Res.IterationAmount.ToString();
                });
            }
            catch (ThreadAbortException) { }
            catch (System.Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }

        private void Clear()
        {
            // rect
            rectResLbl.Text = CLEAR_VALUE_LBL;
            rectCallLbl.Text = CLEAR_VALUE_LBL;
            rectIterLbl.Text = CLEAR_VALUE_LBL;
            // trapeze
            trapezeResLbl.Text = CLEAR_VALUE_LBL;
            trapezeCallLbl.Text = CLEAR_VALUE_LBL;
            trapezeIterLbl.Text = CLEAR_VALUE_LBL;
            // parabola
            parabResLbl.Text = CLEAR_VALUE_LBL;
            parabCallLbl.Text = CLEAR_VALUE_LBL;
            parabIterLbl.Text = CLEAR_VALUE_LBL;
            // 4 Gauss
            gauss4ResLbl.Text = CLEAR_VALUE_LBL;
            gauss4CallLbl.Text = CLEAR_VALUE_LBL;
            gauss4Iterlbl.Text = CLEAR_VALUE_LBL;
            // 5 Gauss
            gauss5ResLbl.Text = CLEAR_VALUE_LBL;
            gauss5CallLbl.Text = CLEAR_VALUE_LBL;
            gauss5IterLbl.Text = CLEAR_VALUE_LBL;
        }
        private void ErrorMessage(string message, string header = "Error")
        {
            System.Windows.Forms.MessageBox.Show(message, header,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
    }
}
