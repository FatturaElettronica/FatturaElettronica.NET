using FatturaElettronica.Common;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader
{
    public class FatturaElettronicaHeader : Common.BaseClassSerializable
    {
        private readonly DatiTrasmissione.DatiTrasmissione _datiTrasmissione;
        private readonly CedentePrestatore.CedentePrestatore _cedentePrestatore;
        private readonly RappresentanteFiscale.RappresentanteFiscale _rappresentanteFiscale;
        private readonly CessionarioCommittente.CessionarioCommittente _cessionarioCommittente;
        private readonly TerzoIntermediarioOSoggettoEmittente.TerzoIntermediarioOSoggettoEmittente 
            _terzoIntermediarioOSoggettoEmittente;

        /// <summary>
        /// Intestazione della Fattura Elettronica.
        /// </summary>
        public FatturaElettronicaHeader() {
            _datiTrasmissione = new DatiTrasmissione.DatiTrasmissione();
            _cedentePrestatore = new CedentePrestatore.CedentePrestatore();
            _rappresentanteFiscale = new RappresentanteFiscale.RappresentanteFiscale();
            _cessionarioCommittente = new CessionarioCommittente.CessionarioCommittente();
            _terzoIntermediarioOSoggettoEmittente = new TerzoIntermediarioOSoggettoEmittente.TerzoIntermediarioOSoggettoEmittente();
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
        public DatiTrasmissione.DatiTrasmissione DatiTrasmissione { get { return _datiTrasmissione; } }

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        [DataProperty]
        public CedentePrestatore.CedentePrestatore CedentePrestatore { get { return _cedentePrestatore; } }

        /// <summary>
        /// Dati relativi al rappresentante fiscale del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public RappresentanteFiscale.RappresentanteFiscale Rappresentante { get { return _rappresentanteFiscale; } }

        /// <summary>
        /// Dati relativi al cessionario / committente
        /// </summary>
        [DataProperty]
        public CessionarioCommittente.CessionarioCommittente CessionarioCommittente { get { return _cessionarioCommittente; } }

        /// <summary>
        /// Dati relativi al soggetto che emette fattura per conto del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public TerzoIntermediarioOSoggettoEmittente.TerzoIntermediarioOSoggettoEmittente TerzoIntermediarioOSoggettoEmittente {
            get { return _terzoIntermediarioOSoggettoEmittente; }
        }

        /// <summary>
        /// Nei casi di documenti emessi da un soggetto diverso dal cedente / prestatore, indica se la fattura sia stata
        /// emessa o da parte del cessionario / committente oppure da parte di un terzo per conto del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public string SoggettoEmittente { get; set; }
    }
}
