using System;
using System.Drawing;

namespace Task1.DomainModels.ColorDifferences
{
    class BColorDifferences : ColorDifferenceBase
    {
        public override string Name => "B";

        public override Color GetDifference(Color first, Color second, int multiplier)
        {
            int r = 0;
            int g = 0;
            int b = Math.Abs(first.B - second.B);

            Normalize(ref r, ref g, ref b, multiplier);

            return Color.FromArgb(byte.MaxValue, r, g, b);
        }
    }
}