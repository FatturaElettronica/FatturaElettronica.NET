using System.Linq;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Soggetto Emittente.
    /// </summary>
    public class SoggettoEmittente
    {
        /// <summary>
        /// Descrizione.
        /// </summary>
        public string Descrizione { get; private set; }
        /// <summary>
        /// Codice.
        /// </summary>
        public string Codice { get; private set; }
        private SoggettoEmittente(string codice, string descrizione)
        {
            Codice = codice;
            Descrizione = descrizione;
        }

        /// <summary>
        /// Array di Codici.
        /// </summary>
        public static string[] Codici
        {
            get { return List.Select(x => x.Codice).ToArray(); }
        }

        /// <summary>
        /// Sogetti emittenti ammessi.
        /// </summary>
        public static readonly SoggettoEmittente[] List =
        {
            new SoggettoEmittente("CC", "cessionario/committente"),
            new SoggettoEmittente("TZ", "terzo")
        };
    }
}