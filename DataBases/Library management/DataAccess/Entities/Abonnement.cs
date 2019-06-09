namespace DataAccess.Entities
{
    public class Abonnement : EntityBase
    {
        public System.DateTime TakeTime { get; set; } = System.DateTime.Now;
        public System.DateTime TakenPeriod { get; set; } = System.DateTime.Now.AddDays(7);
        public System.DateTime? ReturnTime { get; set; }

        public virtual Reader Reader { get; set; }
        public virtual Book Book { get; set; }

        #region METHODS
        public bool IsUnreturned() => !ReturnTime.HasValue; 
        public bool IsLate()
        {
            if (!ReturnTime.HasValue) return false;
            return ReturnTime.Value > TakenPeriod;
        }
        public bool isDebtor()
        {
            if (!ReturnTime.HasValue) return true;
            return ReturnTime.Value > TakenPeriod;
        }
        public override string GetName() => nameof(Abonnement);
        public override string GetBriefInfo() => $"{nameof(Abonnement)} from '{Reader.Name} {Reader.Surname}'{System.Environment.NewLine}with book '{Book?.Name}'";
        #endregion
    }
}
