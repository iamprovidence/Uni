using System.Linq;

namespace Library_management.ViewModel.ViewModels.Abonnements
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.Abonnement.AllItem"/>
    /// </summary>
    class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.Abonnement>
    {
        // FIELDS
        DataAccess.Entities.Reader selectedReader;
        DataAccess.Entities.Reader[] readers;

        DataAccess.Entities.Book selectedBook;
        DataAccess.Entities.Book[] books;

        bool? isDebtor;

        // CONSTRUCTORS
        public AllItemViewModel()
        {
            selectedReader = null;
            readers = UnitOfWork.ReaderRepository.Get().ToArray();

            selectedBook = null;
            books = UnitOfWork.BookRepository.Get().ToArray();
        }

        // PROPERTIES
        public DataAccess.Entities.Reader SelectedReader
        {
            get
            {
                return selectedReader;
            }
            set
            {
                SetProperty(ref selectedReader, value);
                SetFilter();
            }
        }
        public DataAccess.Entities.Reader[] Readers => readers;

        public DataAccess.Entities.Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                SetProperty(ref selectedBook, value);
                SetFilter();
            }
        }
        public DataAccess.Entities.Book[] Books => books;

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

        // NAVIGATION
        #region NAVIGATION
        protected override void NavigateToCreateView(object parameter)
        {
            // opens create window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.Abonnement).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.Abonnement,
                    crudMode: Enums.CrudMode.Create));
        }
        protected override void NavigateToReadView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.Abonnement).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.Abonnement,
                    crudMode: Enums.CrudMode.Read));
        }
        protected override void NavigateToUpdateView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.Abonnement).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.Abonnement,
                    crudMode: Enums.CrudMode.Update));
        }
        #endregion

        // FILTERING METHOD
        protected override bool FilterPredicate(object entity)
        {
            DataAccess.Entities.Abonnement abonnementToFilter = (DataAccess.Entities.Abonnement)entity;
            bool isShown = true;

            // checks reader
            if (selectedReader != null)
            {
                isShown &= DataAccess.Filters.AbonnementFilter.Where(abonnementToFilter, selectedReader);
            }

            // checks books
            if (selectedBook != null)
            {
                isShown &= DataAccess.Filters.AbonnementFilter.Where(abonnementToFilter, selectedBook);
            }

            // checks if abonnement is out of day
            isShown &= DataAccess.Filters.AbonnementFilter.Where(abonnementToFilter, isDebtor);

            return isShown;
        }
    }
}
