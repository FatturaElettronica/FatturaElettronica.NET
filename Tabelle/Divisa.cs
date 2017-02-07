using System.Linq;

namespace FatturaElettronica.Tabelle
{
    /// <summary>
    /// Tipi documento.
    /// </summary>
    public class Divisa
    {
        /// <summary>
        /// Nome della divisa.
        /// </summary>
        public string Nome { get; private set; }
        /// <summary>
        /// Sigla della divisa.
        /// </summary>
        public string Sigla { get; private set; }
        /// <summary>
        /// Nome e Sigla della divisa.
        /// </summary>
        public string Descrizione { get { return Sigla + " " + Nome; }}

        private Divisa(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        /// <summary>
        /// Array di Sigle delle divise.
        /// </summary>
        public static string[] Sigle
        {
            get { return List.Select(x => x.Sigla).ToArray(); }
        }

        /// <summary>
        /// Tipi documento supportati.
        /// </summary>
        public static readonly Divisa[] List =
        {
            new Divisa("AED", string.Empty),
            new Divisa("AFN", string.Empty),
            new Divisa("ALL", string.Empty),
            new Divisa("AMD", string.Empty),
            new Divisa("ANG", string.Empty),
            new Divisa("AOA", string.Empty),
            new Divisa("ARS", string.Empty),
            new Divisa("AUD", string.Empty),
            new Divisa("AWG", string.Empty),
            new Divisa("AZN", string.Empty),
            new Divisa("BAM", string.Empty),
            new Divisa("BBD", string.Empty),
            new Divisa("BDT", string.Empty),
            new Divisa("BGN", string.Empty),
            new Divisa("BHD", string.Empty),
            new Divisa("BIF", string.Empty),
            new Divisa("BMD", string.Empty),
            new Divisa("BND", string.Empty),
            new Divisa("BOB", string.Empty),
            new Divisa("BOV", string.Empty),
            new Divisa("BRL", string.Empty),
            new Divisa("BSD", string.Empty),
            new Divisa("BTN", string.Empty),
            new Divisa("BWP", string.Empty),
            new Divisa("BYR", string.Empty),
            new Divisa("BZD", string.Empty),
            new Divisa("CAD", string.Empty),
            new Divisa("CDF", string.Empty),
            new Divisa("CHE", string.Empty),
            new Divisa("CHF", string.Empty),
            new Divisa("CHW", string.Empty),
            new Divisa("CLF", string.Empty),
            new Divisa("CLP", string.Empty),
            new Divisa("CNY", string.Empty),
            new Divisa("COP", string.Empty),
            new Divisa("COU", string.Empty),
            new Divisa("CRC", string.Empty),
            new Divisa("CUC", string.Empty),
            new Divisa("CUP", string.Empty),
            new Divisa("CVE", string.Empty),
            new Divisa("CZK", string.Empty),
            new Divisa("DJF", string.Empty),
            new Divisa("DKK", string.Empty),
            new Divisa("DOP", string.Empty),
            new Divisa("DZD", string.Empty),
            new Divisa("EGP", string.Empty),
            new Divisa("ERN", string.Empty),
            new Divisa("ETB", string.Empty),
            new Divisa("EUR", string.Empty),
            new Divisa("FJD", string.Empty),
            new Divisa("FKP", string.Empty),
            new Divisa("GBP", string.Empty),
            new Divisa("GEL", string.Empty),
            new Divisa("GHS", string.Empty),
            new Divisa("GIP", string.Empty),
            new Divisa("GMD", string.Empty),
            new Divisa("GNF", string.Empty),
            new Divisa("GTQ", string.Empty),
            new Divisa("GYD", string.Empty),
            new Divisa("HKD", string.Empty),
            new Divisa("HNL", string.Empty),
            new Divisa("HRK", string.Empty),
            new Divisa("HTG", string.Empty),
            new Divisa("HUF", string.Empty),
            new Divisa("IDR", string.Empty),
            new Divisa("ILS", string.Empty),
            new Divisa("INR", string.Empty),
            new Divisa("IQD", string.Empty),
            new Divisa("IRR", string.Empty),
            new Divisa("ISK", string.Empty),
            new Divisa("JMD", string.Empty),
            new Divisa("JOD", string.Empty),
            new Divisa("JPY", string.Empty),
            new Divisa("KES", string.Empty),
            new Divisa("KGS", string.Empty),
            new Divisa("KHR", string.Empty),
            new Divisa("KMF", string.Empty),
            new Divisa("KPW", string.Empty),
            new Divisa("KRW", string.Empty),
            new Divisa("KWD", string.Empty),
            new Divisa("KYD", string.Empty),
            new Divisa("KZT", string.Empty),
            new Divisa("LAK", string.Empty),
            new Divisa("LBP", string.Empty),
            new Divisa("LKR", string.Empty),
            new Divisa("LRD", string.Empty),
            new Divisa("LSL", string.Empty),
            new Divisa("LTL", string.Empty),
            new Divisa("LYD", string.Empty),
            new Divisa("MAD", string.Empty),
            new Divisa("MDL", string.Empty),
            new Divisa("MGA", string.Empty),
            new Divisa("MKD", string.Empty),
            new Divisa("MMK", string.Empty),
            new Divisa("MNT", string.Empty),
            new Divisa("MOP", string.Empty),
            new Divisa("MRO", string.Empty),
            new Divisa("MUR", string.Empty),
            new Divisa("MVR", string.Empty),
            new Divisa("MWK", string.Empty),
            new Divisa("MXN", string.Empty),
            new Divisa("MXV", string.Empty),
            new Divisa("MYR", string.Empty),
            new Divisa("MZN", string.Empty),
            new Divisa("NAD", string.Empty),
            new Divisa("NGN", string.Empty),
            new Divisa("NIO", string.Empty),
            new Divisa("NOK", string.Empty),
            new Divisa("NPR", string.Empty),
            new Divisa("NZD", string.Empty),
            new Divisa("OMR", string.Empty),
            new Divisa("PAB", string.Empty),
            new Divisa("PEN", string.Empty),
            new Divisa("PGK", string.Empty),
            new Divisa("PHP", string.Empty),
            new Divisa("PKR", string.Empty),
            new Divisa("PLN", string.Empty),
            new Divisa("PYG", string.Empty),
            new Divisa("QAR", string.Empty),
            new Divisa("RON", string.Empty),
            new Divisa("RSD", string.Empty),
            new Divisa("RUB", string.Empty),
            new Divisa("RWF", string.Empty),
            new Divisa("SAR", string.Empty),
            new Divisa("SBD", string.Empty),
            new Divisa("SCR", string.Empty),
            new Divisa("SDG", string.Empty),
            new Divisa("SEK", string.Empty),
            new Divisa("SGD", string.Empty),
            new Divisa("SHP", string.Empty),
            new Divisa("SLL", string.Empty),
            new Divisa("SOS", string.Empty),
            new Divisa("SRD", string.Empty),
            new Divisa("SSP", string.Empty),
            new Divisa("STD", string.Empty),
            new Divisa("SVC", string.Empty),
            new Divisa("SYP", string.Empty),
            new Divisa("SZL", string.Empty),
            new Divisa("THB", string.Empty),
            new Divisa("TJS", string.Empty),
            new Divisa("TMT", string.Empty),
            new Divisa("TND", string.Empty),
            new Divisa("TOP", string.Empty),
            new Divisa("TRY", string.Empty),
            new Divisa("TTD", string.Empty),
            new Divisa("TWD", string.Empty),
            new Divisa("TZS", string.Empty),
            new Divisa("UAH", string.Empty),
            new Divisa("UGX", string.Empty),
            new Divisa("USD", string.Empty),
            new Divisa("USN", string.Empty),
            new Divisa("USS", string.Empty),
            new Divisa("UYI", string.Empty),
            new Divisa("UYU", string.Empty),
            new Divisa("UZS", string.Empty),
            new Divisa("VEF", string.Empty),
            new Divisa("VND", string.Empty),
            new Divisa("VUV", string.Empty),
            new Divisa("WST", string.Empty),
            new Divisa("XAF", string.Empty),
            new Divisa("XAG", string.Empty),
            new Divisa("XAU", string.Empty),
            new Divisa("XBA", string.Empty),
            new Divisa("XBB", string.Empty),
            new Divisa("XBC", string.Empty),
            new Divisa("XBD", string.Empty),
            new Divisa("XCD", string.Empty),
            new Divisa("XDR", string.Empty),
            new Divisa("XOF", string.Empty),
            new Divisa("XPD", string.Empty),
            new Divisa("XPF", string.Empty),
            new Divisa("XPF", string.Empty),
            new Divisa("XPT", string.Empty),
            new Divisa("XSU", string.Empty),
            new Divisa("XTS", string.Empty),
            new Divisa("XUA", string.Empty),
            new Divisa("XXX", string.Empty),
            new Divisa("YER", string.Empty),
            new Divisa("ZAR", string.Empty),
            new Divisa("ZMW", string.Empty),
            new Divisa("ZWL", string.Empty)
        };
    }
}