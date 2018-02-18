using System.Text;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class ByteExtensions
    {
        public static string FromArray(this byte[] bytes, Encoding encoding = null)
        {
            return FromArrayInternal(bytes, encoding ?? Encoding.UTF8);
        }

        private static string FromArrayInternal(this byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }
    }
}
