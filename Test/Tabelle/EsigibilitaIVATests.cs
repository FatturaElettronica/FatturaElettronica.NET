using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FatturaElettronica.Test.Tabelle;

[TestClass]
public class EsigibilitaIVATests
{
    [TestMethod]
    public void Test()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("it");
        var esigibilitaIVA = new FatturaElettronica.Tabelle.EsigibilitaIVA();
        var list = esigibilitaIVA.List.OrderBy(e => e.Codice).ToList();

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(list[0].Codice, "D");
        Assert.AreEqual(list[1].Codice, "I");
        Assert.AreEqual(list[2].Codice, "S");

        Assert.AreEqual(list[0].Nome, "IVA ad esigibilità differita");
        Assert.AreEqual(list[1].Nome, "IVA ad esigibilità immediata");
        Assert.AreEqual(list[2].Nome, "scissione dei pagamenti");

        Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");
        esigibilitaIVA = new FatturaElettronica.Tabelle.EsigibilitaIVA();
        list = esigibilitaIVA.List.OrderBy(e => e.Codice).ToList();

        Assert.AreEqual(list[0].Nome, "MwSt. mit aufgeschobener Steuerschuld");
        Assert.AreEqual(list[1].Nome, "MwSt. sofort zahlbar");
        Assert.AreEqual(list[2].Nome, "Zahlungsaufteilung");
    }
}
