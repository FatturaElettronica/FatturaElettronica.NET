using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// - XML (de)serialization;
    /// - JSON serialization.
    /// </summary>
    public class BaseClassSerializable : BaseClass, IXmlSerializable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected BaseClassSerializable()
        {
            XmlOptions = new XmlOptions()
            {
                DateTimeFormat = "yyyy-MM-dd",
                DecimalFormat = "0.00###"
            };
        }
        protected BaseClassSerializable(XmlReader r) : this() { ReadXml(r); }

        public XmlOptions XmlOptions { get; set; }

        /// <summary>
        /// Serializes the instance to JSON
        /// </summary>
        /// <returns>A JSON string representing the class instance.</returns>
        public virtual string ToJson()
        {
            return ToJson(JsonOptions.None);
        }
        /// <summary>
        /// Serializes the class to JSON.
        /// </summary>
        /// <param name="jsonOptions">JSON formatting options.</param>
        /// <returns>A JSON string representing the class instance.</returns>
        public virtual string ToJson(JsonOptions jsonOptions)
        {
            var json = JsonConvert.SerializeObject(
                this, (jsonOptions == JsonOptions.Indented) ? Formatting.Indented : Formatting.None,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize, DefaultValueHandling = DefaultValueHandling.Ignore });
            return json;
        }

        public XmlSchema GetSchema() { return null; }

        /// <summary>
        /// Serializes the current BusinessObject instance to a XML file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        public virtual void WriteXml(string fileName)
        {
            var settings = new XmlWriterSettings {Indent = true};
            using (var writer = XmlWriter.Create(new System.Text.StringBuilder(fileName), settings)) { WriteXml(writer); }
        }

        /// <summary>
        /// Serializes the current BusinessObject instance to a XML stream.
        /// </summary>
        /// <param name="w">Active XML stream writer.</param>
        /// <remarks>Writes only its inner content, not the outer element. Leaves the writer at the same depth.</remarks>
        public virtual void WriteXml(XmlWriter w)
        {
            foreach (var property in GetAllDataProperties())
            {
                var value = property.GetValue(this, null);
                if (value == null && !XmlOptions.SerializeNullValues) continue;

                if (value is BaseClassSerializable child)
                {
                    if (child.IsEmpty() && XmlOptions.SerializeEmptyBusinessObjects == false) continue;

                    var attribute = property.GetCustomAttributes(typeof(XmlElementAttribute), false)
                        .Cast<XmlElementAttribute>()
                        .FirstOrDefault();
                    w.WriteStartElement(attribute == null ? property.Name : attribute.ElementName);
                    child.WriteXml(w);
                    w.WriteEndElement();

                    continue;
                }

                if (property.PropertyType.IsGenericList())
                {
                    WriteXmlList(property.Name, value, w);
                    continue;
                }

                if (value is string) {
                    if (!string.IsNullOrEmpty(value.ToString()) || XmlOptions.SerializeEmptyStrings) {
                        w.WriteElementString(property.Name, value.ToString());
                    }
                    continue;
                }
                if (value is DateTime && XmlOptions.DateTimeFormat != null && !property.GetCustomAttributes<IgnoreXmlDateFormat>().Any()) {
                    w.WriteElementString(property.Name, ((DateTime)value).ToString(XmlOptions.DateTimeFormat));
                    continue;
                }
                if (value is decimal && XmlOptions.DecimalFormat != null) {
                    w.WriteElementString(property.Name, ((decimal)value).ToString(XmlOptions.DecimalFormat, CultureInfo.InvariantCulture));
                    continue;
                }

                // all else fail so just let the value flush straight to XML.
                w.WriteStartElement(property.Name);
                if (value != null) { 
                    w.WriteValue(value); 
                }
                w.WriteEndElement();
            }
        }

        /// <summary>
        /// Deserializes a List of BusinessObject or strings to one or more XML elements.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="value">Property value.</param>
        /// <param name="w">Active XML stream writer.</param>
        private static void WriteXmlList(string propertyName, object value, XmlWriter w)
        {
            var type = value.GetType();
            var e = type.GetMethod("GetEnumerator").Invoke(value, null) as IEnumerator;

            while (e != null && e.MoveNext()) {
                if (e.Current == null) continue;
                var current = e.Current;
                w.WriteStartElement(propertyName);
                {
                    if (current is BaseClassSerializable) {
                        ((BaseClassSerializable)current).WriteXml(w);
                    }
                    else if (current is string)
                    {
                        w.WriteString((string) current);
                    }
                    else {
                        w.WriteValue(e.Current);
                    }
                }
                w.WriteEndElement();
            }
        }

        /// <summary>
        /// Deserializes the current BusinessObject from a XML stream.
        /// </summary>
        /// <param name="r">Active XML stream reader.</param>
        /// <remarks>Reads the outer element. Leaves the reader at the same depth.</remarks>
        public virtual void ReadXml(XmlReader r)
        {
            var isEmpty = r.IsEmptyElement;
            
            r.ReadStartElement();
            if (isEmpty) return;

            var properties = GetAllDataProperties().ToList();
            while (r.NodeType == XmlNodeType.Element) {

                var property = properties
                    .Where(prop => prop.GetCustomAttributes(typeof(XmlElementAttribute), false)
                        .Where(ca => ((XmlElementAttribute)ca).ElementName == r.Name).Any())
                    .FirstOrDefault();
                if (property == null)
                    property = properties.FirstOrDefault(n => n.Name.Equals(r.Name));
                if (property == null) {
                    r.Skip();
                    continue;
                }

                var type = property.PropertyType;
                var value = property.GetValue(this, null);

                if (type.IsSubclassOfBusinessObject())
                {
                    ((BaseClassSerializable)value).ReadXml(r);
                    continue;
                }

                // if property type is List<T>, try to fetch the list from XML.
                if (type.IsGenericList())
                {
                    ReadXmlList(value, type, r.Name, r);
                    continue;
                }

                // ReadElementContentAs won't accept a nullable types.
                if (type == typeof(DateTime?)) type = typeof(DateTime); 
                if (type == typeof(decimal?)) type = typeof(decimal); 
                if (type == typeof(int?)) type = typeof(int); 

                property.SetValue(this, r.ReadElementContentAs(type, null), null);
            }
            r.ReadEndElement();
        }

        /// <summary>
        /// Serializes one or more XML elements into a List of BusinessObjects.
        /// </summary>
        /// <param name="propertyValue">Property value. Must be a List of BusinessObject instances.</param>
        /// <param name="propertyValue">Property type</param>
        /// <param name="elementName">Element name.</param>
        /// <param name="r">Active XML stream reader.</param>
        private static void ReadXmlList(object propertyValue, Type propertyType, string elementName, XmlReader r)
        {

            var argumentType = propertyType.GetTypeInfo().GenericTypeArguments.Single();

            // note that the 'canonical' call to GetRuntimeMethod returns null for some reason,
            // see http://stackoverflow.com/questions/21307845/runtimereflectionextensions-getruntimemethod-does-not-work-as-expected
            //var method = propertyType.GetRuntimeMethod("Clear", new[] { propertyType });
            var clear = propertyType.GetMethod("Clear");
            clear.Invoke(propertyValue, null);

            var add = propertyType.GetMethod("Add");

            while (r.NodeType == XmlNodeType.Element && r.Name == elementName)
            {
                if (argumentType.IsSubclassOfBusinessObject())
                {
                    // list items are expected to be of BusinessObject type.
                    var bo = Activator.CreateInstance(argumentType);
                    ((BaseClassSerializable)bo).ReadXml(r);
                    add.Invoke(propertyValue, new[] { bo });
                    continue;
                }

                if (argumentType == typeof(string))
                {
                    add.Invoke(propertyValue, new [] { r.ReadElementContentAsString() });
                    continue;
                }

                if (argumentType == typeof(int))
                {
                    add.Invoke(propertyValue, new[] { r.ReadElementContentAs(argumentType, null) });
                }
            }
        }
    }
}
