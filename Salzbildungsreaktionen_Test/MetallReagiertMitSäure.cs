using NUnit.Framework;
using Salzbildungsreaktionen_Core.Models.Elemente;
using Salzbildungsreaktionen_Core.Models.Verbindungen;

namespace Salzbildungsreaktionen_Test
{
    public class MetallReagiertMitS�ure
    {
        [Test]
        public void NatriumReagiertMitSalzs�ure()
        {
            S�ure salzs�ure = S�ure.Create(formel: S�ure.Salzs�ure);
            Metall natrium = Metall.Create(symbol: Metall.Natrium, anzahl: 1);

            (Salz salz, Element element) = salzs�ure.ReagiertMit(natrium);

            // �berpr�fe das Ergebnis
            Assert.AreEqual(1, natrium.Anzahl);
            Assert.AreEqual(1, salzs�ure.Anzahl);
        }
    }
}