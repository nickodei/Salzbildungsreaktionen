using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.SaeureLauge
{
    public class SaeureLaugeReaktion : Reaktion
    {      
        public Saeure ReagierendeSaeure { get; set; }
        public Lauge ReagierendeLauge { get; set; }
        public List<SaeureLaugeReaktionsResultat> ReaktionsResultate { get; set; }

        public SaeureLaugeReaktion(Saeure saeure, Lauge lauge)
        {
            ReagierendeSaeure = saeure;
            ReagierendeLauge = lauge;
            ReaktionsResultate = new List<SaeureLaugeReaktionsResultat>();
        }

        public override void BeginneReaktion()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();
            foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
            {
                // Ionisiere das Metall aus der Lauge
                Kation metallIon = new Kation(ReagierendeLauge.Metall);

                // Generie das Salz aus den Ionen
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);
                Reaktionsstoff laugeKomponente = new Reaktionsstoff(ReagierendeLauge);
                Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);


                // Wenn das Metalloxid mehr Metall Atome besitze als das Salz
                if (ReagierendeLauge.Metall.Anzahl > salz.AnzahlKationen)
                {
                    // Somit wissen wir, das es nur ein Metalloxdi Molekühl gibt
                    laugeKomponente.Anzahl = 1;

                    // Die Anzahl des Salzes muss so angepasst werden
                    // sodass die Metallatom Anzahl übereinstimmt
                    salzKomponente.Anzahl = ReagierendeLauge.Metall.Anzahl;
                }
                // Ansonsten
                else
                {
                    // Somit wissen wir, das es nur ein Salz Molekühl gibt
                    salzKomponente.Anzahl = 1;

                    // Die Anzahl des Metalloxides muss so angepasst werden
                    // sodass die Metallatom Anzahl übereinstimmt
                    laugeKomponente.Anzahl = (salzKomponente.Anzahl * salz.AnzahlKationen) / ReagierendeLauge.Metall.Anzahl;
                }

                // Die Anzahl der Säure entspricht die Anzahl des Säurerestions
                // mulipliziert mit der Anzahl des Salzes
                saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.AnzahlAnionen;

                Molekularverbindung wasser = new Molekularverbindung("H₂O", "Wasser");
                Reaktionsstoff wasserKomponente = new Reaktionsstoff(wasser);
                // Berechne die Anzahl des Wasserstoffes um die Anzahl der 
                // Wasser Molekühle zu bekommen
                double anzahlWasserstoffLauge = laugeKomponente.Anzahl * ReagierendeLauge.Hydroxid.Anzahl;
                double anzahlWasserstoffSaeure = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoffverbindung.AnzahlBindungspartner;

                double restlicheWasserstoffAtome = (anzahlWasserstoffSaeure + anzahlWasserstoffLauge) - (salzKomponente.Anzahl * salz.AnzahlAnionen * (ReagierendeSaeure.Wasserstoffverbindung.AnzahlBindungspartner - saeureVariation.wasserstoffIon.Molekuel.Anzahl));

                wasserKomponente.Anzahl = restlicheWasserstoffAtome / 2;

                // Überprüfe mit den vorhanden Sauerstoffatomem, ob die Gleichung
                // korrekt augeglichen wurde

                // TODO: implementieren

                ReaktionsResultate.Add(new SaeureLaugeReaktionsResultat(saeureKomponente, laugeKomponente, salzKomponente, wasserKomponente));
            }
        }
    }
}
