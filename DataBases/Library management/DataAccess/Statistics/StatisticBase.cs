namespace DataAccess.Statistics
{
    public abstract class StatisticBase
    {
        // FIELDS
        Context.UnitOfWork unitOfWork;

        // CONSTRUCTORS
        public StatisticBase(Context.UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // PROPERTIES
        public Context.UnitOfWork UnitOfWork => unitOfWork;

        // METHODS
        public int Percentage(float total, float current)
        {
            return (int)System.Math.Round(current / total * 100);
        }
    }
}
