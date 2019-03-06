using FatturaElettronica.Ordinaria.FatturaElettronicaHeader.TerzoIntermediarioOSoggettoEmittente;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
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