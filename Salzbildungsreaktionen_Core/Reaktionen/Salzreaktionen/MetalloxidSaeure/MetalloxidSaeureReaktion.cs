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
            List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();
            foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
            {
                // Erhalte das Metallelement aus dem Oxid und ionisiere es
                Metall metall = ReagierendesMetalloxid.Bindungspartner.Atombindung.ErhalteElement() as Metall;
                Kation metallIon = new Kation(new Molekuel(new Atombindung(metall, 1), 1));

                // Bilde das Salz aus dem Metallion und der Säure
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff metalloxidKomponente = new Reaktionsstoff(ReagierendesMetalloxid);
                Reaktionsstoff wasserKomponente = new Reaktionsstoff(new Atombindung("H₂O", "Wasser"));
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);
                Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);

                if(ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel() == salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
                {
                    // Die Anzahl der Metall-Atome im Oxid, sowie im Salz sind identisch
                    // => Anzahl Metalloxid und Salz auf 1 setzen
                    metalloxidKomponente.Anzahl = 1;
                    salzKomponente.Anzahl = 1;
                }
                else if (ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel() > salz.Kation.Molekuel.AnzahlAtomeInMolekuel())
                {
                    // Die Anzahl der Metall-Atome im Oxid sind größer als die im Salz
                    // => Anzahl Metalloxid auf 1 setzen und die Anzahl des Salzes berechnen
                    metalloxidKomponente.Anzahl = 1;
                    salzKomponente.Anzahl = ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel() / salz.Kation.Molekuel.AnzahlAtomeInMolekuel();
                }
                else
                {
                    // Die Anzahl der Metall-Atome im Oxid sind geringer als die im Salz
                    // => Anzahl Metalloxid berechnen und die Anzahl des Salzes auf 1 setzen
                    metalloxidKomponente.Anzahl = salz.Kation.Molekuel.AnzahlAtomeInMolekuel() / ReagierendesMetalloxid.Bindungspartner.AnzahlAtomeInMolekuel();
                    salzKomponente.Anzahl = 1;
                }

                // Die Anzahl der Säure entspricht die Anzahl des Säurerestions
                // => Säure um die Anzahl des Säurerest-Ions multiplizieren
                saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl;

                // Berechne die Anzahl der übrigen Wasserstoffatome, um die Anzahl der Wasser Molekühle erhalten
                double wasserstoffAtomeInSaeure = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoff.AnzahlAtomeInMolekuel();
                double wasserstoffAtomeInSalz   = salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl * ((saeureKomponente.Molekuel as Saeure).Wasserstoff.AnzahlAtomeInMolekuel() - saeureVariation.wasserstoffIon.Molekuel.AnzahlAtomeInMolekuel());
                wasserKomponente.Anzahl = (wasserstoffAtomeInSaeure - wasserstoffAtomeInSalz) / 2;

                ReaktionsResultate.Add(new MetalloxidSaeureReaktionsResultat(metalloxidKomponente, saeureKomponente, salzKomponente, wasserKomponente));
            }
        }
    }
}
