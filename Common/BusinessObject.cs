using System.Xml;

namespace FatturaElettronicaPA.Common
{

    /// <summary>
    /// Represents a FatturaElettronica BusinesObject
    /// </summary>
    public abstract class BusinessObject : BusinessObjects.BusinessObject
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
