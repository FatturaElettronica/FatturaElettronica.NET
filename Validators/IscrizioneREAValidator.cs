using FatturaElettronica.FatturaElettronicaHeader.CedentePrestatore;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class IscrizioneREAValidator : AbstractValidator<IscrizioneREA>
    {
        public IscrizioneREAValidator()
        {
            RuleFor(x => x.Ufficio).NotEmpty().ProvinciaDomain();
            RuleFor(x => x.NumeroREA).NotEmpty().Length(1, 20);
            RuleFor(x => x.SocioUnico).SocioUnicoDomain().Unless(x => string.IsNullOrEmpty(x.SocioUnico));
            RuleFor(x => x.StatoLiquidazione).StatoLiquidazioneDomain();
        }
    }
}
