using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class AbonnementConfiguration : EntityTypeConfiguration<Abonnement>
    {
        public AbonnementConfiguration()
        {
            // TAKE TIME
            Property(a => a.TakeTime)
                .IsRequired()
                .HasColumnType("date");

            // TAKEN PERIOD
            Property(a => a.TakenPeriod)
                .IsRequired()
                .HasColumnType("date");
            
            // RETURN TIME
            Property(a => a.ReturnTime)
                .IsOptional()
                .HasColumnType("date");
        }
    }
}
