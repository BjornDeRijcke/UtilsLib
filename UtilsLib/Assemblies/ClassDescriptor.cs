using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using UtilsLib.Extensions;

namespace UtilsLib.Assemblies
{
    public class ClassDescriptor
    {
        public static ClassDescription ForClass(Type classType)
        {
            if (classType == null)
                throw new ArgumentNullException(nameof(classType));

            if (!classType.IsClass && !classType.IsInterface)
                throw new ArgumentException("Type should be a class or interface", nameof(classType));

            var attributes = classType.GetCustomAttributes();
            var dspName = (attributes.FirstOrDefault(att => att.GetType() == typeof(DisplayNameAttribute)) as DisplayNameAttribute)?.DisplayName;

            return new ClassDescription
            {
                DisplayName = dspName,
                ClassType = classType.Name,
                Properties = GetPublicPropertiesOfType(classType).ToList()
            };
        }

        public static List<ClassDescription> DerivativesOfBaseClass(Type baseClass)
        {
            var assembly = Assembly.GetAssembly(baseClass);
            var descriptions = new List<ClassDescription>();

            foreach (var t in assembly.GetTypes())
            {
                if (t == null)
                    continue;

                if (t.BaseType == null)
                    continue;

                if (t.BaseType == baseClass)
                    descriptions.Add(ForClass(t));
            }

            return descriptions;
        }

        private static IEnumerable<ClassProperty> GetPublicPropertiesOfType(Type t)
        {
            foreach (var property in t.GetProperties())
            {
                var attributes = property.GetCustomAttributes();
                var defaultValue = (attributes.FirstOrDefault(att => att.GetType() == typeof(DefaultValueAttribute)) as DefaultValueAttribute)?.Value;
                var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                var cp = new ClassProperty
                {
                    Name = property.Name?.LowercaseFirst(),
                    PropertyType = TypeToString(propertyType),
                    Required = attributes.Any(att => att.GetType() == typeof(RequiredAttribute)),
                    DefaultValue = defaultValue
                };

                if (cp.Required && cp.DefaultValue != null)
                    throw new Exception("Properties with required flag cannot have a default value");

                if (!propertyType.IsValueType && !propertyType.IsPrimitive && propertyType != typeof(String))
                    cp.Properties = GetPublicPropertiesOfType(property.PropertyType).ToList();

                yield return cp;
            }

            yield break;
        }

        private static string TypeToString(Type t)
        {
            if (t == typeof(String))
                return "string";

            if (t == typeof(Byte) || t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64))
                return "integer";

            if (t == typeof(Single) || t == typeof(Double))
                return "number";

            if (t == typeof(Boolean))
                return "boolean";

            if (t == typeof(DateTime) || t == typeof(DateTimeOffset))
                return "datetime";

            return "object:" + t.Name;
        }
    }

    public class ClassDescription
    {
        public string DisplayName { get; set; }

        public string ClassType { get; set; }

        public List<ClassProperty> Properties { get; set; }
    }

    public class ClassProperty
    {
        public string Name { get; set; }

        public string PropertyType { get; set; }

        public List<ClassProperty> Properties { get; set; }

        public bool Required { get; set; }

        public object DefaultValue { get; set; }
    }
}
