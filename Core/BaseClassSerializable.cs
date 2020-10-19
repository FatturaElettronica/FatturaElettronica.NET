﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace FatturaElettronica.Core
{
    /// <summary>
    /// - XML (de)serialization;
    /// - JSON (de)serialization.
    /// </summary>
    public class BaseClassSerializable : BaseClass, IXmlSerializable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected BaseClassSerializable()
        {
            XmlOptions = new XmlOptions {DateTimeFormat = "yyyy-MM-dd", DecimalFormat = "0.00######"};
        }

        protected BaseClassSerializable(XmlReader r)
        {
            ReadXml(r);
        }

        protected XmlOptions XmlOptions { get; set; }

        private readonly Stack<JsonProperty> _stack = new Stack<JsonProperty>();

        /// <summary>
        /// Deserializes the current BusinessObject from a json stream.
        /// </summary>
        /// <param name="r">Active json stream reader</param>
        /// <remarks>Side effects on parse handling</remarks>
        public virtual void FromJson(JsonReader r)
        {
            _stack.Clear();

            r.FloatParseHandling = FloatParseHandling.Decimal;

            PropertyInfo prop = null;

            while (r.Read())
            {
                Type objectType;
                JsonProperty current;
                Type elementType;
                switch (r.TokenType)
                {
                    case JsonToken.StartObject:

                        current = null;
                        if (_stack.Any())
                            current = _stack.Peek();

                        if (current != null)
                        {
                            current.Child = prop;
                            if (current.Child != null)
                            {
                                objectType = current.Child.PropertyType;

                                if (objectType.IsGenericList())
                                {
                                    elementType = objectType.GetTypeInfo().GenericTypeArguments.Single();

                                    var newObject = Activator.CreateInstance(elementType);

                                    var add = objectType.GetMethod("Add");

                                    try
                                    {
                                        if (add != null) add.Invoke(current.Value, new[] {newObject});
                                    }
                                    catch (Exception)
                                    {
                                        throw new JsonParseException($"Unexpected element type {elementType}", r);
                                    }


                                    current = new JsonProperty(newObject);
                                }
                                else
                                {
                                    if (!objectType.IsSubclassOfBusinessObject())
                                        throw new JsonParseException(
                                            $"Unexpected property type {objectType.FullName}",
                                            r);

                                    current = new JsonProperty(current.Child.GetValue(current.Value, null));
                                }
                            }
                        }
                        else
                            current = new JsonProperty(this);

                        _stack.Push(current);

                        break;
                    case JsonToken.EndObject:

                        if (_stack.Count > 0)
                            _stack.Pop();

                        // Restore parent property from stack
                        prop = null;
                        if (_stack.Count > 1)
                            prop = _stack.ElementAt(1).Child;

                        break;
                    case JsonToken.PropertyName:

                        if (!_stack.Any())
                            throw new JsonParseException("Malformed JSON", r);

                        current = _stack.Peek();

                        var name = (string) r.Value;
                        prop = GetPropertyInfo((BaseClassSerializable) current.Value, name);

                        if (prop == null)
                            throw new JsonParseException($"Unexpected property {name}", r);

                        current.Child = prop;

                        break;
                    case JsonToken.StartArray:

                        current = null;
                        if (_stack.Any())
                            current = _stack.Peek();

                        if (current != null && current.Child != null)
                        {
                            objectType = current.Child.PropertyType;

                            if (!objectType.IsGenericList())
                                throw new JsonParseException($"Unexpected property type {objectType.FullName}", r);

                            var value = current.Child.GetValue(current.Value, null);

                            var clear = objectType.GetMethod("Clear");
                            if (clear != null) clear.Invoke(value, null);

                            current = new JsonProperty(current.Child, value);
                        }
                        else
                            current = new JsonProperty(this);

                        _stack.Push(current);

                        break;

                    case JsonToken.EndArray:

                        if (_stack.Count > 0)
                            _stack.Pop();

                        // Restore parent property from stack
                        prop = null;
                        if (_stack.Count > 1)
                            prop = _stack.ElementAt(1).Child;

                        break;
                    case JsonToken.Integer:
                    case JsonToken.Float:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.Null:
                    case JsonToken.Date:

                        current = null;
                        if (_stack.Any())
                            current = _stack.Peek();

                        if (current != null)
                        {
                            objectType = prop?.PropertyType;

                            if (current.Value.GetType().IsGenericList())
                            {
                                elementType = objectType.GetTypeInfo().GenericTypeArguments.Single();

                                var add = objectType?.GetMethod("Add");
                                var value = Cast(elementType, r.Value);

                                try
                                {
                                    if (add != null) add.Invoke(current.Value, new[] {value});
                                }
                                catch (Exception)
                                {
                                    throw new JsonParseException($"Unexpected element type {elementType}", r);
                                }
                            }
                            else
                            {
                                var value = Cast(objectType, r.Value);
                                current.Child.SetValue(current.Value, value, null);
                            }
                        }
                        else
                            throw new JsonParseException("Malformed JSON", r);

                        break;
                    default:
                        throw new JsonParseException($"Unexpected token {r.TokenType}", r);
                }
            }
        }

        /// <summary>
        /// Helper method to cast json properties
        /// </summary>
        /// <param name="target">target type</param>
        /// <param name="value">source value</param>
        /// <returns></returns>
        private static object Cast(Type target, object value)
        {
            if (target == typeof(int) || target == typeof(int?))
                return Convert.ToInt32(value);

            if (target == typeof(decimal) || target == typeof(decimal?))
                return Convert.ToDecimal(value);

            return value;
        }

        /// <summary>
        /// Helper method to get a named property
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static PropertyInfo GetPropertyInfo(BaseClassSerializable value, string name)
        {
            var properties = value.GetAllDataProperties().ToList();

            // XmlElementAttribute comes first
            var property = properties
                .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(XmlElementAttribute), false)
                    .Any(ca => ((XmlElementAttribute) ca).ElementName.Equals(name,
                        StringComparison.OrdinalIgnoreCase)));

            // Fallback to property name
            if (property == null)
                property = properties.FirstOrDefault(n => n.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return property;
        }

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
                this, jsonOptions == JsonOptions.Indented ? Formatting.Indented : Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
            return json;
        }

        public XmlSchema GetSchema()
        {
            return null;
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
                var attribute = property.GetCustomAttributes(typeof(XmlElementAttribute), false)
                    .Cast<XmlElementAttribute>()
                    .FirstOrDefault();
                var propertyName = attribute == null ? property.Name : attribute.ElementName;

                var value = property.GetValue(this, null);
                if (value == null && !XmlOptions.SerializeNullValues) continue;

                var child = value as BaseClassSerializable;
                if (child != null)
                {
                    if (child.IsEmpty() && XmlOptions.SerializeEmptyBusinessObjects == false) continue;

                    w.WriteStartElement(propertyName);
                    child.WriteXml(w);
                    w.WriteEndElement();

                    continue;
                }

                if (property.PropertyType.IsGenericList())
                {
                    WriteXmlList(propertyName, value, w);
                    continue;
                }

                switch (value)
                {
                    case string _:
                    {
                        if (!string.IsNullOrEmpty(value.ToString()) || XmlOptions.SerializeEmptyStrings)
                        {
                            w.WriteElementString(propertyName, value.ToString());
                        }

                        continue;
                    }
                    case DateTime dateTime when XmlOptions.DateTimeFormat != null &&
                                                !property.GetCustomAttributes<IgnoreXmlDateFormat>().Any():
                        w.WriteElementString(propertyName, dateTime.ToString(XmlOptions.DateTimeFormat));
                        continue;
                    case decimal decimalValue when XmlOptions.DecimalFormat != null:
                        w.WriteElementString(propertyName,
                            decimalValue.ToString(XmlOptions.DecimalFormat, CultureInfo.InvariantCulture));
                        continue;
                }

                // all else fail so just let the value flush straight to XML.
                w.WriteStartElement(propertyName);
                if (value != null)
                {
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
            var e = type.GetMethod("GetEnumerator")?.Invoke(value, null) as IEnumerator;

            while (e != null && e.MoveNext())
            {
                if (e.Current == null) continue;
                var current = e.Current;
                w.WriteStartElement(propertyName);
                {
                    switch (current)
                    {
                        case BaseClassSerializable serializable:
                            serializable.WriteXml(w);
                            break;
                        case string s:
                            w.WriteString(s);
                            break;
                        default:
                            w.WriteValue(e.Current);
                            break;
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
            while (r.NodeType == XmlNodeType.Element)
            {
                var property = properties
                    .FirstOrDefault(prop =>
                        prop
                            .GetCustomAttributes(typeof(XmlElementAttribute), false)
                            .Any(ca => ((XmlElementAttribute) ca).ElementName == r.Name));
                if (property == null)
                    property = properties.FirstOrDefault(n => n.Name.Equals(r.Name));
                if (property == null)
                {
                    r.Skip();
                    continue;
                }

                var type = property.PropertyType;
                var value = property.GetValue(this, null);

                if (type.IsSubclassOfBusinessObject())
                {
                    ((BaseClassSerializable) value).ReadXml(r);
                    continue;
                }

                // if property type is List<T>, try to fetch the list from XML.
                if (type.IsGenericList())
                {
                    ReadXmlList(value, type, r.Name, r);
                    continue;
                }

                // ReadElementContentAs won't accept a nullable type.
                if (type == typeof(DateTime?)) type = typeof(DateTime);
                if (type == typeof(decimal?)) type = typeof(decimal);
                if (type == typeof(int?)) type = typeof(int);

                property.SetValue(this, r.ReadElementContentAs(type, null), null);
            }

            if (r.NodeType == XmlNodeType.Text) r.Skip();
            r.ReadEndElement();
        }

        /// <summary>
        /// Serializes one or more XML elements into a List of BusinessObjects.
        /// </summary>
        /// <param name="propertyValue">Property value. Must be a List of BusinessObject instances.</param>
        /// <param name="propertyType"></param>
        /// <param name="elementName">Element name.</param>
        /// <param name="r">Active XML stream reader.</param>
        private static void ReadXmlList(object propertyValue, Type propertyType, string elementName, XmlReader r)
        {
            var argumentType = propertyType.GetTypeInfo().GenericTypeArguments.Single();

            // note that the 'canonical' call to GetRuntimeMethod returns null for some reason,
            // see http://stackoverflow.com/questions/21307845/runtimereflectionextensions-getruntimemethod-does-not-work-as-expected
            //var method = propertyType.GetRuntimeMethod("Clear", new[] { propertyType });
            var clear = propertyType.GetMethod("Clear");
            if (clear != null) clear.Invoke(propertyValue, null);

            var add = propertyType.GetMethod("Add");

            while (r.NodeType == XmlNodeType.Element && r.Name == elementName)
            {
                if (argumentType.IsSubclassOfBusinessObject())
                {
                    // list items are expected to be of BusinessObject type.
                    var bo = Activator.CreateInstance(argumentType);
                    ((BaseClassSerializable) bo).ReadXml(r);
                    if (add != null) add.Invoke(propertyValue, new[] {bo});
                    continue;
                }

                if (argumentType == typeof(string))
                {
                    if (add != null) add.Invoke(propertyValue, new object[] {r.ReadElementContentAsString()});
                    continue;
                }

                if (argumentType != typeof(int)) continue;
                if (add != null) add.Invoke(propertyValue, new[] {r.ReadElementContentAs(argumentType, null)});
            }
        }

        private class JsonProperty
        {
            public PropertyInfo Child { get; set; }
            public object Value { get; set; }

            public JsonProperty(PropertyInfo property, object value)
            {
                Child = property;
                Value = value;
            }

            public JsonProperty(object value) : this(null, value)
            {
            }

            public override string ToString()
            {
                return $"Child {Child} - Value {Value}";
            }
        }
    }
}