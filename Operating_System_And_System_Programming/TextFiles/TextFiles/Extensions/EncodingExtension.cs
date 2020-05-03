using System.Text;

namespace TextFiles.Extensions
{
    internal static class EncodingExtension
    {
        internal static string ToPrettyString(this Encoding encoding)
        {
            if (encoding == Encoding.ASCII)     return "ASCII";
            if (encoding == Encoding.Unicode)   return "Unicode";

            return encoding.ToString();
        }
    }
}
