using DataAccess.Statistics;
using DataAccess.Repositories;

namespace DataAccess.Context
{
    public sealed class UnitOfWork
    {
        // FIELDS
        readonly static UnitOfWork instance;

        DataBaseContext dataBaseContext;

        AbonnementRepository abonnementRepository;
        AuthorRepositories authorRepositories;
        BookRepository bookRepository;
        CategoryRepository categoryRepository;
        GenreRepository genreRepository;
        PublishHouseRepository publishHouseRepository;
        ReaderRepository readerRepository;

        AbonnementStatistic abonnementStatistic;
        AuthorStatistic authorStatistic;
        BookStatistic bookStatistic;
        CategoryStatistic categoryStatistic;
        GenreStatistic genreStatistic;
        PublishingHouseStatistic publishingHouseStatistic;
        ReaderStatistic readerStatistic;

        // CONSTRUCTORS
        private UnitOfWork()
        {
            dataBaseContext = new DataBaseContext();

            authorRepositories = null;
            abonnementRepository = null;
            bookRepository = null;
            categoryRepository = null;
            genreRepository = null;
            publishHouseRepository = null;
            readerRepository = null;

            abonnementStatistic = null;
            authorStatistic = null;
            bookStatistic = null;
            categoryStatistic = null;
            genreStatistic = null;
            publishingHouseStatistic = null;
            readerStatistic = null;
        }
        static UnitOfWork()
        {
            instance = new UnitOfWork();
        }
        ~UnitOfWork()
        {
            dataBaseContext.Dispose();
        }

        // PROPERTIES
        public static UnitOfWork Instance => instance;

        public DataBaseContext DataBaseContext => dataBaseContext;

        // REPOSITORIES
        #region REPOSITORIES
        public AuthorRepositories AuthorRepositories
        {
            get
            {
                if (authorRepositories == null) authorRepositories = new AuthorRepositories(dataBaseContext);
                return authorRepositories;
            }
        }
        public AbonnementRepository AbonnementRepository
        {
            get
            {
                if (abonnementRepository == null) abonnementRepository = new AbonnementRepository(dataBaseContext);
                return abonnementRepository;
            }
        }
        public BookRepository BookRepository
        {
            get
            {
                if (bookRepository == null) bookRepository = new BookRepository(dataBaseContext);
                return bookRepository;
            }
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null) categoryRepository = new CategoryRepository(dataBaseContext);
                return categoryRepository;
            }
        }
        public GenreRepository GenreRepository
        {
            get
            {
                if (genreRepository == null) genreRepository = new GenreRepository(dataBaseContext);
                return genreRepository;
            }
        }
        public PublishHouseRepository PublishHouseRepository
        {
            get
            {
                if (publishHouseRepository == null) publishHouseRepository = new PublishHouseRepository(dataBaseContext);
                return publishHouseRepository;
            }
        }
        public ReaderRepository ReaderRepository
        {
            get
            {
                if (readerRepository == null) readerRepository = new ReaderRepository(dataBaseContext);
                return readerRepository;
            }
        }
        #endregion

        // STATISTICS
        #region STATISTICS
        public AbonnementStatistic AbonnementStatistic
        {
            get
            {
                if (abonnementStatistic == null) abonnementStatistic = new AbonnementStatistic(this);
                return abonnementStatistic;
            }
        }
        public AuthorStatistic AuthorStatistic
        {
            get
            {
                if (authorStatistic == null) authorStatistic = new AuthorStatistic(this);
                return authorStatistic;
            }
        }
        public BookStatistic BookStatistic
        {
            get
            {
                if (bookStatistic == null) bookStatistic = new BookStatistic(this);
                return bookStatistic;
            }
        }
        public CategoryStatistic CategoryStatistic
        {
            get
            {
                if (categoryStatistic == null) categoryStatistic = new CategoryStatistic(this);
                return categoryStatistic;
            }
        }
        public GenreStatistic GenreStatistic
        {
            get
            {
                if (genreStatistic == null) genreStatistic = new GenreStatistic(this);
                return genreStatistic;
            }
        }
        public PublishingHouseStatistic PublishingHouseStatistic
        {
            get
            {
                if (publishingHouseStatistic == null) publishingHouseStatistic = new PublishingHouseStatistic(this);
                return publishingHouseStatistic;
            }
        }
        public ReaderStatistic ReaderStatistic
        {
            get
            {
                if (readerStatistic == null) readerStatistic = new ReaderStatistic(this);
                return readerStatistic;
            }
        }
        #endregion

        // METHODS
        public int Save()
        {
            return dataBaseContext.SaveChanges();
        }
        public GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(dataBaseContext);
        }
    }
}
