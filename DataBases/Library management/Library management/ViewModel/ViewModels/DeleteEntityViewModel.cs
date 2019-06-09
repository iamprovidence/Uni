using System.Windows.Input;

namespace Library_management.ViewModel.ViewModels
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.DeleteItem"/>
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of entity required deleting
    /// </typeparam>
    class DeleteEntityViewModel<TEntity> : ViewModelBase where TEntity : DataAccess.Entities.EntityBase
    {
        // FIELDS
        TEntity entity;
        
        // CONSTRUCTORS
        public DeleteEntityViewModel(TEntity entity)
        {
            this.entity = entity;
        }

        // PROPERTIES
        public TEntity Entity => entity;
        public string EntityName => entity.GetName();
        public string EntityBriefInfo => entity.GetBriefInfo();

        // COMMANDS

        // CANCEL
        #region CANCEL COMMAND
        ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null) cancelCommand = new Commands.Actions.GoBackCommand();
                return cancelCommand;
            }
        }
        #endregion

        // ACCEPT
        #region ACCEPT COMMAND
        ICommand acceptCommand;
        public ICommand AcceptCommand
        {
            get
            {
                if (acceptCommand == null)
                {
                    acceptCommand = new Commands.MultipleCommand(
                    new CommandBase[]
                    {
                        new Commands.RelayCommand(AcceptDeletingCommandMethod),
                        new Commands.Actions.GoBackCommand(doSearchForDefault: true)
                    });
                }
                return acceptCommand;
            }
        }
        private void AcceptDeletingCommandMethod(object parameter)
        {
            // delete from repository
            UnitOfWork.GetRepository<TEntity>().Delete(entity);

            // save changes
            UnitOfWork.Save();
        }
        #endregion

    }
}
