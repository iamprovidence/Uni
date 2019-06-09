using System.Linq;

using DE = DataAccess.Entities;

namespace Library_management.ViewModel.ViewModels.Book
{
    class SingleItemViewModel : SingleEntityViewModelBase<DE.Book>
    {
        // FIELDS
        Structs.SelectedItem<DE.Author>[] authors;
        Structs.SelectedItem<DE.Category>[] categories;
        Structs.SelectedItem<DE.Genre>[] genres;
        Structs.SelectedItem<DE.PublishingHouse>[] publishingHouses;

        // CONSTRUCTORS
        public SingleItemViewModel(DE.Book shownEntity, Enums.CrudMode crudMode)
            : base(shownEntity, crudMode)
        {
            switch (crudMode)
            {
                case Enums.CrudMode.Create: GetAllData(ShownEntity); break;
                case Enums.CrudMode.Update: GetAllData(ShownEntity); break;
                case Enums.CrudMode.Read: GetShownData(ShownEntity); break;
                default: throw new System.NotSupportedException();
            }
        }
        private void GetAllData(DE.Book book)
        {
            authors = UnitOfWork.AuthorRepositories
                .Get(orderBy: q => q.OrderBy(author => author.Nickname))
                .AsEnumerable()
                .Select(author => new Structs.SelectedItemCollection<DE.Author>
                {
                    Item = author,
                    CollectionToModify = book.Authors,
                    IsSelected = book.Authors.Contains(author)
                }).ToArray();

            categories = UnitOfWork.CategoryRepository
                .Get(orderBy: q => q.OrderBy(category => category.Name))
                .AsEnumerable()
                .Select(category => new Structs.SelectedItemCollection<DE.Category>
                {
                    Item = category,
                    CollectionToModify = book.Categories,
                    IsSelected = book.Categories.Contains(category)
                }).ToArray();

            genres = UnitOfWork.GenreRepository
                .Get(orderBy: q => q.OrderBy(genre => genre.Name))
                .AsEnumerable()
                .Select(genre => new Structs.SelectedItemCollection<DE.Genre>
                {
                    Item = genre,
                    CollectionToModify = book.Genres,
                    IsSelected = book.Genres.Contains(genre)
                }).ToArray();

            publishingHouses = UnitOfWork.PublishHouseRepository
                .Get(orderBy: q => q.OrderBy(publishingHouse => publishingHouse.Name))
                .AsEnumerable()
                .Select(publishingHouse => new Structs.SelectedItemCollection<DE.PublishingHouse>
                {
                    Item = publishingHouse,
                    CollectionToModify = book.PublishingHouses,
                    IsSelected = book.PublishingHouses.Contains(publishingHouse)
                }).ToArray();
        }
        private void GetShownData(DE.Book book)
        {
            authors = book.Authors
                .OrderBy(author => author.Nickname)
                .Select(author => new Structs.SelectedItem<DE.Author>
                {
                    Item = author,
                    IsSelected = true
                }).ToArray();

            categories = book.Categories
                .OrderBy(category => category.Name)
                .Select(category => new Structs.SelectedItem<DE.Category>
                {
                    Item = category,
                    IsSelected = true
                }).ToArray();

            genres = book.Genres
                .OrderBy(genre => genre.Name)
                .Select(genre => new Structs.SelectedItem<DE.Genre>
                {
                    Item = genre,
                    IsSelected = true
                }).ToArray();

            publishingHouses = book.PublishingHouses
                .OrderBy(publishingHouse => publishingHouse.Name)
                .Select(publishingHouse => new Structs.SelectedItem<DE.PublishingHouse>
                {
                    Item = publishingHouse,
                    IsSelected = true
                }).ToArray();
        }

        // FIELDS
        public Structs.SelectedItem<DE.Author>[] Authors => authors;
        public Structs.SelectedItem<DE.Category>[] Categories => categories;
        public Structs.SelectedItem<DE.Genre>[] Genres => genres;
        public Structs.SelectedItem<DE.PublishingHouse>[] PublishingHouses => publishingHouses;

    }
}
