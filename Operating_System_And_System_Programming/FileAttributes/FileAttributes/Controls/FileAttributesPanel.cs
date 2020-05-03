using System.Windows.Forms;

namespace FileAttributes.Controls
{
    public partial class FileAttributesPanel : UserControl
    {
        public FileAttributesPanel(DataModels.FileAttributesModel fileAttributes)
        {
            InitializeComponent();
            UpdateInterface(fileAttributes);
        }

        private void UpdateInterface(DataModels.FileAttributesModel fileAttributes)
        {
            fileNameLbl.Text = fileAttributes.Name;
            filePathLbl.Text = fileAttributes.FilePath;
            toolTip.SetToolTip(filePathLbl, fileAttributes.FilePath);

            fileSizeLbl.Text = $"{fileAttributes.Size} bytes";
            creationDateLbl.Text = fileAttributes.CreationTime.ToString();

            contentTb.Text = fileAttributes.Text;
            sumLbl.Text = fileAttributes.Sum.ToString();
        }
    }
}
