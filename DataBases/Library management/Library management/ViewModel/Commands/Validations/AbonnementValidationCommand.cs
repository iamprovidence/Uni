namespace Library_management.ViewModel.Commands.Validations
{
    class AbonnementValidationCommand : ValidationCommandBase<DataAccess.Entities.Abonnement>
    {
        // FIELDS
        System.DateTime minTime;

        // CONSTRUCTORS
        public AbonnementValidationCommand()
        {
            minTime = new System.DateTime(year: 1754, month: 1, day: 1);
        }
        
            
        // METHODS       
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            // TAKE TIME
            if (EntityToValidate.TakeTime < minTime)
            {
                WindowManager.ShowMessageBoxWindow("Minimum allowed date is 01/01/1754", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            // TAKEN PERIOD
            if (EntityToValidate.TakenPeriod < EntityToValidate.TakeTime)
            {
                WindowManager.ShowMessageBoxWindow("Taken period can not be less than take time", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            // RETURN TIME
            if (EntityToValidate.ReturnTime.HasValue && EntityToValidate.ReturnTime < EntityToValidate.TakeTime)
            {
                WindowManager.ShowMessageBoxWindow("Return time can not be less than take time", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            // READER
            if (EntityToValidate.Reader == null)
            {
                WindowManager.ShowMessageBoxWindow("Reader is required", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            // BOOK
            if (EntityToValidate.Book == null)
            {
                WindowManager.ShowMessageBoxWindow("Book is required", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return;
            }

            CommandState = Enums.CommandState.Executed;
        }
    }
}
