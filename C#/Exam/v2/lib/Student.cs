using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Student: Person
    {
        private int totalMark;
        protected event EventHandler<NorifyPropertyChanged> propertyChangedChild;

        public override event EventHandler<NorifyPropertyChanged> propertyChanged
        {
            add
            {
                propertyChangedBase += value;
                propertyChangedChild += value;
            }
            remove
            {
                propertyChangedBase -= value;
                propertyChangedChild -= value;
            }
        }

        public Student():base()
        {
            totalMark = int.MinValue;
        }
        public Student(string[] data):base(data)
        {
            totalMark = int.Parse(data[2]);
        }

        public int TotalMark
        {
            get
            {
                return totalMark;
            }

            set
            {
                if (totalMark.CompareTo(value) != 0)
                {
                    int OldValue = totalMark;
                    totalMark = value;

                    propertyChangedChild?.Invoke(this, new NorifyPropertyChanged(nameof(TotalMark), OldValue, value));
                }
            }
        }
        public override string ToString()
        {
            return $"Person {Name} at age {Age} with mark {totalMark}";
        }
        public override string ToFile()
        {
            return $"S*{Name} {Age} {TotalMark}";
        }
    }
}
