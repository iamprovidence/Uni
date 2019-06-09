using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;

namespace Library_management.ViewModel.ViewModels
{
    abstract class StatisticOfItemViewModelBase<TEntity> : ViewModelBase
    {
        // FIELDS
        System.Random random;
        OxyColor graphColor;

        // CONSTRUCTORS
        public StatisticOfItemViewModelBase()
        {
            random = new System.Random();
            graphColor = OxyColor.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
            BuildStatistic();
        }

        // PROPERTIES
        public System.Random Random => random;
        public OxyColor GraphColor
        {
            get
            {
                return graphColor;
            }
            set
            {
                graphColor = value;
            }
        }

        // METHODS
        public void ChangeGraphColor()
        {
            graphColor = OxyColor.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
        }

        // COMMAND
        #region GO BACK COMMAND
        ICommand goBackCommand;
        public virtual ICommand GoBackCommand => goBackCommand ?? (goBackCommand = new Commands.Actions.GoBackCommand());
        #endregion

        // STATISTICS
        public delegate IEnumerable<KeyValuePair<string, int>> NameAmountDelegate();
        public delegate IEnumerable<KeyValuePair<string, int>> LimitedNameAmountDelegate(int limitAmount);

        protected abstract void BuildStatistic();
        #region BookAmountModel
        PlotModel bookAmountModel;
        public PlotModel BookAmountModel => bookAmountModel;

        protected void BuildBookAmountModel(NameAmountDelegate entityNameBookAmountDelegate)
        {
            // gets entities' names and amount of book for each entity
            IEnumerable<KeyValuePair<string, int>> bookAmountForEntities = entityNameBookAmountDelegate();

            // create plane
            PlotModel bookAmountModel = new PlotModel();

            // add axes

            // add bottom axis with entities' names
            bookAmountModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = bookAmountForEntities.Select(x => new { Name = x.Key }), // select names
                LabelField = "Name", // sets name label
                Angle = 15,
                Maximum = bookAmountForEntities.Count() >= 8 ? 8 : double.NaN,
                IsPanEnabled = true,
            });

            // add left axis, no scrolling
            bookAmountModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsPanEnabled = false
            });

            // add column series
            bookAmountModel.Series.Add(new ColumnSeries
            {
                FillColor = GraphColor,
                ItemsSource = bookAmountForEntities.Select(x => new ColumnItem(x.Value))
            });

            // initialize fields
            this.bookAmountModel = bookAmountModel;
        }
        #endregion
        #region BookAmountInPercentage
        PlotModel bookAmountInPercentageModel;
        public PlotModel BookAmountInPercentageModel => bookAmountInPercentageModel;

        protected void BuildBookEntityPercentageModel(LimitedNameAmountDelegate entityBookAmountPercentageDelegate)
        {
            // create plane
            PlotModel entityBookPercentageModel = new PlotModel();

            // create series
            PieSeries pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                TrackerFormatString = "{1}: ({3:P1})"
            };

            // gets entities' name and amount of book of current entities
            foreach (KeyValuePair<string, int> nameBookAmountPercentagePair in entityBookAmountPercentageDelegate(10))
            {
                pieSeries.Slices.Add(new PieSlice(label: nameBookAmountPercentagePair.Key, value: nameBookAmountPercentagePair.Value)
                {
                    Fill = graphColor
                });
                ChangeGraphColor();
            }

            // add series
            entityBookPercentageModel.Series.Add(pieSeries);

            // initialize fields
            this.bookAmountInPercentageModel = entityBookPercentageModel;
        }
        #endregion
        #region BestEntityPerBook
        PlotModel bestEntityPerBook;
        public PlotModel BestEntityPerBook => bestEntityPerBook;

        protected void BuildBestEntityModel(NameAmountDelegate entityNameTakenBookAmountDelegate)
        {
            // gets entities' name and amount of abonnements of current entities
            IEnumerable<KeyValuePair<string, int>> entityPopularity = entityNameTakenBookAmountDelegate();

            // create plane
            PlotModel entityPopularitytModel = new PlotModel();

            // add axes

            // add bottom axis with entitys' names
            entityPopularitytModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = entityPopularity.Select(x => new { Name = x.Key }), // select names
                LabelField = "Name", // sets name label
                Angle = 15,
                Maximum = entityPopularity.Count() >= 8 ? 8 : double.NaN
            });

            // add left axis, no scrolling
            entityPopularitytModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                IsPanEnabled = false
            });

            // add column series
            entityPopularitytModel.Series.Add(new ColumnSeries
            {
                FillColor = GraphColor,
                ItemsSource = entityPopularity.Select(x => new ColumnItem(x.Value))
            });

            // initialize fields
            this.bestEntityPerBook = entityPopularitytModel;
        }
        #endregion
        #region BestEntityPerBookInPercentage
        PlotModel percentageBestEntityPerBook;
        public PlotModel PercentageBestEntityPerBook => percentageBestEntityPerBook;

        protected void BuildPercentageBestEntityModel(LimitedNameAmountDelegate entityNameTakenBookAmountDelegate)
        {
            // create plane
            PlotModel entityPopularitytModel = new PlotModel();

            // create series
            PieSeries pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                TrackerFormatString = "{1}: ({3:P1})"
            };

            // gets entities' name and amount of abonnements of current entities
            foreach (KeyValuePair<string, int> nameTakenBookAmountPair in entityNameTakenBookAmountDelegate(10))
            {
                pieSeries.Slices.Add(new PieSlice(label: nameTakenBookAmountPair.Key, value: nameTakenBookAmountPair.Value)
                {
                    Fill = graphColor
                });
                ChangeGraphColor();
            }

            // add series
            entityPopularitytModel.Series.Add(pieSeries);

            // initialize fields
            this.percentageBestEntityPerBook = entityPopularitytModel;
        }
        #endregion
    }
}
