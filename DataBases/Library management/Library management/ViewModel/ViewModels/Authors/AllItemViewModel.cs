namespace Library_management.ViewModel.ViewModels.Authors
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.Author.AllItem"/>
    /// </summary>
    public class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.Author>
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
            DataAccess.Entities.Author authorToFilter = (DataAccess.Entities.Author)entity;
            bool isShown = true;

            // checks name
            if (namePattern != null)
            {
                isShown &= DataAccess.Filters.AuthorFilter.Where(authorToFilter, namePattern);
            }

            // checks books amount
            isShown &= DataAccess.Filters.AuthorFilter.Has(authorToFilter, fromBookAmount, toBookAmount);
            
            return isShown;
        }

    }
}
