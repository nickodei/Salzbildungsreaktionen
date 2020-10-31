using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Saeure : Verbindung
    {
        public int AnzahlProtonen { get; set; }
        public Kation<Nichtmetall> WasserstoffIon { get; set; }
        public Anion<Reinstoff> Ester { get; set; }

        public Saeure(string formel) : base()
        {
            //// Überprüfe ob der erste Buchstabe für ein Wasserstoff steht
            //// Wenn nicht, dann gibt es auch keine Säure zum erstellen
            //if (formel[0].Equals('H'))
            //{
            //    bool enthaeltWasserstoffMolekuel = false;

            //    // Hole dir die nächste Stelle nach dem Wasserstoff
            //    // Ist es eine untergestellte Zahl, so gibt es die Anzahl der Wasserstoffatome an
            //    // Ist es keine Zahl, so wird -1 zurückgegeben und wir gehen von einem Wasserstoffatom aus
            //    int anzahlProtonen = UnicodeHelfer.GetNumberOfSubscript(formel[1]);
            //    if (anzahlProtonen == -1)
            //    {
            //        // Setze die Anzahlt der Wasserstoffatome auf 1
            //        enthaeltWasserstoffMolekuel = true;
            //        anzahlProtonen = 1;
            //    }

            //    // Überprüfe, ob es Wasserstoff in der Datenbank gibt
            //    Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            //    if (wasserstoff != null)
            //    {
            //        AnzahlProtonen = anzahlProtonen;
            //        WasserstoffIon = new Kation<Nichtmetall>(wasserstoff);
            //    }

            //    string esterChemischeFormel = "";
            //    if (enthaeltWasserstoffMolekuel)
            //    {
            //        esterChemischeFormel = formel.Substring(1);
            //    }
            //    else
            //    {
            //        esterChemischeFormel = formel.Substring(2);
            //    }



            //    MultiElementMolekuehl saererest = new MultiElementMolekuehl(esterChemischeFormel);
            //    Ester = new Anion<MultiElementMolekuehl>(saererest, -anzahlProtonen);
            //}

            //GeneriereFormel();
            //GeneriereName();
        }

        public Saeure(Kation<ElementMolekuehl> wasserstoff, Anion<MultiElementMolekuehl> saeurerest) : base()
        {
            //WasserstoffIon = wasserstoff;
            //Ester = saeurerest;

            //GeneriereFormel();
            //GeneriereName();
        }

        private void GeneriereFormel()
        {
            //_Formel = $"{WasserstoffIon.GetFormel()}{Ester.GetFormel()}";
        }

        private void GeneriereName()
        {
            //// Überprüfe, ob ein Sauerstoff vorhanden ist
            //if (Formel.Contains("O") == true)
            //{
            //    //TODO Oxidationsstufe beachten
            //    _Name = $"{WasserstoffIon.Stoff.Name}{Ester.GetName().ToLower()}";
            //}
            //else
            //{
            //    _Name = $"{Ester.Stoff.Name}wasserstoffsäure";
            //}
        }

        public List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)> ErhalteVariantenDerSaerebestandteile()
        {
            List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)> resultat = new List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)>();
            //for (int wasserstoffAtome = 1; wasserstoffAtome <= WasserstoffIon.Stoff.AnzahlAtome; wasserstoffAtome++)
            //{
            //    Bestimme das abgegebene Wasserrstoffion
            //    ElementMolekuehl abgegebenesWasserstoffMolekuel = new ElementMolekuehl(WasserstoffIon.Stoff.Element, wasserstoffAtome);
            //    Kation<ElementMolekuehl> abgegebenesWasserstoff = new Kation<ElementMolekuehl>(abgegebenesWasserstoffMolekuel, wasserstoffAtome);

            //    Bestimme das Säurerest
            //    Anion<MultiElementMolekuehl> säurerestIon = null;
            //    int wasserstoffInSaererest = WasserstoffIon.Stoff.AnzahlAtome - wasserstoffAtome;
            //    if (wasserstoffInSaererest == 0)
            //    {
            //        MultiElementMolekuehl saererest = new MultiElementMolekuehl(Ester.Stoff.Formel);
            //        säurerestIon = new Anion<MultiElementMolekuehl>(saererest, Ester.Ladung);
            //    }
            //    else
            //    {
            //        Wasserstoff wird für das Säurerest verwendet
            //        MultiElementMolekuehl saererest = null;
            //        if (wasserstoffInSaererest == 1)
            //        {
            //            saererest = new MultiElementMolekuehl("H" + Ester.Stoff.Formel);
            //        }
            //        else
            //        {
            //            saererest = new MultiElementMolekuehl("H" + UnicodeHelfer.GetSubscriptOfNumber(wasserstoffInSaererest) + Ester.Stoff.Formel);
            //        }
            //        säurerestIon = new Anion<MultiElementMolekuehl>(saererest, Ester.Ladung + wasserstoffInSaererest);
            //    }
            //    resultat.Add((abgegebenesWasserstoff, säurerestIon));
            //}
            return resultat;
        }
    }
}
