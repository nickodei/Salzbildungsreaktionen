using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;
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
                Kation metallIon = new Kation(new ElementMolekuel(1, new Atom(ReagierendesMetall)));

                // Generie das Salz aus den Ionen
                Salz salz = new Salz(metallIon, saeureVariation.saeurerestIon);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff metallKomponente = new Reaktionsstoff(new ElementMolekuel(1, new Atom(ReagierendesMetall)));
                Reaktionsstoff saeureKomponente = new Reaktionsstoff(new VerbindungsMolekuel(ReagierendeSaeure.Formel));
                Reaktionsstoff salzKomponente = new Reaktionsstoff(new VerbindungsMolekuel(salz.Formel));

                // Metall ausgleichen
                metallKomponente.Anzahl = salz.AnzahlKationen;

                // Säure ausgleichen
                saeureKomponente.Anzahl = salz.AnzahlAnionen;

                // Salz ausgleichen
                salzKomponente.Anzahl = 1;

                // Erstelle das Wasserstoff
                Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");

                ElementMolekuel wasserstoffMolekuel = new ElementMolekuel(2, new Atom(wasserstoff));
                Reaktionsstoff wasserstoffKomponente = new Reaktionsstoff(wasserstoffMolekuel);

                // Gleiche den Wasserstoff aus
                double maximaleWasserstoffAtome = saeureKomponente.Anzahl * ReagierendeSaeure.WasserstoffMolekuel.Anzahl;
                double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salz.AnzahlAnionen * (ReagierendeSaeure.WasserstoffMolekuel.Anzahl - saeureVariation.wasserstoffIon.Molekuel.Anzahl));



                wasserstoffKomponente.Anzahl = restlicheWasserstoffAtome / 2;
                ReaktionsResultate.Add(new MetallSaeureReaktionsResultat(metallKomponente, saeureKomponente, salzKomponente, wasserstoffKomponente));                
            }
        }
    }
}
