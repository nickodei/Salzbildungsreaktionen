using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.MetalloxidSaeure
{
public class MetalloxidSaeureReaktion : Reaktion
{
public Oxid ReagierendesMetalloxid { get; set; }
public Saeure ReagierendeSaeure { get; set; }
public List<MetalloxidSaeureReaktionsResultat> ReaktionsResultate { get; set; }

public MetalloxidSaeureReaktion(Oxid metalloxid, Saeure saeure)
{
    ReagierendesMetalloxid = metalloxid;
    ReagierendeSaeure = saeure;
    ReaktionsResultate = new List<MetalloxidSaeureReaktionsResultat>();
}

public override void BeginneReaktion()
{
    // Erhalte die ionisierten Saeurevarianten der Saeure. Die Anzahl der Protonen
    // in der Saeure gibt die Anzahl der Varianten an, da jeweils Protonen im
    // Saeurerest sich anlagern koennen
    List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();

    // Generiere für jede Saerevariante eine Reaktionsgleichung
    foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
    {
        // Erhalte das Metallelement aus dem Oxid und ionisiere es
        Metall metall = ReagierendesMetalloxid.Bindungspartner.Atombindung.ErhalteElement() as Metall;
        Kation metallIon = new Kation(new Molekuel(new Atombindung(metall, 1), 1));

        // Bilde das Salz aus dem Metallion und dem ionisierten Saeurerest
        Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

        // Erstelle die Wasserstoffbindung
        Atombindung wasser = new Atombindung("H₂O", "Wasser");

        // Erstelle die Reaktionsstoffe mit den vorhandenen Bindungen
        // Diese Klasse merkt sich zu den Bindungen auch die Anzahl 
        // der Molekuele nach dem ausgleichen
        Reaktionsstoff metalloxidKomponente = new Reaktionsstoff(ReagierendesMetalloxid);
        Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);
        Reaktionsstoff wasserKomponente = new Reaktionsstoff(wasser);
        Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);

        //Falls die Anzahl der Metallatome im Oxid gleich dem im Salz sind
        if(ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel() == salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
        {
            // Die Anzahl der Metall-Atome im Oxid, sowie im Salz sind identisch,
            // => Anzahl des Metalloxids und des Salzes auf 1 setzen
            metalloxidKomponente.Anzahl = 1;
            salzKomponente.Anzahl = 1;
        }
        //Falls die Anzahl der Metallatome im Oxid groeßer dem im Salz sind
        else if (ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel() > salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
        {
            // Die Anzahl der Metall-Atome im Oxid sind groeßer als die im Salz
            // => Anzahl des Metalloxids auf 1 setzen und die Anzahl des Salzes berechnen
            metalloxidKomponente.Anzahl = 1;
            salzKomponente.Anzahl = ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel() / salz.Kation.Molekuel.AnzahlAtomeInMolekuel();
        }
        //Falls die Anzahl der Metallatome im Oxid kleiner dem im Salz sind
        else
        {
            // Die Anzahl der Metallatome im Oxid sind geringer als die im Salz
            // => Anzahl des Metalloxids berechnen und die Anzahl des Salzes auf 1 setzen
            metalloxidKomponente.Anzahl = salz.Kation.Molekuel.AnzahlAtomeInMolekuel() / ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel();
            salzKomponente.Anzahl = 1;
        }

        // Die Anzahl der Saeure entspricht die Anzahl des Saeurerestions
        // => Saeure um die Anzahl des Saeurerestions multiplizieren
        saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl;

        // Erhalte die Anzahl der Wasserstoffatome in der Saeure
        double wasserstoffAtomeInSaeure = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoff.AnzahlAtomeInMolekuel();
        // Erhalte die Anzahl der Wasserstoffatome im Salz
        double wasserstoffAtomeInSalz   = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl * ((saeureKomponente.Molekuel as Saeure).Wasserstoff.AnzahlAtomeInMolekuel() - saeureVariation.wasserstoffIon.Molekuel.AnzahlAtomeInMolekuel());
        // Subtrahiere die Wasserstoffatome in der Saeure mit dem des Salzes und
        // teile es durch zwei, da H20 gleich zwei Wasserstoffatome pro Molekuel besitzt
        wasserKomponente.Anzahl = (wasserstoffAtomeInSaeure - wasserstoffAtomeInSalz) / 2;

        // Fuege der Liste der Reaktionen diese Reaktion hinzu
        ReaktionsResultate.Add(new MetalloxidSaeureReaktionsResultat(metalloxidKomponente, saeureKomponente, salzKomponente, wasserKomponente));
    }
}
}
}
