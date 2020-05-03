using System;

namespace RunBatFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter bat file name: ");
            string batFile = Console.ReadLine();
            if (!System.IO.File.Exists(batFile))
            {
                Console.WriteLine("File does not exist");
                Console.ReadLine();
                return;
            }
            System.Diagnostics.Process.Start(batFile);
            Console.WriteLine("Enter any key to exit");
            Console.ReadKey();
        }
    }
}
