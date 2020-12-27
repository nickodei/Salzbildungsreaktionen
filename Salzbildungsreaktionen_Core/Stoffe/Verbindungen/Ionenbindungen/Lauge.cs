using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge
{
    public class Lauge : Ionenbindung
    {
        public Kation Metall => Kation;
        public Anion Hydroxid => Anion;

        public Lauge(Metall metall)
        {
            // Erstelle das Metall-Kation
            Kation = new Kation(new ElementMolekuel(new Elementarverbindung(metall, 1)), metall.Hauptgruppe);

            // Erhalte das Oxid-Anion
            Anion = new Anion(new MultiElementMolekuel(new Oxid("OH")), -1);
            Anion.Molekuel.Stoff.SetzteTrivialname("Hydroxid");

            (int anzahlKation, int anzahlAnion) = Ion.BerechneAnzahlMolekuele(Kation, Anion);
            Kation.Molekuel.Anzahl = anzahlKation;
            Anion.Molekuel.Anzahl = anzahlAnion;

            if(Anion.Molekuel.Anzahl == 1)
            {
                _ChemischeFormel = metall.Symol + Hydroxid.Molekuel.Stoff.ChemischeFormel;
            }
            else
            {
                _ChemischeFormel = $"{metall.Symol}({Hydroxid.Molekuel.Stoff.ChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(Hydroxid.Molekuel.Anzahl)}";
            }
        }

        protected override string GeneriereName()
        {
            return Metall.Molekuel.Stoff.Name + "hydroxid";
        }

        protected override string GeneriereChemischeFormel()
        {
            throw new NotImplementedException();
        }
    }
}
