using System.Data.Entity;

using DataAccess.Enums;
using DataAccess.Entities;
using DataAccess.Initializers;
using DataAccess.Configuration;

namespace DataAccess.Context
{
    public class DataBaseContext : DbContext
    {
        // CONST
        private static readonly DataBaseContextInitializerStrategy DB_INITIALIZER_STRATEGY = DataBaseContextInitializerStrategy.Random;

        // PROPERTIES
        public DbSet<Author> Authors { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Reader> Readers { get; set; }

        // CONSTRUCTORS
        static DataBaseContext()
        {
            IDatabaseInitializer<DataBaseContext> databaseInitializer = null;
            switch (DB_INITIALIZER_STRATEGY)
            {
                case DataBaseContextInitializerStrategy.Default: databaseInitializer = new DataBaseContextInitializer(); break;
                case DataBaseContextInitializerStrategy.Random: databaseInitializer = new DataBaseRandomContextInitializer(); break;
                default: throw new System.InvalidOperationException("This strategy is undefined");
            }
            
            Database.SetInitializer(databaseInitializer);
        }

        // METHODS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AbonnementConfiguration());
            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new PublishingHouseConfiguration());
            modelBuilder.Configurations.Add(new ReaderConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
