using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen
{
    public class Salz : Ionenbindung
    {
        public Salz(Kation kation, Anion anion)
        {
            Kation = kation;
            Anion = anion;

            (int anzahlKation, int anzahlAnionen) benoetigeMolekuehle = Ion.BerechneAnzahlMolekuele(kation, anion);
            Kation.Molekuel.Anzahl = benoetigeMolekuehle.anzahlKation;
            Anion.Molekuel.Anzahl = benoetigeMolekuehle.anzahlAnionen;
        }     

        protected override string GeneriereName()
        {
            return Kation.Molekuel.Stoff.Name + Anion.Molekuel.Stoff.Name.ToLower();
        }

        protected override string GeneriereChemischeFormel()
        {
            string chemischeFormel = "";

            if (Kation.Molekuel.Anzahl > 1)
            {
                chemischeFormel += $"{Kation.Molekuel.Stoff.ChemischeFormel}{UnicodeHelfer.GetSubscriptOfNumber(Kation.Molekuel.Anzahl)}";
            }
            else
            {
                chemischeFormel += $"{Kation.Molekuel.Stoff.ChemischeFormel}";
            }

            if (Anion.Molekuel.Anzahl > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(Anion.Molekuel.Stoff.ChemischeFormel.Last()) != -1)
                {
                    chemischeFormel += $"({Anion.Molekuel.Stoff.ChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(Anion.Molekuel.Anzahl)}";
                }
                else
                {
                    chemischeFormel += $"{Anion.Molekuel.Stoff.ChemischeFormel}{UnicodeHelfer.GetSubscriptOfNumber(Anion.Molekuel.Anzahl)}";
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
