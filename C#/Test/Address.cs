using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    class Address : IComparable<Address>
    {
        public string city
        {
            get;
            private set;
        }
        public string street
        {
            get;
            private set;
        }
        public int houseNumber
        {
            get;
            private set;
        }

        public Address(string city, string street, int houseNumber)
        {
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
        }

        public int CompareTo(Address other)
        {
            if (this.city.CompareTo(other.city) != 0) return this.city.CompareTo(other.city);
            else if (this.street.CompareTo(other.street) != 0) return this.street.CompareTo(other.street);
            else return this.houseNumber.CompareTo(other.houseNumber);
        }
        public override string ToString()
        {
            return String.Concat("City\t", city, "\nStreet\t", street, "\nHouse Number\t", houseNumber);
        }
    }
}
