using System.Linq;

namespace FatturaElettronica.Tabelle
{
    /// <summary>
    /// Tipi documento.
    /// </summary>
    public class TipoDocumento
    {
        /// <summary>
        /// Nome del documento.
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Codice del documento.
        /// </summary>
        public string Codice { get; private set; }
        /// <summary>
        /// Nome e Codice del documento.
        /// </summary>
        public string Descrizione { get { return Codice + " " + Nome; }}

        private TipoDocumento(string codice, string nome)
        {
            Codice = codice;
            Nome = nome;
        }

        /// <summary>
        /// Array di Codici dei tipi documento.
        /// </summary>
        public static string[] Codici
        {
            get { return List.Select(x => x.Codice).ToArray(); }
        }

        /// <summary>
        /// Tipi documento supportati.
        /// </summary>
        public static readonly TipoDocumento[] List =
        {
            new TipoDocumento("TD01", "fattura"),
            new TipoDocumento("TD02", "acconto/anticipo su fattura"),
            new TipoDocumento("TD03", "acconto/anticipo su parcella"),
            new TipoDocumento("TD04", "nota di credito"),
            new TipoDocumento("TD05", "nota di debito"),
            new TipoDocumento("TD06", "parcella"),
        };
    }
}