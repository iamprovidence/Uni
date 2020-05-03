using System;
using System.IO;
using System.Linq;

namespace ToCom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter HEX file");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File does not exist");
                Console.ReadLine();
                return;
            }

            byte[] byteArr = File.ReadAllText(fileName)
                .Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => byte.Parse(c, System.Globalization.NumberStyles.HexNumber))
                .ToArray();

            Console.WriteLine("Enter output file name");
            string outFileName = Console.ReadLine();

            using (BinaryWriter writer = new BinaryWriter(File.Open($"{outFileName}.com", FileMode.OpenOrCreate)))
            {
                writer.Write(byteArr);
            }
        }
    }
}
