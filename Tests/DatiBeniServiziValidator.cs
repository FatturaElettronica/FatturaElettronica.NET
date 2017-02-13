using FluentValidation.TestHelper;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi;

namespace Tests
{
    [TestClass]
    public class DatiBeniServiziValidator: BaseClass<DatiBeniServizi, FatturaElettronica.Validators.DatiBeniServiziValidator>
    {
        [TestMethod]
        public void DettaglioLineeHasCollectionValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DettaglioLinee, typeof(FatturaElettronica.Validators.DettaglioLineeValidator));
        }
    }
}
