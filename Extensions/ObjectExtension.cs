using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Copies public properties from the source to the destination where the name and type match.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void CopyProperties(this object source, object destination)
        {
            if (source == null || destination == null)
            {
                throw new ApplicationException("Source or/and Destination Objects are null");
            }
            var destinationType = destination.GetType();
            var sourceType = source.GetType();

            var props = sourceType.GetProperties();
            foreach (var prop in props)
            {
                if (!prop.CanRead)
                {
                    continue;
                }
                var targetProperty = destinationType.GetProperty(prop.Name);
                if (targetProperty == null)
                {
                    continue;
                }
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod() != null && (targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(prop.PropertyType))
                {
                    continue;
                }
                targetProperty.SetValue(destination, prop.GetValue(source, null), null);
            }
        }

        /// <summary>
        /// Creates a full-depth clone of the object. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <remarks>Requires the type to be decorated with the SerializableAttribute.</remarks>
        /// <returns>Clone of T</returns>
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
