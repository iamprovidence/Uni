using System.IO;
using System.Linq;

namespace FileAttributes.DataModels
{
    public class FileAttributesModel
    {
        public string Name { get; private set; }
        public string FilePath { get; private set; }

        public long Size { get; private set; }
        public System.DateTime CreationTime { get; private set; }

        public string Text { get; set; }
        public double Sum { get; set; }

        public FileAttributesModel(string filePath, double defaultValue)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            Name = fileInfo.Name;
            FilePath = fileInfo.FullName;

            Size = fileInfo.Length;
            CreationTime = fileInfo.CreationTime;

            Text = ReadAllText(fileInfo);
            Sum = CalcSum(Text, defaultValue);
        }

        private string ReadAllText(FileInfo file)
        {
            using (FileStream stream = file.OpenRead())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private double CalcSum(string text, double defaultValue)
        {
            return text
                .Split()
                .Sum(c => double.TryParse(c, out double value) ? value : defaultValue);
        }
    }
}
