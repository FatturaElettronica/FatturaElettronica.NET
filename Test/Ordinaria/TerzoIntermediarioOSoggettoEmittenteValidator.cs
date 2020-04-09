using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class TerzoIntermediarioOSoggettoEmittenteValidator :
        BaseClass<TerzoIntermediarioOSoggettoEmittente,
            FatturaElettronica.Validators.TerzoIntermediarioOSoggettoEmittenteValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasDelegateChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.DatiAnagrafici,
                typeof(FatturaElettronica.Validators.DatiAnagraficiTerzoIntermediarioValidator));
        }
    }
}