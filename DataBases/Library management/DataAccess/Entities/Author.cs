using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Author : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        #region METHODS
        public override string GetName() => nameof(Author);
        public override string GetBriefInfo()
        {
            if (string.IsNullOrEmpty(Nickname))
            {
                return string.Join(" ", Name, Surname);
            }
            return Nickname;
        }
        #endregion
    }
}
