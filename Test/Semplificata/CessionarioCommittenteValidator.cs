using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Semplificata.Tests
{
    [TestClass]
    public class CessionarioCommittenteValidator : BaseClass<CessionarioCommittente, FatturaElettronica.Validators.Semplificata.CessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdentificativiFiscaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdentificativiFiscali, typeof(FatturaElettronica.Validators.Semplificata.IdentificativiFiscaliValidator));
        }
        public void IdentificativiFiscaliCannotBeEmpty()
        {
            var r = validator.Validate(challenge);
            Assert.AreEqual("IdentificativiFiscali è obbligatorio", r.Errors.FirstOrDefault(x => x.PropertyName == "IdentificativiFiscali").ErrorMessage);
        }
        [TestMethod]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            validator.ShouldHaveDelegatePropertyChildValidator(x => x.AltriDatiIdentificativi, typeof(FatturaElettronica.Validators.Semplificata.AltriDatiIdentificativiValidator));
        }
    }
}
