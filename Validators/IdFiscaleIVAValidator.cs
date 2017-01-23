using FatturaElettronica.Common;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    class IdFiscaleIVAValidator : AbstractValidator<IdFiscaleIVA>
    {
        public IdFiscaleIVAValidator()
        {
            RuleFor(id => id.IdPaese).NotEmpty().IdPaeseDomain();
            RuleFor(id => id.IdCodice).NotEmpty().Length(1, 28);
        }
    }
}
