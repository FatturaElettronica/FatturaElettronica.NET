using System.Xml;
using FatturaElettronica.Common;

namespace FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore
{

    /// <summary>
    /// Dati relativi al cedente / prestatore.
    /// </summary>
    public class CedentePrestatore : BaseClassSerializable
    {
        /// <summary>
        /// Dati relativi al cedente / prestatore.
        /// </summary>
        public CedentePrestatore() {
            DatiAnagrafici = new DatiAnagraficiCedentePrestatore();
            Sede = new SedeCedentePrestatore();
            StabileOrganizzazione1 = new StabileOrganizzazione();
            IscrizioneREA1 = new IscrizioneREA();
            Contatti1 = new Contatti();
        }
        public CedentePrestatore(XmlReader r) : base(r) { }

        /// IMPORTANT
        /// Each data property must be flagged with the Order attribute or it will be ignored.
        /// Also, properties must be listed with the precise order in the specification.

        /// <summary>
        /// Dati anagrafici, professionali e fiscali del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public DatiAnagraficiCedentePrestatore DatiAnagrafici { get; }

        /// <summary>
        /// Dati della sede del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public SedeCedentePrestatore Sede { get; }

        /// <summary>
        /// Nei casi di cedente / prestatore non residente.
        /// </summary>
        [DataProperty]
        public StabileOrganizzazione StabileOrganizzazione { 
            get { return StabileOrganizzazione1; }
        }

        /// <summary>
        /// Nei casi di società iscritte nel registro delle imprese ai sensi dell'art. 2250 del codice civile.
        /// </summary>
        [DataProperty]
        public IscrizioneREA IscrizioneREA  { 
            get { return IscrizioneREA1; }
        }

        /// <summary>
        /// Contatti del cedente / prestatore.
        /// </summary>
        [DataProperty]
        public Contatti Contatti { 
            get { return Contatti1; }
        }

        /// <summary>
        /// Codice identificativo del cedente / prestatore a fini amministrativi-contabili.
        /// </summary>
        [DataProperty]
        public string RiferimentoAmministrazione { get; set; }

        public StabileOrganizzazione StabileOrganizzazione1 { get; }

        public IscrizioneREA IscrizioneREA1 { get; }

        public Contatti Contatti1 { get; }
    }
}
