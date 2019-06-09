using Core.Extensions;

namespace DataAccess.Filters
{
    public static class CategoryFilter
    {
        public static bool Where(this Entities.Category category, string namePattern)
        {
            if (category == null) throw new System.ArgumentNullException(nameof(category));

            return category.Name.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
        }
        public static bool Has(this Entities.Category category, int? fromBookAmount, int? toBookAmount)
        {
            if (category == null) throw new System.ArgumentNullException(nameof(category));

            bool has = true;
            int bookAmount = category.Books.Count;

            if (fromBookAmount != null) has &= bookAmount >= fromBookAmount.Value;
            if (toBookAmount != null) has &= bookAmount <= toBookAmount.Value;

            return has;
        }
    }
}
