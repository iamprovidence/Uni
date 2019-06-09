using System.Linq;

using DE = DataAccess.Entities;

namespace Library_management.ViewModel.ViewModels.PublishingHouse
{
    /// <summary>
    /// A logic class for <see cref="View.UserControls.PublishingHouse.SingleItem"/>
    /// </summary>
    class SingleItemViewModel : SingleEntityViewModelBase<DE.PublishingHouse>
    {
        // FIELDS
        DE.Country[] countries;

        // CONSTRUCTORS
        public SingleItemViewModel(DE.PublishingHouse shownEntity, Enums.CrudMode crudMode)
            : base(shownEntity, crudMode)
        {
            countries = UnitOfWork.GetRepository<DE.Country>().Get(orderBy: q => q.OrderBy(c => c.Name)).ToArray();
        }

        // PROPERTIES
        public DE.Country[] Countries => countries;
    }
}
