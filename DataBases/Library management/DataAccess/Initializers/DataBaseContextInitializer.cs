using System.Data.Entity;

using DataAccess.Context;


namespace DataAccess.Initializers
{
    internal class DataBaseContextInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            // COUNTRIES
            Entities.Country[] countries = new Entities.Country[]
            {
                new Entities.Country () { Name = "Albania" },
                new Entities.Country () { Name = "Austria" },
                new Entities.Country () { Name = "Canada" },
                new Entities.Country () { Name = "Germany" },
                new Entities.Country () { Name = "Italy" },
                new Entities.Country () { Name = "Ukraine" }
            };
            context.Countries.AddRange(countries);

            // CATEGORIES
            Entities.Category[] categories = new Entities.Category[]
            {
                new Entities.Category () { Name = "Novel" },
                new Entities.Category () { Name = "Poems" }
            };
            context.Categories.AddRange(categories);

            // GENRES
            Entities.Genre[] genres = new Entities.Genre[]
            {
                new Entities.Genre () { Name = "Fantasy" },
                new Entities.Genre () { Name = "Mystery" },
                new Entities.Genre () { Name = "Detective story" },
            };
            context.Genres.AddRange(genres);

            // AUTHORS
            Entities.Author[] authors = new Entities.Author[]
            {
                new Entities.Author () { Name = "Howard", Surname = "Lovecraft", Nickname = "Howard Phillips Lovecraft" },
                new Entities.Author () { Name = "Stephen", Surname = "King", Nickname = "Stephen Edwin King" },
                new Entities.Author () { Name = "Edgar", Surname = "Poe", Nickname = "Edgar Allan Poe" },
            };
            context.Authors.AddRange(authors);

            // PUBLISHING HOUSES
            Entities.PublishingHouse[] publishingHouses = new Entities.PublishingHouse[]
            {
                new Entities.PublishingHouse () { Name = "Wiley", Country = countries[0] },
                new Entities.PublishingHouse () { Name = "Bertelsmann", Country = countries[3] },
                new Entities.PublishingHouse () { Name = "Thomson Reuters", Country = countries[2] },
            };
            context.PublishingHouses.AddRange(publishingHouses);

            // BOOK
            Entities.Book[] books = new Entities.Book[]
            {
                new Entities.Book ()
                {
                    Name = "The Call of Cthulhu",
                    Amount = 23,
                    Year = 1995,
                    Authors = new [] { authors[0] },
                    PublishingHouses = new Entities.PublishingHouse[] { publishingHouses[0] },
                    Categories = new Entities.Category[] { categories[0] },
                    Genres = new Entities.Genre[] { genres[0], genres[1] }
                },

                new Entities.Book ()
                {
                    Name = "The Shining",
                    Amount = 23,
                    Year = 1993,
                    Authors = new [] { authors[1] },
                    PublishingHouses = new Entities.PublishingHouse[] { publishingHouses[1] },
                    Categories = new Entities.Category[] { categories[0] },
                    Genres = new Entities.Genre[] { genres[1] }
                },

                new Entities.Book ()
                {
                    Name = "It",
                    Amount = 23,
                    Year = 1978,
                    Authors = new [] { authors[1] },
                    PublishingHouses = new Entities.PublishingHouse[] { publishingHouses[2] },
                    Categories = new Entities.Category[] { categories[0] },
                    Genres = new Entities.Genre[] { genres[1] }
                },

                new Entities.Book ()
                {
                    Name = "The Raven",
                    Amount = 23,
                    Year = 1990,
                    Authors = new [] { authors[2] },
                    PublishingHouses = new Entities.PublishingHouse[] { publishingHouses[0] },
                    Categories = new Entities.Category[] { categories[1] },
                    Genres = new Entities.Genre[] { genres[1] } },
            };
            context.Books.AddRange(books);

            // READERS
            Entities.Reader[] readers = new Entities.Reader[]
            {
                new Entities.Reader ()
                {
                    Name = "John",
                    Surname ="Doe",
                    Address = "Lorem Ipsum",
                    Phone = "3809912345"
                },
                new Entities.Reader ()
                {
                    Name = "Jane",
                    Surname ="Doe",
                    Address = "Dolor sit amet",
                    Phone = "3809812345"
                },
            };
            context.Readers.AddRange(readers);

            // ABONNEMENTS
            Entities.Abonnement[] abonnements = new Entities.Abonnement[]
            {
                new Entities.Abonnement ()
                {
                    Reader = readers[0],
                    Book = books[0],
                    TakeTime = new System.DateTime(year: 2019, month: 2, day: 23),
                    TakenPeriod = new System.DateTime(year: 2019, month: 2, day: 27)
                },
                new Entities.Abonnement ()
                {
                    Reader = readers[1],
                    Book = books[1],
                    TakeTime = new System.DateTime(year: 2019, month: 2, day: 23),
                    TakenPeriod = new System.DateTime(year: 2019, month: 2, day: 27),
                    ReturnTime = new System.DateTime(year: 2019, month: 2, day: 25)
                },
                new Entities.Abonnement ()
                {
                    Reader = readers[0],
                    Book = books[2],
                    TakeTime = new System.DateTime(year: 2019, month: 2, day: 23),
                    TakenPeriod = new System.DateTime(year: 2019, month: 2, day: 27),
                    ReturnTime = new System.DateTime(year: 2019, month: 2, day: 28)
                },
                new Entities.Abonnement ()
                {
                    Reader = readers[0],
                    Book = books[3],
                    TakeTime = new System.DateTime(year: 2019, month: 2, day: 23),
                    TakenPeriod = new System.DateTime(year: 2019, month: 2, day: 27)
                },
            };
            context.Abonnements.AddRange(abonnements);

            base.Seed(context);
        }
    }
}
