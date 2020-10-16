using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Säure : Verbindung
    {
        public const string Salzsäure = "HCl";
        public const string Schwefelsäure = "H₂SO₄";

        private MolekulareVerbindung _Wasserstoff;
        public MolekulareVerbindung Wasserstoff
        {
            get { return _Wasserstoff; }
            set { _Wasserstoff = value; }
        }

        private SäureRestIon _Säurerest;
        public SäureRestIon Säurerest
        {
            get { return _Säurerest; }
            set { _Säurerest = value; }
        }

        private Säure(string name, string formel, MolekulareVerbindung wasserstoff, SäureRestIon säurerest) : base(name, formel)
        {
            Wasserstoff = wasserstoff;
            Säurerest = säurerest;
        }

        public Säure ErhalteSäure(string formel)
        {
            // Überprüfe ob der erste Buchstabe für ein Wasserstoff steht
            // Wenn nicht, dann gibt es auch keine Säure zum erstellen
            if (!formel[0].Equals('H'))
            {
                return null;
            }

            SäureRestIon säurerestIon = null;

            // Hole dir die nächste Stelle nach dem Wasserstoff
            // Ist es eine untergestellte Zahl, so gibt es die Anzahl der Wasserstoffatome an
            // Ist es keine Zahl, so wird -1 zurückgegeben und wir gehen von einem Wasserstoffatom aus
            int anzahlWasserstoff = Unicodehelfer.GetNumberOfSubscript(formel[1]);
            if (anzahlWasserstoff == -1)
            {
                // Setze die Anzahlt der Wasserstoffatome auf 1
                anzahlWasserstoff = 1;               
                säurerestIon = SäureRestIon.ErhalteSäurerest(formel.Substring(1), -anzahlWasserstoff);
            }
            else
            {
                säurerestIon = SäureRestIon.ErhalteSäurerest(formel.Substring(2), -anzahlWasserstoff);
            }

            MolekulareVerbindung wasserstoff = MolekulareVerbindung.ErhalteVerbindung(Nichtmetall.ErhalteNichtmetall(Nichtmetall.Wasserstoff), anzahlWasserstoff);
            
            switch(formel)
            {
                case Salzsäure:
                    return new Säure(nameof(Salzsäure), formel, wasserstoff, säurerestIon);
                case Schwefelsäure:
                    return new Säure(nameof(Schwefelsäure), formel, wasserstoff, säurerestIon);
                default:
                    return null;
            }
        }
    }
}
