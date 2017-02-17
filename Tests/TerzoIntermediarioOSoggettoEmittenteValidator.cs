using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente;
using FluentValidation.TestHelper;

namespace Tests
{
    [TestClass]
    public class TerzoIntermediarioOSoggettoEmittenteValidator : 
        BaseClass<TerzoIntermediarioOSoggettoEmittente, FatturaElettronica.Validators.TerzoIntermediarioOSoggettoEmittenteValidator>
    {
        [TestMethod]
        public void DatiAnagraficiHasDelegateChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.DatiAnagrafici, typeof(FatturaElettronica.Validators.DatiAnagraficiTerzoIntermediarioValidator));
        }
    }
}
