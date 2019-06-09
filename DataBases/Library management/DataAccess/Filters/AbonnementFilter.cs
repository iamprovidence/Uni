namespace DataAccess.Filters
{
    public static class AbonnementFilter
    {
        public static bool Where(this Entities.Abonnement abonnement, Entities.Reader reader)
        {
            if (abonnement == null) throw new System.ArgumentNullException(nameof(abonnement));
            if (reader == null) throw new System.ArgumentNullException(nameof(reader));

            return abonnement.Reader == reader;
        }
        public static bool Where(this Entities.Abonnement abonnement, Entities.Book book)
        {
            if (abonnement == null) throw new System.ArgumentNullException(nameof(abonnement));
            if (book == null) throw new System.ArgumentNullException(nameof(book));
            
            return abonnement.Book == book;
        }
        public static bool Where(this Entities.Abonnement abonnement, bool? isDebtor)
        {
            if (abonnement == null) throw new System.ArgumentNullException(nameof(abonnement));

            if (isDebtor == null) return true;
            return abonnement.isDebtor() == isDebtor;
        }
    }
}
