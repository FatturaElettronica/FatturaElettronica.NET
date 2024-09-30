using System.Linq;
using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class FatturaSemplificataValidator : AbstractValidator<FatturaSemplificata>
    {
        public FatturaSemplificataValidator()
        {
            RuleFor(dt => dt.FatturaElettronicaHeader)
                .SetValidator(new FatturaElettronicaHeaderValidator());
            RuleForEach(dt => dt.FatturaElettronicaBody)
                .SetValidator(new FatturaElettronicaBodyValidator());
            RuleFor(x => x)
                .Must((fattura, _) => FatturaValidateAgainstError00471(fattura))
                .WithMessage(ValidatorMessages.E00471_S)
                .WithErrorCode("00471");
        }

        private static bool FatturaValidateAgainstError00471(FatturaSemplificata fatturaSemplificata)
        {
            var cedente = fatturaSemplificata.FatturaElettronicaHeader.CedentePrestatore.IdFiscaleIVA.ToString();
            var cessionario =
                fatturaSemplificata.FatturaElettronicaHeader.CessionarioCommittente.IdentificativiFiscali.IdFiscaleIVA
                    .ToString();

            return cedente != cessionario || fatturaSemplificata.FatturaElettronicaBody.All(x =>
                x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento != "TD07");
        }
    }
}
