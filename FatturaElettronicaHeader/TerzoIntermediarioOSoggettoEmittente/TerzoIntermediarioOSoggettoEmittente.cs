using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Common;
using FatturaElettronica.Validators;

namespace FatturaElettronica.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente
{

    /// <summary>
    /// Dati relativi al soggetto terzo che emette fattura per conto del cedente / prestatore.
    /// </summary>
    public class TerzoIntermediarioOSoggettoEmittente : Common.BusinessObject
    {
        private readonly DatiAnagrafici _datiAnagrafici;

        /// <summary>
        /// Dati relativi al soggetto terzo che emette fattura per conto del cedente / prestatore.
        /// </summary>
        public TerzoIntermediarioOSoggettoEmittente() {
            _datiAnagrafici = new DatiAnagrafici();
        }
        public TerzoIntermediarioOSoggettoEmittente(XmlReader r) : base(r) { }

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
        /// Dati fiscali e anagrafici del terzo intermediario.
        /// </summary>
        [DataProperty]
        public DatiAnagrafici DatiAnagrafici { 
            get { return _datiAnagrafici; }
        }
        #endregion
    }
}
