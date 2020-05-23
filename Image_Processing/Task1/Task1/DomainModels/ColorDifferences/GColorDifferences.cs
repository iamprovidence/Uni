using System;
using System.Drawing;

namespace Task1.DomainModels.ColorDifferences
{
    class GColorDifferences : ColorDifferenceBase
    {
        public override string Name => "G";

        public override Color GetDifference(Color first, Color second, int multiplier)
        {
            int r = 0;
            int g = Math.Abs(first.G - second.G);
            int b = 0;

            Normalize(ref r, ref g, ref b, multiplier);

            return Color.FromArgb(byte.MaxValue, r, g, b);
        }
    }
}