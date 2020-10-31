using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Metalloxid : Molekuehl
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
        }

        private string _Formel;
        public string Formel
        {
            get { return _Formel; }
        }

        private Kation<Metall> _MetallIon;
        public Kation<Metall> MetallIon
        {
            get { return _MetallIon; }
            set { _MetallIon = value; }
        }

        private int _AnzahlMetall;
        public int AnzahlMetall
        {
            get { return _AnzahlMetall; }
            set { _AnzahlMetall = value; }
        }

        private Anion<Nichtmetall> _SauerstoffIon;
        public Anion<Nichtmetall> SauerstoffIon
        {
            get { return _SauerstoffIon; }
            set { _SauerstoffIon = value; }
        }

        private int _AnzahlSauerstoff;
        public int AnzahlSauerstoff
        {
            get { return _AnzahlSauerstoff; }
            set { _AnzahlSauerstoff = value; }
        }

        public Metalloxid(Metall metall) : base()
        {
            //// Hole dir das Element: Sauerstoff
            //Nichtmetall sauerstoff = Periodensystem.Instance.Nichtmetalle.Values.Where(x => x.Formel == "O").FirstOrDefault();

            //// Erstelle die Ionen
            //MetallIon = new Kation<Metall>(metall, metall.BerechenLadungszahl());
            //SauerstoffIon = new Anion<Nichtmetall>(sauerstoff, sauerstoff.BerechenLadungszahl());

            //// Berechne die Anzahl der Molekühle
            //(int, int) anzahlMolekuehle = base.BerechneAnzahlDerMolekuehle(MetallIon, SauerstoffIon);
            //AnzahlMetall = anzahlMolekuehle.Item1;
            //AnzahlSauerstoff = anzahlMolekuehle.Item2;

            //GeneriereDieFormel();
            //GeneriereName();
        }

        private void GeneriereName()
        {
            //_Name = MetallIon.Stoff.Name + "oxid";
        }

        private void GeneriereDieFormel()
        {
        //    if (AnzahlMetall > 1)
        //    {
        //        _Formel += $"{MetallIon.GetFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlMetall)}";
        //    }
        //    else
        //    {
        //        _Formel += $"{MetallIon.GetFormel()}";
        //    }

        //    if (AnzahlSauerstoff > 1)
        //    {
        //        if (UnicodeHelfer.GetNumberOfSubscript(SauerstoffIon.GetFormel().Last()) != -1)
        //        {
        //            _Formel += $"({SauerstoffIon.GetFormel()}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlSauerstoff)}";
        //        }
        //        else
        //        {
        //            _Formel += $"{SauerstoffIon.GetFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlSauerstoff)}";
        //        }
        //    }
        //    else
        //    {
        //        _Formel += $"{SauerstoffIon.GetFormel()}";
        //    }
        }

    }
}
