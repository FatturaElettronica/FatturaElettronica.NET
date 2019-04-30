using FatturaElettronica.Semplificata.FatturaElettronicaHeader.CessionarioCommittente;
using FluentValidation.TestHelper;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Semplificata.Tests
{
    [TestClass]
    public class CessionarioCommittenteValidator : BaseClass<CessionarioCommittente, FatturaElettronica.Validators.Semplificata.CessionarioCommittenteValidator>
    {
        [TestMethod]
        [System.Obsolete]
        public void IdentificativiFiscaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.IdentificativiFiscali, typeof(FatturaElettronica.Validators.Semplificata.IdentificativiFiscaliValidator));
        }
        [TestMethod]
        public void IdentificativiFiscaliIsRequiredWhenAltriDatiIdentificativiIsEmptyValidator()
        {
            challenge.AltriDatiIdentificativi = null;

            AssertRequired(x => x.IdentificativiFiscali, expectedErrorCode: "00431");
        }
        [TestMethod]
        [System.Obsolete]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.AltriDatiIdentificativi, typeof(FatturaElettronica.Validators.Semplificata.AltriDatiIdentificativiValidator));
        }
        [TestMethod]
        public void AltriDatiIdentificativiIsRequiredWhenIdentificativiFiscaliIsEmptyValidator()
        {
            challenge.IdentificativiFiscali = null;

            AssertRequired(x => x.AltriDatiIdentificativi, expectedErrorCode: "00431");
        }
    }
}
