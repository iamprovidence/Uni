using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class PublishingHouseConfiguration : EntityTypeConfiguration<PublishingHouse>
    {
        public PublishingHouseConfiguration()
        {
            // NAME
            Property(ph => ph.Name)
                .IsRequired()
                .HasMaxLength(25);

            // COUNTRY
            HasRequired(ph => ph.Country).WithMany(c => c.PublishingHouses);
        }
    }
}
