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

        private FormatoTrasmissione(string nome)
        {
            Nome = nome;
        }

        /// <summary>
        /// Array di Name supportati.
        /// </summary>
        public static string[] Nomi
        {
            get { return List.Select(x => x.Nome).ToArray(); }
        }
        /// <summary>
        /// Formati supportati.
        /// </summary>
        public static readonly FormatoTrasmissione[] List = {
            new FormatoTrasmissione(Impostazioni.FormatoTrasmissione.PubblicaAmministrazione),
            new FormatoTrasmissione(Impostazioni.FormatoTrasmissione.Privati),
        };
    }
}