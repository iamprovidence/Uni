namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    public partial class BBSCipherPanel : System.Windows.Forms.UserControl
    {
        public Models.Cypher.BBSCipher Cipher { get; set; }

        public BBSCipherPanel()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, System.EventArgs e)
        {
            System.Random random = new System.Random();
            int p, q, x;

            do
            {
                p = random.Next(100, 1000);
            } while (p % 4 != 3);

            do
            {
                q = random.Next(100, 1000);
            } while (q % 4 != 3);
            int n = p * q;

            do
            {
                x = random.Next(0, int.MaxValue);
            } while (Models.Math.Algorithms.GCD(n, x) != 1);


            pNud.Value = p;
            qNud.Value = q;
            xNud.Value = x;
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cipher.BBS = new Models.RandomGenerator.BBS((int)pNud.Value, (int)qNud.Value, (int)xNud.Value);
            }
            catch (System.Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }

        }
    }
}
