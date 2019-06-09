namespace Library_management.ViewModel.Commands.Actions
{
    class GoBackCommand : CommandBase
    {
        // FIELDS
        bool doSearchForDefault;

        // CONSTRUCTORS
        public GoBackCommand(bool doSearchForDefault = false)
        {
            this.doSearchForDefault = doSearchForDefault;
        } 
        
        // METHODS
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Executes command
        /// </summary>
        /// <param name="parameter">
        /// Shown entity
        /// </param>
        public override void Execute(object parameter)
        {
            // You don't have to change entity if you want to go back.
            // The entity is detached after it has been created and it isn't yet in database.
            if (parameter != null && UnitOfWork.DataBaseContext.Entry(parameter).State != System.Data.Entity.EntityState.Detached)
            {
                UnitOfWork.DataBaseContext.Entry(parameter).State = System.Data.Entity.EntityState.Unchanged;
            }

            // go back to previous content with its view model
            NavigationManager.NavigateToPrevious(parent: NavigationManager.MainContent, doSearchForDefault: doSearchForDefault);
        }
    }
}
