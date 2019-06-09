namespace Library_management.ViewModel.ViewModels.Category
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.Category>
    {
        // CONSTRUCTORS
        protected override void BuildStatistic()
        {
            // change color for each graph

            // total amount
            BuildBookAmountModel(UnitOfWork.CategoryStatistic.GetCategoryAmount);
            ChangeGraphColor();
            BuildBookEntityPercentageModel(UnitOfWork.CategoryStatistic.GetCategoryPercentageAmount);
            ChangeGraphColor();

            // best
            BuildBestEntityModel(UnitOfWork.CategoryStatistic.GetCategoryPopularityAmount);
            ChangeGraphColor();
            BuildPercentageBestEntityModel(UnitOfWork.CategoryStatistic.GetCategoryPopularityPercentageAmount);
        }
    }
}
