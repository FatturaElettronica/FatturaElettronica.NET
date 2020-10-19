using FluentValidation;
using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class AllegatiValidator : AbstractValidator<Allegati>
    {
        public AllegatiValidator()
        {
            RuleFor(x => x.NomeAttachment)
                .NotEmpty()
                .Latin1SupplementValidator()
                .Length(1, 60);
            RuleFor(x => x.AlgoritmoCompressione)
                .Length(1, 60)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.AlgoritmoCompressione));
            RuleFor(x => x.FormatoAttachment)
                .Length(1, 10)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.FormatoAttachment));
            RuleFor(x => x.DescrizioneAttachment)
                .Length(1, 100)
                .Latin1SupplementValidator()
                .When(x => !string.IsNullOrEmpty(x.DescrizioneAttachment));
            RuleFor(x => x.Attachment)
                .NotEmpty();
        }
    }
}