using System.Linq;
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
                .WithMessage(
                    "Il valore TD07 del tipo documento non ammette l’indicazione in fattura dello stesso soggetto sia come cedente che come cessionario")
                .WithErrorCode("00471");
        }

        private static bool FatturaValidateAgainstError00471(FatturaSemplificata fatturaSemplificata)
        {
            var cedente = fatturaSemplificata.FatturaElettronicaHeader.CedentePrestatore;
            var cessionario =
                fatturaSemplificata.FatturaElettronicaHeader.CessionarioCommittente;

            if (cedente.IdFiscaleIVA?.ToString() != cessionario.IdentificativiFiscali.IdFiscaleIVA?.ToString())
                return true;
            if (cedente.CodiceFiscale != cessionario.IdentificativiFiscali.CodiceFiscale)
                return true;

            var tipiDocumento = new[] { "TD07" };

            return fatturaSemplificata.FatturaElettronicaBody.All(x =>
                !tipiDocumento.Contains(x.DatiGenerali.DatiGeneraliDocumento.TipoDocumento));
        }
    }
}