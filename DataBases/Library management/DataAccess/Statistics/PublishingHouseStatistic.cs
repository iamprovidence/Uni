using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class PublishingHouseStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public PublishingHouseStatistic(Context.UnitOfWork unitOfWork)
            : base(unitOfWork) { }

        // METHODS
        public IEnumerable<KeyValuePair<string, int>> GetPublishedBookAmount()
        {
            return UnitOfWork.PublishHouseRepository
                            .Get(orderBy: q => q.OrderBy(ph => ph.Name)).AsEnumerable()
                            .Select(ph => new KeyValuePair<string, int>(ph.Name, ph.Books.Count));
        }

        public IEnumerable<KeyValuePair<string, int>> GetPublishedBookAmountPercentage(int limitAmount)
        {
            int totalBookAmount = UnitOfWork.BookRepository.Count();

            return UnitOfWork.PublishHouseRepository
                            .Get(orderBy: q => q.OrderBy(ph => ph.Name)).AsEnumerable()
                            .Select(ph => new KeyValuePair<string, int>(ph.Name, Percentage(totalBookAmount, ph.Books.Count)))
                            .OrderByDescending(p => p.Value)
                            .Take(limitAmount);
        }
        public IEnumerable<KeyValuePair<string, int>> GetPublishingHousePopularityAmount()
        {
            return from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from publishingHouse in abonnement.Book.PublishingHouses
                   group publishingHouse by publishingHouse.Name into publishingHouseNameGroup
                   orderby publishingHouseNameGroup.Key
                   select new KeyValuePair<string, int>(publishingHouseNameGroup.Key, publishingHouseNameGroup.Count());
        }
        public IEnumerable<KeyValuePair<string, int>> GetPublishingHousePopularityPercentageAmount(int limitAmount)
        {
            int takenBookAmount = UnitOfWork.AbonnementRepository.Count();

            return (from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from publishingHouse in abonnement.Book.PublishingHouses
                   group publishingHouse by publishingHouse.Name into publishingHouseNameGroup
                   let takenBook = publishingHouseNameGroup.Count()
                   orderby takenBook descending, publishingHouseNameGroup.Key ascending
                   select new KeyValuePair<string, int>(publishingHouseNameGroup.Key, Percentage(takenBookAmount, takenBook)))
                   .Take(limitAmount);
        }
    }
}
