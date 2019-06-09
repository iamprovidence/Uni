using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

using System;
using System.Collections.Generic;

namespace Library_management.ViewModel.ViewModels.Abonnements
{
    class StatisticOfItemViewModel : StatisticOfItemViewModelBase<DataAccess.Entities.Abonnement>
    {
        // FIELDS
        DateTime fromPeriod;
        DateTime toPeriod;

        // CONSTRUCTORS
        protected override void BuildStatistic()
        {
            fromPeriod = DateTime.Now.AddDays(-7);
            toPeriod = DateTime.Now.AddDays(1);

            // change color for each graph

            // reader info
            BuildAbonnementInfoModel();
            ChangeGraphColor();
            BuildAbonnementDateInfoModel(fromPeriod, toPeriod);
        }

        // PROPERTIES
        public DateTime FromPeriod
        {
            get
            {
                return fromPeriod;
            }
            set
            {
                SetProperty(ref fromPeriod, value);
                UpdateDateSefely();
                BuildAbonnementDateInfoModel(fromPeriod, toPeriod);
            }
        }
        public DateTime ToPeriod
        {
            get
            {
                return toPeriod;
            }
            set
            {
                SetProperty(ref toPeriod, value);
                UpdateDateSefely();
                BuildAbonnementDateInfoModel(fromPeriod, toPeriod);
            }
        }

        // METHODS
        /// <summary>
        /// Sets interval in minimum two days
        /// </summary>
        public void UpdateDateSefely(int minInterval = 2)
        {
            if (fromPeriod >= toPeriod || (toPeriod - fromPeriod).Days < minInterval)
            {
                toPeriod = fromPeriod.AddDays(minInterval);
                OnPropertyChanged(nameof(ToPeriod));
            }
        }

        // STATISTICS
        #region AbonnementInfo
        PlotModel abonnementInfoModel;
        public PlotModel AbonnementInfoModel => abonnementInfoModel;

        protected void BuildAbonnementInfoModel()
        {
            // create plane
            PlotModel plotModel = new PlotModel();

            // create series
            PieSeries pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                TrackerFormatString = "{1}: ({3:P1})"
            };

            // return properly amount, unreturned amount, returned with delay amount
            Tuple<int, int, int> abonnementInfo = UnitOfWork.AbonnementStatistic.GetAbonnementInfo();

            // add pie slices
            
            // total
            pieSeries.Slices.Add(new PieSlice("Return properly amount", abonnementInfo.Item1)
            {
                Fill = GraphColor
            });

            ChangeGraphColor();

            // unreturned
            pieSeries.Slices.Add(new PieSlice("Unreturned amount", abonnementInfo.Item2)
            {
                Fill = GraphColor
            });

            ChangeGraphColor();
            
            // delayed
            pieSeries.Slices.Add(new PieSlice("Delayed amount", abonnementInfo.Item3)
            {
                Fill = GraphColor
            });

            // add series
            plotModel.Series.Add(pieSeries);

            // initialize fields
            this.abonnementInfoModel = plotModel;
        }
        #endregion

        #region AbonnementDateInfo
        PlotModel abonnementDateInfoModel;
        public PlotModel AbonnementDateInfoModel => abonnementDateInfoModel;

        protected void BuildAbonnementDateInfoModel(DateTime fromPeriod, DateTime toPeriod)
        {
            // create plane
            PlotModel plotModel = new PlotModel()
            {
                LegendBorderThickness = 0,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter
            };
                       
            // add DateTime axis
            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd/MM",

                MinorIntervalType = DateTimeIntervalType.Days,
                IntervalType = DateTimeIntervalType.Days,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,

                Maximum = DateTimeAxis.ToDouble(fromPeriod.AddDays(7)),
                IsPanEnabled = true,
            });

            // create series
            // take book
            LineSeries takeBookLineSeries = new LineSeries()
            {
                Title = "Take book",

                StrokeThickness = 2,                
                Color = GraphColor,

                MarkerFill = GraphColor,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStrokeThickness = 2,
                MarkerStroke = OxyColor.FromRgb(255, 255, 255),

                TrackerFormatString = String.Join(Environment.NewLine, "Date: {2:dd-MM-yyyy}", "Take book: {4:0}")
            };

            ChangeGraphColor();

            // return book
            LineSeries returnBookLineSeries = new LineSeries()
            {
                Title = "Return book",

                StrokeThickness = 2,
                Color = GraphColor,

                MarkerFill = GraphColor,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStrokeThickness = 2,
                MarkerStroke = OxyColor.FromRgb(255, 255, 255),

                TrackerFormatString = String.Join(Environment.NewLine, "Date: {2:dd-MM-yyyy}", "Return book: {4:0}")
            };
                        
            // add data to the series
            // key = date
            // value = int[] { take book amount, return book amount }            
            IList<KeyValuePair<DateTime, int[]>> abonnementPeriodInfo = UnitOfWork.AbonnementStatistic.GetAbonnementPeriodInfo(fromPeriod, toPeriod);
            
            foreach (KeyValuePair<DateTime, int[]> info in abonnementPeriodInfo)
            {
                takeBookLineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(info.Key), info.Value[0]));// take book amount
                returnBookLineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(info.Key), info.Value[1]));// return book amount
            }
            
            // add series to plot model
            plotModel.Series.Add(takeBookLineSeries);
            plotModel.Series.Add(returnBookLineSeries);

            // initialize fields
            this.abonnementDateInfoModel = plotModel;
            OnPropertyChanged(nameof(AbonnementDateInfoModel));
        }
        #endregion
    }
}
