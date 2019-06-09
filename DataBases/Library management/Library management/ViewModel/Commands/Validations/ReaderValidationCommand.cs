namespace Library_management.ViewModel.Commands.Validations
{
    class ReaderValidationCommand : ValidationCommandBase<DataAccess.Entities.Reader>
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            EntityToValidate.Name = ValidateString(EntityToValidate.Name, "Reader name", 2, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            EntityToValidate.Surname = ValidateString(EntityToValidate.Surname, "Reader surname", 2, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            EntityToValidate.Phone = ValidateString(EntityToValidate.Phone, "Reader phone", 10, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;
            if (!System.Text.RegularExpressions.Regex.IsMatch(EntityToValidate.Phone, @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$"))
            {
                WindowManager.ShowMessageBoxWindow($"Reader phone in wrong format{System.Environment.NewLine}Try XXX-XXX-XXXX", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            EntityToValidate.Address = ValidateString(EntityToValidate.Address, "Reader address", 5, 50);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            CommandState = Enums.CommandState.Executed;
        }
    }
}
