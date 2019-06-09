using System.Linq;

namespace Library_management.ViewModel.ViewModels.PublishingHouse
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.PublishingHouse.AllItem"/>
    /// </summary>
    class AllItemViewModel : AllItemViewModelBase<DataAccess.Entities.PublishingHouse>
    {
        // FIELDS
        string namePattern;
        int? fromBookAmount;
        int? toBookAmount;
        DataAccess.Entities.Country selectedCountry;
        DataAccess.Entities.Country[] countries;

        // CONSTRUCTORS
        public AllItemViewModel()
        {
            namePattern = string.Empty;
            fromBookAmount = null;
            toBookAmount = null;
            selectedCountry = null;
            countries = UnitOfWork.GetRepository<DataAccess.Entities.Country>()
                .Get(orderBy: query => query.OrderBy(country => country.Name)).ToArray();
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
        public DataAccess.Entities.Country SelectedCountry
        {
            get
            {
                return selectedCountry;
            }
            set
            {
                SetProperty(ref selectedCountry, value);
                SetFilter();
            }
        }
        public DataAccess.Entities.Country[] Countries => countries;

        // METHODS
        // NAVIGATION
        #region NAVIGATION
        protected override void NavigateToCreateView(object parameter)
        {
            // opens create window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.PublishingHouse).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.PublishingHouse, 
                    crudMode: Enums.CrudMode.Create));
        }
        protected override void NavigateToReadView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.PublishingHouse).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.PublishingHouse, 
                    crudMode: Enums.CrudMode.Read));
        }
        protected override void NavigateToUpdateView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(DataAccess.Entities.PublishingHouse).FullName,
                viewModel: new SingleItemViewModel(
                    shownEntity: parameter as DataAccess.Entities.PublishingHouse, 
                    crudMode: Enums.CrudMode.Update));
        }
        #endregion

        // FILTERING METHOD
        protected override bool FilterPredicate(object entity)
        {
            DataAccess.Entities.PublishingHouse publisjHouseToFilter = (DataAccess.Entities.PublishingHouse)entity;
            bool isShown = true;

            // checks name
            if (namePattern != null)
            {
                isShown &= DataAccess.Filters.PublishingHouseFilter.Where(publisjHouseToFilter, namePattern);
            }

            // checks books amount
            isShown &= DataAccess.Filters.PublishingHouseFilter.Has(publisjHouseToFilter, fromBookAmount, toBookAmount);

            // checks country
            if (selectedCountry != null)
            {
                isShown &= DataAccess.Filters.PublishingHouseFilter.Where(publisjHouseToFilter, selectedCountry);
            }

            return isShown;
        }
    }
}
