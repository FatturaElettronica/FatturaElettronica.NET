namespace FatturaElettronica.Validators.Semplificata
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiBeniServizi;
    using FluentValidation;

    public class DatiIVAValidator : AbstractValidator<DatiIVA>
    {
        public DatiIVAValidator()
        {
            RuleFor(x => x.Imposta);
            RuleFor(x => x.Aliquota);
        }
    }
}
