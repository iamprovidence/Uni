using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using Task1.DomainModels.Models;
using Task1.DomainModels.Interfaces;
using Task1.DomainModels.ImageFormatters;
using Task1.DomainModels.ColorDifferences;

namespace Task1
{
    public partial class MainForm : Form
    {
        // CONST
        private static readonly string ImageSizeFormat = "{0} байт";
        private static readonly string TimeFormat = "{0} мс";
        private static readonly string FilterStringFormat = "{0} file *.{0} | *.{0}";

        // FIELDS
        private Image imageToFormat;
        private Image imageAfterFormat;
        private Image differenceImage;

        private IImageFormatter[] imageFormatters;
        private IColorDifferences[] colorDifferences;

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
            InitializeFields();
            ConfigureComponents();
            UpdateInterface();
        }
        private void InitializeFields()
        {
            imageFormatters = new IImageFormatter[]
            {
                new BmpFormatter(),
                new TiffFormatter(),
                new JpegFormatter()
            };

            colorDifferences = new IColorDifferences[]
            {
                new RGBColorDifferences(),
                new RColorDifferences(), 
                new GColorDifferences(), 
                new BColorDifferences(), 
            };
        }
        private void ConfigureComponents()
        {
            // formatters combo box
            formattersCb.DisplayMember = "Name";
            formattersCb.Items.AddRange(imageFormatters);
            formattersCb.SelectedIndex = 0;

            // color differences combo box
            colorDifferencesCb.DisplayMember = "Name";
            colorDifferencesCb.Items.AddRange(colorDifferences);
            colorDifferencesCb.SelectedIndex = 0;
        }
        private void UpdateInterface()
        {
            formatImgBtn.Enabled = imageToFormat != null;

            originalImg.BackColor          =    imageToFormat == null ? Color.Gray : DefaultBackColor;
            formattedImage.BackColor       = imageAfterFormat == null ? Color.Gray : DefaultBackColor;
            colorDifferenceImage.BackColor =  differenceImage == null ? Color.Gray : DefaultBackColor;
        }
        private void ResetInterface()
        {
            // formatted image
            imageAfterFormat = null;
            formattedImage.Image = null;
            formattedImgSizeLbl.Text = string.Format(ImageSizeFormat, 0);

            // labels
            writingTimeLbl.Text  = string.Format(TimeFormat, 0);
            readingTimeLbl.Text  = string.Format(TimeFormat, 0);
            decodingTimeLbl.Text = string.Format(TimeFormat, 0);
            encodingTimeLbl.Text = string.Format(TimeFormat, 0);

            // color differences
            differenceImage = null;
            colorDifferenceImage.Image = null;
            rDiffLbl.Text = "0";
            gDiffLbl.Text = "0";
            bDiffLbl.Text = "0";
        }

        // METHODS
        private string GetTime(Action action)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            action();
            timer.Stop();
            return string.Format(TimeFormat, timer.Elapsed.TotalMilliseconds);
        }
        private double GetFileSize(string fileName)
        {
            return new FileInfo(fileName).Length;
        }
        private (Bitmap, ColorDifference) ImagesDifference(Image firstImage, Image secondImage, IColorDifferences colorDifferences, int multiplier = 25)
        {
            int width = Math.Min(firstImage.Width, secondImage.Width);
            int height = Math.Min(firstImage.Height, secondImage.Height);

            Bitmap first = (Bitmap)firstImage;
            Bitmap second = (Bitmap)secondImage;
            Bitmap diff = new Bitmap(width, height);

            ColorDifference totalDifference = new ColorDifference();

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Color firstImagePx = first.GetPixel(i, j);
                    Color secondImagePx = second.GetPixel(i, j);

                    Color differencePx = colorDifferences.GetDifference(firstImagePx, secondImagePx, multiplier);

                    totalDifference.Accumulate(differencePx);

                    diff.SetPixel(i, j, differencePx);
                }
            }
            totalDifference.Reduce(multiplier);

            return (diff, totalDifference);
        }

        // EVENT HANDLERS
        private void loadImgBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageNameTb.Text = openFileDialog.FileName;

                imageToFormat = Image.FromFile(openFileDialog.FileName);
                originalImg.Image = imageToFormat;
                originalImgSizeLbl.Text = string.Format(ImageSizeFormat, GetFileSize(openFileDialog.FileName));

                ResetInterface();
            }

            UpdateInterface();
        }

        private void formatImgBtn_Click(object sender, EventArgs e)
        {
            // config file dialog
            saveFileDialog.DefaultExt = imageFormatters[formattersCb.SelectedIndex].Extension;
            saveFileDialog.Filter = string.Format(FilterStringFormat, saveFileDialog.DefaultExt);
            saveFileDialog.FileName = string.Empty;

            // save file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // encoding
                Stream writeStream = null;
                encodingTimeLbl.Text = GetTime(() =>
                {
                    writeStream = imageFormatters[formattersCb.SelectedIndex].Format(imageToFormat);
                });

                // writing
                Stream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                writingTimeLbl.Text = GetTime(() =>
                {
                    writeStream.CopyTo(fileStream);
                });
                fileStream.Dispose();
                writeStream.Dispose();

                // reading
                Stream readStream = null;
                readingTimeLbl.Text = GetTime(() =>
                {
                    readStream = File.OpenRead(saveFileDialog.FileName);
                });

                // decoding
                decodingTimeLbl.Text = GetTime(() =>
                {
                    imageAfterFormat = Image.FromStream(readStream);
                    formattedImgSizeLbl.Text = string.Format(ImageSizeFormat, GetFileSize(saveFileDialog.FileName));
                });
                readStream.Dispose();

                // change UI
                formattedImage.Image = imageAfterFormat;
                
                CalcColorDifference();
            }

            UpdateInterface();
        }

        private void colorDifferencesCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imageToFormat != null && imageAfterFormat != null)
            {
                CalcColorDifference();
            }
        }

        private void CalcColorDifference()
        {
            (Bitmap, ColorDifference) differenceValue = ImagesDifference(imageToFormat, imageAfterFormat, colorDifferences[colorDifferencesCb.SelectedIndex]);

            // show image
            differenceImage = differenceValue.Item1;
            colorDifferenceImage.Image = differenceImage;

            // update labels
            rDiffLbl.Text = differenceValue.Item2.R.ToString();
            gDiffLbl.Text = differenceValue.Item2.G.ToString();
            bDiffLbl.Text = differenceValue.Item2.B.ToString();
        }
    }
}
