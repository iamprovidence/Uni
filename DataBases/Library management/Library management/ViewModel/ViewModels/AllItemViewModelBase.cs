using System.Linq;
using System.Windows.Input;

using DE = DataAccess.Entities;


namespace Library_management.ViewModel.ViewModels
{
    public abstract class AllItemViewModelBase<TEntity> : ViewModelBase where TEntity : DataAccess.Entities.EntityBase, new ()
    {
        // CONST
        private readonly static string STATISTIC_KEY_FORMAT = Services.NavigationManagerInitializer.DefaultNavigationManagerInitilizer.STATISTIC_KEY_FORMAT;

        // FIELDS
        System.Windows.Data.ListCollectionView entities;
        TEntity selectedEntity;
        Core.Services.Factory<StatisticOfItemViewModelBase<TEntity>> statisticViewModelFactory;

        // CONSTRUCTORS
        public AllItemViewModelBase()
        {
            entities = new System.Windows.Data.ListCollectionView(UnitOfWork.GetRepository<TEntity>().Get().ToArray());
            selectedEntity = null;
            statisticViewModelFactory = new Core.Services.Factory<StatisticOfItemViewModelBase<TEntity>>();
            RegistrateStatisticViewModel();
        }
        private void RegistrateStatisticViewModel()
        {
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.Abonnement).FullName), typeof(Abonnements.StatisticOfItemViewModel));
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.Author).FullName), typeof(Authors.StatisticOfItemViewModel));
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.Book).FullName), typeof(Book.StatisticOfItemViewModel));
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.Category).FullName), typeof(Category.StatisticOfItemViewModel));
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.Genre).FullName), typeof(Genre.StatisticOfItemViewModel));
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.PublishingHouse).FullName), typeof(PublishingHouse.StatisticOfItemViewModel));
            statisticViewModelFactory.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DE.Reader).FullName), typeof(Reader.StatisticOfItemViewModel));
        }

        // PROPERTIES
        public System.Windows.Data.ListCollectionView Entities => entities;

        public TEntity SelectedEntity
        {
            get
            {
                return selectedEntity;
            }
            set
            {
                SetProperty(ref selectedEntity, value);
            }
        }
        
        #region STATISTIC COMMAND
        ICommand statisticCommand;
        public ICommand StatisticCommand => statisticCommand ?? (statisticCommand = new Commands.RelayCommand(NavigateToStatisticView));
        protected virtual void NavigateToStatisticView(object parameter)
        {
            string key = string.Format(STATISTIC_KEY_FORMAT, typeof(TEntity).FullName);

            // opens statistic window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: key,
                viewModel: statisticViewModelFactory.MakeInstance(key));
        }
        #endregion

        // CRUD
        #region CRUD

        #region CREATE COMMAND
        ICommand createCommand;
        public ICommand CreateCommand => createCommand ?? (createCommand = new Commands.RelayCommand(NavigateToCreateView));

        protected virtual void NavigateToCreateView(object parameter)
        {
            // opens create window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(TEntity).FullName,
                viewModel: new SingleEntityViewModelBase<TEntity>(shownEntity: parameter as TEntity, crudMode: Enums.CrudMode.Create));
        }

        #endregion

        #region READ COMMAND
        ICommand readCommand;
        public ICommand ReadCommand => readCommand ?? (readCommand = new Commands.RelayCommand(NavigateToReadView));
        protected virtual void NavigateToReadView(object parameter)
        {
            // opens read window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(TEntity).FullName,
                viewModel: new SingleEntityViewModelBase<TEntity>(shownEntity: parameter as TEntity, crudMode: Enums.CrudMode.Read));
        }
        #endregion

        #region UPDATE COMMAND
        ICommand updateCommand;
        public ICommand UpdateCommand => updateCommand ?? (updateCommand = new Commands.RelayCommand(NavigateToUpdateView));

        protected virtual void NavigateToUpdateView(object parameter)
        {
            // opens edit window 
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(TEntity).FullName,
                viewModel: new SingleEntityViewModelBase<TEntity>(shownEntity: parameter as TEntity, crudMode: Enums.CrudMode.Update));
        }
        #endregion

        #region DELETE COMMAND
        ICommand deleteCommand;
        public virtual ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new Commands.Actions.GoToDeleteContentCommand<TEntity>());
            }
        }
        #endregion
        #endregion

        // METHODS
        public void SetFilter()
        {
            Entities.Filter = FilterPredicate;
        }
        protected abstract bool FilterPredicate(object entity);
    }
}
