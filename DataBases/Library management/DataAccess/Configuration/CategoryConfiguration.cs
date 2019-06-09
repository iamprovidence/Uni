using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            // NAME
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
