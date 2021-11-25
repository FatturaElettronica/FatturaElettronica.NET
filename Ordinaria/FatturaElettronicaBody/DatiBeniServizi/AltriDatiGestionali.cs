using System;
using System.Xml;
using BaseClassSerializable = FatturaElettronica.Core.BaseClassSerializable;

namespace FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi
{
    /// <summary>
    /// Blocco che consente di inserire, con riferimento ad una linea di dettaglio, diverse tipologie di informazioni utili ai fini
    /// amministrativi, gestionali, etc.
    /// </summary>
    public class AltriDatiGestionali : BaseClassSerializable
    {

        public AltriDatiGestionali() { }
        public AltriDatiGestionali(XmlReader r) : base(r) { }

        /// <summary>
        /// Codice che identifica la tipologia di informazione
        /// </summary>
        [Core.DataProperty]
        public string TipoDato { get; set; }

        /// <summary>
        /// Campo in cui inserire un valore alfanumerico riferito alla tipologia di informazione.
        /// </summary>
        [Core.DataProperty]
        public string RiferimentoTesto { get; set; }

        /// <summary>
        /// Campo in cui inserire un valore numerico riferito alla tipologia di informazione.
        /// </summary>
        [Core.DataProperty]
        public decimal? RiferimentoNumero { get; set; }

        /// <summary>
        /// Campo in cui inserire una data riferita alla tiplogia di informazione.
        /// </summary>
        [Core.DataProperty]
        public DateTime? RiferimentoData { get; set; }
    }
}
