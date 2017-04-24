using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FatturaElettronica.Common
{
    public static class TypeExtensions
    {
        public static MethodInfo GetMethod(this Type type, string name)
        {
            return type.GetRuntimeMethods().First(x => x.Name.Contains(name));
        }

        public static bool IsSubclassOfBusinessObject(this Type type)
        {
            return typeof(BaseClassSerializable).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
        }

        public static bool IsGenericList(this Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}
