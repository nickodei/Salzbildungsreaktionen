using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
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
                // Erhalte das Metallelement aus der Lauge und ionisiere es
                Metall metall = ReagierendeLauge.Metall.Atombindung.ErhalteElement() as Metall;
                Kation metallIon = new Kation(new Molekuel(new Atombindung(metall, 1), 1));
                
                // Bilde das Salz aus dem Metallion und der Säure
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);
                Reaktionsstoff wasserKomponente = new Reaktionsstoff(new Atombindung("H₂O", "Wasser"));
                Reaktionsstoff laugeKomponente = new Reaktionsstoff(ReagierendeLauge);
                Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);

                if (ReagierendeLauge.Metall.AnzahlAtomeInMolekuel() == salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
                {
                    // Die Anzahl der Metall-Atome im Oxid, sowie im Salz sind identisch
                    // => Anzahl Metalloxid und Salz auf 1 setzen
                    laugeKomponente.Anzahl = 1;
                    salzKomponente.Anzahl = 1;
                }
                else if (ReagierendeLauge.Metall.AnzahlAtomeInMolekuel() > salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
                {
                    // Die Anzahl der Metall-Atome im Oxid sind größer als die im Salz
                    // => Anzahl Metalloxid auf 1 setzen und die Anzahl des Salzes berechnen
                    laugeKomponente.Anzahl = 1;
                    salzKomponente.Anzahl = ReagierendeLauge.Metall.AnzahlAtomeInMolekuel() / salz.Kation.Molekuel.AnzahlAtomeInMolekuel();
                }
                else
                {
                    // Die Anzahl der Metall-Atome im Oxid sind geringer als die im Salz
                    // => Anzahl Metalloxid berechnen und die Anzahl des Salzes auf 1 setzen
                    laugeKomponente.Anzahl = salz.Kation.Molekuel.AnzahlAtomeInMolekuel() / ReagierendeLauge.Metall.AnzahlAtomeInMolekuel();
                    salzKomponente.Anzahl = 1;
                }

                // Die Anzahl der Säure entspricht die Anzahl des Säurerestions
                // => Säure um die Anzahl des Säurerest-Ions multiplizieren
                saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl;

                // Berechne die Anzahl der übrigen Wasserstoffatome, um die Anzahl der Wasser Molekühle erhalten
                double wasserstoffAtomeInSaeure = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoff.AnzahlAtomeInMolekuel();
                double wasserstoffAtomeInSalz = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl * ((saeureKomponente.Molekuel as Saeure).Wasserstoff.AnzahlAtomeInMolekuel() - saeureVariation.wasserstoffIon.Molekuel.AnzahlAtomeInMolekuel());
                double wasserstoffAtomeInLauge = laugeKomponente.Anzahl * ReagierendeLauge.Hydroxid.Anzahl;
                wasserKomponente.Anzahl = (wasserstoffAtomeInSaeure + wasserstoffAtomeInLauge - wasserstoffAtomeInSalz) / 2;

                ReaktionsResultate.Add(new SaeureLaugeReaktionsResultat(saeureKomponente, laugeKomponente, salzKomponente, wasserKomponente));
            }
        }
    }
}
