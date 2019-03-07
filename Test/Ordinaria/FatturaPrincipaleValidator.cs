using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;
using Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ordinaria.Tests
{
   [TestClass]
    public class FatturaPrincipaleValidator : BaseClass<FatturaPrincipale, FatturaElettronica.Validators.FatturaPrincipaleValidator>
    {
        [TestMethod]
        public void NumeroFatturaPrincipaleIsRequired()
        {
            AssertRequired(x => x.NumeroFatturaPrincipale);
        }
        [TestMethod]
        public void NumeroFatturaPrinicipaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.NumeroFatturaPrincipale, 1, 20);
        }
        [TestMethod]
        public void NumeroFatturaPrincipaleMustBeBasicLatin()
        {
            AssertMustBeBasicLatin(x => x.NumeroFatturaPrincipale);
        }
        [TestMethod]
        public void DataFatturaPrincipaleIsRequired()
        {
            AssertRequired(x => x.DataFatturaPrincipale);
        }
    }
}
