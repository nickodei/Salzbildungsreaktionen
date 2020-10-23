using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Saeure : Verbindung
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

        private Kation<ElementMolekuehl> _WasserstoffIon;
        public Kation<ElementMolekuehl> WasserstoffIon
        {
            get { return _WasserstoffIon; }
            set { _WasserstoffIon = value; }
        }

        private Anion<MultiElementMolekuehl> _SaeurerestIon;
        public Anion<MultiElementMolekuehl> SaeurerestIon
        {
            get { return _SaeurerestIon; }
            set { _SaeurerestIon = value; }
        }

        public Saeure(string formel) : base()
        {
            // Überprüfe ob der erste Buchstabe für ein Wasserstoff steht
            // Wenn nicht, dann gibt es auch keine Säure zum erstellen
            if (formel[0].Equals('H'))
            {
                bool enthaeltWasserstoffMolekuel = false;

                // Hole dir die nächste Stelle nach dem Wasserstoff
                // Ist es eine untergestellte Zahl, so gibt es die Anzahl der Wasserstoffatome an
                // Ist es keine Zahl, so wird -1 zurückgegeben und wir gehen von einem Wasserstoffatom aus
                int anzahlWasserstoff = UnicodeHelfer.GetNumberOfSubscript(formel[1]);
                if (anzahlWasserstoff == -1)
                {
                    // Setze die Anzahlt der Wasserstoffatome auf 1
                    enthaeltWasserstoffMolekuel = true;
                    anzahlWasserstoff = 1;
                }

                // Überprüfe, ob es Wasserstoff in der Datenbank gibt
                if (Periodensystem.Instance.Nichtmetalle.TryGetValue("H", out Nichtmetall wasserstoff))
                {
                    ElementMolekuehl wasserstoffMolekuehl = new ElementMolekuehl(wasserstoff, anzahlWasserstoff);
                    WasserstoffIon = new Kation<ElementMolekuehl>(wasserstoffMolekuehl, wasserstoff.BerechenLadungszahl());
                }

                string saereRestFormel = "";
                if (enthaeltWasserstoffMolekuel)
                {
                    saereRestFormel = formel.Substring(1);
                }
                else
                {
                    saereRestFormel = formel.Substring(2);
                }

                MultiElementMolekuehl saererest = new MultiElementMolekuehl(saereRestFormel);
                SaeurerestIon = new Anion<MultiElementMolekuehl>(saererest, -anzahlWasserstoff);
            }

            GeneriereFormel();
            GeneriereName();
        }

        public Saeure(Kation<ElementMolekuehl> wasserstoff, Anion<MultiElementMolekuehl> saeurerest) : base()
        {
            WasserstoffIon = wasserstoff;
            SaeurerestIon = saeurerest;

            GeneriereFormel();
            GeneriereName();
        }

        private void GeneriereFormel()
        {
            _Formel = $"{WasserstoffIon.GetFormel()}{SaeurerestIon.GetFormel()}";
        }

        private void GeneriereName()
        {
            // Überprüfe, ob ein Sauerstoff vorhanden ist
            if (Formel.Contains("O") == true)
            {
                //TODO Oxidationsstufe beachten
                _Name = $"{WasserstoffIon.Stoff.Name}{SaeurerestIon.GetName().ToLower()}";
            }
            else
            {
                _Name = $"{SaeurerestIon.Stoff.Name}wasserstoffsäure";
            }
        }

        public List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)> ErhalteVariantenDerSaerebestandteile()
        {
            List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)> resultat = new List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)>();
            for (int wasserstoffAtome = 1; wasserstoffAtome <= WasserstoffIon.Stoff.AnzahlAtome; wasserstoffAtome++)
            {
                // Bestimme das abgegebene Wasserrstoffion
                ElementMolekuehl abgegebenesWasserstoffMolekuel = new ElementMolekuehl(WasserstoffIon.Stoff.Element, wasserstoffAtome);
                Kation<ElementMolekuehl> abgegebenesWasserstoff = new Kation<ElementMolekuehl>(abgegebenesWasserstoffMolekuel, wasserstoffAtome);

                // Bestimme das Säurerest
                Anion<MultiElementMolekuehl> säurerestIon = null;
                int wasserstoffInSaererest = WasserstoffIon.Stoff.AnzahlAtome - wasserstoffAtome;
                if (wasserstoffInSaererest == 0)
                {
                    MultiElementMolekuehl saererest = new MultiElementMolekuehl(SaeurerestIon.Stoff.Formel);
                    säurerestIon = new Anion<MultiElementMolekuehl>(saererest, SaeurerestIon.Ladung);
                }
                else
                {
                    // Wasserstoff wird für das Säurerest verwendet
                    MultiElementMolekuehl saererest = null;
                    if (wasserstoffInSaererest == 1)
                    {
                        saererest = new MultiElementMolekuehl("H" + SaeurerestIon.Stoff.Formel);
                    }
                    else
                    {
                        saererest = new MultiElementMolekuehl("H" + UnicodeHelfer.GetSubscriptOfNumber(wasserstoffInSaererest) + SaeurerestIon.Stoff.Formel);
                    }
                    säurerestIon = new Anion<MultiElementMolekuehl>(saererest, SaeurerestIon.Ladung + wasserstoffInSaererest);
                }
                resultat.Add((abgegebenesWasserstoff, säurerestIon));
            }
            return resultat;
        }
    }
}
