using System.Linq;
using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using FatturaElettronica.Resources;

namespace FatturaElettronica.Validators
{
    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.DatiGeneraliDocumento)
                .SetValidator(new DatiGeneraliDocumentoValidator());
            RuleFor(x => x.DatiGeneraliDocumento.Data)
                .Must((datigenerali, data) =>
                {
                    return datigenerali.DatiFattureCollegate.All(fc => !(data < fc.Data));
                })
                .WithMessage(ValidatorMessages.E00418)
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
                .When(x => x.DatiTrasporto != null && !x.DatiTrasporto.IsEmpty());
            RuleFor(x => x.FatturaPrincipale)
                .SetValidator(new FatturaPrincipaleValidator())
                .When(x => x.FatturaPrincipale != null && !x.FatturaPrincipale.IsEmpty());
            RuleForEach(x => x.DatiSAL)
                .SetValidator(new DatiSALValidator());
        }
    }
}
