﻿using FluentValidation;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;

namespace FatturaElettronica.Validators
{
    public class CodiceArticoloValidator : AbstractValidator<CodiceArticolo>
    {
        public CodiceArticoloValidator()
        {
            RuleFor(x => x.CodiceTipo)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 35);
            RuleFor(x => x.CodiceValore)
                .NotEmpty()
                .Latin1SupplementValidator()
                .Length(1, 35);
        }
    }
}