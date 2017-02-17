using System.Xml;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Represents a FatturaElettronica BusinesObject
    /// </summary>
    public abstract class BusinessObject : BusinessObjects.BusinessObjectSerializable
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        protected BusinessObject() {
            XmlOptions.DateTimeFormat = "yyyy-MM-dd";
            XmlOptions.DecimalFormat = "0.00###";
        }
        protected BusinessObject(XmlReader r) : base(r) { }
    }
}
