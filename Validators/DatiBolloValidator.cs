using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiBolloValidator : AbstractValidator<DatiBollo>
    {
        public DatiBolloValidator()
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.BolloVirtuale).NotEmpty().Equal("SI");
                RuleFor(x => x.ImportoBollo).NotNull();
            });
        }
    }
}
