using System;
using System.Drawing;

namespace FourForms
{
    class PurpleRain : DrawBase
    {
        // INNER CLASSES
        struct Drop
        {
            // FIELDS
            Random random;
            Graphics graphic;
            PointF point;
            int dropLength;
            float speed;
            // PROPERTIRS
            public int MaxHeight { get; set; }
            // CONSTRUCTORS
            public Drop(float x, float y, int height, Graphics graphic, Random random)
            {
                this.random = random;
                this.graphic = graphic;
                this.point = new PointF(x, y);
                this.dropLength = 15;
                this.speed = 10;
                this.MaxHeight = height;
            }
            // METHODS
            public void Fall()
            {
                point.Y += speed;

                if (point.Y > MaxHeight)
                {
                    this.point.Y = random.Next(-200, -50);
                }
            }
            public void Show()
            {
                graphic.DrawLine(Pens.Purple, point.X, point.Y, point.X, point.Y + dropLength);
            }
        }
        // FIELDS
        Drop[] drops;
        int dropsAmount;
        Random random;
        // CONSTRUCTORS
        public PurpleRain(int width, int height) 
            : base(width, height)
        {
            random = new Random();
            dropsAmount = 200;
            drops = new Drop[dropsAmount];
            // Initialize new drops
            ResetImage();
        }
        protected override void ResetImage()
        {
            for (int i = 0; i < dropsAmount; ++i)
            {
                drops[i] = new Drop(random.Next(width), random.Next(-200, -50), height, graphics, random);
            }
        }
        // METHODS
        public override void PerformStep()
        {
            for (int i = 0; i < dropsAmount; ++i)
            {
                drops[i].Fall();
            }
        }

        public override Bitmap Show()
        {
            graphics.Clear(Color.Black);
            for (int i = 0; i < dropsAmount; ++i)
            {
                drops[i].Show();
            }
            return bitmap;
        }        
    }
}
