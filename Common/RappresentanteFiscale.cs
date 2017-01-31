using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Dati relativi al rappresentante fiscale del cedente / prestatore.
    /// </summary>
    public abstract class RappresentanteFiscale : BusinessObject
    {
        private readonly DatiAnagrafici _datiAnagrafici;

        /// <summary>
        /// Dati relativi al rappresentante fiscale del cedente / prestatore.
        /// </summary>
        public RappresentanteFiscale() {
            _datiAnagrafici = new DatiAnagrafici();
        }
        public RappresentanteFiscale(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("DatiAnagrafici"));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici del rappresentante fiscae del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public DatiAnagrafici DatiAnagrafici { 
            get { return _datiAnagrafici; }
        }
        #endregion
    }
}
