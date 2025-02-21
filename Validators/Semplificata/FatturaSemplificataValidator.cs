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
                .Must((fattura, _) => ImportoTotaleValidateAgainstError00460(fattura))
                .WithMessage(ValidatorMessages.E00460)
                .WithErrorCode("00460");
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

        private static bool ImportoTotaleValidateAgainstError00460(FatturaSemplificata fatturaSemplificata)
        {
            var regimeFiscale = fatturaSemplificata.FatturaElettronicaHeader.CedentePrestatore.RegimeFiscale;
            if (regimeFiscale == RegimeFiscale.RF19 || regimeFiscale == RegimeFiscale.RF20)
                return true;

            return fatturaSemplificata.FatturaElettronicaBody.All(body =>
            {
                var importoTotale = body.DatiBeniServizi.Sum(x => x.Importo);

                if (importoTotale > 400)
                    return !body.DatiGenerali.DatiFatturaRettificata.IsEmpty();
                return true;
            });
        }
    }
}