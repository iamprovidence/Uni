using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Reader : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();

        #region METHODS
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int UnreturnedAmount => Abonnements.Count(a => a.IsUnreturned());
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int OverdueAmount => Abonnements.Count(a => a.IsLate());
        public override string GetName() => nameof(Reader);
        public override string GetBriefInfo() => string.Join(" ", Name, Surname);
        #endregion
    }
}
