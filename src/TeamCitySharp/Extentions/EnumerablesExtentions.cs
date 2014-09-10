using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.Extentions
{
    public static class PropertiesExtentions
    {

        public static Property FindProperty(this IEnumerable<Property> source, string propertyName)
        {
            //return source.FirstOrDefault(property => property.Name.EqualsIgnoreCase(propertyName));
            return source.FirstOrDefault(property => property.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        
        public static TimeSpan FindDurationByName(this IEnumerable<Property> source, string propertyName)
        {
            Property prop = source.FindProperty(propertyName);
            if (prop != null)
            {
                return TimeSpan.FromMilliseconds(long.Parse(prop.Value));
            }
            return TimeSpan.Zero;
        }
    }
}
