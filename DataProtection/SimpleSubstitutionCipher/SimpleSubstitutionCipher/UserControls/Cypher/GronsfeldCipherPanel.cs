using System;
using System.Windows.Forms;

namespace SimpleSubstitutionCipher.UserControls.Cypher
{
    public partial class GronsfeldCipherPanel : UserControl
    {
        int keyLength;

        public Models.Cypher.GronsfeldCipher Cipher { get; set; }

        public GronsfeldCipherPanel()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (keyLength > 0)
            {
                uint[] key = new uint[keyLength];
                int i = 0;

                foreach (NumericUpDown nud in System.Linq.Enumerable.OfType<NumericUpDown>(keyCodeContainer.Controls))
                {
                    try
                    {

                        key[i++] = (uint)nud.Value;
                    }
                    catch (Exception ex)
                    {
                        Service.DialogService.ErrorMessage(ex.Message);
                    }
                }

                Cipher.Key = key;
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            foreach (NumericUpDown nud in System.Linq.Enumerable.OfType<NumericUpDown>(keyCodeContainer.Controls))
            {
                nud.Value = r.Next(10);
            }
        }

        private void keyLengthTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                keyLength = int.Parse(keyLengthTb.Text);
                if(keyLength < 1)
                {
                    throw new ArgumentException("Key must be longer");
                }
                UpdateInterface();
            }
            catch (Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }
        }
        private void UpdateInterface()
        {
            keyCodeContainer.Controls.Clear();
            for(int i = 0; i < keyLength; ++i)
            {
                keyCodeContainer.Controls.Add(new NumericUpDown()
                {
                    Size = new System.Drawing.Size(40, 20),
                    Minimum = 0,
                    Maximum = 9,
                    TextAlign = HorizontalAlignment.Right
                });
            }
        }
    }
}
