using SimpleSubstitutionCipher.Models.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SimpleSubstitutionCipher.UserControls
{
    public partial class FrequencyPanel : UserControl
    {
        // FIELDS
        OpenFileDialog ofd;
        SaveFileDialog sfd;
        FrequencyAnalyzer frequencyAnalyzer;
        RichTextBox textToDecodeTb;
        // CONSTRUCTORS
        public FrequencyPanel()
        {
            InitializeComponent();

            ofd = null;
            sfd = null;
            frequencyAnalyzer = null;
        }
        // PROPERTIES
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
        public FrequencyAnalyzer FrequencyAnalyzer
        {
            get
            {
                return frequencyAnalyzer;
            }
            set
            {
                frequencyAnalyzer = value;
            }
        }
        public RichTextBox TextBlockToDecode
        {
            get
            {
                return textToDecodeTb;
            }
            set
            {
                textToDecodeTb = value;
            }
        }
        // METHODS
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textTb.Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }

        private void FrequencyBtn_Click(object sender, EventArgs e)
        {
            analysisDgv.Rows.Clear();
            KeyValuePair<char, float>[] analyzeRes = frequencyAnalyzer.Analyze(textTb.Text);
            foreach (KeyValuePair<char, float> keyFrequency in analyzeRes)
            {
                analysisDgv.Rows.Add(keyFrequency.Key, keyFrequency.Value);
            }
            analysisDgv.Sort(analysisDgv.Columns[1], System.ComponentModel.ListSortDirection.Descending);

            hackedDgv.Rows.Clear();
            KeyValuePair<char, float>[] encryptRes = frequencyAnalyzer.Analyze(textToDecodeTb.Text);
            foreach (KeyValuePair<char, float> keyFrequency in encryptRes)
            {
                hackedDgv.Rows.Add(keyFrequency.Key, keyFrequency.Value);
            }
            hackedDgv.Sort(hackedDgv.Columns[1], System.ComponentModel.ListSortDirection.Descending);


            // create dictionary = analysis char value - hacked char value
            Dictionary<char, char> replaceDictionary = frequencyAnalyzer.SetRelationOnFrequency(analyzeRes, encryptRes);

            // replace letter in text
            System.Text.StringBuilder sb = new System.Text.StringBuilder(Alphabet.TextAdapter(textToDecodeTb.Text));
            for (int i = 0; i < sb.Length; ++i)
            {
                try
                {
                    sb[i] = replaceDictionary[sb[i]];
                }
                catch (KeyNotFoundException ex)
                {
                    continue;
                }
                catch (Exception ex)
                {
                    Service.DialogService.ErrorMessage(ex.Message);
                }
            }
            decryptedTextTb.Text = sb.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfd.FileName, decryptedTextTb.Text);
            }
        }
    }
}
