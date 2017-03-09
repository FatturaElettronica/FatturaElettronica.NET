using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaBody.DatiGenerali
{
    public class DatiAnagraficiVettore : DatiAnagrafici
    {
        public DatiAnagraficiVettore() { }
        public DatiAnagraficiVettore(XmlReader r) : base(r) { }

        /// <summary>
        /// Numero identificativo della licenza di guida (es. numero patente).
        /// </summary>
        [DataProperty]
        public string NumeroLicenzaGuida { get; set; }
    }
}
