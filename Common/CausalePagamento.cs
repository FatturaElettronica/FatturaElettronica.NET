using System.Linq;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Tipi documento.
    /// </summary>
    public class CausalePagamento
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

        private CausalePagamento(string codice, string nome)
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
        public static readonly CausalePagamento[] List =
        {
            // TODO add appropriate values for Nome
            new CausalePagamento("A", string.Empty),
            new CausalePagamento("B", string.Empty),
            new CausalePagamento("C", string.Empty),
            new CausalePagamento("D", string.Empty),
            new CausalePagamento("E", string.Empty),
            new CausalePagamento("G", string.Empty),
            new CausalePagamento("H", string.Empty),
            new CausalePagamento("I", string.Empty),
            new CausalePagamento("L", string.Empty),
            new CausalePagamento("M", string.Empty),
            new CausalePagamento("N", string.Empty),
            new CausalePagamento("O", string.Empty),
            new CausalePagamento("P", string.Empty),
            new CausalePagamento("Q", string.Empty),
            new CausalePagamento("R", string.Empty),
            new CausalePagamento("S", string.Empty),
            new CausalePagamento("T", string.Empty),
            new CausalePagamento("U", string.Empty),
            new CausalePagamento("V", string.Empty),
            new CausalePagamento("W", string.Empty),
            new CausalePagamento("X", string.Empty),
            new CausalePagamento("Y", string.Empty),
            new CausalePagamento("Z", string.Empty),
            new CausalePagamento("L1", string.Empty),
            new CausalePagamento("M1", string.Empty),
            new CausalePagamento("O1", string.Empty),
            new CausalePagamento("V1", string.Empty)
        };
    }
}