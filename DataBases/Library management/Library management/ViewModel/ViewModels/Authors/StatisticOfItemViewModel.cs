namespace Library_management.ViewModel.ViewModels.Authors
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.Author>
    {
        // CONSTRUCTORS
        protected override void BuildStatistic()
        {
            // change color for each graph

            // total amount
            BuildBookAmountModel(UnitOfWork.AuthorStatistic.GetWrittenBookAmount);
            ChangeGraphColor();
            BuildBookEntityPercentageModel(UnitOfWork.AuthorStatistic.GetWrittenBookAmountPercentage);
            ChangeGraphColor();

            // best
            BuildBestEntityModel(UnitOfWork.AuthorStatistic.GetAuthorPopularityAmount);
            ChangeGraphColor();
            BuildPercentageBestEntityModel(UnitOfWork.AuthorStatistic.GetAuthorPopularityPercentageAmount);
        }
    }
}
