using System.Drawing;
using System.Drawing.Imaging;

namespace Task1.DomainModels.ImageFormatters
{
    class JpegFormatter : FormatterBase
    {
        public override string Name => "Jpeg";
        public override string Extension => "jpeg";

        public override System.IO.Stream Format(Image imageToFormat)
        {
            return Encode(imageToFormat, ImageFormat.Jpeg);
        }
    }
}
