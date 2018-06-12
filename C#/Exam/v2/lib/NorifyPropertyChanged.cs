using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class NorifyPropertyChanged: EventArgs
    {
        private string message;
        public string Message => message;

        public NorifyPropertyChanged(object PropertyName, object OldValue, object NewValue)
        {
            message = $"Property named \'{PropertyName.ToString()}\' chage value from \'{OldValue.ToString()}\' to \'{NewValue.ToString()}\' ";
        }
    }
}
