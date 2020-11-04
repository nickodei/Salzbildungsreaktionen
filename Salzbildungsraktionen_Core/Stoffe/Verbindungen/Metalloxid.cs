using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen
{
    public class Metalloxid : IStoff
    {
        public string Name { get; set; }
        public string Formel { get; set; }


        public int AnzahlMetall { get; set; }
        public int AnzahlSauerstoff { get; set; }
        public ElementMolekuel Metall { get; set; }
        public ElementMolekuel Sauerstoff { get; set; }

        public Metalloxid(Metall metall)
        {
            // Hole dir das Element: Sauerstoff
            Nichtmetall sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");

            // Kreiere Ionen
            Kation metallIon = new Kation(new ElementMolekuel(1, new Atom(metall)));
            Anion sauerstoffIon = new Anion(new ElementMolekuel(1, new Atom(sauerstoff)));

            // Berechne die Anzahl der Molekühle
            (int anzahlKation, int anzahlAnionen) benoetigeMolekuehle = Ion.BerechneAnzahlDerMolekuehle(metallIon, sauerstoffIon);

            AnzahlMetall = benoetigeMolekuehle.anzahlKation;
            AnzahlSauerstoff = benoetigeMolekuehle.anzahlAnionen;

            Metall = metallIon.Molekuel as ElementMolekuel;
            Sauerstoff = sauerstoffIon.Molekuel as ElementMolekuel;

            GeneriereDieFormel();
            GeneriereName();
        }

        private void GeneriereName()
        {
            Name = Metall.Name + "oxid";
        }

        private void GeneriereDieFormel()
        {
            if (AnzahlMetall > 1)
            {
                Formel += $"{Metall.Formel}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlMetall)}";
            }
            else
            {
                Formel += $"{Metall.Formel}";
            }

            if (AnzahlSauerstoff > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(Sauerstoff.Formel.Last()) != -1)
                {
                    Formel += $"({Sauerstoff.Formel}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlSauerstoff)}";
                }
                else
                {
                    Formel += $"{Sauerstoff.Formel}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlSauerstoff)}";
                }
            }
            else
            {
                Formel += $"{Sauerstoff.Formel}";
            }
        }
    }
}
