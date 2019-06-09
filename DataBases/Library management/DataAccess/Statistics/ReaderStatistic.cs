using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class ReaderStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public ReaderStatistic(Context.UnitOfWork unitOfWork)
            : base(unitOfWork) { }

        // METHODS
        // gets reader name, taken book amount, unreturned amount, returned with a delay
        public IEnumerable<KeyValuePair<string, System.Tuple<int, int, int>>> GetReaderAbonnementInfo()
        {
            return from abonnement in UnitOfWork.AbonnementRepository.Get().AsEnumerable()
                   group abonnement by abonnement.Reader into readerGroup
                   select new KeyValuePair<string, System.Tuple<int, int, int>>
                    (string.Join(" ", readerGroup.Key.Name, readerGroup.Key.Surname),
                    System.Tuple.Create(
                        readerGroup.Key.Abonnements.Count,
                        readerGroup.Key.UnreturnedAmount,
                        readerGroup.Key.OverdueAmount));
        }
    }
}
