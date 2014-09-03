using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronicaPA.Validators;

namespace FatturaElettronicaPA.Common
{

    /// <summary>
    /// Represents a Anagrafica object
    /// </summary>
    public class Anagrafica : BusinessObject
    {

        public Anagrafica() { } 
        public Anagrafica(XmlReader r) : base(r) { } 

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FLengthValidator("Denominazione", 1, 80));
            rules.Add(new FLengthValidator("Nome", 1, 60));
            rules.Add(new FLengthValidator("Cognome", 1, 60));
            rules.Add(new FLengthValidator("Titolo", 2, 10));
            rules.Add(new FLengthValidator("CodEORI", 13, 17));
            rules.Add(new FXorRequiredValidator(new []{"Denominazione", "CognomeNome"}));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Gets or sets the Denominazione.
        /// </summary>
        [DataProperty]
        public string Denominazione { get; set; }

        /// <summary>
        /// Gets or sets the Nome.
        /// </summary>
        [DataProperty]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Cognome.
        /// </summary>
        [DataProperty]
        public string Cognome { get; set; }

        /// <summary>
        /// Returns Cognome and Nome as a single value.
        /// </summary>
        /// <remarks>This is not a OrderedDataProperty so it will not be serialized to XML.</remarks>
        public string CognomeNome
        {
            get
            {
                var r = ((Cognome ?? string.Empty) + " " + (Nome ?? string.Empty)).Trim();
                return String.IsNullOrEmpty(r) ? null : r;
            }
        }
        /// <summary>
        /// Gets or sets the Titolo.
        /// </summary>
        [DataProperty]
        public string Titolo { get; set; }

        /// <summary>
        /// Gets or sets the CodEORI.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string CodEORI { get; set; }
        #endregion
    }
}
