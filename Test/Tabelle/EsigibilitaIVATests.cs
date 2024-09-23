using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Tabelle;


[TestClass]
public class EsigibilitaIVATests
{
    [TestMethod]
    public void Test()
    {
        var esigibilitaIVA = new FatturaElettronica.Tabelle.EsigibilitaIVA();
        var list = esigibilitaIVA.List.OrderBy(e => e.Codice).ToList();
        Assert.AreEqual(3, list.Count);
        Assert.AreEqual("D", list[0].Codice);
        Assert.AreEqual("I", list[1].Codice);
        Assert.AreEqual("S", list[2].Codice);
    }
}
