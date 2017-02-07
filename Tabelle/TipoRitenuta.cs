using System.Linq;

namespace FatturaElettronica.Tabelle
{
    /// <summary>
    /// Tipi documento.
    /// </summary>
    public class TipoRitenuta
    {
        /// <summary>
        /// Nome della ritenuta.
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Codice della ritenuta.
        /// </summary>
        public string Codice { get; private set; }
        /// <summary>
        /// Nome e Codice della ritenuta.
        /// </summary>
        public string Descrizione { get { return Codice + " " + Nome; }}

        private TipoRitenuta(string codice, string nome)
        {
            Codice = codice;
            Nome = nome;
        }

        /// <summary>
        /// Array di codici ritenuta.
        /// </summary>
        public static string[] Codici
        {
            get { return List.Select(x => x.Codice).ToArray(); }
        }

        /// <summary>
        /// Tipi documento supportati.
        /// </summary>
        public static readonly TipoRitenuta[] List =
        {
            new TipoRitenuta("RT01", "ritenuta persone fisiche"),
            new TipoRitenuta("RT02", "ritenuta persone giuridiche"),
        };
    }
}