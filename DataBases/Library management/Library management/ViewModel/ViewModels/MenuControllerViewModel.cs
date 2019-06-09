using System.Windows.Input;

namespace Library_management.ViewModel.ViewModels
{
    class MenuControllerViewModel : ViewModelBase
    {
        // FIELDS
        Structs.MenuItem[] menuItems;
        int menuItemIndex;
        Core.Services.Factory<ViewModelBase> menuItemViewModelFactory;

        // CONSTRUCTORS
        public MenuControllerViewModel()
        {
            menuItemIndex = -1;
            menuItems = new Structs.MenuItem[]
            {
                new Structs.MenuItem
                {
                    ItemText = "Reader",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/reader.png",
                },
                new Structs.MenuItem
                {
                    ItemText = "Abonnement",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/abonnement.png",
                },
                new Structs.MenuItem
                {
                    ItemText = "Book",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/book.png",
                },
                new Structs.MenuItem
                {
                    ItemText = "Author",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/author.png",
                },
                new Structs.MenuItem
                {
                    ItemText = "Category",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/category.png",
                },
                new Structs.MenuItem
                {
                    ItemText = "Genre",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/genre.png",
                },
                new Structs.MenuItem
                {
                    ItemText = "Publishing House",
                    ImagePath = @"pack://application:,,,/Resources/Pictogram/publishing_house.png",
                }
            };

            // register factory, menu item to view model
            menuItemViewModelFactory = new Core.Services.Factory<ViewModelBase>();
            menuItemViewModelFactory.Registrate(menuItems[0].ItemText, typeof(Reader.AllItemViewModel));
            menuItemViewModelFactory.Registrate(menuItems[1].ItemText, typeof(Abonnements.AllItemViewModel));
            menuItemViewModelFactory.Registrate(menuItems[2].ItemText, typeof(Book.AllItemViewModel));
            menuItemViewModelFactory.Registrate(menuItems[3].ItemText, typeof(Authors.AllItemViewModel));
            menuItemViewModelFactory.Registrate(menuItems[4].ItemText, typeof(Category.AllItemViewModel));
            menuItemViewModelFactory.Registrate(menuItems[5].ItemText, typeof(Genre.AllItemViewModel));
            menuItemViewModelFactory.Registrate(menuItems[6].ItemText, typeof(PublishingHouse.AllItemViewModel));
        }

        // PROPERTIES
        public Structs.MenuItem[] MenuItems => menuItems;
        public int MenuItemIndex
        {
            get
            {
                return menuItemIndex;
            }
            set
            {
                SetProperty(ref menuItemIndex, value);

                ChangeContentCommand.Execute(null);
            }
        }

        // COMMANDS
        #region CHANGE CONTENT COMMAND
        private ICommand changeContentCommand;
        public ICommand ChangeContentCommand
        {
            get
            {
                if (changeContentCommand == null) changeContentCommand = new Commands.RelayCommand(ChangeContentMethod);
                return changeContentCommand;
            }
        }
        private void ChangeContentMethod(object obj)
        {
            if (menuItemIndex != -1)
            {
                // clear history
                NavigationManager.ClearHistory();

                // gets menu item text
                string menuItemName = menuItems[menuItemIndex].ItemText;

                // create ViewModel by menu text
                ViewModelBase allItemViewModelBase = menuItemViewModelFactory.MakeInstance(menuItemName);

                // navigate to control registered by ViewModel name and pass him current view model             
                NavigationManager.NavigateTo(
                    parent: NavigationManager.MainContent,
                    key: allItemViewModelBase.GetType().FullName,
                    viewModel: allItemViewModelBase);
            }
        }
        #endregion
    }
}
