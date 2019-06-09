namespace Library_management.ViewModel.Commands.Actions
{
    class GoToDeleteContentCommand<TEntity> : CommandBase where TEntity : DataAccess.Entities.EntityBase
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter">
        /// Entity to delete
        /// </param>
        public override void Execute(object parameter)
        {
            NavigationManager.NavigateTo(
                parent: NavigationManager.MainContent,
                key: typeof(View.UserControls.DeleteItem).FullName,
                viewModel: new ViewModels.DeleteEntityViewModel<TEntity>((TEntity)parameter));
        }
    }
}
