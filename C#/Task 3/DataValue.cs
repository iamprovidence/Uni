using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Task3
{
    public partial class DataValue : Form
    {
        public DataValue()
        {
            InitializeComponent();

            AcceptButton = OK_button;
            CancelButton = Cancel_button;
            ActiveControl = NameTextBox;
            
        }

        public void SetDefaultValue(string name = "", string producer = "", string price = "")
        {
            this.NameTextBox.Text = name;
            this.ProducerTextBox.Text = producer;
            this.PriceTextBox.Text = price;
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void OK_button_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            isValid &= NameTextBox.Text != String.Empty;
            isValid &= ProducerTextBox.Text != String.Empty;

            if (isValid)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show("Fill in all fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public Product getProduct()
        {
            string replaced = PriceTextBox.Text.Replace(' ', '0');
            return new Product(NameTextBox.Text, ProducerTextBox.Text, Regex.Replace(PriceTextBox.Text.Replace(' ', '0'), "-", "").Trim());
        }

        private void NameTextBox_TextLeave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(((Control)sender).Text))
            {
                ep.SetError((Control)sender, "Fiil it");
            }
            else ep.SetError((Control)sender, "");
        }
    }
}
