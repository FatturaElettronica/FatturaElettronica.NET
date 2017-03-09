using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// The class all domain objects must inherit from. 
    ///
    /// Currently supports:
    /// - IEquatable so you can easily compare complex BusinessObjects togheter.
    /// - Binding (INotififyPropertyChanged and IDataErrorInfo).
    /// 
    /// TODO:
    /// - BeginEdit()/EndEdit() combination, and rollbacks for cancels (IEditableObject).
    /// </summary>
    public abstract class BaseClass:  INotifyPropertyChanged, IEquatable<BaseClass>
    {

        /// <summary>
        /// Occurs when any properties are changed on this object.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A helper method that raises the PropertyChanged event for a property.
        /// </summary>
        protected virtual void NotifyChanged([CallerMemberName] string caller = "")
        {
            NotifyChanged(new[]{caller});
        }

        /// <summary>
        /// A helper method that raises the PropertyChanged event for a property.
        /// </summary>
        /// <param name="propertyNames">The names of the properties that changed.</param>
        protected virtual void NotifyChanged(params string[] propertyNames)
        {
            foreach (var name in propertyNames)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Cleans a string by ensuring it isn't null and trimming it.
        /// </summary>
        /// <param name="s">The string to clean.</param>
        protected string CleanString(string s)
        {
            return (s ?? string.Empty).Trim();
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Checks wether a BusinessObject instance is empty.
        /// </summary>
        /// <returns>Returns true if the object is empty; false otherwise.</returns>
        public virtual bool IsEmpty()
        {
            // TODO support more data types.

            var props = GetAllDataProperties().ToList();
            var i = 0;
            foreach (var prop in props)
            {

                // Default value for Lists is Count
                if (prop.PropertyType.IsGenericList() && ((IList)prop.GetValue(this, null)).Count == 0)
                {
                    i++;
                    continue;
                }

                var v = prop.GetValue(this, null);
                if (v == null) {
                    i++;
                    continue;
                }
                if (v is string && string.IsNullOrEmpty((string) v))
                {
                    i++;
                    continue;
                }
                if (v is BaseClass && ((BaseClass)v).IsEmpty()) { 
                    i++;
                }
            }
            return i == props.Count();
        }

        /// <summary>
        /// Provides a list of actual data properties for the current BusinessObject instance, sorted by writing order.
        /// </summary>
        /// <remarks>Only properties flagged with the OrderedDataProperty attribute will be returned.</remarks>
        /// <returns>A enumerable list of PropertyInfo instances.</returns>
        protected IEnumerable<PropertyInfo> GetAllDataProperties()
        {
            return GetType()
                .GetRuntimeProperties()
                .Where(pi => pi.GetCustomAttributes<DataProperty>(true).Any())
                .OrderBy(pi => pi.GetCustomAttribute<DataProperty>(true).Order);
        }


        public bool Equals(BaseClass other)
        {
            if (other == null)
                return false;

            foreach (var prop in GetAllDataProperties()) {
                var v1 = prop.GetValue(this, null);
                var v2 = prop.GetValue(other, null);

                if (prop.PropertyType.IsGenericList()) { 
                    // We only support List<string>.
                    if (!((List<string>) v1).SequenceEqual((List<string>) v2)) {
                        return false;
                    }    
                } 
                else {
                    // Other types, and BusinessObject type.
                    if ( v1 != v2 && !v1.Equals(v2)) {
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var o = obj as BaseClass;
            return o != null && GetType().Name == o.GetType().Name && Equals(o);
        }

        public static bool operator == (BaseClass o1, BaseClass o2)
        {
            if ((object)o1 == null || ((object)o2) == null)
                return Equals(o1, o2);

            return o1.Equals(o2);
        }

        public static bool operator != (BaseClass o1, BaseClass o2)
        {
            if (o1 == null || o2 == null)
                return !Equals(o1, o2);

            return !(o1.Equals(o2));
        }

        public override int GetHashCode()
        {
            return this.GetHashCodeFromFields(GetAllDataProperties());
        }
    }
    public static class ObjectExtensions
    {
        private const int SeedPrimeNumber = 691;
        private const int FieldPrimeNumber = 397;
        /// <summary>
        /// Allows GetHashCode() method to return a Hash based ont the object properties.
        /// </summary>
        /// <param name="obj">The object fro which the hash is being generated.</param>
        /// <param name="fields">The list of fields to include in the hash generation.</param>
        /// <returns></returns>
        public static int GetHashCodeFromFields(this object obj, params object[] fields)
        {
            unchecked
            { //unchecked to prevent throwing overflow exception
                var hashCode = SeedPrimeNumber;
                foreach (var b in fields)
                    if (b != null)
                        hashCode *= FieldPrimeNumber + b.GetHashCode();
                return hashCode;
            }
        }
    }
}