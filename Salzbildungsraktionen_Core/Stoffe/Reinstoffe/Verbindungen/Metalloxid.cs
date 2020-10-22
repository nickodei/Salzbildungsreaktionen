using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Metalloxid : Verbindung
    {
        private MetallIon _Metall;
        public MetallIon Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
        }

        private int _AnzahlMetall;
        public int AnzahlMetall
        {
            get { return _AnzahlMetall; }
            set { _AnzahlMetall = value; }
        }

        private NichtmetallIon _Sauerstoff;
        public NichtmetallIon Sauerstoff
        {
            get { return _Sauerstoff; }
            set { _Sauerstoff = value; }
        }

        private int _AnzahlSauerstoff;
        public int AnzahlSauerstoff
        {
            get { return _AnzahlSauerstoff; }
            set { _AnzahlSauerstoff = value; }
        }


        public Metalloxid(Metall metall) : base("")
        {
            // Hole dir das Element: Sauerstoff
            Nichtmetall sauerstoff = Periodensystem.Instance.Nichtmetalle.Values.Where(x => x.Symbol == "O").FirstOrDefault();

            // Erstelle die Ionen
            Metall = new MetallIon(metall);
            Sauerstoff = new NichtmetallIon(sauerstoff);

            // Berechne die Anzahl der Molekühle
            (int, int) anzahlMolekuehle = base.BerechneAnzahlDerMolekuehle(Metall, Sauerstoff);
            AnzahlMetall = anzahlMolekuehle.Item1;
            AnzahlSauerstoff = anzahlMolekuehle.Item2;

            GeneriereDieFormel();
            GeneriereName();
        }

        private void GeneriereName()
        {
            Name = Metall.Stoff.Name + "oxid";
        }

        private void GeneriereDieFormel()
        {
            if (AnzahlMetall > 1)
            {
                Formel += $"{Metall.GetFormel()}{Unicodehelfer.GetSubscriptOfNumber(AnzahlMetall)}";
            }
            else
            {
                Formel += $"{Metall.GetFormel()}";
            }

            if (AnzahlSauerstoff > 1)
            {
                if (Unicodehelfer.GetNumberOfSubscript(Sauerstoff.GetFormel().Last()) != -1)
                {
                    Formel += $"({Sauerstoff.GetFormel()}){Unicodehelfer.GetSubscriptOfNumber(AnzahlSauerstoff)}";
                }
                else
                {
                    Formel += $"{Sauerstoff.GetFormel()}{Unicodehelfer.GetSubscriptOfNumber(AnzahlSauerstoff)}";
                }
            }
            else
            {
                Formel += $"{Sauerstoff.GetFormel()}";
            }
        }

    }
}
