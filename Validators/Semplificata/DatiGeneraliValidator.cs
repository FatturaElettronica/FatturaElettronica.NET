namespace FatturaElettronica.Validators.Semplificata
{
    using FatturaElettronica.Semplificata.FatturaElettronicaBody.DatiGenerali;
    using FluentValidation;

    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.DatiGeneraliDocumento)
                .SetValidator(new DatiGeneraliDocumentoValidator());
            RuleFor(x => x.DatiFatturaRettificata)
                .SetValidator(new DatiFatturaRettificataValidator());
            RuleFor(x => x.DatiFatturaRettificata.DataFR)
                .Must((datigenerali, data) =>
                {
                    return datigenerali.DatiGeneraliDocumento.Data < data;
                })
            .WithMessage("Data antecedente a data fattura rettificata")
            .WithErrorCode("00418");
        }
    }
}
