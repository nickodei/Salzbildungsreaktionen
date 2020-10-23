using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Lauge : Verbindung
    {
        private string _Name;
        public override string Name
        {
            get { return _Name; }
        }

        private string _Formel;
        public override string Formel
        {
            get { return _Formel; }
        }

        private Anion<MultiElementMolekuehl> _OHMolekuehlIon;
        public Anion<MultiElementMolekuehl> OHMolekuehlIon
        {
            get { return _OHMolekuehlIon; }
            set { _OHMolekuehlIon = value; }
        }

        private int _AnzahlOHMolekuehle;
        public int AnzahlOHMolekuehle
        {
            get { return _AnzahlOHMolekuehle; }
            set { _AnzahlOHMolekuehle = value; }
        }

        private Kation<Metall> _MetallMolekuehlIon;
        public Kation<Metall> MetallMolekuehlIon
        {
            get { return _MetallMolekuehlIon; }
            set { _MetallMolekuehlIon = value; }
        }

        private int _AnzahlMetallIonMolekuehle;
        public int AnzahlMetallIonMolekuehle
        {
            get { return _AnzahlMetallIonMolekuehle; }
            set { _AnzahlMetallIonMolekuehle = value; }
        }

        public Lauge(string formel) : base()
        {
        }

        public Lauge(Metall metall) : base()
        {
            MetallMolekuehlIon = new Kation<Metall>(metall, metall.BerechenLadungszahl());

            MultiElementMolekuehl OHMolekuehl = new MultiElementMolekuehl("OH");
            OHMolekuehlIon = new Anion<MultiElementMolekuehl>(OHMolekuehl, -1);

            (int, int) anzahlMolekuehle = base.BerechneAnzahlDerMolekuehle(MetallMolekuehlIon, OHMolekuehlIon);

            AnzahlMetallIonMolekuehle = anzahlMolekuehle.Item1;
            AnzahlOHMolekuehle = anzahlMolekuehle.Item2;

            GeneriereDieFormel();
        }

        private void GeneriereDieFormel()
        {
            if (AnzahlMetallIonMolekuehle > 1)
            {
                _Formel += $"{MetallMolekuehlIon.GetFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlMetallIonMolekuehle)}";
            }
            else
            {
                _Formel += $"{MetallMolekuehlIon.GetFormel()}";
            }

            if (AnzahlOHMolekuehle > 1)
            {
                if (UnicodeHelfer.GetNumberOfSubscript(OHMolekuehlIon.GetFormel().Last()) != -1)
                {
                    _Formel += $"({OHMolekuehlIon.GetFormel()}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlOHMolekuehle)}";
                }
                else
                {
                    _Formel += $"{OHMolekuehlIon.GetFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlOHMolekuehle)}";
                }
            }
            else
            {
                _Formel += $"{OHMolekuehlIon.GetFormel()}";
            }
        }
    }
}
