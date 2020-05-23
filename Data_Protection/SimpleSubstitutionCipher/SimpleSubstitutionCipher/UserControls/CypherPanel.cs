using System.Windows.Forms;

namespace SimpleSubstitutionCipher.UserControls
{
    public partial class CypherPanel : UserControl
    {
        // FIELDS
        OpenFileDialog ofd;
        SaveFileDialog sfd;
        Models.Interfaces.ICypher cypher;
        // CONSTRUCTORS
        public CypherPanel()
            : this(null, null, null)  {  }
        public CypherPanel(Models.Interfaces.ICypher cypher, OpenFileDialog ofd, SaveFileDialog sfd)
        {
            InitializeComponent();

            this.cypher = cypher;
            this.ofd = ofd;
            this.sfd = sfd;
        }
        // PROPERTIES
        public Button ReadFileBtn => readFileBtn;
        public Button SaveToFileBtn => saveToFileBtn;
        public Button SaveToFileBtn2 => saveToFileBtn2;
        public Button EncodeBtn => encodeBtn;
        public Button DecodeBtn => decodeBtn;

        public RichTextBox TextTb => textTb;
        public RichTextBox EncryptedTextTb => encryptedTextTb;
        public RichTextBox DecodedTextTb => decodedTextTb;

        public Models.Interfaces.ICypher Cypher
        {
            get
            {
                return cypher;
            }
            set
            {
                this.cypher = value;
            }
        }
        public OpenFileDialog OpenFileDialog
        {
            get
            {
                return ofd;
            }
            set
            {
                ofd = value;
            }
        }
        public SaveFileDialog SaveFileDialog
        {
            get
            {
                return sfd;
            }
            set
            {
                sfd = value;
            }
        }
        // METHODS
        private void readFileBtn_Click(object sender, System.EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textTb.Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }

        private void saveToFileBtn_Click(object sender, System.EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfd.FileName, EncryptedTextTb.Text);
            }
        }

        private void saveToFileBtn2_Click(object sender, System.EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfd.FileName, decodedTextTb.Text);
            }
        }

        private void encodeBtn_Click(object sender, System.EventArgs e)
        {
            if (cypher == null) throw new System.NullReferenceException("Cypher is null");

            try
            {
                encryptedTextTb.Text = cypher.Encrypt(textTb.Text);
            }
            catch (System.Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }
        }

        private void decodeBtn_Click(object sender, System.EventArgs e)
        {
            if (cypher == null) throw new System.NullReferenceException("Cypher is null");

            try
            {
                decodedTextTb.Text = cypher.Decrypt(encryptedTextTb.Text);
            }
            catch (System.Exception ex)
            {
                Service.DialogService.ErrorMessage(ex.Message);
            }
        }
    }
}
