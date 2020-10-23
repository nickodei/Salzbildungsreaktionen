using NUnit.Framework;

namespace Salzbildungsreaktionen_Test
{
    public class MetalloxidReagiertMitSäure
    {
        [Test]
        public void NatriumReagiertMitSalzsäure()
        {
            //// Beinhaltet alle Reaktionsresultate, die mit den verschiedenen Säurevariationen gemacht werden können
            //List<MetalloxidSäureReaktionsresultat> reaktionsResultate = new List<MetalloxidSäureReaktionsresultat>();

            //List<Säure> salzsäureVarianten = Säure.ErstelleSäure(chemischeFormel: Säure.Salzsäure);
            //for(int cnt = 0; cnt < salzsäureVarianten.Count; cnt++)
            //{
            //    Säure salzsäure = salzsäureVarianten[cnt];
            //    Metall natrium = Metall.Create(symbol: Metall.Natrium);
            //    Metalloxid natriumoxid = Metalloxid.Create(natrium);

            //    MetalloxidSäureReaktionsresultat reaktionsResultat = Reaktionshelfer.SäureReagiertMirMetalloxid(salzsäure, natriumoxid);
            //    reaktionsResultate.Add(reaktionsResultat);
            //}

            //// Anzahl der erwarteten Reaktionsgleichungen
            //Assert.AreEqual(1, reaktionsResultate.Count);

            //// Die einzelnen Bestandteile überprüfen
            //// 1. Metalloxid
            //Assert.AreEqual("Na₂O", reaktionsResultate[0].m_Metalloxid.ChemischeFormel);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Metalloxid.Anzahl);
            //Assert.AreEqual(2, reaktionsResultate[0].m_Metalloxid.m_Metall.Anzahl);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Metalloxid.m_Sauerstoff.Anzahl);

            //// 2. Säure
            //Assert.AreEqual("HCl", reaktionsResultate[0].m_Säure.ChemischeFormel);
            //Assert.AreEqual(2, reaktionsResultate[0].m_Säure.Anzahl);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Säure.AnzahlWasserstoff);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Säure.Säurerestion.Anzahl);

            //// 3.Salz
            //Assert.AreEqual("NaCl", reaktionsResultate[0].m_Salz.ChemischeFormel);
            //Assert.AreEqual(2, reaktionsResultate[0].m_Salz.Anzahl);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Metall.Anzahl);
            //Assert.AreEqual(1, reaktionsResultate[0].m_Salz.m_Säurerestion.Anzahl);

            //// 4.Wasser
            //Assert.AreEqual(1, reaktionsResultate[0].m_Wasser.Anzahl);

            //// Mit Sauerstoff kontrolieren
            //double anzahlSauerstoffMetalloxid = reaktionsResultate[0].m_Metalloxid.m_Sauerstoff.Anzahl * reaktionsResultate[0].m_Metalloxid.Anzahl;
            //double anzahlSauerstoffWasser = reaktionsResultate[0].m_Wasser.m_Sauerstoff.Anzahl * reaktionsResultate[0].m_Wasser.Anzahl;
            //Assert.AreEqual(anzahlSauerstoffMetalloxid, anzahlSauerstoffWasser);
        }
    }
}
