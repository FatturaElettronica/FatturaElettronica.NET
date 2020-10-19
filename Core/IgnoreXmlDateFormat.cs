using System;

namespace FatturaElettronica.Core
{
    /// <summary>
    /// Use this attribute to flag DateTime properties which should not be serialized to XML using the class XmlDateFormat property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IgnoreXmlDateFormat : Attribute
    {
    }
}