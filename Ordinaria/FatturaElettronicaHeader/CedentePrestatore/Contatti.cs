using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore
{
    /// <summary>
    /// Represents a Contatti object
    /// </summary>
    public class Contatti : BaseClassSerializable
    {
        public Contatti() { } 
        public Contatti(XmlReader r) : base(r) { } 

        //public override string XmlName { get { return "Contatti"; } }

        /// <summary>
        /// Contatto telefonico fisso o mobile.
        /// </summary>
        [Core.DataProperty]
        public string Telefono { get; set; }

        /// <summary>
        /// Numero di fax.
        /// </summary>
        [Core.DataProperty]
        public string Fax { get; set; }

        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        [Core.DataProperty]
        public string Email { get; set; }
    }
}
