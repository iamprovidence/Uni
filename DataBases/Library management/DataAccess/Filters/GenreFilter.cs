using Core.Extensions;

namespace DataAccess.Filters
{
    public static class GenreFilter
    {
        public static bool Where(this Entities.Genre genre, string namePattern)
        {
            if (genre == null) throw new System.ArgumentNullException(nameof(genre));

            return genre.Name.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
        }
        public static bool Has(this Entities.Genre genre, int? fromBookAmount, int? toBookAmount)
        {
            if (genre == null) throw new System.ArgumentNullException(nameof(genre));

            bool has = true;
            int bookAmount = genre.Books.Count;

            if (fromBookAmount != null) has &= bookAmount >= fromBookAmount.Value;
            if (toBookAmount != null) has &= bookAmount <= toBookAmount.Value;

            return has;
        }
    }
}
