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
            RuleFor(x => x.DatiOrdineAcquisto).SetCollectionValidator(new DatiOrdineAcquistoValidator());
            RuleFor(x => x.DatiContratto).SetCollectionValidator(new DatiContrattoValidator());
            RuleFor(x => x.DatiConvenzione).SetCollectionValidator(new DatiConvenzioneValidator());
            RuleFor(x => x.DatiRicezione).SetCollectionValidator(new DatiRicezioneValidator());
            RuleFor(x => x.DatiFattureCollegate).SetCollectionValidator(new DatiFattureCollegateValidator());
            RuleFor(x => x.DatiDDT).SetCollectionValidator(new DatiDDTValidator());
        }
    }
}
