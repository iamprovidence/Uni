using Core.Extensions;

namespace DataAccess.Filters
{
    public static class AuthorFilter
    {
        public static bool Has(this Entities.Author author, int? fromBookAmount, int? toBookAmount)
        {
            if (author == null) throw new System.ArgumentNullException(nameof(author));

            bool has = true;
            int bookAmount = author.Books.Count;

            if (fromBookAmount != null) has &= bookAmount >= fromBookAmount.Value;
            if (toBookAmount != null) has &= bookAmount <= toBookAmount.Value;

            return has;
        }
        public static bool Where(this Entities.Author author, string namePattern)
        {
            if (author == null) throw new System.ArgumentNullException(nameof(author));


            if (string.IsNullOrWhiteSpace(namePattern)) return true;
            bool has = false;

            if (!string.IsNullOrWhiteSpace(author.Name)) has |= author.Name.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
            if (!string.IsNullOrWhiteSpace(author.Surname)) has |= author.Surname.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
            if (!string.IsNullOrWhiteSpace(author.Nickname)) has |= author.Nickname.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);

            return has;
        }
    }
}
