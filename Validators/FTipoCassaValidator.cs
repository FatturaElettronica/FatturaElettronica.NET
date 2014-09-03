using BusinessObjects.Validators;

namespace FatturaElettronicaPA.Validators
{
    /// <summary>
    /// Validates FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.TipoCassa
    /// </summary>
    public class FTipoCassaValidator : DomainValidator
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public FTipoCassaValidator()
            : this(null, "Deve essere un tipo cassa valido ([TC01], [TC02], [..], [TC22])")
        {
        }

        public FTipoCassaValidator(string propertyName, string description) : base(propertyName, description)
        {
            Domain = new[]
            {
                "TC01", "TC02", "TC03", "TC04", "TC05", "TC06", "TC07", "TC08", "TC09", "TC10", "TC11", "TC12", "TC13", "TC14",
                "TC15", "TC16", "TC17", "TC18", "TC19", "TC20", "TC21", "TC22"
            };
        }
    }
}
