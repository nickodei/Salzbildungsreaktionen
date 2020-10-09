using NUnit.Framework;
using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using Salzbildungsreaktionen_Core.Models.Verbindungen;

namespace Salzbildungsreaktionen_Test
{
    public class MetalloxidReagiertMitSäure
    {
        [Test]
        public void NatriumReagiertMitSalzsäure()
        {
            Säure salzsäure = Säure.Create(formel: Säure.Salzsäure);
            Metall natrium = Metall.Create(symbol: Metall.Natrium);
            Metalloxid natriumoxid = Metalloxid.Create(natrium);

            var result = Reaktionshelfer.SäureReagiertMirMetalloxid(salzsäure, natriumoxid);

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, result.Count);

            // Die einzelnen Bestandteile überprüfen
            // 1. Metalloxid
            Assert.AreEqual("Na₂O", result[0].m_Metalloxid.Formel);
            Assert.AreEqual(1, result[0].m_Metalloxid.Anzahl);
            Assert.AreEqual(2, result[0].m_Metalloxid.m_Metall.Anzahl);
            Assert.AreEqual(1, result[0].m_Metalloxid.m_Sauerstoff.Anzahl);

            // 2. Säure
            Assert.AreEqual("HCl", result[0].m_Säure.Formel);
            Assert.AreEqual(2, result[0].m_Säure.Anzahl);
            Assert.AreEqual(1, result[0].m_Säure.AnzahlWasserstoff);
            Assert.AreEqual(1, result[0].m_Säure.Säurerestion.Anzahl);

            // 3.Salz
            Assert.AreEqual("NaCl", result[0].m_Salz.Formel);
            Assert.AreEqual(2, result[0].m_Salz.Anzahl);
            Assert.AreEqual(1, result[0].m_Salz.m_Metall.Anzahl);
            Assert.AreEqual(1, result[0].m_Salz.m_Säurerestion.Anzahl);

            // 4.Wasser
            Assert.AreEqual(1, result[0].m_Wasser.Anzahl);

            // Mit Sauerstoff kontrolieren
            double anzahlSauerstoffMetalloxid = result[0].m_Metalloxid.m_Sauerstoff.Anzahl * result[0].m_Metalloxid.Anzahl;
            double anzahlSauerstoffWasser = result[0].m_Wasser.m_Sauerstoff.Anzahl * result[0].m_Wasser.Anzahl;
            Assert.AreEqual(anzahlSauerstoffMetalloxid, anzahlSauerstoffWasser);
        }
    }
}
