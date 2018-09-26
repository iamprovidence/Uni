using System;
using System.Drawing;

namespace FourForms
{
    class Radar : DrawBase
    {
        // FIELDS
        PointF center;
        PointF[] eightPoints;// net
        RectangleF[] ellipses;// circles
        int circleAmount;
        double angle;
        int arrowLenght;
        PointF endArrow;

        // CONSTRUCTORS
        public Radar(int width, int height) 
            : base(width, height)
        {
            angle = 0;
            ResetImage();
        }
        protected override void ResetImage()
        {
            center = new Point(Width / 2, Height / 2);
            eightPoints = new PointF[8];
            // net
            int k = 0;
            int lineLenght = width < height ? width / 2 : height / 2;// net lenght
            for (double angleLocal = 0; k < 8; angleLocal += Math.PI / 4, ++k)
            {
                eightPoints[k].X = (float)(center.X + lineLenght * Math.Cos(angleLocal));
                eightPoints[k].Y = (float)(center.Y + lineLenght * Math.Sin(angleLocal));
            }
            // circles
            circleAmount = 3;
            ellipses = new RectangleF[circleAmount];
            int circleOffset = width < height ? width / 2 : height / 2;
            for (int i = 0; i < circleAmount; ++i)
            {
                ellipses[i] = new RectangleF( center.X - circleOffset, center.Y - circleOffset, circleOffset * 2, circleOffset * 2);
                circleOffset /= (i + 2);
            }
            // running line
            arrowLenght = lineLenght - 10;
        }
        // METHODS
        public override void PerformStep()
        {
            angle -= 0.01;
            endArrow = new PointF((float)Math.Sin(angle) * arrowLenght, (float)Math.Cos(angle) * arrowLenght);
        }

        public override Bitmap Show()
        {
            graphics.Clear(Color.Black);
            // net
            for (int i = 0; i < eightPoints.Length / 2; ++i)// 4 lines
            {
                graphics.DrawLine(Pens.Green, eightPoints[i], eightPoints[i + 4]);
            }
            // circles
            for (int i = 0; i < ellipses.Length; ++i)// 3 circle
            {
                graphics.DrawEllipse(Pens.Green, ellipses[i]);
            }
            // running line
            graphics.DrawLine(Pens.ForestGreen, center.X, center.Y, center.X + endArrow.X, center.Y + endArrow.Y);

            return bitmap;
        }        
    }
}
