using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public interface IPersonality: IComparable<IPersonality>
    {
        string Name { get; set; }
        int Age { get; set; }
        event EventHandler<NorifyPropertyChanged> propertyChanged;
        string ToFile();
    }
}
