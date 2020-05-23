using SimpleSubstitutionCipher.Models.Classes;
using SimpleSubstitutionCipher.Models.Cypher;
using System.Windows.Forms;

namespace SimpleSubstitutionCipher
{
    public partial class MainForm : Form
    {
        // CONST
        static readonly string latinLatters = "abcdefghijklmnopqrstuvwxyz";
        static readonly string symbols = " .,!?*+&:;-_—\'\"\\\r\n[]";
        static readonly string numbers = "0123456789";
        // FIELDS
        Alphabet alphabet;
        Models.Interfaces.ICypher cypher;

        OpenFileDialog ofd;
        SaveFileDialog sfd;
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
            ofd = new OpenFileDialog()
            {
                Filter = "Text file *.txt | *.txt"
            };
            sfd = new SaveFileDialog()
            {
                Filter = "Text file *.txt | *.txt"
            };


            alphabet = new Alphabet(string.Concat(latinLatters, symbols, numbers));
            cypher = null;

            frequencyPanel.OpenFileDialog = ofd;
            frequencyPanel.SaveFileDialog = sfd;
            cypherPanel.OpenFileDialog = ofd;
            cypherPanel.SaveFileDialog = sfd;
            frequencyPanel.TextBlockToDecode = cypherPanel.EncryptedTextTb;
            frequencyPanel.FrequencyAnalyzer = new FrequencyAnalyzer(alphabet);

            algoithmLb.BeginUpdate();
            algoithmLb.Items.Add("Affine Ciper");
            algoithmLb.Items.Add("Gronsfeld Ciper");
            algoithmLb.Items.Add("Hill Ciper");
            algoithmLb.Items.Add("Gamma Ciper");
            algoithmLb.Items.Add("BBS Ciper");
            algoithmLb.EndUpdate();

            UpdateInterface();
        }

        private void UpdateInterface()
        {
            frequencyPanel.Enabled = algoithmLb.SelectedIndex != -1;
            cypherPanel.Enabled = algoithmLb.SelectedIndex != -1;
        }
        // METHODS
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ofd.Dispose();
            sfd.Dispose();
        }

        private void algoithmLb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (algoithmLb.SelectedIndex != -1)
            {
                algorithmConfig.Controls.Clear();

                if (algoithmLb.SelectedIndex == 0)
                {

                    cypher = new AffineCipher(alphabet, 1, 0);
                    new UserControls.Cypher.AffineCipherPanel()
                    {
                        Parent = algorithmConfig,
                        Dock = DockStyle.Fill,
                        Cipher = (AffineCipher)cypher
                    };
                }
                else if (algoithmLb.SelectedIndex == 1)
                {
                    cypher = new GronsfeldCipher(alphabet, null);
                    new UserControls.Cypher.GronsfeldCipherPanel()
                    {
                        Parent = algorithmConfig,
                        Dock = DockStyle.Fill,
                        Cipher = (GronsfeldCipher)cypher
                    };
                }
                else if (algoithmLb.SelectedIndex == 2)
                {
                    cypher = new HillCipher(alphabet, "c");
                    new UserControls.Cypher.HillCipherPanel()
                    {
                        Parent = algorithmConfig,
                        Dock = DockStyle.Fill,
                        Cipher = (HillCipher)cypher
                    };
                }
                else if (algoithmLb.SelectedIndex == 3)
                {
                    cypher = new GammaCipher(alphabet, null);
                    new UserControls.Cypher.GammaCipherPanel()
                    {
                        Parent = algorithmConfig,
                        Dock = DockStyle.Fill,
                        Cipher = (GammaCipher)cypher
                    };
                }
                else if (algoithmLb.SelectedIndex == 4)
                {
                    cypher = new BBSCipher(alphabet, null);
                    new UserControls.Cypher.BBSCipherPanel()
                    {
                        Parent = algorithmConfig,
                        Dock = DockStyle.Fill,
                        Cipher = (BBSCipher)cypher
                    };
                }

                cypherPanel.Cypher = cypher;
            }
            UpdateInterface();
        }
    }
}
