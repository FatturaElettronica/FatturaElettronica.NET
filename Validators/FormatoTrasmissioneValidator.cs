namespace FatturaElettronica.Validators
{
    public class FormatoTrasmissioneDomainValidator<T> : DomainValidator<T>
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
