using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
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
        /// Startet die Metall-Säure Reaktion
        /// </summary>
        public override void BeginneReaktion()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> saeureVariationen = ReagierendeSaeure.ErhalteIonisierteSaeurevarianten();
            foreach ((Kation wasserstoffIon, Anion saeurerestIon) saeureVariation in saeureVariationen)
            {
                // Ionisiere das Metall
                Kation metallIon = new Kation(new ElementMolekuel(new Elementarverbindung(ReagierendesMetall, 1)));

                // Generie das Salz aus den Ionen
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe                
                Reaktionsstoff wasserstoffKomponente = new Reaktionsstoff(new Molekularverbindung("H₂", "Wasserstoff"));
                Reaktionsstoff metallKomponente = new Reaktionsstoff(ReagierendesMetall);
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(ReagierendeSaeure);
                Reaktionsstoff salzKomponente = new Reaktionsstoff(salz);

                // Metall ausgleichen
                metallKomponente.Anzahl = salz.Kation.Molekuel.Anzahl;

                // Säure ausgleichen
                saeureKomponente.Anzahl = salz.Anion.Molekuel.Anzahl;

                // Salz ausgleichen
                salzKomponente.Anzahl = 1;

                // Gleiche den Wasserstoff aus
                double maximaleWasserstoffAtome = saeureKomponente.Anzahl * ReagierendeSaeure.Wasserstoff.Ladung;
                double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salz.Anion.Molekuel.Anzahl * (ReagierendeSaeure.Wasserstoff.Ladung - saeureVariation.wasserstoffIon.Molekuel.Anzahl));
                wasserstoffKomponente.Anzahl = restlicheWasserstoffAtome / 2;

                ReaktionsResultate.Add(new MetallSaeureReaktionsResultat(metallKomponente, saeureKomponente, salzKomponente, wasserstoffKomponente));                
            }
        }
    }
}
