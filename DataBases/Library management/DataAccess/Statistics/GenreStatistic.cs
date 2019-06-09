using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class GenreStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public GenreStatistic(Context.UnitOfWork unitOfWork)
            : base(unitOfWork) { }

        // METHODS
        public IEnumerable<KeyValuePair<string, int>> GetGenreAmount()
        {
            return UnitOfWork.GenreRepository.Get(orderBy: q => q.OrderBy(g => g.Name)).AsEnumerable().Select(g => new KeyValuePair<string, int>(g.Name, g.Books.Count));
        }

        public IEnumerable<KeyValuePair<string, int>> GetGenrePercentageAmount(int limitAmount)
        {
            int totalBook = UnitOfWork.BookRepository.Count();

            return UnitOfWork.GenreRepository
                    .Get(orderBy: q => q.OrderBy(g => g.Name)).AsEnumerable()
                    .Select(g => new KeyValuePair<string, int>(g.Name, Percentage(totalBook, g.Books.Count)))
                    .OrderByDescending(p => p.Value)
                    .Take(limitAmount);
        }
        public IEnumerable<KeyValuePair<string, int>> GetGenrePopularityAmount()
        {
            return from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from genre in abonnement.Book.Genres
                   group genre by genre.Name into genreyNameGroup
                   orderby genreyNameGroup.Key
                   select new KeyValuePair<string, int>(genreyNameGroup.Key, genreyNameGroup.Count());
        }

        public IEnumerable<KeyValuePair<string, int>> GetGenrePopularityPercentageAmount(int limitAmount)
        {
            int takenBook = UnitOfWork.AbonnementRepository.Count();

            return (from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from genre in abonnement.Book.Genres
                   group genre by genre.Name into genreyNameGroup
                   let takenBookPerGroup = genreyNameGroup.Count()
                   orderby takenBookPerGroup descending, genreyNameGroup.Key ascending
                   select new KeyValuePair<string, int>(genreyNameGroup.Key, Percentage(takenBook, takenBookPerGroup)))
                   .Take(limitAmount);
        }
    }
}
