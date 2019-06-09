namespace DataAccess.Repositories
{
    public class ReaderRepository : GenericRepository<Entities.Reader>
    {
        public ReaderRepository(Context.DataBaseContext context)
            : base(context) { }
    }
}
