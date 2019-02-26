namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
    using FluentValidation;

    public class DatiIVAValidator : AbstractValidator<DatiIVA>
    {
        public DatiIVAValidator()
        {
            RuleFor(x => x.Imposta);
            RuleFor(x => x.Aliquota);
        }
    }
}
