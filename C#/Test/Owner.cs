using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    class Owner
    {
        List<string> message = new List<string>();

        string name = $"Owner {id++}";
        static int id = 1;

        public void GetNews(object o, EventMessage e)
        {
            message.Add(String.Format("Dear {0}, please do not forget to pay taxes for your new property locatd at {1}", name, e.message));
        }
        public string GetAllMessage()
        {
            string mes = String.Empty;
            foreach (string s in message)
            {
                mes += s + Environment.NewLine;
            }
            return mes;
        }

    }
}
