using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class BookStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public BookStatistic(Context.UnitOfWork unitOfWork)
            : base(unitOfWork) { }

        // METHODS
        // gets Book name, total amount, and remains amount
        public IEnumerable<KeyValuePair<string, System.Tuple<int, int>>> GetStorageInfo()
        {
            return UnitOfWork.BookRepository
                    .Get(orderBy: q => q.OrderBy(b => b.Name)).AsEnumerable()
                    .Select(b => new KeyValuePair<string, System.Tuple<int, int>>(b.Name, System.Tuple.Create(b.Amount, b.RemainsAmount)));
        }

        // best
        public IEnumerable<KeyValuePair<string, int>> GetBookPopularityAmount()
        {
            return from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   group abonnement by abonnement.Book.Name into bookNameGroup
                   orderby bookNameGroup.Key
                   select new KeyValuePair<string, int>(bookNameGroup.Key, bookNameGroup.Count());
        }
        public IEnumerable<KeyValuePair<string, int>> GetBookPopularityPercentageAmount(int limitAmount)
        {
            int takenBookAmount = UnitOfWork.AbonnementRepository.Count();

            return (from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   group abonnement by abonnement.Book.Name into bookNameGroup
                   let takenBookPerGroup = bookNameGroup.Count()
                   orderby takenBookPerGroup descending, bookNameGroup.Key ascending
                   select new KeyValuePair<string, int>(bookNameGroup.Key, Percentage(takenBookAmount, takenBookPerGroup)))
                   .Take(limitAmount);
        }
    }
}
