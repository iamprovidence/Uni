using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            // NAME
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(20);

            // SURNAME
            Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(20);

            // NICKNAME
            Property(a => a.Nickname)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}
