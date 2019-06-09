namespace Library_management.ViewModel.ViewModels.Genre
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.Genre>
    {
        // CONSTRUCTORS
        protected override void BuildStatistic()
        {
            // change color for each graph

            // total amount
            BuildBookAmountModel(UnitOfWork.GenreStatistic.GetGenreAmount);
            ChangeGraphColor();
            BuildBookEntityPercentageModel(UnitOfWork.GenreStatistic.GetGenrePercentageAmount);
            ChangeGraphColor();

            // best
            BuildBestEntityModel(UnitOfWork.GenreStatistic.GetGenrePopularityAmount);
            ChangeGraphColor();
            BuildPercentageBestEntityModel(UnitOfWork.GenreStatistic.GetGenrePopularityPercentageAmount);
        }

    }
}
