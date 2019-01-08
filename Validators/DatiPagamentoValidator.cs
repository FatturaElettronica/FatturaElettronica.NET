﻿using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.DatiPagamento;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Validators
{
    public class DatiPagamentoValidator : AbstractValidator<DatiPagamento>
    {
        public DatiPagamentoValidator()
        {
            RuleFor(x => x.CondizioniPagamento)
                .NotEmpty()
                .SetValidator(new IsValidValidator<CondizioniPagamento>());
            RuleForEach(x => x.DettaglioPagamento)
                .SetValidator(new DettaglioPagamentoValidator());
            RuleFor(x => x.DettaglioPagamento)
                .NotEmpty();
        }
    }
}
