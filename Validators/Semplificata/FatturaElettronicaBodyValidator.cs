using System.Collections.Generic;
using System.Linq;
using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata;
using FatturaElettronica.Semplificata.FatturaElettronicaBody;
using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Semplificata.FatturaElettronicaHeader;
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

            RuleForEach(x => x.Allegati)
                .SetValidator(new AllegatiValidator());
        }
    }
}