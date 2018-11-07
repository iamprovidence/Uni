using FillingInYourDataBase.Entities;
using System.Collections.Generic;

namespace FillingInYourDataBase
{
    class EntitiesGenerator
    {
        System.Random random = new System.Random();
        DATA dataGnerator = new DATA();


        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            int bookAmount = random.Next(1, 40);
            for (int i = 0; i < bookAmount; ++i)
            {
                int amount = random.Next(20, 100);
                books.Add(new Book()
                {
                    Name = dataGnerator.GetBookName(),
                    TotalAmount = amount,
                    AmountToReadHome = random.Next(amount),
                    AmountToRepair = random.Next(0, 5),
                    Year = random.Next(1900, 2020),
                    ISBN = dataGnerator.GetISBN()
                });
            }
            return books;
        }
        public Author GetAuthor(List<Book> books)
        {         
            return new Author()
            {
                Name = dataGnerator.GetName(),
                Surname = dataGnerator.GetSurname(),
                Books = books
            };
        }
        public PublishingHouse GetPublishingHouse()
        {
            return new PublishingHouse()
            {
                Name = dataGnerator.GetPublishingHouseName(),
                Country = dataGnerator.GetCountry()
            };
        }
        public Reader GetReader()
        {

            return new Reader()
            {
                Name = dataGnerator.GetName(),
                Surname = dataGnerator.GetSurname(),
                Age = random.Next(8, 18),
                CityName = dataGnerator.GetCity(),
                Code = dataGnerator.GetCode(),
                PhoneNumber = dataGnerator.GetPhone()
            };
        }
        public Abonnement GetAbonnement()
        {
            int takeDate = random.Next(1, 20);
            string takeBookDate = $"{takeDate}/4/2018";
            string returnBookDate = random.NextDouble()< 0.5? null : $"{takeDate + random.Next(2, 8)}/4/2018";

            return new Abonnement()
            {
                BookAmount = random.Next(1, 12),
                TakeBookDate = takeBookDate,
                ReturnBookDate = returnBookDate
            };
        }
    }
}
