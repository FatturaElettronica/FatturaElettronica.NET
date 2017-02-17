using System.Xml;
using FatturaElettronica.BusinessObjects;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{

    /// <summary>
    /// Dati relativi al cessionario/ committente.
    /// </summary>
    public class CessionarioCommittente : Common.BusinessObject
    {
        private readonly DatiAnagraficiCessionarioCommittente _datiAnagrafici;
        private readonly SedeCessionarioCommittente _sede;
        private readonly StabileOrganizzazione _stabileOrganizzazione;
        private readonly RappresentanteFiscaleCessionarioCommittente _rappresentanteFiscale;

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        public CessionarioCommittente() {
            _datiAnagrafici = new DatiAnagraficiCessionarioCommittente();
            _sede = new SedeCessionarioCommittente();
            _stabileOrganizzazione = new StabileOrganizzazione();
            _rappresentanteFiscale = new RappresentanteFiscaleCessionarioCommittente();
        }
        public CessionarioCommittente(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cessionario / committente.
        /// </summary>
        [DataProperty]
        public DatiAnagraficiCessionarioCommittente DatiAnagrafici { 
            get { return _datiAnagrafici; }
        }

        /// <summary>
        /// Dati della sede del cessionario / committente.
        /// </summary>
        [DataProperty]
        public SedeCessionarioCommittente Sede { 
            get { return _sede; }
        }

        /// <summary>
        /// Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 FormatoTrasmissione = "FPR12" (fattura tra privati), nel caso di cessionario/committente non residente e con stabile organizzazione in Italia.
        /// </summary>
        [DataProperty]
        public StabileOrganizzazione StabileOrganizzazione { 
            get { return _stabileOrganizzazione; }
        }

        /// <summary>
        /// Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente che si avvale di rappresentante fiscale in Italia.
        /// </summary>
        [DataProperty]
        public RappresentanteFiscaleCessionarioCommittente RappresentanteFiscale { 
            get { return _rappresentanteFiscale; }
        }
    }
}
