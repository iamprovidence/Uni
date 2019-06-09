namespace DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Entities.Category>
    {
        public CategoryRepository(Context.DataBaseContext context)
            : base(context) { }
    }
}
