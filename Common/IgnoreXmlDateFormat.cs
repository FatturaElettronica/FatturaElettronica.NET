using System;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Use this attribute to flag DateTime properties which should not be serialized to XML using the class XmlDateFormat property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class IgnoreXmlDateFormat : Attribute { }
}
