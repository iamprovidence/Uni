using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void ok_but_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ChangeStyle(object o, OptionArg arg)
        {
            this.Opacity = arg.Opacity;
        }
        private void About_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Today.ToString("d");
        }
    }
}
