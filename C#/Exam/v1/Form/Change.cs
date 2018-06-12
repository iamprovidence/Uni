using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Test
{
    public partial class ChangeEL : Form
    {
        public ChangeEL()
        {
            InitializeComponent();
        }

        public ChangeEL(string name, string page, string author)
        {
            InitializeComponent();
            textBox1.Text = name;


            textBox2.Text = page;

            textBox3.Text = author;
        }
        public string BookName => textBox1.Text;

        public string Page => textBox2.Text;

        public string Author => textBox3.Text;
        public ChangeEL(string name, string page)
        {
            InitializeComponent();


            textBox1.Text = name;
            textBox2.Text = page;

            textBox3.Visible = false;

        }
        private void Change_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }
    }
}
