using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    class Apartment : IRealEstateObject, IPayTaxes, IComparable
    {
        public Address address
        {
            get;
            private set;
        }

        public int numberOfRooms
        {
            get;
            private set;
        }
        Owner realOwner;
        public Owner owner
        {
            get { return realOwner; }
            set
            {
                realOwner = value;
                OwnerChange?.Invoke(this, new EventMessage(this.address.ToString()));
            }
        }


        public int square
        {
            get;
            private set;
        }

        readonly static public int taxRate;

        public event EventHandler<EventMessage> OwnerChange;

        public Apartment(Address address, Owner owner, int numberOfRooms, int square)
        {
            this.address = address;
            this.owner = owner;
            this.numberOfRooms = numberOfRooms;
            this.square = square;
        }
        static Apartment()
        {
            taxRate = 15;
        }

        public double tax()
        {
            return numberOfRooms >= 2 ? square * taxRate * 0.8 : square * taxRate;
        }

        public int CompareTo(object obj)
        {
            IRealEstateObject a = obj as IRealEstateObject;

            return address.CompareTo(a.address);
        }
        public override string ToString()
        {
            return "Apartment \n" + address.ToString();
        }
    }
}
