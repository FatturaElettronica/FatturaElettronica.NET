using System.Collections.Generic;
using System.Xml;
using BusinessObjects;
using BusinessObjects.Validators;

namespace FatturaElettronicaPA.FatturaElettronicaHeader.DatiTrasmissione
{
    /// <summary>
    /// Represents a ContattiTrasmittente object
    /// </summary>
    public class ContattiTrasmittente : Common.BusinessObject
    {
        private string _telefono;
        private string _email;

        public ContattiTrasmittente() { }
        public ContattiTrasmittente(XmlReader r) : base(r) { }

        /// <summary>
        /// Contatto telefonico fisso o mobile.
        /// </summary>
        [DataProperty]
        public string Telefono {
            get { return _telefono; }
            set {
                _telefono = CleanString(value);
                NotifyChanged();
            }
        }

        /// <summary>
        /// Indirizzo di posta elettronica.
        /// </summary>
        [DataProperty]
        public string Email {
            get { return _email; }
            set {
                _email = CleanString(value);
                NotifyChanged();
            }
        }

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new LengthValidator("Telefono", 5, 12));
            rules.Add(new LengthValidator("Email", 7, 256));
            return rules;
        }
    }

}
