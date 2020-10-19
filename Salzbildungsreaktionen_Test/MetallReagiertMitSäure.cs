using NUnit.Framework;
using Salzbildungsreaktionen_Core.Reaktionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Test
{
    public class MetallReagiertMitSäure
    {
        [Test]
        public void NatriumReagiertMitSalzsäure()
        {
            List<MetallSäureReaktion> metallSäureReaktionen = new List<MetallSäureReaktion>();
            List<Saeure> säureVarianten = Saeure.ErhalteAlleSäurevarianten(Saeure.Salzsäure);

            foreach(Saeure säure in säureVarianten)
            {
                Metall metall = Metall.ErhalteMetall(Metall.Natrium);

                MetallSäureReaktion reaktion = new MetallSäureReaktion(metall, säure);
                reaktion.BeginneReaktion();

                metallSäureReaktionen.Add(reaktion);
            }

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, metallSäureReaktionen.Count);

            // 1.0 Überprüfung der 1. Gleichung
            // 1.1 Salzkomponente
            Assert.AreEqual("NaCl", metallSäureReaktionen[0].SalzKomponente.Stoff.Formel);
            Assert.AreEqual(1, metallSäureReaktionen[0].SalzKomponente.Anzahl);
            Assert.AreEqual(1, metallSäureReaktionen[0].SalzKomponente.Stoff.MetallIonMolekühle);
            Assert.AreEqual(1, metallSäureReaktionen[0].SalzKomponente.Stoff.SäurerestIonMolekühle);

            // 1.2 Wasserstoffkomponente
            Assert.AreEqual("H₂", metallSäureReaktionen[0].WasserstoffKomponente.Stoff.Formel);
            Assert.AreEqual(0.5, metallSäureReaktionen[0].WasserstoffKomponente.Anzahl);
        }

        [Test]
        public void NatriumReagiertMitSchwefelsäure()
        {
            //// Beinhaltet alle Reaktionsresultate, die mit den verschiedenen Säurevariationen gemacht werden können
            //List<MetallSäureReaktionsresultat> reaktionsResultate = new List<MetallSäureReaktionsresultat>();

            //List<Säure> schwefelsäureVarianten = Säure.ErstelleSäure(chemischeFormel: Säure.Schwefelsäure);
            //for (int cnt = 0; cnt < schwefelsäureVarianten.Count; cnt++)
            //{
            //    Säure salzsäure = schwefelsäureVarianten[cnt];
            //    Metall natrium = Metall.Create(symbol: Metall.Natrium);

            //    MetallSäureReaktionsresultat reaktionsResultat = Reaktionshelfer.SäureReagiertMirMetall(salzsäure, natrium);
            //    reaktionsResultate.Add(reaktionsResultat);
            //}

            //// Anzahl der Reaktionsgleichungen
            //Assert.AreEqual(1, reaktionsResultate.Count);
            //// Formel des Salzes
            //Assert.AreEqual("Na₂SO₄", reaktionsResultate[0].m_Salz.ChemischeFormel);
            //// Anzahl der Bestandteile
            //// 1.Salz
            //Assert.AreEqual(1, reaktionsResultate[0].m_Salz.Anzahl);
            //Assert.AreEqual(2, reaktionsResultate[0].m_Salz.m_Metall.Anzahl);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Säurerestion.Anzahl);
            //// 2.Wasserstoff
            //Assert.AreEqual("H₂", reaktionsResultate[0].m_Wasserstoff.ChemischeFormel);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Wasserstoff.Anzahl);
        }

        [Test]
        public void MagnesiumReagiertMitSalzsäure()
        {
            List<MetallSäureReaktion> metallSäureReaktionen = new List<MetallSäureReaktion>();
            List<Saeure> säureVarianten = Saeure.ErhalteAlleSäurevarianten(Saeure.Salzsäure);

            foreach (Saeure säure in säureVarianten)
            {
                Metall metall = Metall.ErhalteMetall(Metall.Magnesium);

                MetallSäureReaktion reaktion = new MetallSäureReaktion(metall, säure);
                reaktion.BeginneReaktion();

                metallSäureReaktionen.Add(reaktion);
            }

            // Anzahl der Reaktionsgleichungen
            Assert.AreEqual(1, metallSäureReaktionen.Count);

            // 1.0 Überprüfung der 1. Gleichung
            // 1.1 Salzkomponente
            Assert.AreEqual("MgCl₂", metallSäureReaktionen[0].SalzKomponente.Stoff.Formel);
            Assert.AreEqual(1, metallSäureReaktionen[0].SalzKomponente.Anzahl);
            Assert.AreEqual(1, metallSäureReaktionen[0].SalzKomponente.Stoff.MetallIonMolekühle);
            Assert.AreEqual(2, metallSäureReaktionen[0].SalzKomponente.Stoff.SäurerestIonMolekühle);

            // 1.2 Wasserstoffkomponente
            Assert.AreEqual("H₂", metallSäureReaktionen[0].WasserstoffKomponente.Stoff.Formel);
            Assert.AreEqual(1, metallSäureReaktionen[0].WasserstoffKomponente.Anzahl);
        }
    }
}