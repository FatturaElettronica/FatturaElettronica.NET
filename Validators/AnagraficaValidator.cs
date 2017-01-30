using FluentValidation;
using FatturaElettronica.Common;
namespace FatturaElettronica.Validators
{
    public class AnagraficaValidator : DenominazioneNomeCognomeValidator<Anagrafica>
    {
        public AnagraficaValidator()
        {
            RuleFor(x => x.Titolo).Length(2, 10);
            RuleFor(x => x.CodEORI).Length(13, 17);
        }
    }
}
