using System.Text;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a byte array for the given string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <remarks>Defaults to UTF8 encoding.</remarks>
        /// <returns>Encoded byte array.</returns>
        public static byte[] ToArray(this string input, Encoding encoding = null)
        {
            return ToArrayInternal(input, encoding ?? Encoding.UTF8);
        }

        private static byte[] ToArrayInternal(string input, Encoding encoding)
        {
            return encoding.GetBytes(input);
        }
    }
}
