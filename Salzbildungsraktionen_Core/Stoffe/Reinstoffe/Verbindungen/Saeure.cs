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

            Name = $"{WasserstoffIon.GetName()}{SaeurerestIon.GetName().ToLower()}";
            Formel = $"{WasserstoffIon.GetFormel()}{SaeurerestIon.GetFormel()}";
        }

        public Saeure(Kation<MolekulareVerbindung> wasserstoff, Anion<Verbindung> saeurerest) : base("")
        {
            WasserstoffIon = wasserstoff;
            SaeurerestIon = saeurerest;

            Name = $"{WasserstoffIon.GetName()}{SaeurerestIon.GetName().ToLower()}";

            if(Unicodehelfer.GetNumberOfSubscript(SaeurerestIon.GetFormel().Last()) != -1)
            {
                //TODO: Stimmt noch nicht
                Formel = $"{WasserstoffIon.GetFormel()}({SaeurerestIon.GetFormel()})";
            }
            else
            {
                Formel = $"{WasserstoffIon.GetFormel()}{SaeurerestIon.GetFormel()}";
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


        public static List<Saeure> ErhalteAlleSäurevarianten(string formel)
        {
            List<Saeure> säureVarianten = new List<Saeure>();

            // Überprüfe ob der erste Buchstabe für ein Wasserstoff steht
            // Wenn nicht, dann gibt es auch keine Säure zum erstellen
            if (!formel[0].Equals('H'))
            {
                return null;
            }

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
                for (int counter = anzahlWasserstoff; counter >= 1; counter--)
                {
                    // Erstelle das Wasserstoffmolekühl für die Säure
                    MolekulareVerbindung wasserstoffMolekuehl = new MolekulareVerbindung(wasserstoff, counter);
                    Kation<MolekulareVerbindung> wasserstoffIon = new Kation<MolekulareVerbindung>(wasserstoffMolekuehl, wasserstoff.ErhalteLadung());

                    string saereRestFormel = "";

                    // Vorhandener Wasserstoff für das Säurerestion
                    int wasserstoffInSaererest = anzahlWasserstoff - counter;
                    if(wasserstoffInSaererest == 0)
                    {
                        // Kein Wasserstoff für das Säurerest vorhanden
                        if(enthaeltWasserstoffMolekuel)
                        {
                            saereRestFormel = formel.Substring(1);
                        }
                        else
                        {
                            saereRestFormel = formel.Substring(2);
                        }
                    }
                    else
                    {
                        // Wasserstoff wird für das Säurerest verwendet
                        if(wasserstoffInSaererest == 1)
                        {
                            // Bei der abgabe des Wasserstoffes gibt es genau ein Wasserstoff für das Säurerestion
                            saereRestFormel = "H" + formel.Substring(2);
                        }
                        else
                        {
                            // Bei der abgabe des Wasserstoffes gibt es mehrere Wasserstoffatome für das Säurerestion
                            saereRestFormel = "H" + Unicodehelfer.GetSubscriptOfNumber(counter) + formel.Substring(2);
                        }
                    }

                    Verbindung saererest = new Verbindung(saereRestFormel);
                    Anion<Verbindung> säurerestIon = new Anion<Verbindung>(saererest, -anzahlWasserstoff + wasserstoffInSaererest);

                    säureVarianten.Add(new Saeure(wasserstoffIon, säurerestIon));                    
                }
            }

            return säureVarianten;
        }
    }
}
