using System;
using System.Drawing;
using System.Windows.Forms;

using FiniteElementMethod.Models;
using FiniteElementMethod.Models.Structs;

namespace FiniteElementMethod
{
    public partial class MainForm : Form
    {
        // FILDS
        Reference<CoordinateSystemConfig> systemConfig;

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();

            // initialize fields
            systemConfig = new Reference<CoordinateSystemConfig> { Value = null };
        }        
        private void MainForm_Load(object sender, EventArgs e)
        {
            settingBtn.PerformClick();
        }

        // METHODS
        private void settingBtn_Click(object sender, EventArgs e)
        {
            contentPnl.Controls.Clear();

            new View.UserControls.InputData(systemConfig)
            {
                Parent = contentPnl,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void matricesBtn_Click(object sender, EventArgs e)
        {
            contentPnl.Controls.Clear();

            new View.UserControls.Matrices(systemConfig)
            {
                Parent = contentPnl,
                Dock = DockStyle.Fill
            };
        }
    }
}
