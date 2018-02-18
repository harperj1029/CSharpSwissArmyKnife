using System.Text;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Returns a string for a given encoded byte array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encoding"></param>
        /// <remarks>Defaults to UTF8 encoding.</remarks>
        /// <returns>Decoded String</returns>
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
