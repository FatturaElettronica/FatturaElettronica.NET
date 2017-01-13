using System;
using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;

namespace FatturaElettronica.Common
{

    /// <summary>
    /// Represents a Anagrafica object
    /// </summary>
    public class Anagrafica : DenominazioneNomeCognome
    {

        public Anagrafica() { } 
        public Anagrafica(XmlReader r) : base(r) { } 

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new FLengthValidator("Titolo", 2, 10));
            rules.Add(new FLengthValidator("CodEORI", 13, 17));
            return rules;
        }

        #region Properties 

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

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
