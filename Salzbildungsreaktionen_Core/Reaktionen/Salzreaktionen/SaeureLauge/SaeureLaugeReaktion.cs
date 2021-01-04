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
    // Erhalte die ionisierten Saeurevarianten der Saeure. Die Anzahl der Protonen
    // in der Saeure gibt die Anzahl der Varianten an, da jeweils Protonen im
    // Saeurerest sich anlagern koennen
    List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();

    // Generiere fuer jede Saerevariante eine Reaktionsgleichung
    foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
    {
        // Definiere die benoetigten Komponenenten, damit ihrer Anzahl gesezt werden kann
        Reaktionsstoff laugeKomponente = new Reaktionsstoff(ReagierendeLauge);
        Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);

        Salz salz = null;
        // Überprüfe, ob es sich bei der Lauge um Ammoniak handelt
        if (ReagierendeLauge is Ammoniak)
        {
            // Es handelt sich bei der Lauge um Ammoniak
            Ammoniak ammoniak = ReagierendeLauge as Ammoniak;

            // Erstelle das Ammonium-Ion
            Kation ammonium = new Kation(new Molekuel(new Atombindung("NH₄", "Ammonium"), 1), 1);

            // Erstelle das Salz aus dem Ammonium-Ion und dem Saeurerest-Ion
            salz = new Salz(ammonium, saeureVariation.saeurerestIon);

            // Setze die Anzahl der Lauge gleich der Anzahl der Ammonium-Moeluele
            laugeKomponente.Anzahl = salz.Kation.Molekuel.Anzahl;

            // Erstelle die restlichen Reaktionsstoffe
            Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);
                    
            // Setze die Anzahl der restlichen Komponenten gleich eins
            saeureKomponente.Anzahl = 1;
            salzKomponente.Anzahl = 1;
                    
            // Fuege der Liste der Reaktionen diese Reaktion hinzu
            ReaktionsResultate.Add(new SaeureLaugeReaktionsResultat(saeureKomponente, laugeKomponente, salzKomponente, null));
        }
        else
        {
            // Es handelt sich bei der Lauge um ein Metallhydroxid
            Metall metall = ReagierendeLauge.Metall.Atombindung.ErhalteElement() as Metall;

            // Erstelle das Metall-Ion
            Kation metallIon = new Kation(new Molekuel(new Atombindung(metall, 1), 1));

            // Erstelle das Salz aus dem Metall-Ion und dem Saeurerest-Ion
            salz = new Salz(metallIon, saeureVariation.saeurerestIon);

            // Erstelle die Wasserstoffbindung
            Atombindung wasser = new Atombindung("H₂O", "Wasser");

            // Erstelle die restlichen Reaktionsstoffe
            Reaktionsstoff wasserKomponente = new Reaktionsstoff(wasser);
            Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);

            //Falls die Anzahl der Metallatome in der Lauge gleich dem im Salz sind
            if (ReagierendeLauge.Metall.AnzahlAtomeInMolekuel() == salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
            {
                // Die Anzahl der Metallatome in der Lauge, sowie im Salz sind identisch
                // => Anzahl Lauge und Salz auf 1 setzen
                laugeKomponente.Anzahl = 1;
                salzKomponente.Anzahl = 1;
            }
            //Falls die Anzahl der Metallatome in der Lauge groeßer dem im Salz sind
            else if (ReagierendeLauge.Metall.AnzahlAtomeInMolekuel() > salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
            {
                // Die Anzahl der Metallatome in der Lauge sind groeßer als die im Salz
                // => Anzahl Lauge auf 1 setzen und die Anzahl des Salzes berechnen
                laugeKomponente.Anzahl = 1;
                salzKomponente.Anzahl = ReagierendeLauge.Metall.AnzahlAtomeInMolekuel() / salz.Kation.Molekuel.AnzahlAtomeInMolekuel();
            }
            //Falls die Anzahl der Metallatome in der Lauge kleiner dem im Salz sind
            else
            {
                // Die Anzahl der Metallatome in der Lauge sind geringer als die im Salz
                // => Anzahl Lauge berechnen und die Anzahl des Salzes auf 1 setzen
                laugeKomponente.Anzahl = salz.Kation.Molekuel.AnzahlAtomeInMolekuel() / ReagierendeLauge.Metall.AnzahlAtomeInMolekuel();
                salzKomponente.Anzahl = 1;
            }

            // Die Anzahl der Saeure entspricht die Anzahl des Saeurerestions
            // => Saeure um die Anzahl des Saeurerestions multiplizieren
            saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl;

            // Erhalte die Anzahl der Wasserstoffatome in der Saeure
            double wasserstoffAtomeInSaeure = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoff.AnzahlAtomeInMolekuel();
            // Erhalte die Anzahl der Wasserstoffatome im Salz
            double wasserstoffAtomeInSalz = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl * ((saeureKomponente.Molekuel as Saeure).Wasserstoff.AnzahlAtomeInMolekuel() - saeureVariation.wasserstoffIon.Molekuel.AnzahlAtomeInMolekuel());
            // Erhalte die Anzahl der Wasserstoffatome in der Lauge
            double wasserstoffAtomeInLauge = laugeKomponente.Anzahl * ReagierendeLauge.Hydroxid.Anzahl;
            // Subtrahiere die Wasserstoffatome im Salz von der Saeure + Lauge und
            // teile es durch zwei, da H20 gleich zwei Wasserstoffatome pro Molekuel besitzt
            wasserKomponente.Anzahl = (wasserstoffAtomeInSaeure + wasserstoffAtomeInLauge - wasserstoffAtomeInSalz) / 2;

            // Fuege der Liste der Reaktionen diese Reaktion hinzu
            ReaktionsResultate.Add(new SaeureLaugeReaktionsResultat(saeureKomponente, laugeKomponente, salzKomponente, wasserKomponente));
        }
    }
}
}
}
