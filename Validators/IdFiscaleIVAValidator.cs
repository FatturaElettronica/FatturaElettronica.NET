using FatturaElettronica.Common;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class IdFiscaleIVAValidator : AbstractValidator<IdFiscaleIVA>
    {
        public IdFiscaleIVAValidator()
        {
            RuleFor(id => id.IdPaese).NotEmpty().IsValidIdPaeseValue();
            RuleFor(id => id.IdCodice).NotEmpty().Length(1, 28);
        }
    }
}
