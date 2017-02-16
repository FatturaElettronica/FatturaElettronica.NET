using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FatturaElettronica.BusinessObjects
{
    /// <summary>
    /// The class all domain objects must inherit from. 
    ///
    /// Currently supports:
    /// - Exensible and complex validation;
    /// - IEquatable so you can easily compare complex BusinessObjects togheter.
    /// - Binding (INotififyPropertyChanged and IDataErrorInfo).
    /// 
    /// TODO:
    /// - BeginEdit()/EndEdit() combination, and rollbacks for cancels (IEditableObject).
    /// </summary>
    public abstract class BusinessObjectBase:  
        INotifyPropertyChanged,
        IEquatable<BusinessObjectBase> {

        /// <summary>
        /// Occurs when any properties are changed on this object.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A helper method that raises the PropertyChanged event for a property.
        /// </summary>
        ///<remarks>This is a paremeterless version which uses .NET 4.0 CallerMemberName to guess the calling function name.</remarks>
        protected virtual void NotifyChanged([CallerMemberName] string caller = "") {
            NotifyChanged(new[]{caller});
        }
        /// <summary>
        /// A helper method that raises the PropertyChanged event for a property.
        /// </summary>
        /// <param name="propertyNames">The names of the properties that changed.</param>
        /// <remarks>This is a .NET 2.0 compatible version.</remarks>
        protected virtual void NotifyChanged(params string[] propertyNames) {
            foreach (var name in propertyNames) {
                OnPropertyChanged(new PropertyChangedEventArgs(name));
            }
            OnPropertyChanged(new PropertyChangedEventArgs("IsValid"));
        }

        /// <summary>
        /// Cleans a string by ensuring it isn't null and trimming it.
        /// </summary>
        /// <param name="s">The string to clean.</param>
        protected string CleanString(string s) {
            return (s ?? string.Empty).Trim();
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }

        /// <summary>
        /// Checks wether a BusinessObject instance is empty.
        /// </summary>
        /// <returns>Returns true if the object is empty; false otherwise.</returns>
        public virtual Boolean IsEmpty()
        {
            // TODO support more data types.

            var props = GetAllDataProperties().ToList();
            var i = 0;
            foreach (var prop in props) {
                var v = prop.GetValue(this, null);
                if (v == null) {
                    i++;
                    continue;
                }
                if (v is string) {
                    if (string.IsNullOrEmpty((string) v)) 
                        i++;
                    continue;
                }
                if (v is BusinessObjectBase && ((BusinessObjectBase)v).IsEmpty()) { 
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
        protected IEnumerable<PropertyInfo> GetAllDataProperties() {
            return GetType()
                .GetRuntimeProperties()
                .Where(pi => pi.GetCustomAttributes<DataProperty>(true).Any())
                .OrderBy(pi => pi.GetCustomAttribute<DataProperty>(true).Order);
            //var props = GetType().GetTypeInfo().DeclaredProperties.Where(prop => Attribute.IsDefined(prop, typeof(DataProperty)));
            //return props.OrderBy(order => ((DataProperty)Attribute.GetCustomAttribute(order, typeof(DataProperty))).Order);
        }


        #region IEquatable
        public bool Equals(BusinessObjectBase other)
        {
            if (other == null)
                return false;

            foreach (var prop in GetAllDataProperties()) {
                var v1 = prop.GetValue(this, null);
                var v2 = prop.GetValue(other, null);

                if (IsListOfT(prop.PropertyType)) { 
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
        public override bool Equals(object obj) {
            if (obj == null)
                return false;

            var o = obj as BusinessObjectBase;
            return o != null && GetType().Name == o.GetType().Name && Equals(o);
        }
        public static bool operator == (BusinessObjectBase o1, BusinessObjectBase o2)
        {
            if ((object)o1 == null || ((object)o2) == null)
                return Equals(o1, o2);

            return o1.Equals(o2);
        }

        public static bool operator != (BusinessObjectBase o1, BusinessObjectBase o2)
        {
            if (o1 == null || o2 == null)
                return !Equals(o1, o2);

            return !(o1.Equals(o2));
        }
        public override int GetHashCode() {
            return this.GetHashCodeFromFields(GetAllDataProperties());
        }

        public bool IsListOfT(Type type)
        {

            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
        #endregion
    }
    public static class ObjectExtensions
    {
        private const int SeedPrimeNumber = 691;
        private const int FieldPrimeNumber = 397;
        /// <summary>
        /// Allows GetHashCode() method to return a Hash based ont he object properties.
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