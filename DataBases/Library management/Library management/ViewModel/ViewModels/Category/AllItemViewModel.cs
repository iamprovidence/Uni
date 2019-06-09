namespace Library_management.ViewModel.ViewModels.Category
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.Category.AllItem"/>
    /// </summary>
    class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.Category>
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
            DataAccess.Entities.Category categoryToFilter = (DataAccess.Entities.Category)entity;
            bool isShown = true;

            // checks name
            if (namePattern != null)
            {
                isShown &= DataAccess.Filters.CategoryFilter.Where(categoryToFilter, namePattern);
            }

            // checks books amount
            isShown &= DataAccess.Filters.CategoryFilter.Has(categoryToFilter, fromBookAmount, toBookAmount);

            return isShown;
        }
    }
}
