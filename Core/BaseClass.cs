using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FatturaElettronica.Core
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
    public abstract class BaseClass : INotifyPropertyChanged, IEquatable<BaseClass>
    {
        /// <summary>
        /// Occurs when any properties are changed on this object.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        /// Checks wether a BusinessObject instance is empty.
        /// </summary>
        /// <returns>Returns true if the object is empty; false otherwise.</returns>
        public virtual bool IsEmpty()
        {
            // TODO support more data types. Also refactor: can be improved.

            var props = GetAllDataProperties().ToList();
            var i = 0;
            foreach (var prop in props)
            {
                // Default value for Lists is Count
                if (prop.PropertyType.IsGenericList() &&
                    ((IList) prop.GetValue(this, null)).Count == 0)
                {
                    i++;
                    continue;
                }

                var v = prop.GetValue(this, null);
                switch (v)
                {
                    case null:
                        i++;
                        continue;
                    case string s when string.IsNullOrEmpty(s):
                        i++;
                        continue;
                }

                if (IsNumericType(prop.PropertyType) && v.Equals(0))
                {
                    i++;
                    continue;
                }

                switch (v)
                {
                    case DateTime _ when v.Equals(DateTime.MinValue):
                        i++;
                        continue;
                    case BaseClass @class when @class.IsEmpty():
                        i++;
                        break;
                }
            }

            return i == props.Count;
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

            foreach (var prop in GetAllDataProperties())
            {
                var v1 = prop.GetValue(this, null);
                var v2 = prop.GetValue(other, null);
                if (prop.PropertyType.IsGenericList()
                    && prop.PropertyType == typeof(List<string>))
                {
                    // We only support List<string>.
                    if (!((List<string>) v1).SequenceEqual((List<string>) v2))
                    {
                        return false;
                    }
                }
                else
                {
                    // Other types, and BusinessObject type.
                    if (v1 != null && v2 != null && v1 != v2 && !v1.Equals(v2))
                    {
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

        public static bool operator ==(BaseClass o1, BaseClass o2)
        {
            if ((object) o1 == null || (object) o2 == null)
                return Equals(o1, o2);

            return o1.Equals(o2);
        }

        public static bool operator !=(BaseClass o1, BaseClass o2)
        {
            if (o1 == null || o2 == null)
                return !Equals(o1, o2);

            return !o1.Equals(o2);
        }

        public override int GetHashCode()
        {
            return ObjectExtensions.GetHashCodeFromFields(GetAllDataProperties());
        }

        private static readonly HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(int), typeof(uint), typeof(double), typeof(decimal),
        };

        private static bool IsNumericType(Type type)
        {
            return NumericTypes.Contains(type) ||
                   NumericTypes.Contains(Nullable.GetUnderlyingType(type));
        }
    }

    public static class ObjectExtensions
    {
        private const int SeedPrimeNumber = 691;
        private const int FieldPrimeNumber = 397;

        /// <summary>
        /// Allows GetHashCode() method to return a Hash based ont the object properties.
        /// </summary>
        /// <param name="fields">The list of fields to include in the hash generation.</param>
        /// <returns></returns>
        public static int GetHashCodeFromFields(params object[] fields)
        {
            unchecked
            {
                //unchecked to prevent throwing overflow exception
                var hashCode = SeedPrimeNumber;
                foreach (var b in fields)
                    if (b != null)
                        hashCode *= FieldPrimeNumber + b.GetHashCode();
                return hashCode;
            }
        }
    }
}