using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Common;
using FatturaElettronica.Validators;

namespace FatturaElettronica.FatturaElettronicaHeader.CessionarioCommittente
{

    /// <summary>
    /// Dati relativi al cessionario/ committente.
    /// </summary>
    public class CessionarioCommittente : Common.BusinessObject
    {
        private readonly DatiAnagrafici _datiAnagrafici;
        private readonly Sede _sede;
        private readonly StabileOrganizzazione _stabileOrganizzazione;
        private readonly RappresentanteFiscale _rappresentanteFiscale;

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        public CessionarioCommittente() {
            _datiAnagrafici = new DatiAnagrafici();
            _sede = new Sede();
            _stabileOrganizzazione = new StabileOrganizzazione();
            _rappresentanteFiscale = new RappresentanteFiscale();
        }
        public CessionarioCommittente(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("DatiAnagrafici"));
            rules.Add(new FRequiredValidator("Sede"));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cessionario / committente.
        /// </summary>
        [DataProperty]
        public DatiAnagrafici DatiAnagrafici { 
            get { return _datiAnagrafici; }
        }

        /// <summary>
        /// Dati della sede del cessionario / committente.
        /// </summary>
        [DataProperty]
        public Sede Sede { 
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
        public RappresentanteFiscale RappresentanteFiscale { 
            get { return _rappresentanteFiscale; }
        }
        #endregion
    }
}
