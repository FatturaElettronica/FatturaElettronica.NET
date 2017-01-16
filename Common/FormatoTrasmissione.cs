using System.Linq;
using FatturaElettronica.Impostazioni;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Lista dei FormatoTrasmissione supportati.
    /// </summary>
    public class FormatoTrasmissione
    {
        /// <summary>
        /// Formato trasmissione.
        /// </summary>
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public string Descrizione { 
            get {
                return string.Format("{0} {1}", Sigla, Nome);
            }
        }

        private FormatoTrasmissione(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        /// <summary>
        /// Array di Name supportati.
        /// </summary>
        public static string[] Nomi
        {
            get { return List.Select(x => x.Nome).ToArray(); }
        }
        public static string[] Sigle
        {
            get { return List.Select(x => x.Sigla).ToArray(); }
        }
        /// <summary>
        /// Formati supportati.
        /// </summary>
        public static readonly FormatoTrasmissione[] List = {
            new FormatoTrasmissione(Impostazioni.FormatoTrasmissione.PubblicaAmministrazione, "Fattura verso la PA"),
            new FormatoTrasmissione(Impostazioni.FormatoTrasmissione.Privati, "Fattura verso privati"),
        };
    }
}