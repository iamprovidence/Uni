namespace Library_management.ViewModel.Commands.Validations
{
    class PublishingHouseValidationCommand : ValidationCommandBase<DataAccess.Entities.PublishingHouse>
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            EntityToValidate.Name = ValidateString(EntityToValidate.Name, "Publishing house name", 3, 25);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            if (EntityToValidate.Country == null)
            {
                WindowManager.ShowMessageBoxWindow("Country is required", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            CommandState = Enums.CommandState.Executed;
        }
    }
}
