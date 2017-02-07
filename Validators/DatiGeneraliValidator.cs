using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.DatiGeneraliDocumento).SetValidator(new DatiGeneraliDocumentoValidator());
            RuleFor(x => x.DatiGeneraliDocumento.Data).Must((datigenerali, data) =>
            {
                foreach(var fc in datigenerali.DatiFattureCollegate)
                {
                    if (data < fc.Data) return false;
                }
                return true;
            }).WithMessage("00418 Data antecedente a una o più date in DatiFattureCollegate");
        }
    }
}
