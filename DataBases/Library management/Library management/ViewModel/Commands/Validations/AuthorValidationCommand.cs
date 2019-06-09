namespace Library_management.ViewModel.Commands.Validations
{
    class AuthorValidationCommand : ValidationCommandBase<DataAccess.Entities.Author>
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            CommandState = Enums.CommandState.Default;

            EntityToValidate.Name = ValidateString(EntityToValidate.Name, "Author name", 3, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;
            EntityToValidate.Surname = ValidateString(EntityToValidate.Surname, "Author surname", 3, 20);
            if (this.CommandState == Enums.CommandState.Interrupted) return;
            EntityToValidate.Nickname = ValidateString(EntityToValidate.Nickname, "Author nickname", 3, 45);
            if (this.CommandState == Enums.CommandState.Interrupted) return;
            
            CommandState = Enums.CommandState.Executed;
        }
    }
}
