using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            // NAME
            Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
