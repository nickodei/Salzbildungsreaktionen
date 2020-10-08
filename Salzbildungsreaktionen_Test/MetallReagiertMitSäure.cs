using NUnit.Framework;
using Salzbildungsreaktionen_Core.Helper;
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
            Metall natrium = Metall.Create(symbol: Metall.Natrium);

            var result = Reaktionshelfer.S�ureReagiertMirMetall(salzs�ure, natrium);

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, result.Count);
            // Formel des Salzes
            Assert.AreEqual("NaCl", result[0].m_Salz.Formel);
            // Anzahl der Bestandteile
            // 1.Salz
            Assert.AreEqual(1, result[0].m_Salz.Anzahl);
            Assert.AreEqual(1, result[0].m_Salz.m_Metall.Anzahl);
            Assert.AreEqual(1, result[0].m_Salz.m_S�urerestion.Anzahl);
            // 2.Wasserstoff
            Assert.AreEqual("H2", result[0].m_Wasserstoff.Formel);
            Assert.AreEqual(0.5, result[0].m_Wasserstoff.Anzahl);
        }

        [Test]
        public void MagnesiumReagiertMitSalzs�ure()
        {
            S�ure salzs�ure = S�ure.Create(formel: S�ure.Salzs�ure);
            Metall magnesium = Metall.Create(symbol: Metall.Magnesium);

            var result = Reaktionshelfer.S�ureReagiertMirMetall(salzs�ure, magnesium);

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, result.Count);
            // Formel des Salzes
            Assert.AreEqual("MgCl2", result[0].m_Salz.Formel);
            // Anzahl der Bestandteile
            Assert.AreEqual(1, result[0].m_Salz.Anzahl);
            Assert.AreEqual(1, result[0].m_Salz.m_Metall.Anzahl);
            Assert.AreEqual(2, result[0].m_Salz.m_S�urerestion.Anzahl);
            // 2.Wasserstoff
            Assert.AreEqual("H2", result[0].m_Wasserstoff.Formel);
            Assert.AreEqual(1, result[0].m_Wasserstoff.Anzahl);
        }
    }
}