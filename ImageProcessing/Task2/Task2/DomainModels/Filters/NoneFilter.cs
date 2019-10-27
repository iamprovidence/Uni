using System.Drawing;

namespace Task2.DomainModels.Filters
{
    class NoneFilter : Interfaces.IFilter
    {
        public string Name => "None";

        public Bitmap Filter(Bitmap image)
        {
            return image;
        }
    }
}
