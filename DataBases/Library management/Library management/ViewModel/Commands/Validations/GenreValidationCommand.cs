namespace Library_management.ViewModel.Commands.Validations
{
    class GenreValidationCommand : ValidationCommandBase<DataAccess.Entities.Genre>
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            EntityToValidate.Name = ValidateString(EntityToValidate.Name, "Genre name", 3, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            CommandState = Enums.CommandState.Executed;
        }
    }
}
