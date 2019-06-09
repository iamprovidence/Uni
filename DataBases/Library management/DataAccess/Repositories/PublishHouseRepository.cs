namespace DataAccess.Repositories
{
    public class PublishHouseRepository : GenericRepository<Entities.PublishingHouse>
    {
        public PublishHouseRepository(Context.DataBaseContext context)
            : base(context) { }
    }
}
