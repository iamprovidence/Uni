using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public int Amount { get; set; } = 5;       
        public int? Year { get; set; }
        public string CoverPath { get; set; }

        public virtual ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
        public virtual ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<PublishingHouse> PublishingHouses { get; set; } = new HashSet<PublishingHouse>();

        [NotMapped]
        public int RemainsAmount
        {
            get
            {
                return Amount - Abonnements.Count;
            }
        }

        #region METHODS
        public override string GetName() => nameof(Book);
        public override string GetBriefInfo() => Name;
        #endregion
    }
}
