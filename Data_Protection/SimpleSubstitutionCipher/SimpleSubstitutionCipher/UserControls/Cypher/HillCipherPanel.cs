namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    public partial class HillCipherPanel : System.Windows.Forms.UserControl
    {
        public Models.Cypher.HillCipher Cipher { get; set; }
        public HillCipherPanel()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                int keylength = int.Parse(keyLengthTb.Text);
                if (keylength!= keyTb.Text.Length)
                {
                    Service.DialogService.ErrorMessage("Key length is different");
                    return;
                }
                if (!MathNet.Numerics.Euclid.IsPerfectSquare(keylength))
                {
                    Service.DialogService.ErrorMessage("Should be perfect square");
                    return;
                }
                Cipher.KeyWord = keyTb.Text.ToLower();
            }
            catch (System.Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }
        }

        private void generateBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                int keyLength = int.Parse(keyLengthTb.Text);
                if (!MathNet.Numerics.Euclid.IsPerfectSquare(keyLength))
                {
                    Service.DialogService.ErrorMessage("Should be perfect square");
                    return;
                }
                // generating
                System.Random random = new System.Random();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                Models.Math.Matrix matrix;
                int det;
                do
                {
                    sb.Clear();
                    for (int i = 0; i < keyLength; ++i)
                    {
                        sb.Append((char)random.Next('a', 'z'));
                    }
                    var l = new System.Collections.Generic.List<char>(Cipher.Alphabet.Letters);
                    int key = (int)System.Math.Sqrt(keyLength);
                    matrix = new Models.Math.Matrix(key, key, System.Linq.Enumerable.Select(sb.ToString(), c => l.BinarySearch(c)));
                    det = System.Convert.ToInt32( matrix.Determinant());

                } while (det == 0 || Models.Math.Algorithms.GCD(det, Cipher.Alphabet.Lenght) != 1);

                keyTb.Text = sb.ToString();
            }
            catch (System.Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }            
        }
    }
}
