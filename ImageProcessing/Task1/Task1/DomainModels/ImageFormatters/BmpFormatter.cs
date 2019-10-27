using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Task1.DomainModels.ImageFormatters
{
    class BmpFormatter : FormatterBase
    {
        public override string Name => "BMP";
        public override string Extension => "bmp";

        public override Stream Format(Image imageToFormat)
        {
            return Encode(imageToFormat, ImageFormat.Bmp);
        }
    }
}
