using System;
using System.Runtime.CompilerServices;

namespace FatturaElettronica.Core
{
    /// <summary>
    /// Use this attribute to flag DataObject properties which are meant to be represent actual Business Object values
    /// (i.e. LastName, but not IsValid). Also, in order for the Read/Write XML methods to work properly, remember
    /// that these properties should be defined in the same order with which they are expected to appear in the XML file. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataProperty : Attribute
    {
        public DataProperty([CallerLineNumber] int order = 0)
        {
            Order = order;
        }

        public int Order { get; }
    }
}