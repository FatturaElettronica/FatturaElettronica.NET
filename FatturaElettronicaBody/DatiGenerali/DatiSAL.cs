using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Da valorizzare nei casi di fattura per stato di avanzamento.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class DatiSAL : Common.BusinessObject
    {
        public DatiSAL() { }
        public DatiSAL(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("RiferimentoFase"));
            return rules;
        }

        #region Properties

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.
        
        /// <summary>
        /// Fase dello stato di avanzamento cui il documento si riferisce.
        /// </summary>
        [DataProperty]
        public int RiferimentoFase { get; set; }
        #endregion
    }
}
