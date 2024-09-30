using System.Collections.Generic;
using System.Linq;
using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata.FatturaElettronicaBody;
using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class FatturaElettronicaBodyValidator : AbstractValidator<FatturaElettronicaBody>
    {
        public FatturaElettronicaBodyValidator()
        {
            RuleFor(x => x.DatiGenerali)
                .SetValidator(new DatiGeneraliValidator());
            RuleForEach(x => x.DatiBeniServizi)
                .SetValidator(new DatiBeniServiziValidator());
            RuleFor(x => x.DatiBeniServizi)
                .NotEmpty().WithMessage(ValidatorMessages.DatiBeniServiziEObbligatorio);

            RuleFor(x => x.DatiBeniServizi)
                .Must(ImportoTotaleValidateAgainstError00460)
                .WithMessage(ValidatorMessages.E00460)
                .WithErrorCode("00460");

            RuleForEach(x => x.Allegati)
                .SetValidator(new AllegatiValidator());
        }

        private static bool ImportoTotaleValidateAgainstError00460(FatturaElettronicaBody fatturaElettronicaBody,
            List<DatiBeniServizi> datiBeniServizi)
        {
            var importoTotale = datiBeniServizi.Sum(x => x.Importo);

            if (importoTotale > 400)
            {
                return !fatturaElettronicaBody.DatiGenerali.DatiFatturaRettificata.IsEmpty();
            }

            return true;
        }
    }
}
