using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Semplificata.FatturaElettronicaBody
{
    public class FatturaElettronicaBody : BaseClassSerializable
    {
        /// <summary>
        /// Fattura inclusa nella conunicazione.
        /// </summary>
        public FatturaElettronicaBody()
        {
            DatiGenerali = new DatiGenerali.DatiGenerali();
            DatiBeniServizi = new List<DatiBeniServizi.DatiBeniServizi>();
            Allegati = new List<Allegati.Allegati>();
        }
        public FatturaElettronicaBody(XmlReader r) : base(r) { }

        /// <summary>
        /// Dati generali del documento principale.
        /// </summary>
        [DataProperty]
        public DatiGenerali.DatiGenerali DatiGenerali { get; set; }

        /// <summary>
        /// Blocco semre obbligatorio contenente natura qualità e quantità dei beni/servizi oggetto dell'operazione.
        /// </summary>
        [DataProperty]
        public List<DatiBeniServizi.DatiBeniServizi> DatiBeniServizi { get; set; }

        /// <summary>
        /// Dati relativi ad eventuali allegati.
        /// </summary>
        [DataProperty]
        public List<Allegati.Allegati> Allegati { get; set; }
    }
}
