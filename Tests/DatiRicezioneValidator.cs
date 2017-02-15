using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatturaElettronica.FatturaElettronicaBody.DatiGenerali;

namespace Tests
{
    [TestClass]
    public class DatiRicezioneValidator
        : BaseDatiDocumentoValidator<DatiRicezione, FatturaElettronica.Validators.DatiRicezioneValidator>
    {
    }
}
