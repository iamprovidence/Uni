using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public abstract class EntityBase
    {
        // PROPERTIES
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid Id { get; set; }

        // METHODS
        public abstract string GetName();
        public abstract string GetBriefInfo();
    }
}
