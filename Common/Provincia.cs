using System.Linq;

namespace FatturaElettronicaPA.Common
{
    /// <summary>
    /// Province italiane.
    /// </summary>
    public class Provincia
    {
        /// <summary>
        /// Nome della provincia.
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Sigla della provincia.
        /// </summary>
        public string Sigla { get; private set; }
        /// <summary>
        /// Nome e Sigla nel formato Provincia (Sigla).
        /// </summary>
        public string Descrizione { 
            get {
                return (string.IsNullOrEmpty(Nome)) ? string.Empty : Nome + " (" + Sigla + ")";
            }
        }

        private Provincia(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        /// <summary>
        /// Array di Sigle di provincia.
        /// </summary>
        public static string[] Sigle
        {
            get { return List.Select(x => x.Sigla).ToArray(); }
        }
        /// <summary>
        /// Array di Nomi di provincia.
        /// </summary>
        public static string[] Nomi
        {
            get { return List.Select(x => x.Nome).ToArray(); }
        }

        /// <summary>
        /// Province italiane.
        /// </summary>
        public static readonly Provincia[] List =
        {
            new Provincia("", null),
            new Provincia("AG", "Agrigento"),
            new Provincia("AL", "Alessandria"),
            new Provincia("AN", "Ancona"),
            new Provincia("AO", "Aosta"),
            new Provincia("AQ", "L'Aquila"),
            new Provincia("AR", "Arezzo"),
            new Provincia("AP", "Ascoli-Piceno"),
            new Provincia("AT", "Asti"),
            new Provincia("AV", "Avellino"),
            new Provincia("BA", "Bari"),
            new Provincia("BT", "Barletta-Andria-Trani"),
            new Provincia("BL", "Belluno"),
            new Provincia("BN", "Benevento"),
            new Provincia("BG", "Bergamo"),
            new Provincia("BI", "Biella"),
            new Provincia("BO", "Bologna"),
            new Provincia("BZ", "Bolzano"),
            new Provincia("BS", "Brescia"),
            new Provincia("BR", "Brindisi"),
            new Provincia("CA", "Cagliari"),
            new Provincia("CL", "Caltanissetta"),
            new Provincia("CB", "Campobasso"),
            new Provincia("CI", "Carbonia Iglesias"),
            new Provincia("CE", "Caserta"),
            new Provincia("CT", "Catania"),
            new Provincia("CZ", "Catanzaro"),
            new Provincia("CH", "Chieti"),
            new Provincia("CO", "Como"),
            new Provincia("CS", "Cosenza"),
            new Provincia("CR", "Cremona"),
            new Provincia("KR", "Crotone"),
            new Provincia("CN", "Cuneo"),
            new Provincia("EN", "Enna"),
            new Provincia("FM", "Fermo"),
            new Provincia("FE", "Ferrara"),
            new Provincia("FI", "Firenze"),
            new Provincia("FG", "Foggia"),
            new Provincia("FC", "Forli-Cesena"),
            new Provincia("FR", "Frosinone"),
            new Provincia("GE", "Genova"),
            new Provincia("GO", "Gorizia"),
            new Provincia("GR", "Grosseto"),
            new Provincia("IM", "Imperia"),
            new Provincia("IS", "Isernia"),
            new Provincia("SP", "La-Spezia"),
            new Provincia("LT", "Latina"),
            new Provincia("LE", "Lecce"),
            new Provincia("LC", "Lecco"),
            new Provincia("LI", "Livorno"),
            new Provincia("LO", "Lodi"),
            new Provincia("LU", "Lucca"),
            new Provincia("MC", "Macerata"),
            new Provincia("MN", "Mantova"),
            new Provincia("MS", "Massa-Carrara"),
            new Provincia("MT", "Matera"),
            new Provincia("VS", "Medio Campidano"),
            new Provincia("ME", "Messina"),
            new Provincia("MI", "Milano"),
            new Provincia("MO", "Modena"),
            new Provincia("MB", "Monza-Brianza"),
            new Provincia("NA", "Napoli"),
            new Provincia("NO", "Novara"),
            new Provincia("NU", "Nuoro"),
            new Provincia("OG", "Ogliastra"),
            new Provincia("OT", "Olbia Tempio"),
            new Provincia("OR", "Oristano"),
            new Provincia("PD", "Padova"),
            new Provincia("PA", "Palermo"),
            new Provincia("PR", "Parma"),
            new Provincia("PV", "Pavia"),
            new Provincia("PG", "Perugia"),
            new Provincia("PU", "Pesaro-Urbino"),
            new Provincia("PE", "Pescara"),
            new Provincia("PC", "Piacenza"),
            new Provincia("PI", "Pisa"),
            new Provincia("PT", "Pistoia"),
            new Provincia("PN", "Pordenone"),
            new Provincia("PZ", "Potenza"),
            new Provincia("PO", "Prato"),
            new Provincia("RG", "Ragusa"),
            new Provincia("RA", "Ravenna"),
            new Provincia("RC", "Reggio-Calabria"),
            new Provincia("RE", "Reggio-Emilia"),
            new Provincia("RI", "Rieti"),
            new Provincia("RN", "Rimini"),
            new Provincia("RM", "Roma"),
            new Provincia("RO", "Rovigo"),
            new Provincia("SA", "Salerno"),
            new Provincia("SS", "Sassari"),
            new Provincia("SV", "Savona"),
            new Provincia("SI", "Siena"),
            new Provincia("SR", "Siracusa"),
            new Provincia("SO", "Sondrio"),
            new Provincia("TA", "Taranto"),
            new Provincia("TE", "Teramo"),
            new Provincia("TR", "Terni"),
            new Provincia("TO", "Torino"),
            new Provincia("TP", "Trapani"),
            new Provincia("TN", "Trento"),
            new Provincia("TV", "Treviso"),
            new Provincia("TS", "Trieste"),
            new Provincia("UD", "Udine"),
            new Provincia("VA", "Varese"),
            new Provincia("VE", "Venezia"),
            new Provincia("VB", "Verbania"),
            new Provincia("VC", "Vercelli"),
            new Provincia("VR", "Verona"),
            new Provincia("VV", "Vibo-Valentia"),
            new Provincia("VI", "Vicenza"),
            new Provincia("VT", "Viterbo")
        };
    }
}