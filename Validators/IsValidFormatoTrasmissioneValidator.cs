namespace FatturaElettronica.Validators
{
    public class IsValidFormatoTrasmissioneValidator<T> : DomainValidator<T>
    {
        protected override string[] Domain
        {
            get
            {
                return new[] { "FPA12", "FPR12" };
            }
        }
    }
}
