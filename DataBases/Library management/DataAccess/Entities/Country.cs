using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Country : EntityBase
    {
        public string Name { get; set; }

        public ICollection<PublishingHouse> PublishingHouses { get; set; } = new List<PublishingHouse>();

        // METHODS
        #region METHODS
        public override string GetBriefInfo() => $"{nameof(Country)} {Name}";
        public override string GetName() => nameof(Country);
        #endregion
    }
}
