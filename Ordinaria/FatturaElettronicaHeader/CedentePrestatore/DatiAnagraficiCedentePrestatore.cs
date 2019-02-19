using System;
using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore
{
    public class DatiAnagraficiCedentePrestatore : DatiAnagrafici
    {
        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cedente / prestatore.
        /// </summary>
        public DatiAnagraficiCedentePrestatore() { }
        public DatiAnagraficiCedentePrestatore(XmlReader r) : base(r) { }

        /// <summary>
        /// Nome dell'albo professionale.
        /// </summary>
        [DataProperty (order:10)]
        public string AlboProfessionale { get; set; }

        /// <summary>
        /// Sigla della provincia di competenza dell'albo professionale.
        /// </summary>
        [DataProperty (order:11)]
        public string ProvinciaAlbo { get; set; }

        /// <summary>
        /// Numero di iscrizione all'albo professionale.
        /// </summary>
        [DataProperty (order:12)]
        public string NumeroIscrizioneAlbo { get; set; }

        /// <summary>
        /// Data di iscrizione all'albo professionale. 
        /// </summary>
        [DataProperty (order:13)]
        public DateTime? DataIscrizioneAlbo { get; set; }

        /// <summary>
        /// Regime fiscale.
        /// </summary>
        [DataProperty (order:14)]
        public string RegimeFiscale { get; set; }
    }
}
