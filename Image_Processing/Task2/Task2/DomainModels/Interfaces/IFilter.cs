using System.Drawing;

namespace Task2.DomainModels.Interfaces
{
    interface IFilter
    {
        string Name { get; }

        Bitmap Filter(Bitmap image);
    }
}
