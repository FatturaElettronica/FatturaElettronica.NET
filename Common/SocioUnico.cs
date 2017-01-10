using System.Linq;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Indica se vi è un socio unico oppure se vi sono più soci.
    /// </summary>
    /// <remarks>Andrebbe usato solo nei casi di società SRL iscritte al registro imprese.</remarks>
    public class SocioUnico
    {
        /// <summary>
        /// Descrizione.
        /// </summary>
        public string Descrizione { get; private set; }
        /// <summary>
        /// Codice.
        /// </summary>
        public string Codice { get; private set; }
        private SocioUnico(string codice, string descrizione)
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
        /// Situazioni societarie ammesse.
        /// </summary>
        public static readonly SocioUnico[] List =
        {
            new SocioUnico("SU", "Socio unico"),
            new SocioUnico("SM", "Più soci")
        };
    }
}