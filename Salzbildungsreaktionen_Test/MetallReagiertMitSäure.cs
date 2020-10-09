using NUnit.Framework;
using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using Salzbildungsreaktionen_Core.Models.Reaktionen;
using Salzbildungsreaktionen_Core.Models.Verbindungen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Test
{
    public class MetallReagiertMitSäure
    {
        [Test]
        public void NatriumReagiertMitSalzsäure()
        {
            // Beinhaltet alle Reaktionsresultate, die mit den verschiedenen Säurevariationen gemacht werden können
            List<MetallSäureReaktionsresultat> reaktionsResultate = new List<MetallSäureReaktionsresultat>();

            List<Säure> salzsäureVarianten = Säure.ErstelleSäure(chemischeFormel: Säure.Salzsäure);
            for (int cnt = 0; cnt < salzsäureVarianten.Count; cnt++)
            {
                Säure salzsäure = salzsäureVarianten[cnt];
                Metall natrium = Metall.Create(symbol: Metall.Natrium);

                MetallSäureReaktionsresultat reaktionsResultat = Reaktionshelfer.SäureReagiertMirMetall(salzsäure, natrium);
                reaktionsResultate.Add(reaktionsResultat);
            }

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, reaktionsResultate.Count);
            // Formel des Salzes
            Assert.AreEqual("NaCl", reaktionsResultate[0].m_Salz.ChemischeFormel);
            // Anzahl der Bestandteile
            // 1.Salz
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.Anzahl);
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Metall.Anzahl);
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Säurerestion.Anzahl);
            // 2.Wasserstoff
            Assert.AreEqual("H₂", reaktionsResultate[0].m_Wasserstoff.ChemischeFormel);
            Assert.AreEqual(0.5, reaktionsResultate[0].m_Wasserstoff.Anzahl);
        }

        [Test]
        public void NatriumReagiertMitSchwefelsäure()
        {
            // Beinhaltet alle Reaktionsresultate, die mit den verschiedenen Säurevariationen gemacht werden können
            List<MetallSäureReaktionsresultat> reaktionsResultate = new List<MetallSäureReaktionsresultat>();

            List<Säure> schwefelsäureVarianten = Säure.ErstelleSäure(chemischeFormel: Säure.Schwefelsäure);
            for (int cnt = 0; cnt < schwefelsäureVarianten.Count; cnt++)
            {
                Säure salzsäure = schwefelsäureVarianten[cnt];
                Metall natrium = Metall.Create(symbol: Metall.Natrium);

                MetallSäureReaktionsresultat reaktionsResultat = Reaktionshelfer.SäureReagiertMirMetall(salzsäure, natrium);
                reaktionsResultate.Add(reaktionsResultat);
            }

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, reaktionsResultate.Count);
            // Formel des Salzes
            Assert.AreEqual("Na₂SO₄", reaktionsResultate[0].m_Salz.ChemischeFormel);
            // Anzahl der Bestandteile
            // 1.Salz
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.Anzahl);
            Assert.AreEqual(2, reaktionsResultate[0].m_Salz.m_Metall.Anzahl);
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Säurerestion.Anzahl);
            // 2.Wasserstoff
            Assert.AreEqual("H₂", reaktionsResultate[0].m_Wasserstoff.ChemischeFormel);
            Assert.AreEqual(1, reaktionsResultate[0].m_Wasserstoff.Anzahl);
        }

        [Test]
        public void MagnesiumReagiertMitSalzsäure()
        {
            // Beinhaltet alle Reaktionsresultate, die mit den verschiedenen Säurevariationen gemacht werden können
            List<MetallSäureReaktionsresultat> reaktionsResultate = new List<MetallSäureReaktionsresultat>();

            List<Säure> salzsäureVarianten = Säure.ErstelleSäure(chemischeFormel: Säure.Salzsäure);
            for (int cnt = 0; cnt < salzsäureVarianten.Count; cnt++)
            {
                Säure salzsäure = salzsäureVarianten[cnt];
                Metall magnesium = Metall.Create(symbol: Metall.Magnesium);

                MetallSäureReaktionsresultat reaktionsResultat = Reaktionshelfer.SäureReagiertMirMetall(salzsäure, magnesium);
                reaktionsResultate.Add(reaktionsResultat);
            }

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, reaktionsResultate.Count);
            // Formel des Salzes
            Assert.AreEqual("MgCl₂", reaktionsResultate[0].m_Salz.ChemischeFormel);
            // Anzahl der Bestandteile
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.Anzahl);
            Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Metall.Anzahl);
            Assert.AreEqual(2, reaktionsResultate[0].m_Salz.m_Säurerestion.Anzahl);
            // 2.Wasserstoff
            Assert.AreEqual("H₂", reaktionsResultate[0].m_Wasserstoff.ChemischeFormel);
            Assert.AreEqual(1, reaktionsResultate[0].m_Wasserstoff.Anzahl);
        }
    }
}