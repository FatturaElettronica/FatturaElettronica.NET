using FluentValidation;

namespace FatturaElettronica.Validators
{
    public abstract class DatiAnagraficiBaseValidator<T> : AbstractValidator<T> where T : Common.DatiAnagrafici
    {
        public DatiAnagraficiBaseValidator(bool optional = false)
        {
            if (optional)
            {
                When(x => !x.IsEmpty(), () =>
                {
                    SetRules();
                });
            }
            else
            {
                SetRules();
            }
        }
        private void SetRules()
        {
            RuleFor(x => x.IdFiscaleIVA).SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale).Length(11, 16);
            RuleFor(x => x.Anagrafica).SetValidator(new AnagraficaValidator());
        }
    }
}
