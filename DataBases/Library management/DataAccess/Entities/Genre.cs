using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Genre : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        #region METHODS
        public override string GetName() => nameof(Genre);
        public override string GetBriefInfo() => Name;
        #endregion
    }
}
