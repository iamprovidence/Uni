using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

using System;
using System.Linq;
using System.Collections.Generic;

namespace Library_management.ViewModel.ViewModels.Reader
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.Reader>
    {
        protected override void BuildStatistic()
        {
            // change color for each graph

            // reader info
            BuildReaderAbonnementInfoModel();
        }

        // STATISTIC
        #region ReaderInfo
        PlotModel readerInfoModel;
        public PlotModel ReaderInfoModel => readerInfoModel;

        protected void BuildReaderAbonnementInfoModel()
        {
            // gets reader name, taken book amount, unreturned amount and returned with a delay
            IEnumerable<KeyValuePair<string, Tuple<int, int, int>>> readerInfo = UnitOfWork.ReaderStatistic.GetReaderAbonnementInfo();

            // create plane
            PlotModel readerPlotModel = new PlotModel()
            {
                LegendBorderThickness = 0,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter
            };

            // add axes

            // add bottom axis with readers' names
            readerPlotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = readerInfo.Select(x => new { Name = x.Key }), // select names
                LabelField = "Name", // sets name label
                Angle = 15,
                Maximum = readerInfo.Count() >= 8 ? 8 : double.NaN,
                IsPanEnabled = true
            });

            // add left axis, no scrolling
            readerPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsPanEnabled = false
            });

            // add column series

            // taken book amount
            readerPlotModel.Series.Add(new ColumnSeries
            {
                Title = "Taken book amount",
                IsStacked = true,
                FillColor = GraphColor,
                ItemsSource = readerInfo.Select(x => new ColumnItem(x.Value.Item1))
            });

            ChangeGraphColor();

            // unreturned book amount
            readerPlotModel.Series.Add(new ColumnSeries
            {
                Title = "Unreturned book amount",
                IsStacked = true,
                FillColor = GraphColor,
                ItemsSource = readerInfo.Select(x => new ColumnItem(x.Value.Item2))
            });

            ChangeGraphColor();

            // returned with a delay 
            readerPlotModel.Series.Add(new ColumnSeries
            {
                Title = "Delayed book amount",
                IsStacked = true,
                FillColor = GraphColor,
                ItemsSource = readerInfo.Select(x => new ColumnItem(x.Value.Item3))
            });

            // initialize fields
            this.readerInfoModel = readerPlotModel;
        }
        #endregion
    }
}
