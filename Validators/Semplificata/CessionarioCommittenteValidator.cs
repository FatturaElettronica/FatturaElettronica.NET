namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
    using FluentValidation;

    public class CessionarioCommittenteValidator : AbstractValidator<CessionarioCommittente>
    {
        public CessionarioCommittenteValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .NotEmpty()
                .SetValidator(new IdentificativiFiscaliValidator())
                .WithErrorCode("00431")
                .When(x => x.AltriDatiIdentificativi.IsEmpty());


            RuleFor(x => x.AltriDatiIdentificativi)
                .NotEmpty()
                .SetValidator(new AltriDatiIdentificativiValidator())
                .WithErrorCode("00431")
                .When(x => x.IdentificativiFiscali.IsEmpty());

        }
    }
}
