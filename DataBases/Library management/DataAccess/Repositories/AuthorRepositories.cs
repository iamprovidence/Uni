namespace DataAccess.Repositories
{
    public class AuthorRepositories : GenericRepository<Entities.Author>
    {
        public AuthorRepositories(Context.DataBaseContext dataBaseContext)
            : base(dataBaseContext) { }
    }
}
