﻿using FatturaElettronica.Resources;
using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;

namespace FatturaElettronica.Validators.Semplificata
{
    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.DatiGeneraliDocumento)
                .SetValidator(new DatiGeneraliDocumentoValidator());
            RuleFor(x => x.DatiFatturaRettificata)
                .SetValidator(new DatiFatturaRettificataValidator())
                .When(x => x.DatiFatturaRettificata != null && !x.DatiFatturaRettificata.IsEmpty());
            RuleFor(x => x.DatiFatturaRettificata.DataFR)
                .Must((datigenerali, data) => datigenerali.DatiGeneraliDocumento.Data >= data)
                .WithMessage(ValidatorMessages.E00418_S)
                .WithErrorCode("00418")
                .When(x => !x.DatiFatturaRettificata.IsEmpty());
        }
    }
}
