namespace DataAccess.Repositories
{
    public class BookRepository : GenericRepository<Entities.Book>
    {
        public BookRepository(Context.DataBaseContext context)
            : base(context) { }
    }
}
