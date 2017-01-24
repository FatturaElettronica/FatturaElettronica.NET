using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class ContattiTrasmittenteValidator : AbstractValidator<ContattiTrasmittente>
    {
        public ContattiTrasmittenteValidator()
        {
            RuleFor(dt => dt.Telefono).Length(5, 12);
            RuleFor(dt => dt.Email).Length(7, 256);
        }
    }
}
