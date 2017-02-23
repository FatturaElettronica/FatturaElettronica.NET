using FatturaElettronica.Common;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    /// <summary>
    /// Represents a Contatti object
    /// </summary>
    public class Contatti : Common.BaseClassSerializable
    {
        public Contatti() { } 
        public Contatti(XmlReader r) : base(r) { } 

        //public override string XmlName { get { return "Contatti"; } }

        /// <summary>
        /// Contatto telefonico fisso o mobile.
        /// </summary>
        [DataProperty]
        public string Telefono { get; set; }

        /// <summary>
        /// Numero di fax.
        /// </summary>
        [DataProperty]
        public string Fax { get; set; }

        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        [DataProperty]
        public string Email { get; set; }
    }
}
