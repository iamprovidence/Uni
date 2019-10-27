using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Task1.DomainModels.ImageFormatters
{
    class TiffFormatter : FormatterBase
    {
        public override string Name => "Tiff";
        public override string Extension => "tiff";

        public override Stream Format(Image imageToFormat)
        {
            return Encode(imageToFormat, ImageFormat.Tiff);
        }
    }
}
