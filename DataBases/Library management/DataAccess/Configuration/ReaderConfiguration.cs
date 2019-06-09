using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class ReaderConfiguration : EntityTypeConfiguration<Reader>
    {
        public ReaderConfiguration()
        {
            // NAME
            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(20);

            // SURNAME
            Property(r => r.Surname)
                .IsRequired()
                .HasMaxLength(20);

            // PHONE
            Property(r => r.Phone)
                .IsRequired()
                .HasMaxLength(20);

            // ADDRESS
            Property(r => r.Address)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
