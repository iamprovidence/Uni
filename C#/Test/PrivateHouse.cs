using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    class PrivateHouse : IRealEstateObject, IPayTaxes, IComparable
    {
        public Address address
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
        readonly static public int taxRate2;

        public event EventHandler<EventMessage> OwnerChange;

        public double tax()
        {
            return taxRate + square * taxRate2;
        }
        public PrivateHouse(Address address, Owner owner, int square)
        {
            this.address = address;
            this.owner = owner;
            this.square = square;
        }
        static PrivateHouse()
        {
            taxRate = 12;
            taxRate2 = 20;
        }

        public int CompareTo(object obj)
        {
            IRealEstateObject a = obj as IRealEstateObject;

            return address.CompareTo(a.address);
        }

        public override string ToString()
        {
            return "Private House\n" + address.ToString();
        }
    }
}
