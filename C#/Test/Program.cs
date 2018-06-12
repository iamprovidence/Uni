using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 податкова веде реєстр об'єктів нерухомості. Об'єкт нерухомості(адреса, власник, площа)
 може бути 2 видів:
 - квартира
 - приватний будинок
 Адреса складається з міста, вулиці та номеру будинку.


    Дано список об'єктів нерухомості в реєстрі податкової

    1) нарахувати і вивести податок за об'єкти нерухомості із списку.
    У випадку квартири  податок рахується як: площа * ставка за податок* (20%, якщо має більше 2 кімнат)
    У приватному будинку: податок + площа * ставка податку.
    
    2) вивести назви міст, в якому найбільше об'єктів нерухомості з реєстру
    
    3)Посортувати за адресою
    
    4) як тільки змінюється власник — податкова надсилає повідослення власнику такого типу: 
    "Dear {OWNER} please do not forget to pay taxes for your new property locatd ar {ADDRESS}"
    За допомогою події просимулюємо зміну декількох власників, об'єктів нерухомості із списку 
    і вивести на екран всі повідомлення, які податкова мала б надіслати власникам 
     */


namespace kr
{       
    class Program
    {

        static void Main()
        {
            string[] text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras accumsan mi a quam viverra luctus. Suspendisse ut vulputate nisi, nec fermentum libero. Morbi sollicitudin, orci sit amet congue cursus, nibh nunc lobortis orci, et hendrerit arcu nunc a lorem. Curabitur dignissim risus non diam ornare mattis ac vitae elit. Suspendisse euismod gravida diam et varius. Sed quis commodo magna. Nunc a ex nec erat feugiat dapibus. Donec id nulla et dolor efficitur convallis. Maecenas vel sem neque. Vivamus volutpat quam ac urna condimentum, vitae posuere neque scelerisque. Aenean et lacinia dolor.".Split();
            string[] cityArr = { "Lviv", "Kyiv", "Ternopil", "New York", "Stambul", "Sambir" };

            const int REGISTRY_SIZE = 25;
            Random rand = new Random();

            // 1 
            List<IRealEstateObject> taxRegistry = new List<IRealEstateObject>();
            for (int i = 0; i < REGISTRY_SIZE; ++i)
            {
                if (rand.Next(0, 2) == 0)
                {
                    //Address address, Owner owner, int numberOfRooms, int square
                    taxRegistry.Add(new Apartment(
                        address: new Address(
                            city: cityArr[rand.Next(0, cityArr.Length)],
                            street: text[rand.Next(0, text.Length)],
                            houseNumber: rand.Next(0, 25)),
                        owner: new Owner(),
                        numberOfRooms: rand.Next(1, 5),
                        square: rand.Next(10, 50))
                    );
                }
                else
                {
                    //Address address, Owner owner, int square)
                    taxRegistry.Add(new PrivateHouse(
                        address: new Address(
                            city: cityArr[rand.Next(0, cityArr.Length)],
                            street: text[rand.Next(0, text.Length)],
                            houseNumber: rand.Next(0, 25)),
                        owner: new Owner(),
                        square: rand.Next(10, 50))
                    );
                }
            }

            taxRegistry.ForEach(c => Console.WriteLine(((IPayTaxes)c).tax()));
            Console.ReadKey();
            Console.Clear();

            // 2
            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (IRealEstateObject es in taxRegistry)
            {
                if (!d.ContainsKey(es.address.city)) d.Add(es.address.city, 0);
                else ++d[es.address.city];
            }


            taxRegistry.ForEach(Console.WriteLine);
            Console.WriteLine("CITY WITH BIGGEST AMOUNT OF ESTATE\t");
            Console.WriteLine(d.FirstOrDefault(x => x.Value == d.Values.Max()).Key);
            Console.ReadKey();
            Console.Clear();

            // 3
            Console.WriteLine("SORTED");
            taxRegistry.Sort();
            //taxRegistry.Sort(delegate(IRealEstateObject x, IRealEstateObject y) { return x.address.city.CompareTo(y.address.city); });
            taxRegistry.ForEach(Console.WriteLine);
            Console.ReadKey();
            Console.Clear();

            // 4 
            Owner previousOwner = taxRegistry[0].owner;
            taxRegistry[0].OwnerChange += taxRegistry[0].owner.GetNews;
            taxRegistry[0].owner = new Owner();
            taxRegistry[0].owner = new Owner();
            taxRegistry[0].OwnerChange -= previousOwner.GetNews;
            Console.WriteLine(previousOwner.GetAllMessage());

            Console.ReadLine();
        }
    }
}