using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(boardSize: 5);
            b.Run(2, 2);

            Console.ReadLine();

        }
    }
}
