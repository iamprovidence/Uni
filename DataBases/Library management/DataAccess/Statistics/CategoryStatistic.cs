using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class CategoryStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public CategoryStatistic(Context.UnitOfWork unitOfWork)
            : base(unitOfWork) { }

        // METHODS
        public IEnumerable<KeyValuePair<string, int>> GetCategoryAmount()
        {
            return UnitOfWork.CategoryRepository.Get(orderBy: q => q.OrderBy(c => c.Name)).AsEnumerable().Select(c => new KeyValuePair<string, int>(c.Name, c.Books.Count));
        }

        public IEnumerable<KeyValuePair<string, int>> GetCategoryPercentageAmount(int limitAmount)
        {
            int totalBook = UnitOfWork.BookRepository.Count();

            return UnitOfWork.CategoryRepository
                    .Get(orderBy: q => q.OrderBy(c => c.Name)).AsEnumerable()
                    .Select(c => new KeyValuePair<string, int>(c.Name, Percentage(totalBook, c.Books.Count())))
                    .OrderByDescending(p => p.Value)
                    .Take(limitAmount);
        }
        public IEnumerable<KeyValuePair<string, int>> GetCategoryPopularityAmount()
        {
            return from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from category in abonnement.Book.Categories
                   group category by category.Name into categoryNameGroup
                   orderby categoryNameGroup.Key
                   select new KeyValuePair<string, int>(categoryNameGroup.Key, categoryNameGroup.Count());
        }
        public IEnumerable<KeyValuePair<string, int>> GetCategoryPopularityPercentageAmount(int limitAmount)
        {
            int takenBook = UnitOfWork.AbonnementRepository.Count();

            return (from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from category in abonnement.Book.Categories
                   group category by category.Name into categoryNameGroup
                   let takenBookPerGroup = categoryNameGroup.Count()
                   orderby takenBookPerGroup descending, categoryNameGroup.Key ascending
                   select new KeyValuePair<string, int>(categoryNameGroup.Key, Percentage(takenBook, takenBookPerGroup)))
                   .Take(limitAmount);
        }
    }
}
