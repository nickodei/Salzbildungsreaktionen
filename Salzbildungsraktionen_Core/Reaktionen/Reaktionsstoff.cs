using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class Reaktionsstoff<T> where T : Stoff
    {
        private T _Stoff;
        public T Stoff
        {
            get { return _Stoff; }
            set { _Stoff = value; }
        }

        private double _Anzahl;
        public double Anzahl
        {
            get { return _Anzahl; }
            set { _Anzahl = value; }
        }

        public Reaktionsstoff(T stoff)
        {
            Stoff = stoff;
            Anzahl = 0;
        }

        public string GetFormel()
        {
            Element element = Stoff as Element;
            if (element != null)
            {
                return (Anzahl != 1) ? $"{Anzahl} {element.Symbol}" : element.Symbol;
            }

            Verbindung verbindung = Stoff as Verbindung;
            if (verbindung != null)
            {
                return (Anzahl != 1) ? $"{Anzahl} {verbindung.Formel}" : verbindung.Formel;
            }

            return "-";
        }
    }
}
