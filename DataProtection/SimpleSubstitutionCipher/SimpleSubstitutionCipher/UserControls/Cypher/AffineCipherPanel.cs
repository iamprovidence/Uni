namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    public partial class AffineCipherPanel : System.Windows.Forms.UserControl
    {
        public Models.Cypher.AffineCipher Cipher { get; set; }

        public AffineCipherPanel()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cipher.A = int.Parse(aTb.Text);
                Cipher.B = int.Parse(bTb.Text);
            }
            catch (System.Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }
        }

        private void generateBtn_Click(object sender, System.EventArgs e)
        {
            System.Random random = new System.Random();
            System.Collections.Generic.List<int> lint = new System.Collections.Generic.List<int>();
            int i = 1;
            int m = Cipher.Alphabet.Lenght;
            while (i != m)
            {
                if (Models.Math.Algorithms.GCD(i, m) == 1)
                {
                    lint.Add(i);
                }
                ++i;
            }

            aTb.Text = lint[random.Next(0, lint.Count)].ToString();
            bTb.Text = random.Next(0, 100).ToString();            
        }
    }
}
