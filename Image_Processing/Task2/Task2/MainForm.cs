using System.Drawing;
using System.Windows.Forms;

using Task2.DomainModels.Filters;
using Task2.DomainModels.Interfaces;

namespace Task2
{
    public partial class MainForm : Form
    {
        // FIELDS
        private string fileName;

        private Bitmap defaultImage;
        private Bitmap filteredImage;

        private IFilter[] filters;

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
            InitializeFields();
            ConfigureComponents();
        }
        private void InitializeFields()
        {
            fileName = null;

            defaultImage  = null;
            filteredImage = null;

            filters = new IFilter[]
            {
                new NoneFilter(),
                new EqualizationFilter(),
                new RobertsFilter(),
                new PrewittFilter(),
                new SobelFilter(),
                new KirschFilter(),
                new LaplacianFilter(),
            };
        }
        private void ConfigureComponents()
        {
            // filters combo box
            filtersCb.DisplayMember = nameof(IFilter.Name);
            filtersCb.Items.AddRange(filters);
            filtersCb.SelectedIndex = 0;
        }
        private void UpdateInterface()
        {
            if (defaultImage != null)
            {
                filteredImage = filters[filtersCb.SelectedIndex].Filter(defaultImage);

                imagePb.Image = filteredImage;
            }
        }

        // EVENT HANDLERS
        private void loadImgBtn_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;

                defaultImage = Image.FromFile(fileName) as Bitmap;

                UpdateInterface();
            }
        }

        private void saveImgBtn_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filteredImage?.Save(saveFileDialog.FileName + System.IO.Path.GetExtension(fileName));
            }
        }

        private void filtersCb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            UpdateInterface();
        }
    }
}
