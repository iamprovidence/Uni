namespace DataAccess.Repositories
{
    public class GenreRepository : GenericRepository<Entities.Genre>
    {
        public GenreRepository(Context.DataBaseContext context)
            : base(context) { }
    }
}
