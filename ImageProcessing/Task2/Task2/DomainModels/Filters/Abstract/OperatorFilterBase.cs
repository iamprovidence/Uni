using System;
using System.Drawing;

using Task2.DomainModels.Interfaces;

namespace Task2.DomainModels.Filters.Abstract
{
    abstract class OperatorFilterBase : IFilter
    {
        public abstract string Name { get; }

        protected abstract int[,] GetHorizontalFilterMatrix();
        protected abstract int[,] GetVerticalFilterMatrix();

        public Bitmap Filter(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            int[,] xFilterMatrix = GetHorizontalFilterMatrix();
            int[,] yFiltermatrix = GetVerticalFilterMatrix();

            int operatorMatrixSize = GetMatrixSize(xFilterMatrix, yFiltermatrix) - 1;

            Color[,] pixels = GetCachedPixels(image);

            for (int i = 1; i < image.Width - 1; ++i)
            {
                for (int j = 1; j < image.Height - 1; ++j)
                {
                    int Rx = 0, Ry = 0;
                    int Gx = 0, Gy = 0;
                    int Bx = 0, By = 0;
                    for (int x = -1; x < operatorMatrixSize; ++x)
                    {
                        for (int y = -1; y < operatorMatrixSize; ++y)
                        {
                            Color pixel = pixels[i + y, j + x];

                            int xFilterValue = xFilterMatrix[x + 1, y + 1];
                            int yFilterValue = yFiltermatrix[x + 1, y + 1];

                            // accumulate
                            Rx += xFilterValue * pixel.R;
                            Ry += yFilterValue * pixel.R;

                            Gx += xFilterValue * pixel.G;
                            Gy += yFilterValue * pixel.G;

                            Bx += xFilterValue * pixel.B;
                            By += yFilterValue * pixel.B;
                        }
                    }
                    
                    result.SetPixel(i, j, Color.FromArgb(ColorCast(Rx, Ry), ColorCast(Gx, Gy), ColorCast(Bx, By)));
                }
            }
            return result;
        }

        private int GetMatrixSize(int[,] horizontal, int[,] vertical)
        {
            if (horizontal.GetLength(0) != horizontal.GetLength(1)) throw new ArgumentException("Horizontal matrix should be square");
            if (vertical.GetLength(0) != vertical.GetLength(1))     throw new ArgumentException("Vertical matrix should be square");
            if (horizontal.GetLength(0) != vertical.GetLength(0))   throw new ArgumentException("Matrices should have same sizes");

            return horizontal.GetLength(0);
        }

        private Color[,] GetCachedPixels(Bitmap image)
        {
            Color[,] pixels = new Color[image.Width, image.Height];
            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    pixels[i, j] = image.GetPixel(i, j);
                }
            }
            return pixels;
        }

        protected virtual int ColorCast(double cx, double cy)
        {
            double number = Math.Sqrt(cx * cx + cy * cy);

            return (int)Math.Min(number, 255);
        }
    }
}
