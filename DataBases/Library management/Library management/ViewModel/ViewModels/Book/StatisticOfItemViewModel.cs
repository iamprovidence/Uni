using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

using System;
using System.Linq;
using System.Collections.Generic;

namespace Library_management.ViewModel.ViewModels.Book
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.Book>
    {
        // CONSTRUCTORS
        protected override void BuildStatistic()
        {
            // change color for each graph

            // storage info
            BuildStorageModel();
            ChangeGraphColor();

            // best
            BuildBestEntityModel(UnitOfWork.BookStatistic.GetBookPopularityAmount);
            ChangeGraphColor();
            BuildPercentageBestEntityModel(UnitOfWork.BookStatistic.GetBookPopularityPercentageAmount);
        }

        // STATISTIC
        #region StorageInfo
        PlotModel storageInfoModel;
        public PlotModel StorageInfoModel => storageInfoModel;

        protected void BuildStorageModel()
        {
            // gets book name, total amount and remains amount
            IEnumerable<KeyValuePair<string, Tuple<int, int>>> booksStorageInfo = UnitOfWork.BookStatistic.GetStorageInfo();

            // create plane
            PlotModel bookStorageModel = new PlotModel()
            {
                LegendBorderThickness = 0,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Outside, 
                LegendPosition = LegendPosition.BottomCenter
            };

            // add axes

            // add bottom axis with book' names
            bookStorageModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = booksStorageInfo.Select(x => new { Name = x.Key }), // select names
                LabelField = "Name", // sets name label
                Angle = 15,
                Maximum = booksStorageInfo.Count() >= 8 ? 8 : double.NaN
            });

            // add left axis, no scrolling
            bookStorageModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsPanEnabled = false
            });

            // add column series

            // remains book
            bookStorageModel.Series.Add(new ColumnSeries
            {
                Title = "Remains book amount",
                FillColor = GraphColor,
                ItemsSource = booksStorageInfo.Select(x => new ColumnItem(x.Value.Item2))
            });
            
            ChangeGraphColor();

            // total books
            bookStorageModel.Series.Add(new ColumnSeries 
            {
                Title = "Total book amount",
                FillColor = GraphColor,
                ItemsSource = booksStorageInfo.Select(x => new ColumnItem(x.Value.Item1))
            });
            
            // initialize fields
            this.storageInfoModel = bookStorageModel;
        }
        #endregion
    }
}
