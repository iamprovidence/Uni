using Core.Extensions;

namespace DataAccess.Filters
{
    public static class BookFilter
    {
        public static bool Where(this Entities.Book book, string namePattern)
        {
            if (book == null) throw new System.ArgumentNullException(nameof(book));

            return book.Name.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
        }
        public static bool Where(this Entities.Book book, int? fromBookAmount, int? toBookAmount)
        {
            if (book == null) throw new System.ArgumentNullException(nameof(book));

            bool has = true;

            if (fromBookAmount != null) has &= book.Amount >= fromBookAmount.Value;
            if (toBookAmount != null) has &= book.Amount <= toBookAmount.Value;

            return has;
        }
    }
}
