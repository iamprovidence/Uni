using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person: IPersonality
    {
        protected string name;
        protected int age;

        protected event EventHandler<NorifyPropertyChanged> propertyChangedBase;
        public virtual event EventHandler<NorifyPropertyChanged> propertyChanged
        {
            add
            {
                propertyChangedBase += value;
            }
            remove
            {
                propertyChangedBase -= value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if(name.CompareTo(value) != 0)
                {

                    string oldName = name;
                    name = value;
                    propertyChangedBase?.Invoke(this, new NorifyPropertyChanged(nameof(Name), oldName, value));
                }
            }
        }

        public Person()
        {
            name = String.Empty;
            age = int.MinValue;
        }
        public Person(string[] data)
        {
            name = data[0];
            age = int.Parse(data[1]);
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (age.CompareTo(value) != 0)
                {
                    int oldAge = age;
                    age = value;
                    propertyChangedBase?.Invoke(this, new NorifyPropertyChanged(nameof(Age), oldAge, value));
                }
            }
        }

        public override string ToString()
        {
            return $"Person {Name} at age {Age}";
        }
        public virtual string ToFile()
        {
            return $"P*{Name} {Age}";
        }
        public int CompareTo(IPersonality other)
        {
            int nameComp = Name.CompareTo(other.Name);
            if (nameComp == 0) return Age.CompareTo(other.Age);
            else return nameComp;
        }
    }
}
