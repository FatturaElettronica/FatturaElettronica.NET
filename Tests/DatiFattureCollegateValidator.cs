using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiFattureCollegateValidator
        : BaseDatiDocumentoValidator<DatiFattureCollegate, FatturaElettronica.Validators.DatiFattureCollegateValidator>
    {
    }
}
