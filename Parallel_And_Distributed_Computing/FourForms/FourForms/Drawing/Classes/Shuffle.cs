using System;
using System.Drawing;

namespace FourForms
{
    class Shuffle : DrawBase
    {
        // FIELDS
        Random random;
        int arraySize;
        Rectangle[] rectangles;
        int stepIndex;
        int i, j;
        SolidBrush selectedBrush;
        Action[] steps;
        // CONSTRUCTORS
        public Shuffle(int width, int height) 
            : base(width, height)
        {
            random = new Random();
            stepIndex = 0;
            i = j = -1;
            selectedBrush = new SolidBrush(Color.Red);
            steps = new Action[] { ResetIndex, SelectI, SelectJ, Swapping, SwappingComplete };
            // array filling
            arraySize = 6;
            ResetImage();
        }
        protected override void ResetImage()
        {
            rectangles = new Rectangle[arraySize];
            int colWidth = width / arraySize;
            for (int i = 0; i < arraySize; ++i)
            {
                rectangles[i] = new Rectangle(
                    width: colWidth,
                    x: i * colWidth,

                    height: (i + 1) * height / (arraySize + 1),
                    y: height - (i + 1) * height / (arraySize + 1));
            }
        }
        // PROPERTIES
        private int StepIndex
        {
            get
            {
                return stepIndex;
            }
            set
            {
                stepIndex = value;
                stepIndex %= steps.Length;
            }
        }
        // METHODS
        public override void PerformStep()
        {
            steps[StepIndex++].Invoke();
        }

        public override Bitmap Show()
        {
            graphics.Clear(Color.Black);

            graphics.FillRectangles(Brushes.Gray, rectangles);
            if (i != -1)
            {
                graphics.FillRectangle(selectedBrush, rectangles[i]);
            }
            if (j != -1)
            {
                graphics.FillRectangle(selectedBrush, rectangles[j]);
            }
            graphics.DrawRectangles(Pens.GhostWhite, rectangles);

            return bitmap;
        }
        private void ResetIndex()
        {
            i = j = -1;
            selectedBrush.Color = Color.Red;
        }
        private void SelectI()
        {
            i = random.Next(arraySize);
        }
        private void SelectJ()
        {
            do
            {
                j = random.Next(arraySize);
            } while (j == i);
        }
        private void Swapping()
        {
            int tempY = rectangles[i].Y;
            int tempHeight = rectangles[i].Height;
            
            rectangles[i].Y = rectangles[j].Y;
            rectangles[i].Height = rectangles[j].Height;
            
            rectangles[j].Y = tempY;
            rectangles[j].Height = tempHeight;
        }
        private void SwappingComplete()
        {
            selectedBrush.Color = Color.Green;
        }
        public override void Dispose()
        {
            selectedBrush.Dispose();
            base.Dispose();
        }
    }
}
