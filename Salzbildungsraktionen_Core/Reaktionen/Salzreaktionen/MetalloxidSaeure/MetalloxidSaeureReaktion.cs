using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.MetalloxidSaeure
{
    public class MetalloxidSaeureReaktion : Reaktion
    {
        public Metalloxid ReagierendesMetalloxid { get; set; }
        public Saeure ReagierendeSaeure { get; set; }
        public List<MetalloxidSaeureReaktionsResultat> ReaktionsResultate { get; set; }

        public MetalloxidSaeureReaktion(Metalloxid metalloxid, Saeure saeure)
        {
            ReagierendesMetalloxid = metalloxid;
            ReagierendeSaeure = saeure;
            ReaktionsResultate = new List<MetalloxidSaeureReaktionsResultat>();
        }

        public override void BeginneReaktion()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();
            foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
            {
                // Ionisiere das Metall
                Kation metallIon = new Kation(new ElementMolekuel(1, ReagierendesMetalloxid.Metall.Atom));

                // Generie das Salz aus den Ionen
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff metalloxidKomponente = new Reaktionsstoff(new VerbindungsMolekuel(ReagierendesMetalloxid.Formel));
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(new VerbindungsMolekuel(ReagierendeSaeure.Formel));
                Reaktionsstoff salzKomponente = new Reaktionsstoff(new VerbindungsMolekuel(salz.Formel));


                // Wenn das Metalloxid mehr Metall Atome besitze als das Salz
                if (ReagierendesMetalloxid.AnzahlMetall > salz.AnzahlKationen)
                {
                    // Somit wissen wir, das es nur ein Metalloxdi Molekühl gibt
                    metalloxidKomponente.Anzahl = 1;

                    // Die Anzahl des Salzes muss so angepasst werden
                    // sodass die Metallatom Anzahl übereinstimmt
                    salzKomponente.Anzahl = ReagierendesMetalloxid.AnzahlMetall;
                }
                // Ansonsten
                else
                {
                    // Somit wissen wir, das es nur ein Salz Molekühl gibt
                    salzKomponente.Anzahl = 1;

                    // Die Anzahl des Metalloxides muss so angepasst werden
                    // sodass die Metallatom Anzahl übereinstimmt
                    metalloxidKomponente.Anzahl = (salzKomponente.Anzahl * salz.AnzahlKationen) / ReagierendesMetalloxid.AnzahlMetall;
                }

                // Die Anzahl der Säure entspricht die Anzahl des Säurerestions
                // mulipliziert mit der Anzahl des Salzes
                saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.AnzahlAnionen;


                VerbindungsMolekuel wasser = new VerbindungsMolekuel("H₂O");
                Reaktionsstoff wasserKomponente = new Reaktionsstoff(wasser);
                // Berechne die Anzahl des Wasserstoffes um die Anzahl der 
                // Wasser Molekühle zu bekommen
                double maximaleWasserstoffAtome = saeureKomponente.Anzahl * ReagierendeSaeure.WasserstoffMolekuel.Anzahl;
                double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salz.AnzahlAnionen * (ReagierendeSaeure.WasserstoffMolekuel.Anzahl - saeureVariation.wasserstoffIon.Molekuel.Anzahl));

                wasserKomponente.Anzahl = restlicheWasserstoffAtome / 2;

                // Überprüfe mit den vorhanden Sauerstoffatomem, ob die Gleichung
                // korrekt augeglichen wurde

                // TODO: implementieren

                ReaktionsResultate.Add(new MetalloxidSaeureReaktionsResultat(metalloxidKomponente, saeureKomponente, salzKomponente, wasserKomponente));
            }
        }
    }
}
