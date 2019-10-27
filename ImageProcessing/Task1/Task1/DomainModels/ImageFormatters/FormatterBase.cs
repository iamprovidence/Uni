using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Task1.DomainModels.ImageFormatters
{
    abstract class FormatterBase : Interfaces.IImageFormatter
    {
        public abstract string Name { get; }
        public abstract string Extension { get; }

        public abstract Stream Format(Image imageToFormat);

        protected Stream Encode(Image imageToFormat, ImageFormat format)
        {
            Stream stream = new MemoryStream();
            imageToFormat.Save(stream, format);
            stream.Position = 0;
            return stream;
        }
    }
}
