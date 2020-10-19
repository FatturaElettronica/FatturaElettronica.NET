using System.Xml;
using FatturaElettronica.Common;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaHeader.CedentePrestatore
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
            DatiAnagrafici = new DatiAnagraficiCedentePrestatore();
            Sede = new SedeCedentePrestatore();
            StabileOrganizzazione = new StabileOrganizzazione();
            IscrizioneREA = new IscrizioneREA();
            Contatti = new Contatti();
        }
        public CedentePrestatore(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public DatiAnagraficiCedentePrestatore DatiAnagrafici { get; set; }

        /// <summary>
        /// Dati della sede del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public SedeCedentePrestatore Sede { get; set; }

        /// <summary>
        /// Nei casi di cedente / prestatore non residente.
        /// </summary>
        [Core.DataProperty]
        public StabileOrganizzazione StabileOrganizzazione { get; set; }

        /// <summary>
        /// Nei casi di società iscritte nel registro delle imprese ai sensi dell'art. 2250 del codice civile.
        /// </summary>
        [Core.DataProperty]
        public IscrizioneREA IscrizioneREA { get; set; }

        /// <summary>
        /// Contatti del cedente / prestatore.
        /// </summary>
        [Core.DataProperty]
        public Contatti Contatti { get; set; }

        /// <summary>
        /// Codice identificativo del cedente / prestatore a fini amministrativi-contabili.
        /// </summary>
        [Core.DataProperty]
        public string RiferimentoAmministrazione { get; set; }
    }
}
