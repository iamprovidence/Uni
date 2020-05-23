using System;
using System.Drawing;

namespace Task1.DomainModels.ColorDifferences
{
    abstract class ColorDifferenceBase : Interfaces.IColorDifferences
    {
        public abstract string Name { get; }
        public abstract Color GetDifference(Color first, Color second, int multiplier);

        protected void Normalize(ref int r, ref int g, ref int b,int multiplier)
        {
            r *= multiplier;
            g *= multiplier;
            b *= multiplier;

            r = Math.Min(r, 255);
            g = Math.Min(g, 255);
            b = Math.Min(b, 255);
        }
    }
}
