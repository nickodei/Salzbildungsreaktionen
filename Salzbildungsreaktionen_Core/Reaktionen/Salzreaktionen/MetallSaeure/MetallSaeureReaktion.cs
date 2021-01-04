using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.MetallSaeure
{
public class MetallSaeureReaktion : Reaktion
{
public Metall ReagierendesMetall { get; set; }
public Saeure ReagierendeSaeure { get; set; }
public List<MetallSaeureReaktionsResultat> ReaktionsResultate { get; set; }

public MetallSaeureReaktion(Metall metall, Saeure saeure)
{
    ReagierendesMetall = metall;
    ReagierendeSaeure = saeure;
    ReaktionsResultate = new List<MetallSaeureReaktionsResultat>();
}

/// <summary>
/// Startet die Metall-Saeure Reaktion
/// </summary>
public override void BeginneReaktion()
{
    // Erhalte die ionisierten Saeurevarianten der Saeure. Die Anzahl der Protonen
    // in der Saeure gibt die Anzahl der Varianten an, da jeweils Protonen im
    // Saeurerest sich anlagern koennen
    List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();
    
    // Generiere fuer jede Saerevariante eine Reaktionsgleichung
    foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
    {
        // Ionisiere das Metall, damit ein Salz kreiert werden kann
        Kation metallIon = new Kation(new Molekuel(new Atombindung(ReagierendesMetall, 1), 1));

        // Generie das Salz aus dem ionisierten Metall + dem ionisierten 
        // Saeurerest
        Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

        // Erstelle die Wasserstoffbindung
        Atombindung wasserstoff = new Atombindung("H₂", "Wasserstoff");

        // Erstelle die Reaktionsstoffe mit den vorhandenen Bindungen
        // Diese Klasse merkt sich zu den Bindungen auch die Anzahl 
        // der Molekuele nach dem ausgleichen
        Reaktionsstoff wasserstoffKomponente = new Reaktionsstoff(wasserstoff);
        Reaktionsstoff metallKomponente = new Reaktionsstoff(ReagierendesMetall);
        Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);
        Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);

        // Die Anzahl der Metallkomponente entspricht der Anzahl der Metallatome 
        // im Salz bei der Salzkreierung werden die Metallatome so gesetzt, dass 
        // sie mit der Ladung des Saeurerestes uebereinstimmt
        metallKomponente.Anzahl = salz.Kation.Molekuel.AnzahlAtomeInMolekuel();

        // Die Anzahl der Saeurekomponente entspricht der Anzahl des 
        // Saeurerestmolekuels im Salz bei der Salzkreierung werden 
        // die Saeurerestmoleküle so gesetzt, dass sie mit der Ladung
        // des Metalls übereinstimmt
        saeureKomponente.Anzahl = salz.Anion.Molekuel.Anzahl;

        // Die Anzahl der Salzkomponente bleibt bei dieser Reaktion immer eins
        salzKomponente.Anzahl = 1;

        // Erhalte die Anzahl der Wasserstoffatome in der Saeure
        double maximaleWasserstoffAtome = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoff.AnzahlAtomeInMolekuel();

        // Subtrahiere die Anzahl der Wasserstoffatome in der Saeure mit der 
        // Anzahl der Wasserstoffatome im Salz um die restlichen 
        // Wasserstoffatome für die Wasserstoffbindung H2 zu erhalten
        double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl * (ReagierendeSaeure.Wasserstoff.AnzahlAtomeInMolekuel() - saeureVariation.wasserstoffIon.Molekuel.AnzahlAtomeInMolekuel()));

        // Die Anzahl der Wasserstoffbindung H2 ergibt sich aus der Anzahl 
        // Wasserstoffatomeder restlichen Wasserstoffatome / 2
        wasserstoffKomponente.Anzahl = restlicheWasserstoffAtome / 2;

        // Fuege der Liste der Reaktionen diese Reaktion hinzu
        ReaktionsResultate.Add(new MetallSaeureReaktionsResultat(metallKomponente, saeureKomponente, salzKomponente, wasserstoffKomponente));                
    }
}
}
}
