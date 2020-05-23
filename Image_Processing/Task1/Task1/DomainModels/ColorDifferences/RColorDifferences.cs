using System;
using System.Drawing;

namespace Task1.DomainModels.ColorDifferences
{
    class RColorDifferences : ColorDifferenceBase
    {
        public override string Name => "R";

        public override Color GetDifference(Color first, Color second, int multiplier)
        {
            int r = Math.Abs(first.R - second.R);
            int g = 0;
            int b = 0;

            Normalize(ref r, ref g, ref b, multiplier);

            return Color.FromArgb(byte.MaxValue, r, g, b);
        }
    }
}