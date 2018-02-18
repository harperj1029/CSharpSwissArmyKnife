using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Helpers
{
    public class SerializationHelper
    {
        public static class Xml
        {
            public static byte[] ToXml(object target)
            {
                using (var stream = new MemoryStream())
                {
                    var serializer = new XmlSerializer(target.GetType());
                    serializer.Serialize(stream, target);
                    return stream.ToArray();
                }
            }

            public static T FromXml<T>(byte[] bytes)
            {
                var xml = Bytes.ConvertFromArray(bytes);
                using (TextReader reader = new StringReader(xml))
                {
                    return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
            }
        }

        public static class Bytes
        {
            public static string ConvertFromArray(this byte[] bytes)
            {
                return Encoding.UTF8.GetString(bytes);
            }

            public static byte[] ConvertToArray(string s)
            {
                return Encoding.UTF8.GetBytes(s);
            }
        }

        public static class Streams
        {
            public static byte[] ConvertFromStream(Stream stream)
            {
                var buffer = new byte[16 * 1024];
                using (var ms = new MemoryStream())
                {
                    int enumerator;
                    while ((enumerator = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, enumerator);
                    }
                    return ms.ToArray();
                }
            }
        }     
       
    }
}
