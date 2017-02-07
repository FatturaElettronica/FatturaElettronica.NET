using System.Linq;

namespace FatturaElettronica.Tabelle
{
    /// <summary>
    /// Stato Liquidazione di società iscritta al registro imprese.
    /// </summary>
    public class StatoLiquidazione
    {
        /// <summary>
        /// Descrizione.
        /// </summary>
        public string Descrizione { get; private set; }
        /// <summary>
        /// Codice.
        /// </summary>
        public string Codice { get; private set; }
        private StatoLiquidazione(string codice, string descrizione)
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
        public static readonly StatoLiquidazione[] List =
        {
            new StatoLiquidazione("LS", "In liquidazione"),
            new StatoLiquidazione("LN", "Non in liquidazione")
        };
    }
}