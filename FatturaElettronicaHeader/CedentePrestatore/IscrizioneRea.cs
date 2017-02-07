using BusinessObjects;
using BusinessObjects.Validators;
using FatturaElettronica.Validators;
using System.Collections.Generic;
using System.Xml;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{
    /// <summary>
    /// Represents a DatiAnagrafici object
    /// </summary>
    public class IscrizioneREA : Common.BusinessObject
    {
        public IscrizioneREA() { } 
        public IscrizioneREA(XmlReader r) : base(r) { } 

        protected override List<Validator> CreateRules() {
            var rules = base.CreateRules();
            rules.Add(new AndCompositeValidator("Ufficio",
                new List<Validator> {
                    new FRequiredValidator(),
                    new FProvinciaValidator()
                }));
            rules.Add(new AndCompositeValidator("NumeroREA",
                new List<Validator> {
                    new FRequiredValidator(),
                    new FLengthValidator(1, 20)
                }));
            rules.Add(new DomainValidator("SocioUnico", "Valori ammessi: [SU],[SM].", Tabelle.SocioUnico.Codici));
            rules.Add(new AndCompositeValidator("StatoLiquidazione",
                new List<Validator> {
                    new FRequiredValidator(),
                    new DomainValidator("Valori ammessi: [LS],[LN].", Tabelle.StatoLiquidazione.Codici)}));
            return rules;
        }

        # region Properties 
        /// <summary>
        /// Sigla della provincia dell'Ufficio del registro delle imprese presso il quale è registata la società.
        /// </summary>
        [DataProperty]
        public string Ufficio { get; set; }

        /// <summary>
        /// Numero di iscrizione al registro delle imprese.
        /// </summary>
        [DataProperty]
        // ReSharper disable once InconsistentNaming
        public string NumeroREA { get; set; }

        /// <summary>
        /// Nei soli casi di società di capitali (Spa, SApA, SRL), il campo va valorizzato per indicare il capitale sociale.
        /// </summary>
        [DataProperty]
        public decimal? CapitaleSociale { get; set; }

        /// <summary>
        /// Nei soli casi di SRL, il campo va valorizzato per indicare se vi è un socio unico oppure se vi sono più soci.
        /// </summary>
        [DataProperty]
        public string SocioUnico { get; set; }

        /// <summary>
        /// Indica se la Società si trova in stato di liquidazione oppure no.
        /// </summary>
        [DataProperty]
        public string StatoLiquidazione { get; set; }
        # endregion

    }
}
