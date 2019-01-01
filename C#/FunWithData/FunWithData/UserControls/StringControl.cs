namespace FunWithData.UserControls
{
    public partial class StringControl : System.Windows.Forms.UserControl
    {
        public StringControl()
        {
            InitializeComponent();
        }
        public string StringValue => dataTb.Text;
    }
}
