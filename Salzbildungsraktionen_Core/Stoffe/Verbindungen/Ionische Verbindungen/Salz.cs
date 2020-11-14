using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
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

            GeneriereFormel();

            if(Anion.Molekuel.Bindung is Oxid)
            {
                Oxid oxid = Anion.Molekuel.Bindung as Oxid;
                Name = Kation.Molekuel.Bindung.ErhalteName() + oxid.ErhalteAnionenName(Anion.Ladung).ToLower();
            }
            else
            {
                Name = Kation.Molekuel.Bindung.ErhalteName() + Anion.Molekuel.Bindung.ErhalteName().ToLower();
            }
        }

        private void GeneriereFormel()
        {
            if (AnzahlKationen > 1)
            {
                ChemischeFormel += $"{Kation.Molekuel.Bindung.ErhalteFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlKationen)}";
            }
            else
            {
                ChemischeFormel += $"{Kation.Molekuel.Bindung.ErhalteFormel()}";
            }

            if (AnzahlAnionen > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(Anion.Molekuel.Bindung.ErhalteFormel().Last()) != -1)
                {
                    ChemischeFormel += $"({Anion.Molekuel.Bindung.ErhalteFormel()}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnionen)}";
                }
                else
                {
                    ChemischeFormel += $"{Anion.Molekuel.Bindung.ErhalteFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnionen)}";
                }
            }
            else
            {
                ChemischeFormel += $"{Anion.Molekuel.Bindung.ErhalteFormel()}";
            }
        }
    }
}
