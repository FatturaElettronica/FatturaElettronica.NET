using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class IscrizioneREAValidator : AbstractValidator<IscrizioneREA>
    {
        public IscrizioneREAValidator()
        {
            RuleFor(x => x.Ufficio)
                .NotEmpty()
                .Matches(@"^[A-Z]{2}$");
            RuleFor(x => x.NumeroREA)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleFor(x => x.SocioUnico)
                .SetValidator(new IsValidValidator<SocioUnico>())
                .When(x => !string.IsNullOrEmpty(x.SocioUnico));
            RuleFor(x => x.StatoLiquidazione)
                .NotEmpty()
                .SetValidator(new IsValidValidator<StatoLiquidazione>());
        }
    }
}
