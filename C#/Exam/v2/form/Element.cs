using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Second_Exam
{
    public partial class Element : Form
    {
        public Element()
        {
            InitializeComponent();

            AcceptButton = button1;

            label3.Visible = false;
            textBox3.Visible = false;
        }
        public Element(string name, string age)
        {
            InitializeComponent();

            PersonName = name;
            Age = age;

            AcceptButton = button1;

            checkBox1.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;

        }
        public Element(string name, string age, string mark)
        {
            InitializeComponent();

            PersonName = name;
            Age = age;
            TotalMark = mark;

            AcceptButton = button1;


            checkBox1.Visible = false;
        }
        public string PersonName
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public string Age
        {
            get
            {
                return maskedTextBox1.Text;
            }
            set
            {
                maskedTextBox1.Text = value;
            }
        }
        public string TotalMark
        {
            get
            {
                return textBox3.Text;
            }
            set
            {
                textBox3.Text = value;
            }
        }
        public bool isStudent => checkBox1.Checked;
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = checkBox1.Checked;
            textBox3.Visible = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
