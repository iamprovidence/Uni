using System.Windows.Input;

using DE = DataAccess.Entities;
using CV = Library_management.ViewModel.Commands.Validations;

namespace Library_management.ViewModel.ViewModels
{
    public class SingleEntityViewModelBase<TEntity> : ViewModelBase where TEntity: DE.EntityBase, new()
    {
        // FIELDS
        TEntity shownEntity;
        Enums.CrudMode crudMode;
        Core.Services.Factory<CV.ValidationCommandBase<TEntity>> validationCommandFactory;

        // CONSTRUCTORS
        public SingleEntityViewModelBase(TEntity shownEntity, Enums.CrudMode crudMode)
        {
            if (crudMode == Enums.CrudMode.Create) shownEntity = new TEntity();
            if (shownEntity == null) throw new System.ArgumentException(nameof(shownEntity));

            // initialize fields
            this.shownEntity = shownEntity;
            this.crudMode = crudMode;
            this.validationCommandFactory = new Core.Services.Factory<CV.ValidationCommandBase<TEntity>>();

            // registrate validation command
            RegistrateValidationCommand();
        }
        private void RegistrateValidationCommand()
        {
            validationCommandFactory.Registrate(typeof(DE.Abonnement).Name,         typeof(CV.AbonnementValidationCommand));
            validationCommandFactory.Registrate(typeof(DE.Author).Name,             typeof(CV.AuthorValidationCommand));
            validationCommandFactory.Registrate(typeof(DE.Book).Name,               typeof(CV.BookValidationCommand));
            validationCommandFactory.Registrate(typeof(DE.Category).Name,           typeof(CV.CategoryValidationCommand));
            validationCommandFactory.Registrate(typeof(DE.Genre).Name,              typeof(CV.GenreValidationCommand));
            validationCommandFactory.Registrate(typeof(DE.PublishingHouse).Name,    typeof(CV.PublishingHouseValidationCommand));
            validationCommandFactory.Registrate(typeof(DE.Reader).Name,             typeof(CV.ReaderValidationCommand));
        }

        // PROPERTIES
        public TEntity ShownEntity => shownEntity;
        public bool IsWritingEnabled => crudMode == Enums.CrudMode.Create || crudMode == Enums.CrudMode.Update;
        public string CrudOperationName
        {
            get
            {
                switch (crudMode)
                {
                    case Enums.CrudMode.Create: return "Create";
                    case Enums.CrudMode.Read: return "Delete";
                    case Enums.CrudMode.Update: return "Save Changes";
                    default: throw new System.InvalidOperationException();
                }
            }
        }

        // COMMANDS
        #region GO BACK COMMAND
        ICommand goBackCommand;
        public virtual ICommand GoBackCommand => goBackCommand ?? (goBackCommand = new Commands.Actions.GoBackCommand());
        #endregion
        #region CRUD OPERATION
        ICommand crudOperation;
        public ICommand CrudOperation
        {
            get
            {
                if (crudOperation == null) SetCrudOperation();
                return crudOperation;
            }
        }

        private void SetCrudOperation()
        {
            switch (crudMode)
            {
                case Enums.CrudMode.Create:
                    crudOperation = new Commands.MultipleCommand(new CommandBase[]
                    {
                        CreateValidationCommand(),
                        new Commands.RelayCommand(CreateEntity),
                        new Commands.Actions.GoBackCommand()
                    }); break;
                case Enums.CrudMode.Update:
                    crudOperation = new Commands.MultipleCommand(new CommandBase[]
                    {
                        CreateValidationCommand(),
                        new Commands.RelayCommand(UpdateEntity),
                        new Commands.Actions.GoBackCommand()
                    }); break;
                case Enums.CrudMode.Read: crudOperation = new Commands.Actions.GoToDeleteContentCommand<TEntity>(); break;
                default: throw new System.InvalidOperationException();
            }
        }
        private CV.ValidationCommandBase<TEntity> CreateValidationCommand()
        {
            CV.ValidationCommandBase<TEntity> validationCommand = validationCommandFactory.MakeInstance(typeof(TEntity).Name);
            validationCommand.EntityToValidate = shownEntity;
            return validationCommand;
        }
        private void CreateEntity(object parameter)
        {
            // add to database
            UnitOfWork.GetRepository<TEntity>()
                .Insert(shownEntity);

            // save changes
            UnitOfWork.Save();
        }
        public void UpdateEntity(object parameter)
        {
            // update in database
            UnitOfWork.GetRepository<TEntity>()
                .Update(shownEntity);

            // save changes
            UnitOfWork.Save();
        }
        #endregion
    }
}
