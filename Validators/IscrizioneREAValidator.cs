using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class IscrizioneREAValidator : AbstractValidator<IscrizioneREA>
    {
        public IscrizioneREAValidator()
        {
            RuleFor(x => x.Ufficio).NotEmpty().IsValidProvinciaValue();
            RuleFor(x => x.NumeroREA).NotEmpty().Length(1, 20);
            RuleFor(x => x.SocioUnico).IsValidSocioUnicoValue().Unless(x => string.IsNullOrEmpty(x.SocioUnico));
            RuleFor(x => x.StatoLiquidazione).IsValidStatoLiquidazioneValue();
        }
    }
}
