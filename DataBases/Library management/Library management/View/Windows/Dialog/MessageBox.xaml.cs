using System.Windows;
using System.Windows.Controls;

namespace Library_management.View.Windows.Dialog
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window, Interfaces.IMessageBox
    {
        // CONSTRUCTORS
        public MessageBox()
        {
            InitializeComponent();
        }
        
        public string Header
        {
            get
            {
                return HeaderLbl.Content.ToString();
            }
            set
            {
                HeaderLbl.Content = value;
            }
        }
        public string Text
        {
            get
            {
                return ContentTb.Text;
            }
            set
            {
                ContentTb.Text = value;
            }
        }

        // METHODS
        private void MovingWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Yes(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        private void No(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public bool? ShowDialog(Enums.MessageBoxButton messageBoxButton)
        {
            // get button Resources
            Style buttonStyle = (Style)FindResource("MessageBoxButton");

            // initialize buttons
            if (messageBoxButton == Enums.MessageBoxButton.Ok)
            {
                // ok button
                Button okButton = new Button()
                {
                    Content = "Ok",
                    Style = buttonStyle,
                    IsDefault = true
                };
                okButton.Click += Yes;
                // set position
                Grid.SetRow(okButton, 2);
                Grid.SetColumn(okButton, 0);
                // add to grid
                GridMain.Children.Add(okButton);
            }
            else if (messageBoxButton == Enums.MessageBoxButton.YesNo)
            {
                // 2 cols
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                Grid.SetColumn(grid, 0);
                Grid.SetRow(grid, 2);
                // yes and no buttons
                Button yesButton = new Button()
                {
                    Content = "Yes",
                    Style = buttonStyle,
                    IsDefault = true
                };
                yesButton.Click += Yes;

                Grid.SetRow(yesButton, 0);
                Grid.SetColumn(yesButton, 0);

                Button noButton = new Button()
                {
                    Content = "No",
                    Style = buttonStyle
                };
                noButton.Click += No;

                Grid.SetRow(noButton, 0);
                Grid.SetColumn(noButton, 1);

                // adding to the grid
                grid.Children.Add(yesButton);
                grid.Children.Add(noButton);

                GridMain.Children.Add(grid);
            }

            // show the window
            return this.ShowDialog();
        }
    }
}
