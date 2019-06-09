namespace Library_management.ViewModel.Commands
{
    class RelayCommand : CommandBase
    {
        // FIELDS
        private System.Action<object> execute;
        private System.Func<object, bool> canExecute;

        // EVENT
        public override event System.EventHandler CanExecuteChanged
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
        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
