using System;
using System.Collections.Generic;
using System.Linq;
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
                .NotEmpty().WithMessage("DatiBeniServizi è obbligatorio");

            RuleFor(x => x.DatiBeniServizi)
                .Must((fatturaElettronicaBody, datiBeniServizi) => ImportoTotaleValidateAgainstError00460(fatturaElettronicaBody,datiBeniServizi))
                .WithMessage("Importo totale superiore al limite previsto per le fatture semplificate ai sensi del DPR 633/72, art. 21bis")
                .WithErrorCode("00460");

            RuleForEach(x => x.Allegati)
                .SetValidator(new AllegatiValidator());
        }

        private bool ImportoTotaleValidateAgainstError00460(FatturaElettronicaBody fatturaElettronicaBody, List<DatiBeniServizi> datiBeniServizi)
        {
            var importoTotale = datiBeniServizi.Sum(x => x.Importo);

            if(importoTotale > 100M)
            {
                return !fatturaElettronicaBody.DatiGenerali.DatiFatturaRettificata.IsEmpty();
            }
            else
            {
                return true;
            }
        }
    }
}
