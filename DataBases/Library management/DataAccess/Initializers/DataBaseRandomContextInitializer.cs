using DataAccess.Context;

using System.Linq;
using System.Xml.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace DataAccess.Initializers
{
    internal class DataBaseRandomContextInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        // FIELDS
        readonly System.Random random;
        readonly string[] names;
        readonly string[] words;
        readonly string[] countriesList;

        // CONSTRCTORS
        public DataBaseRandomContextInitializer() : base()
        {
            random = new System.Random();
            names = new string[50] { "John", "Wan", "Neil", "Lynna", "Chrissy", "Vivienne", "Ambrose", "Salina", "Thelma", "Joellen", "Donovan", "Margarita", "Eliseo", "Lavada",
                                     "Letitia", "Kayleen", "Hermine", "Yvette", "Dino", "Tabitha", "Margareta", "Jordon", "Loree", "Crystle", "Darcey", "Tameika", "Josiah", "Kathie",
                                     "Galen", "Chauncey", "Jeannetta", "Sharonda", "Petra", "Victor", "Vida", "Corinna", "Dee", "Pia", "Carry", "Hipolito", "Colleen", "Katelynn",
                                     "Henry", "Argelia", "Rossie", "Lavonia", "Zena", "Ashleigh", "Annmarie", "Debbra" }; ;
            words = string.Concat("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras accumsan mi a quam viverra luctus. ",
                                  "Suspendisse ut vulputate nisi, nec fermentum libero. ",
                                  "Morbi sollicitudin, orci sit amet congue cursus, nibh nunc lobortis orci, et hendrerit arcu nunc a lorem. Curabitur dignissim risus non diam ornare mattis ac vitae elit. ",
                                  "Suspendisse euismod gravida diam et varius. Sed quis commodo magna. Nunc a ex nec erat feugiat dapibus. Donec id nulla et dolor efficitur convallis. ",
                                  "Maecenas vel sem neque. Vivamus volutpat quam ac urna condimentum, vitae posuere neque scelerisque. Aenean et lacinia dolor.")
                                  .ToLower().Split(new char[] { ',', '.', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            if (System.IO.File.Exists("Resources/Files/Countries.xml"))
            {
                countriesList = XDocument.Load("Resources/Files/Countries.xml").Elements("countries").Elements("country")
                            .Select(country => country.Attribute("countryName").Value)
                            .ToArray();
            }
            else
            {
                countriesList = words;
            }        
        }
        
        // METHODS
        protected override void Seed(DataBaseContext context)
        {
            // COUNTRIES
            int countriesAmount = countriesList.Length;

            Entities.Country[] countries = new Entities.Country[countriesAmount];
            for (int i = 0; i < countriesAmount; ++i)
            {
                countries[i] = new Entities.Country() { Name = countriesList[i] };
            }
            context.Countries.AddRange(countries);

            // CATEGORIES
            int categoriesAmount = random.Next(10, 25);

            Entities.Category[] categories = new Entities.Category[categoriesAmount];
            for (int i = 0; i < categoriesAmount; ++i)
            {
                categories[i] = new Entities.Category() { Name = words[random.Next(words.Length)] };
            }
            context.Categories.AddRange(categories);

            // GENRES
            int genresAmount = random.Next(10, 25);

            Entities.Genre[] genres = new Entities.Genre[genresAmount];
            for (int i = 0; i < genresAmount; ++i)
            {
                genres[i] = new Entities.Genre() { Name = words[random.Next(words.Length)] };
            }
            context.Genres.AddRange(genres);

            // AUTHORS
            int authorsAmount = random.Next(50, 150);

            Entities.Author[] authors = new Entities.Author[authorsAmount];
            for (int i = 0; i < authorsAmount; ++i)
            {
                authors[i] = new Entities.Author()
                {
                    Name = words[random.Next(words.Length)],
                    Surname = words[random.Next(words.Length)],
                    Nickname = words[random.Next(words.Length)] + words[random.Next(words.Length)]
                };
            }
            context.Authors.AddRange(authors);

            // PUBLISHING HOUSES
            int publishingHousesAmount = random.Next(20, 50);

            Entities.PublishingHouse[] publishingHouses = new Entities.PublishingHouse[publishingHousesAmount];
            for (int i = 0; i < publishingHousesAmount; ++i)
            {
                publishingHouses[i] = new Entities.PublishingHouse()
                {
                    Name = words[random.Next(words.Length)],
                    Country = countries[random.Next(countriesAmount)],
                };
            }
            context.PublishingHouses.AddRange(publishingHouses);

            // BOOK
            int booksAmount = random.Next(100, 500);

            Entities.Book[] books = new Entities.Book[booksAmount];
            for (int i = 0; i < booksAmount; ++i)
            {
                books[i] = new Entities.Book()
                {
                    Name = string.Join(" ", GenerateList(names, 1, 5)),
                    Amount = random.Next(25, 50),
                    Year = random.Next(1975, System.DateTime.Now.Year),
                    Authors = GenerateList(authors, 1, 5),
                    PublishingHouses = GenerateList(publishingHouses, 1, 3),
                    Categories = GenerateList(categories, 1, 5),
                    Genres = GenerateList(genres, 1, 5)
                };
            }
            context.Books.AddRange(books);

            // READERS
            int readersAmount = random.Next(100, 500);

            Entities.Reader[] readers = new Entities.Reader[readersAmount];
            for (int i = 0; i < readersAmount; ++i)
            {
                readers[i] = new Entities.Reader()
                {
                    Name = names[random.Next(names.Length)],
                    Surname = names[random.Next(names.Length)],
                    Address = string.Join(" ", GenerateList(words, 1, 5)),
                    Phone = GeneratePhoneNumber()
                };
            }
            context.Readers.AddRange(readers);

            // ABONNEMENTS
            int abonnementsAmount = random.Next(1500, 5000);

            Entities.Abonnement[] abonnements = new Entities.Abonnement[abonnementsAmount];
            for (int i = 0; i < abonnementsAmount; ++i)
            {
                System.DateTime takeDate = GenerateDate();
                bool isReturned = random.Next(2) == 1;

                abonnements[i] = new Entities.Abonnement()
                {
                    Reader = readers[random.Next(readers.Length)],
                    Book = books[random.Next(books.Length)],
                    TakeTime = takeDate,
                    TakenPeriod = takeDate.AddDays(random.Next(7, 28)),
                    ReturnTime = isReturned ? (System.DateTime?)takeDate.AddDays(random.Next(1, 20)) : null
                };
            }            
            context.Abonnements.AddRange(abonnements);


            base.Seed(context);
        }

        private ICollection<T> GenerateList<T>(T[] data, int minAmount, int maxAmount)
        {
            int collectionAmount = random.Next(minAmount, maxAmount);
            T[] list = new T[collectionAmount];
            for (int i = 0; i < collectionAmount; ++i)
            {
                list[i] = data[random.Next(data.Length)];
            }
            return list;
        }
        private string GeneratePhoneNumber()
        {
            return string.Concat(Enumerable.Range(0, 10).Select(n => random.Next(1, 9).ToString()));
        }
        private System.DateTime GenerateDate()
        {
            return new System.DateTime(year: random.Next(2000, System.DateTime.Now.Year), month: random.Next(1, 13), day: random.Next(1, 28));
        }
    }
}
