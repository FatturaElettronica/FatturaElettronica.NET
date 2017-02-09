using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiAnagraficiVettoreValidator : DatiAnagraficiBaseValidator<DatiAnagraficiVettore>
    {
        public DatiAnagraficiVettoreValidator(): base(optional:true)
        {
            When(x => !x.IsEmpty(), () =>
            {
                RuleFor(x => x.NumeroLicenzaGuida).Length(1,20).Unless(x => string.IsNullOrEmpty(x.NumeroLicenzaGuida));
            });
        }
    }
}
