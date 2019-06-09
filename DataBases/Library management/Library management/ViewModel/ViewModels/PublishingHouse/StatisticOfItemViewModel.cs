namespace Library_management.ViewModel.ViewModels.PublishingHouse
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.PublishingHouse>
    {
        // CONSTRUCTORS
        protected override void BuildStatistic()
        {
            // change color for each graph

            // total amount
            BuildBookAmountModel(UnitOfWork.PublishingHouseStatistic.GetPublishedBookAmount);
            ChangeGraphColor();
            BuildBookEntityPercentageModel(UnitOfWork.PublishingHouseStatistic.GetPublishedBookAmountPercentage);
            ChangeGraphColor();

            // best
            BuildBestEntityModel(UnitOfWork.PublishingHouseStatistic.GetPublishingHousePopularityAmount);
            ChangeGraphColor();
            BuildPercentageBestEntityModel(UnitOfWork.PublishingHouseStatistic.GetPublishingHousePopularityPercentageAmount);
        }
    }
}
