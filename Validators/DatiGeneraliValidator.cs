using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

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
            RuleForEach(x => x.DatiOrdineAcquisto)
                .SetValidator(new DatiOrdineAcquistoValidator());
            RuleForEach(x => x.DatiContratto)
                .SetValidator(new DatiContrattoValidator());
            RuleForEach(x => x.DatiConvenzione)
                .SetValidator(new DatiConvenzioneValidator());
            RuleForEach(x => x.DatiRicezione)
                .SetValidator(new DatiRicezioneValidator());
            RuleForEach(x => x.DatiFattureCollegate)
                .SetValidator(new DatiFattureCollegateValidator());
            RuleForEach(x => x.DatiDDT)
                .SetValidator(new DatiDDTValidator());
            RuleFor(x => x.DatiTrasporto)
                .SetValidator(new DatiTrasportoValidator())
                .When(x=>!x.DatiTrasporto.IsEmpty());
            RuleFor(x => x.FatturaPrincipale)
                .SetValidator(new FatturaPrincipaleValidator())
                .When(x=>!x.FatturaPrincipale.IsEmpty());
        }
    }
}
