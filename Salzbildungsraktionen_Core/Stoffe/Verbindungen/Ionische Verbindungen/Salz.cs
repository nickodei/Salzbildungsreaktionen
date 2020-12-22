using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen
{
    public class Salz : IonischeVerbindung
    {
        public Kation Kation { get; set; }
        public int AnzahlKationen { get; set; }
        public Anion Anion { get; set; }
        public int AnzahlAnionen { get; set; }

        public Salz(Kation kation, Anion anion)
        {
            Kation = kation;
            Anion = anion;

            (int anzahlKation, int anzahlAnionen) benoetigeMolekuehle = Ion.BerechneAnzahlDerMolekuehle(kation, anion);
            AnzahlKationen = benoetigeMolekuehle.anzahlKation;
            AnzahlAnionen = benoetigeMolekuehle.anzahlAnionen;
        }     

        protected override string GeneriereName()
        {
            return Kation.Molekuel.Stoff.Name + Anion.Molekuel.Stoff.Name.ToLower();
        }

        protected override string GeneriereChemischeFormel()
        {
            string chemischeFormel = "";

            if (AnzahlKationen > 1)
            {
                chemischeFormel += $"{Kation.Molekuel.Stoff.ChemischeFormel}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlKationen)}";
            }
            else
            {
                chemischeFormel += $"{Kation.Molekuel.Stoff.ChemischeFormel}";
            }

            if (AnzahlAnionen > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(Anion.Molekuel.Stoff.ChemischeFormel.Last()) != -1)
                {
                    chemischeFormel += $"({Anion.Molekuel.Stoff.ChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnionen)}";
                }
                else
                {
                    chemischeFormel += $"{Anion.Molekuel.Stoff.ChemischeFormel}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnionen)}";
                }
            }
            else
            {
                chemischeFormel += $"{Anion.Molekuel.Stoff.ChemischeFormel}";
            }

            return chemischeFormel;
        }
    }
}
