using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators {
    /// <summary>
    /// Validates that a property conforms to ISO 3166-1 alpha 2 codes.
    /// </summary>
    public class FDivisaValidator : DomainValidator {

        private const string BrokenDescription = "Valori ammessi ([TD01], [TD02], [..], [TD06])";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FDivisaValidator() : this(null, BrokenDescription) { }
        public FDivisaValidator(string propertyName) : this(propertyName, BrokenDescription) { }
        public FDivisaValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[] {"AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN", "BAM", "BBD", "BDT", 
                "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BOV", "BRL", "BSD", "BTN", "BWP", "BYR", "BZD", "CAD", "CDF", 
                "CHE", "CHF", "CHW", "CLF", "CLP", "CNY", "COP", "COU", "CRC", "CUC", "CUP", "CVE", "CZK", "DJF", "DKK", 
                "DOP", "DZD", "EGP", "ERN", "ETB", "EUR", "FJD", "FKP", "GBP", "GEL", "GHS", "GIP", "GMD", "GNF", "GTQ", 
                "GYD", "HKD", "HNL", "HRK", "HTG", "HUF", "IDR", "ILS", "INR", "IQD", "IRR", "ISK", "JMD", "JOD", "JPY", 
                "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD", "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", "LTL", 
                "LYD", "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MUR", "MVR", "MWK", "MXN", "MXV", "MYR",
                "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD", "OMR", "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PYG",
                "QAR", "RON", "RSD", "RUB", "RWF", "SAR", "SBD", "SCR", "SDG", "SEK", "SGD", "SHP", "SLL", "SOS", "SRD",
                "SSP", "STD", "SVC", "SYP", "SZL", "THB", "TJS", "TMT", "TND", "TOP", "TRY", "TTD", "TWD", "TZS", "UAH",
                "UGX", "USD", "USN", "USS", "UYI", "UYU", "UZS", "VEF", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XBA",
                "XBB", "XBC", "XBD", "XCD", "XDR", "XOF", "XPD", "XPF", "XPF", "XPT", "XSU", "XTS", "XUA", "XXX", "YER",
                "ZAR", "ZMW", "ZWL"};
        }
    }
}
