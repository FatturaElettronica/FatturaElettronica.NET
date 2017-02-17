using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.DatiGeneraliDocumento)
                .SetValidator(new DatiGeneraliDocumentoValidator());
            RuleFor(x => x.DatiGeneraliDocumento.Data)
                .Must((datigenerali, data) => {
                    foreach (var fc in datigenerali.DatiFattureCollegate)
                    {
                        if (data < fc.Data) return false;
                    }
                    return true;
                })
            .WithMessage("Data antecedente a una o più date in DatiFattureCollegate")
            .WithErrorCode("00418");
            RuleFor(x => x.DatiOrdineAcquisto)
                .SetCollectionValidator(new DatiOrdineAcquistoValidator());
            RuleFor(x => x.DatiContratto)
                .SetCollectionValidator(new DatiContrattoValidator());
            RuleFor(x => x.DatiConvenzione)
                .SetCollectionValidator(new DatiConvenzioneValidator());
            RuleFor(x => x.DatiRicezione)
                .SetCollectionValidator(new DatiRicezioneValidator());
            RuleFor(x => x.DatiFattureCollegate)
                .SetCollectionValidator(new DatiFattureCollegateValidator());
            RuleFor(x => x.DatiDDT)
                .SetCollectionValidator(new DatiDDTValidator());
            RuleFor(x => x.DatiTrasporto)
                .SetValidator(new DatiTrasportoValidator())
                .When(x=>!x.DatiTrasporto.IsEmpty());
            RuleFor(x => x.FatturaPrincipale)
                .SetValidator(new FatturaPrincipaleValidator())
                .When(x=>!x.FatturaPrincipale.IsEmpty());
        }
    }
}
