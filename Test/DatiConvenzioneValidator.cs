using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiConvenzioneValidator
        : BaseDatiDocumentoValidator<DatiConvenzione, FatturaElettronica.Validators.DatiConvenzioneValidator>
    {
    }
}
