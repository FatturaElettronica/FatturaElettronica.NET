using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class FatturaPrincipaleValidator : AbstractValidator<FatturaPrincipale>
    {
        public FatturaPrincipaleValidator()
        {
            RuleFor(x => x.NumeroFatturaPrincipale).NotEmpty().Length(1, 20);
            RuleFor(x => x.DataFatturaPrincipale).NotNull();
        }
    }
}
