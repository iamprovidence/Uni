using System;
using System.Drawing;

namespace Task1.DomainModels.ColorDifferences
{
    class RGBColorDifferences : ColorDifferenceBase
    {
        public override string Name => "RGB";

        public override Color GetDifference(Color first, Color second, int multiplier)
        {
            int r = Math.Abs(first.R - second.R);
            int g = Math.Abs(first.G - second.G);
            int b = Math.Abs(first.B - second.B);

            Normalize(ref r, ref g, ref b, multiplier);

            return Color.FromArgb(byte.MaxValue, r, g, b);
        }
    }
}
