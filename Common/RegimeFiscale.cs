using System.Linq;

namespace FatturaElettronicaPA.Common
{
    /// <summary>
    /// Regimi fiscali.
    /// </summary>
    public class RegimeFiscale
    {
        /// <summary>
        /// Nome del regime fiscale.
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Codice del regime fiscale.
        /// </summary>
        public string Codice { get; private set; }
        /// <summary>
        /// Nome e Codice nel regime fiscale.
        /// </summary>
        public string Descrizione { get { return Codice + " " + Nome; }}

        private RegimeFiscale(string codice, string nome)
        {
            Codice = codice;
            Nome = nome;
        }

        /// <summary>
        /// Array di Codici dei regimi fiscali.
        /// </summary>
        public static string[] Codici
        {
            get { return List.Select(x => x.Codice).ToArray(); }
        }

        /// <summary>
        /// Regimi fiscali supportati.
        /// </summary>
        public static readonly RegimeFiscale[] List =
        {
            new RegimeFiscale("RF01", "Ordinario"),
            new RegimeFiscale("RF02", "Contribuenti minimi (art.1, c.96-117, L. 244/07)"),
            new RegimeFiscale("RF03", "Nuove iniziative produttive (art.13, L. 388/00)"),
            new RegimeFiscale("RF04", "Agricoultura e attività connesse e pesca (artt.34 e 34-bis, DPR 633/72)"),
            new RegimeFiscale("RF05", "Vendita sali e tabacchi (art.74, c.1, DPR 633/72)"),
            new RegimeFiscale("RF06", "Commercio fiammiferi (art.74, c.1, DPR 633/72)"),
            new RegimeFiscale("RF07", "Editoria (art.74, c.1, DPR 633/72)"),
            new RegimeFiscale("RF08", "Gestione servizi telefonia pubblica (art.74, c.1, DPR 633/72)"),
            new RegimeFiscale("RF09", "Rivendita documenti di trasporto pubblico e di sosta (art.74, c.1, DPR 633/72)"),
            new RegimeFiscale("RF10", "Intrattenimenti, giochi e altre attività di cui all atariffa allegata al DPR 640/72 (art.74, c.6, DPR 633/72)"),
            new RegimeFiscale("RF11", "Agenzie viaggi e turismo (art.74-ter, DPR 633/72)"),
            new RegimeFiscale("RF12", "Agriturismo (art.5, c.2 L. 413/91)"),
            new RegimeFiscale("RF13", "Vendite a domicilio (art.25-bis, c.6, DPR 600/73)"),
            new RegimeFiscale("RF14", "Rivendita beni usati, oggetti d'arte, d'antiquariato o da collezione (art.36, DL 41/95)"),
            new RegimeFiscale("RF15", "Agenzie di vendite all'asta di oggetti d'arte, antiquariato o da collezione (art.40-bis, DL 41/95)"),
            new RegimeFiscale("RF16", "IVA per cassa P.A. (art.6, c.5, DPR 633/72)"),
            new RegimeFiscale("RF17", "IVA per cassa soggetti con vol. d'affari inferiore ad euro 200.000 (art.7, DL 185/2008)"),
            new RegimeFiscale("RF18", "Altro"),
            new RegimeFiscale("RF19", "Regime forfettario (art.1, c.54-89, L. 190/2014)")
        };
    }
}