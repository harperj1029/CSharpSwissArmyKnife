using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class ObjectExtension
    {
        public static T DeepClone<T>(this T obj) where T : class
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Position = 0;
                return (T)bf.Deserialize(ms);
            }
        }
    }
}
