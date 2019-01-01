namespace FunWithData.UserControls
{
    public partial class NumberControl : System.Windows.Forms.UserControl
    {
        public NumberControl()
        {
            InitializeComponent();
        }
        public int MinValue => (int)minNud.Value;
        public int MaxValue => (int)maxNud.Value;
    }
}
