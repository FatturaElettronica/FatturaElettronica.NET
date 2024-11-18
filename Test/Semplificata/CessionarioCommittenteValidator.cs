using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FatturaElettronica.Resources;

namespace FatturaElettronica.Test.Semplificata
{
    [TestClass]
    public class CessionarioCommittenteValidator : BaseClass<CessionarioCommittente,
        FatturaElettronica.Validators.Semplificata.CessionarioCommittenteValidator>
    {
        [TestMethod]
        public void IdentificativiFiscaliHasChildValidator()
        {
            Validator.ShouldHaveChildValidator(x => x.IdentificativiFiscali,
                typeof(FatturaElettronica.Validators.Semplificata.IdentificativiFiscaliValidator));
        }

        [TestMethod]
        public void IdentificativiFiscaliCannotBeEmpty()
        {
            var r = Validator.Validate(Challenge);
            Assert.AreEqual(ValidatorMessages.IdentificativiFiscaliEObbligatorio,
                r.Errors.FirstOrDefault(x => x.PropertyName == "IdentificativiFiscali")?.ErrorMessage);
        }

        [TestMethod]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            Validator.ShouldHaveDelegatePropertyChildValidator(x => x.AltriDatiIdentificativi,
                typeof(FatturaElettronica.Validators.Semplificata.AltriDatiIdentificativiValidator));
        }
    }
}
