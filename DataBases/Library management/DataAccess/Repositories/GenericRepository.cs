using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : Interfaces.IRepository<TEntity> where TEntity : class
    {
        // FIELDS
        /// <summary>
        /// A context for database
        /// </summary>
        protected Context.DataBaseContext context;
        /// <summary>
        /// A generic set
        /// </summary>
        protected DbSet<TEntity> dbSet;

        // CONSTRUCTORS
        /// <summary>
        /// Initialize a new instance of <see cref="GenericRepository{TEntity}"/>
        /// </summary>
        /// <param name="context">Data context</param>
        public GenericRepository(Context.DataBaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        // METHODS
        public int Count()
        {
            return dbSet.Count();
        }

        public int Count(Func<TEntity, bool> predicate)
        {
            return dbSet.Count(predicate);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, 
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            // filter
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // include properties
            foreach (var includeProperty in includeProperties.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // ordering
            if (orderBy != null) return orderBy(query);
            return query;
        }

        public TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            // find
            if (id == null) throw new ArgumentNullException(nameof(id));
            TEntity entityToDelete = dbSet.Find(id);

            // delete finded
            if (entityToDelete == null) throw new InvalidOperationException($"There is no records with such id = {id.ToString()}");
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null) throw new ArgumentNullException(nameof(entityToDelete));

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }        
    }
}
