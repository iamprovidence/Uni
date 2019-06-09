using System.Windows.Input;

namespace Library_management.ViewModel.Commands
{
    /// <summary>
    /// Implements Chain-of-Responsibility pattern
    /// </summary>
    class MultipleCommand : CommandBase
    {
        // FIELDS
        CommandBase[] commands;

        // EVENT
        /// <summary>
        /// Occurs when state of the command has been changed
        /// </summary>
        public override event System.EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        // CONSTRUCTORS
        public MultipleCommand(CommandBase[] commands)
        {
            this.commands = commands;
        }

        // METHODS
        public override bool CanExecute(object parameter)
        {
            // check if all commands can be executed
            foreach (CommandBase command in commands)
            {
                if (!command.CanExecute(parameter))
                {
                    return false;
                }
            }

            // all command can be executed
            return true;
        }
        
        public override void Execute(object parameter)
        {
            // execute command one by one
            foreach (CommandBase command in commands)
            {
                command.Execute(parameter);

                // stop command executing, if current command has been interrupted
                if (command.CommandState == Enums.CommandState.Interrupted)
                {
                    return;
                }
            }
        }
    }
}
