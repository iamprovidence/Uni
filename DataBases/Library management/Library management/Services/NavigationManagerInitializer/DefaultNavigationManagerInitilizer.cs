using Library_management.View.UserControls;

// VIEW MODELS
using AbonnementsVM = Library_management.ViewModel.ViewModels.Abonnements;
using AuthorsVM = Library_management.ViewModel.ViewModels.Authors;
using BookVM = Library_management.ViewModel.ViewModels.Book;
using CategoryVM = Library_management.ViewModel.ViewModels.Category;
using GenreVM = Library_management.ViewModel.ViewModels.Genre;
using PublishingHouseVM = Library_management.ViewModel.ViewModels.PublishingHouse;
using ReaderVM = Library_management.ViewModel.ViewModels.Reader;

// VIEW
using AbonnementV = Library_management.View.UserControls.Abonnement;
using AuthorV = Library_management.View.UserControls.Author;
using BookV = Library_management.View.UserControls.Book;
using CategoryV = Library_management.View.UserControls.Category;
using GenreV = Library_management.View.UserControls.Genre;
using PublishingHouseV = Library_management.View.UserControls.PublishingHouse;
using ReaderV = Library_management.View.UserControls.Reader;

// DATA ACCESS ENTITIES
using DA = DataAccess.Entities;

namespace Library_management.Services.NavigationManagerInitializer
{
    public class DefaultNavigationManagerInitilizer : NavigationManagerInitializerBase
    {
        public static string STATISTIC_KEY_FORMAT => "{0}Statistic";

        public override void Initialize(NavigationManager navigationManager)
        {
            // ALL ITEMS CONTROL are registered by theirs ViewModel full name
            // SINGLE ITEM CONTROL are registered by theirs Entity full name
            // STATISTIC CONTROL are registered by theirs Entity full name + ___Statistic
            // windows are registered by theirs full name


            // DELETE
            navigationManager.Registrate(typeof(DeleteItem).FullName, typeof(DeleteItem));

            // ABONNEMENT
            navigationManager.Registrate(typeof(AbonnementsVM.AllItemViewModel).FullName, typeof(AbonnementV.AllItem));
            navigationManager.Registrate(typeof(DA.Abonnement).FullName, typeof(AbonnementV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.Abonnement).FullName), typeof(AbonnementV.StatisticOfItem));

            // AUTHOR
            navigationManager.Registrate(typeof(AuthorsVM.AllItemViewModel).FullName, typeof(AuthorV.AllItem));
            navigationManager.Registrate(typeof(DA.Author).FullName, typeof(AuthorV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.Author).FullName), typeof(AuthorV.StatisticOfItem));

            // BOOK
            navigationManager.Registrate(typeof(BookVM.AllItemViewModel).FullName, typeof(BookV.AllItem));
            navigationManager.Registrate(typeof(DA.Book).FullName, typeof(BookV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.Book).FullName), typeof(BookV.StatisticOfItem));

            // CATEGORY
            navigationManager.Registrate(typeof(CategoryVM.AllItemViewModel).FullName, typeof(CategoryV.AllItem));
            navigationManager.Registrate(typeof(DA.Category).FullName, typeof(CategoryV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.Category).FullName), typeof(CategoryV.StatisticOfItem));

            // GENRE
            navigationManager.Registrate(typeof(GenreVM.AllItemViewModel).FullName, typeof(GenreV.AllItem));
            navigationManager.Registrate(typeof(DA.Genre).FullName, typeof(GenreV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.Genre).FullName), typeof(GenreV.StatisticOfItem));

            // PUBLISHING HOUSE
            navigationManager.Registrate(typeof(PublishingHouseVM.AllItemViewModel).FullName, typeof(PublishingHouseV.AllItem));
            navigationManager.Registrate(typeof(DA.PublishingHouse).FullName, typeof(PublishingHouseV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.PublishingHouse).FullName), typeof(PublishingHouseV.StatisticOfItem));

            // READER
            navigationManager.Registrate(typeof(ReaderVM.AllItemViewModel).FullName, typeof(ReaderV.AllItem));
            navigationManager.Registrate(typeof(DA.Reader).FullName, typeof(ReaderV.SingleItem));
            navigationManager.Registrate(string.Format(STATISTIC_KEY_FORMAT, typeof(DA.Reader).FullName), typeof(ReaderV.StatisticOfItem));
        }
    }
}
