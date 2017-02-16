using FluentValidation;
using FatturaElettronica.Common;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiCessionarioCommittenteValidator 
        : DatiAnagraficiBaseValidator<DatiAnagrafici>
    {
        public DatiAnagraficiCessionarioCommittenteValidator()
        {
            RuleFor(x => x.CodiceFiscale)
                .Must((challenge, _) => { return !(string.IsNullOrEmpty(challenge.CodiceFiscale) && challenge.IdFiscaleIVA.IsEmpty()); })
                .WithMessage("IdFiscaleIVA e CodiceFiscale non valorizzati (almeno uno dei due deve essere valorizzato)")
                .WithErrorCode("00417");
            RuleFor(x => x.IdFiscaleIVA)
                .Must((challenge, _) => { return !(string.IsNullOrEmpty(challenge.CodiceFiscale) && challenge.IdFiscaleIVA.IsEmpty()); })
                .WithMessage("IdFiscaleIVA e CodiceFiscale non valorizzati (almeno uno dei due deve essere valorizzato)")
                .WithErrorCode("00417");
        }
    }
}
