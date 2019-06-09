namespace Library_management.ViewModel
{
    abstract class CommandBase : System.Windows.Input.ICommand
    {
        // FIELDS        
        readonly Services.WindowManager windowManager;
        readonly Services.NavigationManager navigationManager;
        readonly DataAccess.Context.UnitOfWork unitOfWork;
        Enums.CommandState commandState;

        // CONSTRUCTORS
        public CommandBase()
        {
            windowManager = Services.WindowManager.Instance;
            navigationManager = Services.NavigationManager.Instance;
            unitOfWork = DataAccess.Context.UnitOfWork.Instance;
            commandState = Enums.CommandState.Default;
        }

        // PROPERTIES
        public Services.WindowManager WindowManager => windowManager;
        public Services.NavigationManager NavigationManager => navigationManager;
        public DataAccess.Context.UnitOfWork UnitOfWork => unitOfWork;
        public Enums.CommandState CommandState
        {
            get
            {
                return commandState;
            }
            protected set
            {
                commandState = value;
            }
        }

        // EVENTS
        public virtual event System.EventHandler CanExecuteChanged;

        // METHODS
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
        
        protected virtual void OnCanExecuteChanged(System.EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }
    }
}
