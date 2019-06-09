namespace Library_management.ViewModel.Commands.Validations
{
    class CategoryValidationCommand : ValidationCommandBase<DataAccess.Entities.Category>
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            EntityToValidate.Name = ValidateString(EntityToValidate.Name, "Category name", 3, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            CommandState = Enums.CommandState.Executed;
        }
    }
}
