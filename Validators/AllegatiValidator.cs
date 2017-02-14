using FluentValidation;
using FatturaElettronica.FatturaElettronicaBody.Allegati;

namespace FatturaElettronica.Validators
{
    public class AllegatiValidator : AbstractValidator<Allegati>
    {
        public AllegatiValidator()
        {
            RuleFor(x => x.NomeAttachment).NotEmpty().Length(1, 60);
            RuleFor(x => x.AlgoritmoCompressione).Length(1, 60).When(x => !string.IsNullOrEmpty(x.AlgoritmoCompressione));
            RuleFor(x => x.FormatoAttachment).Length(1, 10).When(x => !string.IsNullOrEmpty(x.FormatoAttachment));
            RuleFor(x => x.DescrizioneAttachment).Length(1, 100).When(x => !string.IsNullOrEmpty(x.DescrizioneAttachment));
            RuleFor(x => x.Attachment).NotEmpty();
        }
    }
}
