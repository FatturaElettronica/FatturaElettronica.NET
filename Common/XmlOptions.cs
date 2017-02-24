namespace FatturaElettronica.Common
{
    /// <summary>
    /// XML serialization options for BusinessObject instances.
    /// </summary>
    public class XmlOptions
    {
        /// <summary>
        /// Format string to be applied on DateTime properties. This format will be ignored if the IgnoreXmlDateFormat attribute has been set 
        /// for the property.
        /// </summary>
        public string DateTimeFormat { get; set;}
        /// <summary>
        /// Format string to be applied on Decimal properties.
        /// </summary>
        public string DecimalFormat { get; set;}
        /// <summary>
        /// Whether null properties should be serialized or not. Defaults to <value>false</value>.
        /// </summary>
        public bool SerializeNullValues { get; set; }
        /// <summary>
        /// Whether empty BusinessObject children should be serialized or not. Defaults to <value>false</value>.
        /// </summary>
        public bool SerializeEmptyBusinessObjects { get; set; }
        /// <summary>
        /// Wether emty strings should be serialized or not. Defaults to <value>false</value>.
        /// </summary>
        public bool SerializeEmptyStrings { get; set; }
    }
}
