using Salzbildungsreaktionen_Core.Helper;
using System;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Salz<K, A>: Verbindung where K: Stoff where A: Stoff 
    {
        private Kation<K> _Katione;
        public Kation<K> Katione
        {
            get { return _Katione; }
            set { _Katione = value; }
        }

        private int _AnzahlKatione;
        public int AnzahlKatione
        {
            get { return _AnzahlKatione; }
            set { _AnzahlKatione = value; }
        }

        private Anion<A> _Anione;
        public Anion<A> Anione
        {
            get { return _Anione; }
            set { _Anione = value; }
        }

        private int _AnzahlAnione;
        public int AnzahlAnione
        {
            get { return _AnzahlAnione; }
            set { _AnzahlAnione = value; }
        }

        public Salz(Kation<K> katione, Anion<A> anione) : base("")
        {
            // Setze die Ionen
            Katione = katione;
            Anione = anione;

            // Setze die restlichen Eingenschaften
            SetzeBenötigteIonen();
            GeneriereDieFormel();
            GeneriereDenName();
        }

        private void SetzeBenötigteIonen()
        {
            // Berechne die Anzahl der benötigten Ionen
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(Katione.Ladung), Math.Abs(Anione.Ladung));
            AnzahlKatione = kgV / Math.Abs(Katione.Ladung);
            AnzahlAnione = kgV / Math.Abs(Anione.Ladung);
        }

        private void GeneriereDenName()
        {
            Name = $"{Katione.GetName()}{Anione.GetName().ToLower()}";
        }

        private void GeneriereDieFormel()
        {
            if (AnzahlKatione > 1)
            {
                Formel += $"{Katione.GetFormel()}{Unicodehelfer.GetSubscriptOfNumber(AnzahlKatione)}";
            }
            else
            {
                Formel += $"{Katione.GetFormel()}";
            }

            if (AnzahlAnione > 1)
            {
                if (Unicodehelfer.GetNumberOfSubscript(Anione.GetFormel().Last()) != -1)
                {
                    Formel += $"({Anione.GetFormel()}){Unicodehelfer.GetSubscriptOfNumber(AnzahlAnione)}";
                }
                else
                {
                    Formel += $"{Anione.GetFormel()}{Unicodehelfer.GetSubscriptOfNumber(AnzahlAnione)}";
                }
            }
            else
            {
                Formel += $"{Anione.GetFormel()}";
            }
        }
    }
}
