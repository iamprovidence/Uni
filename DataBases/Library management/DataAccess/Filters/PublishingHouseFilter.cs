using Core.Extensions;

namespace DataAccess.Filters
{
    public static class PublishingHouseFilter
    {
        public static bool Where(this Entities.PublishingHouse publishingHouse, string namePattern)
        {
            if (publishingHouse == null) throw new System.ArgumentNullException(nameof(publishingHouse));

            return publishingHouse.Name.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
        }
        public static bool Where(this Entities.PublishingHouse publishingHouse, Entities.Country country)
        {
            if (publishingHouse == null) throw new System.ArgumentNullException(nameof(publishingHouse));
            if (country == null) throw new System.ArgumentNullException(nameof(country));

            return publishingHouse.Country == country;
        }
        public static bool Has(this Entities.PublishingHouse publishingHouse, int? fromBookAmount, int? toBookAmount)
        {
            if (publishingHouse == null) throw new System.ArgumentNullException(nameof(publishingHouse));

            bool has = true;
            int bookAmount = publishingHouse.Books.Count;

            if (fromBookAmount != null) has &= bookAmount >= fromBookAmount.Value;
            if (toBookAmount != null) has &= bookAmount <= toBookAmount.Value;

            return has;
        }
    }
}
