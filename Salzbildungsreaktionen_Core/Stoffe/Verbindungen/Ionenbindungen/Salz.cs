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

            Name = Kation.Molekuel.Atombindung.Name + Anion.Molekuel.Atombindung.Name.ToLower();

            if (Kation.Molekuel.Anzahl > 1)
            {
                ChemischeFormel += $"{Kation.Molekuel.Atombindung.ChemischeFormel}{UnicodeHelfer.GetSubscriptOfNumber(Kation.Molekuel.Anzahl)}";
            }
            else
            {
                ChemischeFormel += $"{Kation.Molekuel.Atombindung.ChemischeFormel}";
            }

            if (Anion.Molekuel.Anzahl > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(Anion.Molekuel.Atombindung.ChemischeFormel.Last()) != -1)
                {
                    ChemischeFormel += $"({Anion.Molekuel.Atombindung.ChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(Anion.Molekuel.Anzahl)}";
                }
                else
                {
                    ChemischeFormel += $"{Anion.Molekuel.Atombindung.ChemischeFormel}{UnicodeHelfer.GetSubscriptOfNumber(Anion.Molekuel.Anzahl)}";
                }
            }
            else
            {
                ChemischeFormel += $"{Anion.Molekuel.Atombindung.ChemischeFormel}";
            }
        }     
    }
}
