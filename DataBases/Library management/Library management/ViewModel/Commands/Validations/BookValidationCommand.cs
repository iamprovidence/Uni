namespace Library_management.ViewModel.Commands.Validations
{
    class BookValidationCommand : ValidationCommandBase<DataAccess.Entities.Book>
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            // NAME
            EntityToValidate.Name = ValidateString(EntityToValidate.Name, "Book name", 1, 40);
            if (this.CommandState == Enums.CommandState.Interrupted) return;

            // AMOUNT
            if (EntityToValidate.Amount < 5)
            {
                WindowManager.ShowMessageBoxWindow("Minimum allowed amount = 5", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            if (EntityToValidate.Amount > 50000)
            {
                WindowManager.ShowMessageBoxWindow("Maximum allowed amount = 50 000", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }
            
            // REMAINS AMOUNT
            if (EntityToValidate.RemainsAmount < 0)
            {
                WindowManager.ShowMessageBoxWindow("You can not set 'remains amount' to negative", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            // YEAR
            if (EntityToValidate.Year.HasValue && EntityToValidate.Year.Value < 1873)
            {
                WindowManager.ShowMessageBoxWindow("Minimum allowed year = 1873", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            // COLLECTIONS

            // author or publishing house can stay unknown

            // CATEGORIES
            if (EntityToValidate.Categories.Count == 0)
            {
                WindowManager.ShowMessageBoxWindow("At least one category required", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }
            // GENRES
            if (EntityToValidate.Genres.Count == 0)
            {
                WindowManager.ShowMessageBoxWindow("At least one genre required", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            CommandState = Enums.CommandState.Executed;
        }
    }
}
