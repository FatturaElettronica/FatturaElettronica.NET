using System.Xml;
using System.Xml.Serialization;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader
{
    public class FatturaElettronicaHeader : Core.BaseClassSerializable
    {
        /// <summary>
        /// Intestazione della FatturaOrdinaria Elettronica.
        /// </summary>
        public FatturaElettronicaHeader()
        {
            DatiTrasmissione = new DatiTrasmissione.DatiTrasmissione();
            CedentePrestatore = new CedentePrestatore.CedentePrestatore();
            Rappresentante = new RappresentanteFiscale.RappresentanteFiscale();
            CessionarioCommittente = new CessionarioCommittente.CessionarioCommittente();
            TerzoIntermediarioOSoggettoEmittente =
                new TerzoIntermediarioOSoggettoEmittente.TerzoIntermediarioOSoggettoEmittente();
        }

        public FatturaElettronicaHeader(XmlReader r) : base(r)
        {
        }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        /// <summary>
        /// Informazioni che identificano univocamente il soggetto che trasmette, il documento trasmesso, 
        /// il formato in cui è stato trasmesso il documento, il soggetto destinatario.
        /// </summary>
        [Core.DataProperty]
        public DatiTrasmissione.DatiTrasmissione DatiTrasmissione { get; set; }

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public CedentePrestatore.CedentePrestatore CedentePrestatore { get; set; }

        /// <summary>
        /// Dati relativi al rappresentante fiscale del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        [XmlElement(ElementName = "RappresentanteFiscale")]
        public RappresentanteFiscale.RappresentanteFiscale Rappresentante { get; set; }

        /// <summary>
        /// Dati relativi al cessionario / committente
        /// </summary>
        [Core.DataProperty]
        public CessionarioCommittente.CessionarioCommittente CessionarioCommittente { get; set; }

        /// <summary>
        /// Dati relativi al soggetto che emette fattura per conto del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public TerzoIntermediarioOSoggettoEmittente.TerzoIntermediarioOSoggettoEmittente
            TerzoIntermediarioOSoggettoEmittente { get; set; }

        /// <summary>
        /// Nei casi di documenti emessi da un soggetto diverso dal cedente / prestatore, indica se la fattura sia stata
        /// emessa o da parte del cessionario / committente oppure da parte di un terzo per conto del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public string SoggettoEmittente { get; set; }
    }
}