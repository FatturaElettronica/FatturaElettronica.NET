using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiGenerali;

namespace FatturaElettronica.Test.Ordinaria
{
    [TestClass]
    public class DatiDocumentoValidator
        : BaseDatiDocumentoValidator<DatiOrdineAcquisto, Validators.DatiOrdineAcquistoValidator>
    {
    }
}