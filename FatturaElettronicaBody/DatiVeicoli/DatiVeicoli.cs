using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaBody.DatiVeicoli
{
    /// <summary>
    /// Dati relativi ai veicoli di cui all'art. 38 comma 4 del ddl 331 del 1993.
    /// </summary>
    public class DatiVeicoli : Common.BusinessObject
    {
        public DatiVeicoli() { }
        public DatiVeicoli(XmlReader r) : base(r) { }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FRequiredValidator("Data"));
            rules.Add( new AndCompositeValidator("TotalePercorso", new List<Validator> {new FRequiredValidator(), new FLengthValidator(1, 15)}));
            return rules;
        }

        #region Properties
        /// <summary>
        /// Data di prima immatricolazione o iscrizione nei pubblici registri.
        /// </summary>
        [DataProperty]
        public DateTime Data { get; set; }

        /// <summary>
        /// Totale chilometri percorsi, oppure totale ora navigate o volate.
        /// </summary>
        [DataProperty]
        public string TotalePercorso { get; set; }
        #endregion
    }
}
