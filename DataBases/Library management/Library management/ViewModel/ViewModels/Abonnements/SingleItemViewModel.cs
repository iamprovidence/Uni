using System.Linq;

using DE = DataAccess.Entities;

namespace Library_management.ViewModel.ViewModels.Abonnements
{
    class SingleItemViewModel : SingleEntityViewModelBase<DE.Abonnement>
    {
        // FIELDS
        DE.Reader[] readers;
        DE.Book[] books;

        // CONSTRUCTORS
        public SingleItemViewModel(DE.Abonnement shownEntity, Enums.CrudMode crudMode)
            : base (shownEntity, crudMode)
        {
            readers = UnitOfWork.ReaderRepository.Get(orderBy: q => q.OrderBy(r => r.Name).ThenBy(r => r.Surname)).ToArray();
            books = UnitOfWork.BookRepository
                              .Get(orderBy: q => q.OrderBy(b => b.Name))
                              .AsEnumerable()
                              .Where(b => b.RemainsAmount > 0)
                              .ToArray();
        }

        // PROPERTIES
        public DE.Reader[] Readers => readers;
        public DE.Book[] Books => books;
    }
}
