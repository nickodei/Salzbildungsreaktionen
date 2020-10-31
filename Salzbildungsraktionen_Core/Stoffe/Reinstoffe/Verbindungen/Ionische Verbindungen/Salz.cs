using Salzbildungsreaktionen_Core.Helper;
using System;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Salz<K, A>: Verbindung where K: Stoff where A: Stoff 
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

        public Salz(Kation<K> katione, Anion<A> anione) : base()
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
            //int kgV = Verbindung.GetLCM(Math.Abs(Katione.Ladung), Math.Abs(Anione.Ladung));
            //AnzahlKatione = kgV / Math.Abs(Katione.Ladung);
            //AnzahlAnione = kgV / Math.Abs(Anione.Ladung);
        }

        private void GeneriereDenName()
        {
            //_Name = $"{Katione.GetName()}{Anione.GetName().ToLower()}";
        }

        private void GeneriereDieFormel()
        {
            //if (AnzahlKatione > 1)
            //{
            //    _Formel += $"{Katione.GetFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlKatione)}";
            //}
            //else
            //{
            //    _Formel += $"{Katione.GetFormel()}";
            //}

            //if (AnzahlAnione > 1)
            //{
            //    if (UnicodeHelfer.GetNumberOfSubscript(Anione.GetFormel().Last()) != -1)
            //    {
            //        _Formel += $"({Anione.GetFormel()}){UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnione)}";
            //    }
            //    else
            //    {
            //        _Formel += $"{Anione.GetFormel()}{UnicodeHelfer.GetSubscriptOfNumber(AnzahlAnione)}";
            //    }
            //}
            //else
            //{
            //    _Formel += $"{Anione.GetFormel()}";
            //}
        }
    }
}
