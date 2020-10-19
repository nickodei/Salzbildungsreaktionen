using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Säure : Verbindung
    {
        public const string Salzsäure = "HCl";
        public const string Schwefelsäure = "H₂SO₄";

        private NichtmetallIon _Wasserstoff;
        public NichtmetallIon Wasserstoff
        {
            get { return _Wasserstoff; }
            set { _Wasserstoff = value; }
        }

        private int _WasserstoffMolekühle;
        public int WasserstoffMolekühle
        {
            get { return _WasserstoffMolekühle; }
            set { _WasserstoffMolekühle = value; }
        }

        private SäurerestIon _Säurerest;
        public SäurerestIon Säurerest
        {
            get { return _Säurerest; }
            set { _Säurerest = value; }
        }

        private Säure(string name, string formel, NichtmetallIon wasserstoff, int wasserstoffMolekühle, SäurerestIon säurerest) : base(name, formel)
        {
            Wasserstoff = wasserstoff;
            WasserstoffMolekühle = wasserstoffMolekühle;
            Säurerest = säurerest;
        }

        public static List<Säure> ErhalteAlleSäurevarianten(string formel)
        {
            List<Säure> säureVarianten = new List<Säure>();

            // Überprüfe ob der erste Buchstabe für ein Wasserstoff steht
            // Wenn nicht, dann gibt es auch keine Säure zum erstellen
            if (!formel[0].Equals('H'))
            {
                return null;
            }

            string säureRestIonFormel = null;

            // Hole dir die nächste Stelle nach dem Wasserstoff
            // Ist es eine untergestellte Zahl, so gibt es die Anzahl der Wasserstoffatome an
            // Ist es keine Zahl, so wird -1 zurückgegeben und wir gehen von einem Wasserstoffatom aus
            int anzahlWasserstoff = Unicodehelfer.GetNumberOfSubscript(formel[1]);
            if (anzahlWasserstoff == -1)
            {
                // Setze die Anzahlt der Wasserstoffatome auf 1
                anzahlWasserstoff = 1;
                säureRestIonFormel = formel.Substring(1);
            }
            else
            {
                säureRestIonFormel = formel.Substring(2);
            }

            for (int counter = 1; counter <= anzahlWasserstoff; counter++)
            {
                SäurerestIon säurerestIon = SäurerestIon.ErhalteSäurerest(säureRestIonFormel, counter - anzahlWasserstoff - 1);
                NichtmetallIon wasserstoffIon = NichtmetallIon.ErhalteNichtmetallIon(Nichtmetall.ErhalteNichtmetall(Nichtmetall.Wasserstoff));

                switch (formel)
                {
                    case Salzsäure:
                        säureVarianten.Add(new Säure(nameof(Salzsäure), formel, wasserstoffIon, counter, säurerestIon));
                        break;
                    case Schwefelsäure:
                        säureVarianten.Add(new Säure(nameof(Schwefelsäure), formel, wasserstoffIon, counter, säurerestIon));
                        break;
                    default:
                        säureVarianten.Add(new Säure("Unbekannt", formel, wasserstoffIon, counter, säurerestIon));
                        break;
                }
            }

            return säureVarianten;
        }
    }
}
