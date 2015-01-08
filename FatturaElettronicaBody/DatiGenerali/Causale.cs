using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiGenerali
{
    /// <summary>
    /// Causale del documento
    /// </summary>
    public class Causale : Common.BusinessObject
    {
        public Causale() { }
        public Causale(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new LengthValidator("Nome", 1, 200));
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
        public string Nome { get; set; } 

        #endregion
    }
}
