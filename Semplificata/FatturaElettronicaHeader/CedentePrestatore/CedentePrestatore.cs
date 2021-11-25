using System.Text.Json.Serialization;
using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Semplificata.FatturaElettronicaHeader.CedentePrestatore
{

    /// <summary>
    /// Dati relativi al cedente / prestatore.
    /// </summary>
    public class CedentePrestatore : BaseClassSerializable
    {
        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        public CedentePrestatore()
        {
            IdFiscaleIVA = new();
            Sede = new();
            StabileOrganizzazione = new();
            RappresentanteFiscale = new();
            IscrizioneREA = new();
        }
        public CedentePrestatore(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese ed i restanti il codice
        /// vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
        /// </summary>
        [Core.DataProperty(order: 0)]
        public IdFiscaleIVA IdFiscaleIVA { get; set; }

        /// <summary>
        /// Numero di Codice Fiscale.
        /// </summary>
        [Core.DataProperty(order: 1)]
        public string CodiceFiscale { get; set; }

        /// <summary>
        /// Gets or sets the Denominazione.
        /// </summary>
        [Core.DataProperty(order: 2)]
        public string Denominazione { get; set; }

        /// <summary>
        /// Gets or sets the Nome.
        /// </summary>
        [Core.DataProperty(order: 3)]
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the Cognome.
        /// </summary>
        [Core.DataProperty(order: 4)]
        public string Cognome { get; set; }

        /// <summary>
        /// Returns Cognome and Nome as a single value.
        /// </summary>
        /// <remarks>This is not a OrderedDataProperty so it will not be serialized to XML.</remarks>
        [JsonIgnore]
        public string CognomeNome
        {
            get
            {
                var r = ((Cognome ?? string.Empty) + " " + (Nome ?? string.Empty)).Trim();
                return string.IsNullOrEmpty(r) ? null : r;
            }
        }

        /// <summary>
        /// Dati della sede del cedente / prestatore.
        /// </summary>
        [Core.DataProperty(order: 5)]
        public SedeCedentePrestatore Sede { get; set; }

        /// <summary>
        /// Nei casi di cedente / prestatore non residente.
        /// </summary>
        [Core.DataProperty(order: 6)]
        public StabileOrganizzazione StabileOrganizzazione { get; set; }

        /// <summary>
        /// Rappresentante fiscale
        /// </summary>
        [Core.DataProperty(order: 7)]
        public RappresentanteFiscale RappresentanteFiscale { get; set; }

        /// <summary>
        /// Nei casi di società iscritte nel registro delle imprese ai sensi dell'art. 2250 del codice civile.
        /// </summary>
        [Core.DataProperty(order: 8)]
        public IscrizioneREA IscrizioneREA { get; set; }

        /// <summary>
        /// Codice identificativo del cedente / prestatore a fini amministrativi-contabili.
        /// </summary>
        [Core.DataProperty(order: 9)]
        public string RiferimentoAmministrazione { get; set; }

        /// <summary>
        /// Regime fiscale.
        /// </summary>
        [Core.DataProperty(order: 10)]
        public string RegimeFiscale { get; set; }
    }
}
