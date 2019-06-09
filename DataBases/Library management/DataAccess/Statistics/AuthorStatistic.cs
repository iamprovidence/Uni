using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class AuthorStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public AuthorStatistic(Context.UnitOfWork unitOfWork)
            : base(unitOfWork) { }

        // METHODS
        public IEnumerable<KeyValuePair<string, int>> GetWrittenBookAmount()
        {
            return UnitOfWork.AuthorRepositories
                            .Get(orderBy: q => q.OrderBy(a => a.Nickname)).AsEnumerable()
                            .Select(a => new KeyValuePair<string, int>(a.Nickname, a.Books.Count));
        }

        public IEnumerable<KeyValuePair<string, int>> GetWrittenBookAmountPercentage(int limitAmount)
        {
            int totalBookAmount = UnitOfWork.BookRepository.Count();

            return UnitOfWork.AuthorRepositories
                            .Get(orderBy: q => q.OrderBy(a => a.Nickname)).AsEnumerable()
                            .Select(a => new KeyValuePair<string, int>(a.Nickname, Percentage(totalBookAmount, a.Books.Count)))
                            .OrderByDescending(p => p.Value)
                            .Take(limitAmount);
        }
        public IEnumerable<KeyValuePair<string, int>> GetAuthorPopularityAmount()
        {
            return from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from author in abonnement.Book.Authors
                   group author by author.Nickname into authorNicknameGroup
                   orderby authorNicknameGroup.Key
                   select new KeyValuePair<string, int>(authorNicknameGroup.Key, authorNicknameGroup.Count());
        }
        public IEnumerable<KeyValuePair<string, int>> GetAuthorPopularityPercentageAmount(int limitAmount)
        {
            int takenBookAmount = UnitOfWork.AbonnementRepository.Count();

            return (from abonnement in UnitOfWork.AbonnementRepository.Get(a => a.Book != null).AsEnumerable()
                   from author in abonnement.Book.Authors
                   group author by author.Nickname into authorNicknameGroup
                   let takenBookPerGroup = authorNicknameGroup.Count()
                   orderby takenBookPerGroup descending, authorNicknameGroup.Key ascending
                   select new KeyValuePair<string, int>(authorNicknameGroup.Key, Percentage(takenBookAmount, takenBookPerGroup)))
                   .Take(limitAmount);
        }
    }
}
