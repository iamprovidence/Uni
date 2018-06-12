using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    interface IRealEstateObject
    {
        Address address { get; }
        Owner owner { get; set; }
        int square { get; }

        event EventHandler<EventMessage> OwnerChange;
    }
}
