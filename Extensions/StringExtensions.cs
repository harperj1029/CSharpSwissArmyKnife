using System.Text;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class StringExtensions
    {
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
