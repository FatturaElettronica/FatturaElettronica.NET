using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Dati relativi al bollo.
    /// </summary>
    public class DatiBollo : Common.BusinessObject
    {
        public DatiBollo() { }
        public DatiBollo(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(
                new AndCompositeValidator("BolloVirtuale", 
                    new List<Validator> {new FRequiredValidator(), new DomainValidator("Valore consentito: [SI]", new[] {"SI"}) }));
            rules.Add(new FRequiredValidator("ImportoBollo"));
            return rules;
        }

        #region Properties

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Bollo virtuale.
        /// </summary>
        [DataProperty]
        public string BolloVirtuale { get; set; }
        

        /// <summary>
        /// Importo del bollo.
        /// </summary>
        [DataProperty]
        public decimal? ImportoBollo { get; set; }
        #endregion
    }
}
