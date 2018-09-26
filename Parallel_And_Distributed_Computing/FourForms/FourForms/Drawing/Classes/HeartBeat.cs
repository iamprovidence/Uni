using System.Linq;
using System.Drawing;

namespace FourForms
{
    class HeartBeat : DrawBase
    {
        delegate void RefAction<T>(ref T item);
        // FIELDS
        Point[] points;
        RefAction<Point> direction;
        int stepsDone;
        int[] stepsLengthConfig;
        int stepIndex;
        // CONSTRUCTORS
        public HeartBeat(int width, int height) : base(width, height)
        {            
            ResetImage();
            // how much step should be done to change direction
            // first number stand for straightforward moving
            // if you want to stay at one line, sum of [1, 3, ...] shoud be equal to [2, 4, ...]
            stepsLengthConfig = new int[7] { 70, 2, 5, 20, 30, 25, 12 };        
        }
        protected override void ResetImage()
        {
            stepsDone = 0;
            stepIndex = 0;
            direction = StraightForward;
            points = new Point[width*2];
            for (int i = 0; i < points.Length; ++i)
            {
                points[i] = new Point(i/4, height / 2);
            }
        }
        // METHODS
        public override void PerformStep()
        {
            // do move for last point
            direction(ref points[points.Length - 1]);
            // copy path
            for (int i = 0; i < points.Length - 1; ++ i)
            {
                points[i].Y = points[i + 1].Y;
            }
            // calc steps and change direction
            ++stepsDone;
            if (stepsDone == stepsLengthConfig[stepIndex])
            {
                SwitchDirection();
                ++ stepIndex;
                stepsDone = 0;
                // if cicle is done...
                if (stepIndex == stepsLengthConfig.Length)
                {
                    // ... repeat it
                    direction = StraightForward;
                    stepIndex = 0;
                }
            }
        }
        public override Bitmap Show()
        {
            graphics.Clear(Color.Black);
            for (int i = 0; i < points.Length; ++i)
            {
                graphics.FillRectangle(Brushes.Red, points[i].X, points[i].Y - 1, 1, 3);
            }
            graphics.FillEllipse(Brushes.Yellow, points.Last().X - 4, points.Last().Y - 4, 8, 8);
            graphics.DrawEllipse(Pens.Red, points.Last().X - 4, points.Last().Y - 4, 8, 8);
            return bitmap;
        }
        private void SwitchDirection()
        {
            if (direction == Down) direction = Up;
            else direction = Down;
        }
        private void Down(ref Point p) => ++p.Y;
        private void Up(ref Point p) => --p.Y;
        private void StraightForward(ref Point p) {}// do not change point
    }
}
