using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
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
                .Matches(@"^[A-Z0-9]+$")
                .When(x => !string.IsNullOrEmpty(x.CodiceDestinatario));
            RuleFor(dt => dt.CodiceDestinatario)
                .Length(6)
                .When(dt => dt.FormatoTrasmissione == Defaults.FormatoTrasmissione.PubblicaAmministrazione)
                .WithErrorCode("00427");
            RuleFor(dt => dt.CodiceDestinatario)
                .Length(7)
                .When(dt => dt.FormatoTrasmissione == Defaults.FormatoTrasmissione.Privati)
                .WithErrorCode("00427");
            RuleFor(dt => dt.ContattiTrasmittente)
                .SetValidator(new ContattiTrasmittenteValidator())
                .When(x => x.ContattiTrasmittente != null && !x.ContattiTrasmittente.IsEmpty());
            RuleFor(dt => dt.PECDestinatario)
                .Length(7, 256)
                .When(x => !string.IsNullOrEmpty(x.PECDestinatario));
        }
    }
}