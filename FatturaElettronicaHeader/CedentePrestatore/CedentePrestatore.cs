using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaHeader.CedentePrestatore
{

    /// <summary>
    /// Dati relativi al cedente / prestatore.
    /// </summary>
    public class CedentePrestatore : Common.BusinessObject
    {
        private readonly DatiAnagrafici _datiAnagrafici;
        private readonly Sede _sede;
        private readonly StabileOrganizzazione _stabileOrganizzazione;
        private readonly IscrizioneRea _iscrizioneRea;
        private readonly Contatti _contatti;

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        public CedentePrestatore() {
            _datiAnagrafici = new DatiAnagrafici();
            _sede = new Sede();
            _stabileOrganizzazione = new StabileOrganizzazione();
            _iscrizioneRea = new IscrizioneRea();
            _contatti = new Contatti();
        }
        public CedentePrestatore(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("DatiAnagrafici"));
            rules.Add(new FRequiredValidator("Sede"));
            rules.Add(new FLengthValidator("RiferimentoAmministrazione", 1, 20));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public DatiAnagrafici DatiAnagrafici { 
            get { return _datiAnagrafici; }
        }

        /// <summary>
        /// Dati della sede del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public Sede Sede { 
            get { return _sede; }
        }

        /// <summary>
        /// Nei casi di cedente / prestatore non residente.
        /// </summary>
        [DataProperty]
        public StabileOrganizzazione StabileOrganizzazione { 
            get { return _stabileOrganizzazione; }
        }

        /// <summary>
        /// Nei casi di società iscritte nel registro delle imprese ai sensi dell'art. 2250 del codice civile.
        /// </summary>
        [DataProperty]
        public IscrizioneRea IscrizioneRea  { 
            get { return _iscrizioneRea; }
        }

        /// <summary>
        /// Contatti del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public Contatti Contatti { 
            get { return _contatti; }
        }

        /// <summary>
        /// Codice identificativo del cedente / prestatore a fini amministrativi-contabili.
        /// </summary>
        [DataProperty]
        public string RiferimentoAmministrazione { get; set; }
        #endregion
    }
}
