namespace DiffieHellman.View
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : System.Windows.Window
    {
        public MessageBox()
        {
            InitializeComponent();
        }
        public string HeaderText
        {
            get
            {
                return Header.Content.ToString();
            }
            set
            {
                Header.Content = value;
            }
        }
        public string ContentText
        {
            get
            {
                return Text.Text.ToString();
            }
            set
            {
                Text.Text = value;
            }
        }
        private void MovingWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Exit(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
