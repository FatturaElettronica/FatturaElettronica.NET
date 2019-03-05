namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader
{
    using System.Xml;
    using FatturaElettronica.Common;

    public class FatturaElettronicaHeader : BaseClassSerializable
    {
        /// <summary>
        /// Intestazione della FatturaOrdinaria Elettronica.
        /// </summary>
        public FatturaElettronicaHeader()
        {
            DatiTrasmissione = new DatiTrasmissione.DatiTrasmissione();
            CedentePrestatore = new CedentePrestatore.CedentePrestatore();
            CessionarioCommittente = new CessionarioCommittente.CessionarioCommittente();
        }
        public FatturaElettronicaHeader(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Informazioni che identificano univocamente il soggetto che trasmette, il documento trasmesso, 
        /// il formato in cui è stato trasmesso il documento, il soggetto destinatario.
        /// </summary>
        [DataProperty]
        public DatiTrasmissione.DatiTrasmissione DatiTrasmissione { get; set; }

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        [DataProperty]
        public CedentePrestatore.CedentePrestatore CedentePrestatore { get; set; }

        /// <summary>
        /// Dati relativi al cessionario / committente
        /// </summary>
        [DataProperty]
        public CessionarioCommittente.CessionarioCommittente CessionarioCommittente { get; set; }

        /// <summary>
        /// Nei casi di documenti emessi da un soggetto diverso dal cedente / prestatore, indica se la fattura sia stata
        /// emessa o da parte del cessionario / committente oppure da parte di un terzo per conto del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public string SoggettoEmittente { get; set; }
    }
}
