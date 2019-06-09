namespace Library_management.ViewModel.ViewModels.Genre
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.Genre.AllItem"/>
    /// </summary>
    class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.Genre>
    {
        // FIELDS
        string namePattern;
        int? fromBookAmount;
        int? toBookAmount;

        // CONSTRUCTORS
        public AllItemViewModel()
        {
            namePattern = string.Empty;
            fromBookAmount = null;
            toBookAmount = null;
        }

        // PROPERTIES
        public string NamePattern
        {
            get
            {
                return namePattern;
            }
            set
            {
                SetProperty(ref namePattern, value.Trim());
                SetFilter();
            }
        }
        public int? FromBookAmount
        {
            get
            {
                return fromBookAmount;
            }
            set
            {
                SetProperty(ref fromBookAmount, value);
                SetFilter();
            }
        }
        public int? ToBookAmount
        {
            get
            {
                return toBookAmount;
            }
            set
            {
                SetProperty(ref toBookAmount, value);
                SetFilter();
            }
        }

        // METHODS
        // FILTERING METHOD
        protected override bool FilterPredicate(object entity)
        {
            DataAccess.Entities.Genre genreToFilter = (DataAccess.Entities.Genre)entity;
            bool isShown = true;

            // checks name
            if (namePattern != null)
            {
                isShown &= DataAccess.Filters.GenreFilter.Where(genreToFilter, namePattern);
            }

            // checks books amount
            isShown &= DataAccess.Filters.GenreFilter.Has(genreToFilter, fromBookAmount, toBookAmount);

            return isShown;
        }
    }
}
