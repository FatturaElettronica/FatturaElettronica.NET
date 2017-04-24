﻿using FatturaElettronica.Common;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiDocumentoValidator : AbstractValidator<DatiDocumento>
    {
        public DatiDocumentoValidator()
        {
            RuleFor(x => x.IdDocumento)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 20);
            RuleFor(x => x.NumItem)
                .Length(1, 20)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.NumItem));
            RuleFor(x => x.CodiceCommessaConvenzione)
                .Length(1, 100)
                .Latin1SupplementValidator() 
                .When(x => !string.IsNullOrEmpty(x.CodiceCommessaConvenzione));
            RuleFor(x => x.CodiceCUP)
                .Length(1, 15)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.CodiceCUP));
            RuleFor(x => x.CodiceCIG)
                .Length(1, 15)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.CodiceCIG));
        }
    }
}
