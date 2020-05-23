using System.Drawing;

namespace Task1.DomainModels.Models
{
    class ColorDifference
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        public void Accumulate(Color color)
        {
            R += color.R;
            G += color.G;
            B += color.B;
        }

        public void Reduce(int divider)
        {
            R /= divider;
            G /= divider;
            B /= divider;
        }
    }
}
