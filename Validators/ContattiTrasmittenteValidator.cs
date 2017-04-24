using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class ContattiTrasmittenteValidator : AbstractValidator<ContattiTrasmittente>
    {
        public ContattiTrasmittenteValidator()
        {
            RuleFor(dt => dt.Telefono)
                .Length(5, 12)
                .When(x => !string.IsNullOrEmpty(x.Telefono));
            RuleFor(dt => dt.Email)
                .Length(7, 256)
                .When(x=>!string.IsNullOrEmpty(x.Email));
        }
    }
}
