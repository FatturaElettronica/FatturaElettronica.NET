using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiFattureCollegateValidator
        : BaseDatiDocumentoValidator<DatiFattureCollegate, FatturaElettronica.Validators.DatiFattureCollegateValidator>
    {
    }
}
