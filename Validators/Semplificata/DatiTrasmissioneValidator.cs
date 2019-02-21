using FatturaElettronica.Semplificata.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;
using FatturaElettronica.Validators;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class DatiTrasmissioneValidator : AbstractValidator<DatiTrasmissione>
    {
        public DatiTrasmissioneValidator()
        {
            RuleFor(dt => dt.IdTrasmittente)
                .SetValidator(new IdTrasmittenteValidator());
            RuleFor(dt => dt.ProgressivoInvio)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 10);
            RuleFor(dt => dt.FormatoTrasmissione)
                .NotEmpty()
                .SetValidator(new IsValidValidator<FormatoTrasmissione>())
                .WithErrorCode("00428");
            RuleFor(dt => dt.CodiceDestinatario)
                .NotEmpty();
            RuleFor(dt => dt.CodiceDestinatario)
                .Length(7)
                .When(dt => dt.FormatoTrasmissione == Defaults.FormatoTrasmissione.Semplificata)
                .WithErrorCode("00311");
            RuleFor(dt => dt.PECDestinatario)
                .Length(7, 256)
                .When(x => !string.IsNullOrEmpty(x.PECDestinatario));
        }
    }
}
