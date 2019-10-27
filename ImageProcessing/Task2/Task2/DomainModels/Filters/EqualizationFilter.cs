using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Task2.DomainModels.Filters
{
    class EqualizationFilter : Interfaces.IFilter
    {
        public string Name => "Equalization";

        public Bitmap Filter(Bitmap image)
        {
            Bitmap result = image.Clone() as Bitmap;

            Rectangle rect = new Rectangle(0, 0, result.Width, result.Height);
            BitmapData bmpData = result.LockBits(rect, ImageLockMode.ReadWrite, result.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytesLength = bmpData.Stride * result.Height;

            byte[] grayValues = new byte[bytesLength];
            int[] R = new int[256];
            byte[] N = new byte[256];
            byte[] left = new byte[256];
            byte[] right = new byte[256];
            Marshal.Copy(ptr, grayValues, 0, bytesLength);

            for (int i = 0; i < grayValues.Length; ++i)
            {
                ++R[grayValues[i]];
            }

            int z = 0;
            int Hint = 0;
            int Havg = grayValues.Length / R.Length;

            for (int i = 0; i < R.Length; ++i)
            {
                if (z > 255) left[i] = 255;
                else         left[i] = (byte)z;

                Hint += R[i];
                while (Hint > Havg)
                {
                    Hint -= Havg;
                    ++z;
                }

                if (z > 255) right[i] = 255;
                else         right[i] = (byte)z;

                N[i] = (byte)((left[i] + right[i]) / 2);
            }

            for (int i = 0; i < grayValues.Length; ++i)
            {
                if (left[grayValues[i]] == right[grayValues[i]]) grayValues[i] = left[grayValues[i]];
                else                                             grayValues[i] = N[grayValues[i]];
            }

            Marshal.Copy(grayValues, 0, ptr, bytesLength);
            result.UnlockBits(bmpData);
            return result;
        }
    }
}
