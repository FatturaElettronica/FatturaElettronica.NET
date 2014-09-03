using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Common;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaHeader.CessionarioCommittente
{

    /// <summary>
    /// Dati relativi al cessionario/ committente.
    /// </summary>
    public class CessionarioCommittente : Common.BusinessObject
    {
        private readonly DatiAnagrafici _datiAnagrafici;
        private readonly Sede _sede;

        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        public CessionarioCommittente() {
            _datiAnagrafici = new DatiAnagrafici();
            _sede = new Sede();
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
        #endregion
    }
}
