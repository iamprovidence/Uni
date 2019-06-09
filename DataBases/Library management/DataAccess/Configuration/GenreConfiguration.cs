using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            // NAME
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
