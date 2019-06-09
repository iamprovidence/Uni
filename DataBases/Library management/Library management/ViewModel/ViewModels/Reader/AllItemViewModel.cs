namespace Library_management.ViewModel.ViewModels.Reader
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.Reader.AllItem"/>
    /// </summary>
    class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.Reader>
    {
        // FIELDS
        string namePattern;
        string addressPattern;
        bool? hasUnreturnedBook;
        bool? isDebtor;

        // CONSTRUCTORS
        public AllItemViewModel()
        {
            namePattern = string.Empty;
            addressPattern = string.Empty;
            hasUnreturnedBook = null;
            isDebtor = null;
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
        public string AddressPattern
        {
            get
            {
                return addressPattern;
            }
            set
            {
                SetProperty(ref addressPattern, value.Trim());
                SetFilter();
            }
        }
        public bool? HasUnreturnedBook
        {
            get
            {
                return hasUnreturnedBook;
            }
            set
            {
                SetProperty(ref hasUnreturnedBook, value);
                SetFilter();
            }
        }
        public bool? IsDebtor
        {
            get
            {
                return isDebtor;
            }
            set
            {
                SetProperty(ref isDebtor, value);
                SetFilter();
            }
        }

        // METHODS
        // FILTERING METHOD
        protected override bool FilterPredicate(object entity)
        {
            DataAccess.Entities.Reader readerToFilter = (DataAccess.Entities.Reader)entity;
            bool isShown = true;

            // checks name
            if (namePattern != null)
            {
                isShown &= DataAccess.Filters.ReaderFilter.Where(readerToFilter, namePattern);
            }

            // checks address
            if (addressPattern != null)
            {
                isShown &= DataAccess.Filters.ReaderFilter.Has(readerToFilter, addressPattern);
            }

            // checks if reader has unreturned book
            isShown &= DataAccess.Filters.ReaderFilter.Has(readerToFilter, hasUnreturnedBook);

            // checks if reader is debtor
            isShown &= DataAccess.Filters.ReaderFilter.Where(readerToFilter, isDebtor);

            return isShown;
        }
    }
}
