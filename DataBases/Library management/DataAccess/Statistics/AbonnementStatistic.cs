using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Statistics
{
    public class AbonnementStatistic : StatisticBase
    {
        // CONSTRUCTORS
        public AbonnementStatistic(Context.UnitOfWork unitOfWork) 
            : base(unitOfWork) {  }

        // METHODS
        // return properly amount, unreturned amount, returned with delay amount
        public Tuple<int, int, int> GetAbonnementInfo()
        {
            int returnProperly = UnitOfWork.AbonnementRepository.Count(a => !a.IsLate() && !a.IsUnreturned());
            int unreturned = UnitOfWork.AbonnementRepository.Count(a => a.IsUnreturned());
            int delayed = UnitOfWork.AbonnementRepository.Count(a => a.IsLate());

            return Tuple.Create(returnProperly, unreturned, delayed);
        }

        // key = date
        // value = int[] { take book amount, return book amount }
        public IList<KeyValuePair<DateTime, int[]>> GetAbonnementPeriodInfo(DateTime fromPeriod, DateTime toPeriod)
        {
            fromPeriod = fromPeriod.Date;
            toPeriod = toPeriod.Date;
            if (toPeriod < fromPeriod) throw new InvalidOperationException($"{nameof(toPeriod)} can not be less than {nameof(fromPeriod)}");
            
            // cannot be done through LINQ, full join is not allowed ;(

            // gets aboonnements in current range
            IEnumerable<Entities.Abonnement> abonnements = UnitOfWork.AbonnementRepository
                    .Get(a => (a.TakeTime >= fromPeriod && a.TakeTime < toPeriod) || (a.ReturnTime >= fromPeriod && a.ReturnTime < toPeriod));

            // generates free array of dates
            IList<KeyValuePair<DateTime, int[]>> dateBookCountList = Enumerable.Range(0, (toPeriod - fromPeriod).Days)
                .Select((value, index) => new KeyValuePair<DateTime, int[]>(fromPeriod.AddDays(index), new int[2])).ToArray();

            // foreach abonnement..
            foreach (Entities.Abonnement abonnement in abonnements)
            {
                // if there is taken book in this period...
                if (IsInRange(abonnement.TakeTime, fromPeriod, toPeriod))
                {
                    // ...count them
                    dateBookCountList[(abonnement.TakeTime - fromPeriod).Days ].Value[0]++;
                }
                // if there is return book in this period...
                if (abonnement.ReturnTime.HasValue && IsInRange(abonnement.ReturnTime, fromPeriod, toPeriod))
                {
                    // ... count them
                    dateBookCountList[(abonnement.ReturnTime.Value - fromPeriod).Days].Value[1]++;
                }
            }

            return dateBookCountList;
        }
        
        public bool IsInRange(DateTime? date, DateTime from, DateTime to)
        {
            return date >= from && date < to;
        }
    }
}
