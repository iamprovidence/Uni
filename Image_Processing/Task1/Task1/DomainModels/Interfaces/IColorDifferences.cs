using System.Drawing;

namespace Task1.DomainModels.Interfaces
{
    interface IColorDifferences
    {
        string Name { get; }

        Color GetDifference(Color first, Color second, int multiplier);
    }
}
