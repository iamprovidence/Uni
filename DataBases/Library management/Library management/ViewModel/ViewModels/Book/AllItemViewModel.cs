namespace Library_management.ViewModel.ViewModels.Book
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.Book.AllItem"/>
    /// </summary>
    class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.Book>
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

        // NAVIGATION
        #region NAVIGATION
        protected override void NavigateToCreateView(object parameter)
        {
            // opens create window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.Book).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.Book,
                    crudMode: Enums.CrudMode.Create));
        }
        protected override void NavigateToReadView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.Book).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.Book,
                    crudMode: Enums.CrudMode.Read));
        }
        protected override void NavigateToUpdateView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.Book).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.Book,
                    crudMode: Enums.CrudMode.Update));
        }
        #endregion
        // FILTERING METHOD
        protected override bool FilterPredicate(object entity)
        {
            DataAccess.Entities.Book bookToFilter = (DataAccess.Entities.Book)entity;
            bool isShown = true;

            // checks name
            if (namePattern != null)
            {
                isShown &= DataAccess.Filters.BookFilter.Where(bookToFilter, namePattern);
            }

            // checks books amount
            isShown &= DataAccess.Filters.BookFilter.Where(bookToFilter, fromBookAmount, toBookAmount);

            return isShown;
        }
        
    }
}
