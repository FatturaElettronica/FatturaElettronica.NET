namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
    using FluentValidation;

    public class IdentificativiFiscaliValidator : AbstractValidator<IdentificativiFiscali>
    {
        public IdentificativiFiscaliValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale)
                .Length(11, 16)
                .When(x => !string.IsNullOrEmpty(x.CodiceFiscale));
        }
    }
}
