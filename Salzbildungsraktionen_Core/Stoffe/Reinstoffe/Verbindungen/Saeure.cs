using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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

        public Saeure(string formel) : base("")
        {
            // Überprüfe ob der erste Buchstabe für ein Wasserstoff steht
            // Wenn nicht, dann gibt es auch keine Säure zum erstellen
            if (formel[0].Equals('H'))
            {
                bool enthaeltWasserstoffMolekuel = false;

                // Hole dir die nächste Stelle nach dem Wasserstoff
                // Ist es eine untergestellte Zahl, so gibt es die Anzahl der Wasserstoffatome an
                // Ist es keine Zahl, so wird -1 zurückgegeben und wir gehen von einem Wasserstoffatom aus
                int anzahlWasserstoff = Unicodehelfer.GetNumberOfSubscript(formel[1]);
                if (anzahlWasserstoff == -1)
                {
                    // Setze die Anzahlt der Wasserstoffatome auf 1
                    enthaeltWasserstoffMolekuel = true;
                    anzahlWasserstoff = 1;
                }

                // Überprüfe, ob es Wasserstoff in der Datenbank gibt
                if (Periodensystem.Instance.Nichtmetalle.TryGetValue("H", out Nichtmetall wasserstoff))
                {
                    MolekulareVerbindung wasserstoffMolekuehl = new MolekulareVerbindung(wasserstoff, anzahlWasserstoff);
                    WasserstoffIon = new Kation<MolekulareVerbindung>(wasserstoffMolekuehl, wasserstoff.ErhalteLadung());
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

                Verbindung saererest = new Verbindung(saereRestFormel);
                SaeurerestIon = new Anion<Verbindung>(saererest, -anzahlWasserstoff);
            }

            GeneriereFormel();
            GeneriereName();
        }

        public Saeure(Kation<MolekulareVerbindung> wasserstoff, Anion<Verbindung> saeurerest) : base("")
        {
            WasserstoffIon = wasserstoff;
            SaeurerestIon = saeurerest;

            GeneriereFormel();
            GeneriereName();
        }

        private void GeneriereFormel()
        {
            //if (Unicodehelfer.GetNumberOfSubscript(SaeurerestIon.GetFormel().Last()) != -1)
            //{
            //    //TODO: Stimmt noch nicht
            //    Formel = $"{WasserstoffIon.GetFormel()}({SaeurerestIon.GetFormel()})";
            //}
            //else
            //{
                
            //}

            Formel = $"{WasserstoffIon.GetFormel()}{SaeurerestIon.GetFormel()}";
        }

        private void GeneriereName()
        {
            // Überprüfe, ob ein Sauerstoff vorhanden ist
            if (Formel.Contains("O") == true)
            {
                //TODO Oxidationsstufe beachten
                Name = $"{WasserstoffIon.Stoff.Name}{SaeurerestIon.GetName().ToLower()}";
            }
            else
            {
                Name = $"{SaeurerestIon.Stoff.Name}wasserstoffsäure";
            }
        }

        public List<(Kation<MolekulareVerbindung>, Anion<Verbindung>)> ErhalteVariantenDerSaerebestandteile()
        {
            List<(Kation<MolekulareVerbindung>, Anion<Verbindung>)> resultat = new List<(Kation<MolekulareVerbindung>, Anion<Verbindung>)>();
            for (int wasserstoffAtome = 1; wasserstoffAtome <= WasserstoffIon.Stoff.AnzahlAtome; wasserstoffAtome++)
            {
                // Bestimme das abgegebene Wasserrstoffion
                MolekulareVerbindung abgegebenesWasserstoffMolekuel = new MolekulareVerbindung(WasserstoffIon.Stoff.BasisElement, wasserstoffAtome);
                Kation<MolekulareVerbindung> abgegebenesWasserstoff = new Kation<MolekulareVerbindung>(abgegebenesWasserstoffMolekuel, wasserstoffAtome);

                // Bestimme das Säurerest
                Anion<Verbindung> säurerestIon = null;
                int wasserstoffInSaererest = WasserstoffIon.Stoff.AnzahlAtome - wasserstoffAtome;
                if (wasserstoffInSaererest == 0)
                {
                    Verbindung saererest = new Verbindung(SaeurerestIon.Stoff.Formel);
                    säurerestIon = new Anion<Verbindung>(saererest, SaeurerestIon.Ladung);
                }
                else
                {
                    // Wasserstoff wird für das Säurerest verwendet
                    Verbindung saererest = null;
                    if (wasserstoffInSaererest == 1)
                    {
                        saererest = new Verbindung("H" + SaeurerestIon.Stoff.Formel);
                    }
                    else
                    {
                        saererest = new Verbindung("H" + Unicodehelfer.GetSubscriptOfNumber(wasserstoffInSaererest) + SaeurerestIon.Stoff.Formel);
                    }
                    säurerestIon = new Anion<Verbindung>(saererest, SaeurerestIon.Ladung + wasserstoffInSaererest);
                }
                resultat.Add((abgegebenesWasserstoff, säurerestIon));
            }
            return resultat;
        }
    }
}
