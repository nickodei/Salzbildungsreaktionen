using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
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
            List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();
            foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
            {
                // Ionisiere das Metall
                Kation metallIon = new Kation(new Molekuel(ReagierendesMetalloxid.Bindungselement, 1));

                // Generie das Salz aus den Ionen
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff metalloxidKomponente = new Reaktionsstoff(new MolekulareVerbindung(ReagierendesMetalloxid.ChemischeFormel));
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(new MolekulareVerbindung(ReagierendeSaeure.ChemischeFormel));
                Reaktionsstoff salzKomponente = new Reaktionsstoff(new MolekulareVerbindung(salz.ChemischeFormel));

                // Wenn das Metalloxid mehr Metall Atome besitze als das Salz
                if (ReagierendesMetalloxid.ErhalteBindungselementMolekuel().Anzahl > salz.AnzahlKationen)
                {
                    // Somit wissen wir, das es nur ein Metalloxdi Molekühl gibt
                    metalloxidKomponente.Anzahl = 1;

                    // Die Anzahl des Salzes muss so angepasst werden
                    // sodass die Metallatom Anzahl übereinstimmt
                    salzKomponente.Anzahl = ReagierendesMetalloxid.ErhalteBindungselementMolekuel().Anzahl;
                }
                // Ansonsten
                else
                {
                    // Somit wissen wir, das es nur ein Salz Molekühl gibt
                    salzKomponente.Anzahl = 1;

                    // Die Anzahl des Metalloxides muss so angepasst werden
                    // sodass die Metallatom Anzahl übereinstimmt
                    metalloxidKomponente.Anzahl = (salzKomponente.Anzahl * salz.AnzahlKationen) / ReagierendesMetalloxid.ErhalteBindungselementMolekuel().Anzahl;
                }

                // Die Anzahl der Säure entspricht die Anzahl des Säurerestions
                // mulipliziert mit der Anzahl des Salzes
                saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.AnzahlAnionen;


                MolekulareVerbindung wasser = new MolekulareVerbindung("H₂O", "Wasser");
                Reaktionsstoff wasserKomponente = new Reaktionsstoff(wasser);
                // Berechne die Anzahl des Wasserstoffes um die Anzahl der 
                // Wasser Molekühle zu bekommen
                double maximaleWasserstoffAtome = saeureKomponente.Anzahl * ReagierendeSaeure.ErhalteWasserstoffMolekuel().Anzahl;
                double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salz.AnzahlAnionen * (ReagierendeSaeure.ErhalteWasserstoffMolekuel().Anzahl - saeureVariation.wasserstoffIon.Molekuel.Anzahl));

                wasserKomponente.Anzahl = restlicheWasserstoffAtome / 2;

                // Überprüfe mit den vorhanden Sauerstoffatomem, ob die Gleichung
                // korrekt augeglichen wurde

                // TODO: implementieren

                ReaktionsResultate.Add(new MetalloxidSaeureReaktionsResultat(metalloxidKomponente, saeureKomponente, salzKomponente, wasserKomponente));
            }
        }
    }
}
