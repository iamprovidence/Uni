using System.Drawing;
using System.Windows.Forms;

namespace Bonus
{
    public partial class MainForm : Form
    {
        // CONSTS
        readonly string TIME_MESSAGE_FORMAT = "Time {0}";
        readonly string SQUARE_MESSAGE_FORMAT = "Square {0:F2}";

        // FIELDS
        Classes.Polygon polygon1;
        Classes.Polygon polygon2;
        Classes.Polygon collided;

        int maxTime;
        int timeCounter;
        double currentSquare;

        Graphics graphics;

        double maxSquare;
        int timeMoment;

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            graphics = displayPb.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            SetDefaultValues();
        }
        private void MainForm_Shown(object sender, System.EventArgs e)
        {
            polygonPanel1.Commit();
            polygonPanel2.Commit();

            polygon1 = polygonPanel1.Polygon;
            polygon2 = polygonPanel2.Polygon;
            collided = null;

            polygonPanel1.Commited += PolygonPanel1_Commited;
            polygonPanel2.Commited += PolygonPanel2_Commited;

            maxTime = System.Math.Min(polygon1.StepsAmount, polygon2.StepsAmount);
            timeCounter = 0;
            currentSquare = 0;

            timer.Start();
        }
        private void SetDefaultValues()
        {
            // 1
            polygonPanel1.Text = "Polygon 1";
            polygonPanel1.Add(170, 400);
            polygonPanel1.Add(160, 430);
            polygonPanel1.Add(126, 460);
            polygonPanel1.Add(84, 450);
            polygonPanel1.Add(20, 340);
            polygonPanel1.Add(100, 340);

            polygonPanel1.SetDefaultStartPosition(100, 400);
            polygonPanel1.SetDefaultEndPosition(400, 50);
            polygonPanel1.SetDefaultStepsAmount(10);
            polygonPanel1.SetDefaultColorPicker(Color.FromArgb(150, 0, 150, 255));

            // 2
            polygonPanel2.Text = "Polygon 2";
            polygonPanel2.Add(400, 400);
            polygonPanel2.Add(440, 450);
            polygonPanel2.Add(300, 310);
            polygonPanel2.Add(450, 350);

            polygonPanel2.SetDefaultStartPosition(380, 370);
            polygonPanel2.SetDefaultEndPosition(60, 50);
            polygonPanel2.SetDefaultStepsAmount(10);
            polygonPanel2.SetDefaultColorPicker(Color.FromArgb(150, 0, 255, 150));
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            polygon1?.Dispose();
            polygon2?.Dispose();
            collided?.Dispose();
            graphics?.Dispose();
        }

        // PROPERTIES
        public double MaxSquare
        {
            get
            {
                return maxSquare;
            }
            set
            {
                if (value > maxSquare)
                {
                    maxSquare = value;
                    squareLbl.Text = maxSquare.ToString("F2");
                    TimeMoment = timeCounter;
                }
            }
        }
        public int TimeMoment
        {
            get
            {
                return timeMoment;
            }
            set
            {
                if (value != timeMoment)
                {
                    timeMoment = value;
                    timeLbl.Text = timeMoment.ToString();
                }
            }
        }
        // METHODS
        private void PolygonPanel1_Commited(object sender, System.EventArgs e)
        {
            polygon1.Dispose();
            polygon1 = polygonPanel1.Polygon;

            Reset();
        }
        private void PolygonPanel2_Commited(object sender, System.EventArgs e)
        {
            polygon2.Dispose();            
            polygon2 = polygonPanel2.Polygon;

            Reset();
        }
        private void Reset()
        {
            polygon1.Reset();
            polygon2.Reset();

            maxTime = System.Math.Min(polygon1.StepsAmount, polygon2.StepsAmount);

            displayPb.Invalidate();

            timer.Start();
            timeCounter = 0;

            MaxSquare = 0;
            TimeMoment = 0;
        }
        private void timer_Tick(object sender, System.EventArgs e)
        {
            polygon1.PerformStep();
            polygon2.PerformStep();

            displayPb.Invalidate();

            ++timeCounter;
            if (maxTime == timeCounter)
            {
                timeCounter = 0;
            }
        }
        // PAINTING
        private void displayPb_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.LightGray);
            try
            {
                // check for collision
                collided?.Dispose();
                Classes.CollisionOption collisionOption = Classes.Polygon.Collided(polygon1, polygon2);
                if (collisionOption.Collided == true)
                {
                    // collision point
                    foreach (var item in collisionOption.Points)
                    {
                        graphics.FillEllipse(Brushes.Red, item.X - 2, item.Y - 2, 4, 4);
                    }
                    // collision area
                    collided = Classes.Polygon.CollidedZone(collisionOption.Points);
                    currentSquare = collided.S;
                    MaxSquare = currentSquare;
                }
                else
                {
                    collided = null;
                    currentSquare = 0;
                }

                // showing all
                polygon1?.Show(graphics);
                polygon2?.Show(graphics);
                collided?.Show(graphics);
                // text
                graphics.DrawString(string.Format(TIME_MESSAGE_FORMAT, timeCounter), this.Font, Brushes.Black, 15, 10);
                graphics.DrawString(string.Format(SQUARE_MESSAGE_FORMAT, currentSquare), this.Font, Brushes.Black, 15, 30);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, ex.TargetSite.Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                timer.Stop();
                timeCounter = 0;
                return;
            }
        }

        private void displayPb_SizeChanged(object sender, System.EventArgs e)
        {
            graphics.Dispose();

            graphics = displayPb.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }
    }
}
