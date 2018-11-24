namespace DiffieHellman.ViewModel
{
    class RelayCommand : System.Windows.Input.ICommand
    {
        // FIELDS
        private System.Action<object> execute;
        private System.Func<object, bool> canExecute;

        // EVENT
        public event System.EventHandler CanExecuteChanged
        {
            add
            {
                System.Windows.Input.CommandManager.RequerySuggested += value;
            }
            remove
            {
                System.Windows.Input.CommandManager.RequerySuggested -= value;
            }
        }

        // CONSTRUCTORS
        public RelayCommand(System.Action<object> execute, System.Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        // METHODS
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}