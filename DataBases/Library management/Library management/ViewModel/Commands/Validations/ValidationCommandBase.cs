namespace Library_management.ViewModel.Commands.Validations
{
    abstract class ValidationCommandBase<TEntity> : CommandBase where TEntity : DataAccess.Entities.EntityBase
    {
        // PROPERTIES
        public TEntity EntityToValidate { get; set; }

        // METHODS
        public string Trim(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim();
        }
        public string ValidateString(string stringToValidate, string nameOfProperty, int minLength, int maxLength)
        {
            if (stringToValidate == null)
            {
                WindowManager.ShowMessageBoxWindow($"{nameOfProperty} is required", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return stringToValidate;
            }
            stringToValidate = this.Trim(stringToValidate);
            if (string.IsNullOrWhiteSpace(stringToValidate))
            {
                WindowManager.ShowMessageBoxWindow($"{nameOfProperty} can not be empty", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return stringToValidate;
            }
            if (stringToValidate.Length < minLength)
            {
                WindowManager.ShowMessageBoxWindow($"{nameOfProperty} is too short{System.Environment.NewLine}Min length allowed = {minLength}", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return stringToValidate;
            }
            if (stringToValidate.Length > maxLength)
            {
                WindowManager.ShowMessageBoxWindow($"{nameOfProperty} is too long{System.Environment.NewLine}Max length allowed = {maxLength}", "Error");
                CommandState = Enums.CommandState.Interrupted;
                return stringToValidate;
            }

            return stringToValidate;
        }
    }
}
