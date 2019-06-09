using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class PublishingHouse : EntityBase
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        #region METHODS
        public override string GetName() => nameof(PublishingHouse);
        public override string GetBriefInfo() => Name;
        #endregion
    }
}
