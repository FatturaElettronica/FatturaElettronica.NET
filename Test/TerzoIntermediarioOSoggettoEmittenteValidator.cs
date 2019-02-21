namespace Tests
{
    using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente;
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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