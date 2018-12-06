using System.Windows.Forms;

namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    public partial class GammaCipherPanel : UserControl
    {
        public Models.Cypher.GammaCipher Cipher { get; set; }

        public GammaCipherPanel()
        {
            InitializeComponent();
        }
        private void generateBtn_Click(object sender, System.EventArgs e)
        {
            System.Random r = new System.Random();
            foreach (NumericUpDown nud in System.Linq.Enumerable.OfType<NumericUpDown>(keyCodeContainer.Controls))
            {
                nud.Value = r.Next(Cipher.Alphabet.Lenght);
            }
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            uint[] key = new uint[3];
            int i = 0;

            foreach (NumericUpDown nud in System.Linq.Enumerable.OfType<NumericUpDown>(keyCodeContainer.Controls))
            {
                try
                {
                    if (nud.Value > Cipher.Alphabet.Lenght) nud.Value = Cipher.Alphabet.Lenght;
                    key[i++] = (uint)nud.Value;
                }
                catch (System.Exception ex)
                {
                    Service.DialogService.ErrorMessage(ex.Message);
                }
            }

            Cipher.Key = key;
        }        
    }
}
