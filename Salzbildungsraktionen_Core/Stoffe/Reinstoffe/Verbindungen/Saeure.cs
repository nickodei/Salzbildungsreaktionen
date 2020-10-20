using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Saeure : Verbindung
    {
        private Kation<MolekulareVerbindung> _WasserstoffIon;
        public Kation<MolekulareVerbindung> WasserstoffIon
        {
            get { return _WasserstoffIon; }
            set { _WasserstoffIon = value; }
        }

        private Anion<Verbindung> _SaeurerestIon;
        public Anion<Verbindung> SaeurerestIon
        {
            get { return _SaeurerestIon; }
            set { _SaeurerestIon = value; }
        }

        public Saeure(Kation<MolekulareVerbindung> wasserstoff, Anion<Verbindung> saeurerest) : base("")
        {
            WasserstoffIon = wasserstoff;
            SaeurerestIon = saeurerest;

            GeneriereDenName();
            GeneriereDieFormel();
        }

        private void GeneriereDenName()
        {
            Name = $"{WasserstoffIon.GetName()}{SaeurerestIon.GetName().ToLower()}";
        }

        private void GeneriereDieFormel()
        {
            Formel = $"{WasserstoffIon.GetFormel()}{SaeurerestIon.GetFormel()}";
        }

        public static List<Saeure> ErhalteAlleSäurevarianten(string formel)
        {
            List<Saeure> säureVarianten = new List<Saeure>();

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
                if(Periodensystem.Instance.Nichtmetalle.TryGetValue("H", out Nichtmetall wasserstoff))
                {
                    MolekulareVerbindung wasserstoffMolekuehl = new MolekulareVerbindung(wasserstoff, counter);
                    Kation<MolekulareVerbindung> wasserstoffIon = new Kation<MolekulareVerbindung>(wasserstoffMolekuehl, wasserstoff.ErhalteLadung());

                    Verbindung saererest = new Verbindung(säureRestIonFormel);
                    Anion<Verbindung> säurerestIon = new Anion<Verbindung>(saererest, counter - anzahlWasserstoff - 1);

                    säureVarianten.Add(new Saeure(wasserstoffIon, säurerestIon));
                }
            }

            return säureVarianten;
        }
    }
}
