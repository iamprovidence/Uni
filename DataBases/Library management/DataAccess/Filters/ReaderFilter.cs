using System.Linq;
using Core.Extensions;

namespace DataAccess.Filters
{
    public static class ReaderFilter
    {
        public static bool Where(this Entities.Reader reader, string namePattern)
        {
            if (reader == null) throw new System.ArgumentNullException(nameof(reader));

            return reader.Name.Contains(namePattern, System.StringComparison.OrdinalIgnoreCase);
        }
        public static bool Where(this Entities.Reader reader, bool? isDebtor)
        {
            if (reader == null) throw new System.ArgumentNullException(nameof(reader));

            if (isDebtor == null) return true;
            return isDebtor.Value == reader.Abonnements.Any(a => a.IsLate());
        }
        public static bool Has(this Entities.Reader reader, string addressPattern)
        {
            if (reader == null) throw new System.ArgumentNullException(nameof(reader));

            return reader.Address.Contains(addressPattern, System.StringComparison.OrdinalIgnoreCase);
        }
        public static bool Has(this Entities.Reader reader, bool? hasUnreturnedBook)
        {
            if (reader == null) throw new System.ArgumentNullException(nameof(reader));

            if (hasUnreturnedBook == null) return true;
            return reader.UnreturnedAmount > 0 == hasUnreturnedBook.Value;
        }
    }
}
