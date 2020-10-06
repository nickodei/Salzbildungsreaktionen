using NUnit.Framework;
using Salzbildungsreaktionen_Core.Models.Elemente;
using Salzbildungsreaktionen_Core.Models.Verbindungen;

namespace Salzbildungsreaktionen_Test
{
    public class MetallReagiertMitSäure
    {
        [Test]
        public void NatriumReagiertMitSalzsäure()
        {
            Säure salzsäure = Säure.Create(formel: Säure.Salzsäure);
            Metall natrium = Metall.Create(symbol: Metall.Natrium, anzahl: 1);

            (Salz salz, Element element) = salzsäure.ReagiertMit(natrium);

            // Überprüfe das Ergebnis
            Assert.AreEqual(1, natrium.Anzahl);
            Assert.AreEqual(1, salzsäure.Anzahl);
        }
    }
}