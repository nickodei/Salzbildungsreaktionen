using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen
{
    public class Salz : IStoff
    {
        public string Name { get; set; }
        public string Formel { get; set; }

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

            GeneriereFormel();
        }

        private void GeneriereFormel()
        {
            if (AnzahlKationen > 1)
            {
                Formel += $"{Kation.Molekuel.Formel}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlKationen)}";
            }
            else
            {
                Formel += $"{Kation.Molekuel.Formel}";
            }

            if (AnzahlAnionen > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(Anion.Molekuel.Formel.Last()) != -1)
                {
                    Formel += $"({Anion.Molekuel.Formel}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnionen)}";
                }
                else
                {
                    Formel += $"{Anion.Molekuel.Formel}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnionen)}";
                }
            }
            else
            {
                Formel += $"{Anion.Molekuel.Formel}";
            }
        }
    }
}
