namespace DataAccess.Repositories
{
    public class AbonnementRepository : GenericRepository<Entities.Abonnement>
    {
        public AbonnementRepository(Context.DataBaseContext context)
            : base(context) { }
    }
}
