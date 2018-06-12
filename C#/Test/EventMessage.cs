using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    class EventMessage : EventArgs
    {
        public string message { get; }
        public EventMessage(string message)
        {
            this.message = message;
        }

    }
}
