using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CSharpSwissArmyKnife.Extensions
{
    public static class ExpandoObjectExtensions
    {
        /// <summary>
        /// Adds public properties from the source object onto the destination.  If the property already exists
        /// it will be updated *if* there is a non-null value (thus last actual value wins).
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <returns>A dynamic object containing the merged properties from the source.</returns>
        public static ExpandoObject AddProperties(this ExpandoObject destination, object source)
        {
            var sourceType = source.GetType();

            var props = sourceType.GetProperties();
            var destinationAsDictionary = destination as IDictionary<string, Object>;
            foreach (var prop in props)
            {
                if (destinationAsDictionary.ContainsKey(prop.Name) == false)
                {
                    destinationAsDictionary.Add(prop.Name, prop.GetValue(source, null));
                }
                else
                {
                    var propertyValue = prop.GetValue(source, null);
                    if (propertyValue != null)
                    {
                        destinationAsDictionary[prop.Name] = propertyValue;
                    }
                }
            }
            return destination;
        }
    }
}
