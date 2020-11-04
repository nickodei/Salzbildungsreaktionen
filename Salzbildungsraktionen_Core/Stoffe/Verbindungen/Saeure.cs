using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using Salzbildungsreaktionen_Core.Teilchen.Molekuel;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure
{
    public class Saeure : IStoff
    {
        public string Name { get; set; }
        public string Formel { get; set; }

        public ElementMolekuel WasserstoffMolekuel { get; set; }
        public IMolekuel SaeurerestMolekuel { get; set; }

        public Saeure(string chemischeFormel)
        {
            Formel = chemischeFormel;

            // Überprüfe, ob die Formel mit einem Wasserstoffatom beginnt
            if (chemischeFormel[0].Equals('H') == false)
            {
                throw new Exception("Die Säureformel muss mit mindestens einem Wasserstoffatom beginnen");
            }

            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            if(wasserstoff == null)
            {
                throw new Exception("Wasserstoff konnte im Periodensystem nicht gefunden werden");
            }

            string restFormel = null;

            // Überprüfe, ob die Anzahl der Wasserstoffatome angegeben ist
            if (UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[1]) != -1)
            {
                int anzahlWasserstoffAtome = UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[1]);
                WasserstoffMolekuel = new ElementMolekuel(anzahlWasserstoffAtome, new Atom(wasserstoff));

                restFormel = chemischeFormel.Substring(2);
            }
            else
            {
                WasserstoffMolekuel = new ElementMolekuel(1, new Atom(wasserstoff));

                restFormel = chemischeFormel.Substring(1);
            }

            Nichtmetall restElement = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(restFormel);
            if (restElement != null)
            {
                SaeurerestMolekuel = new ElementMolekuel(1, new Atom(restElement));
            }
            else
            {
                SaeurerestMolekuel = new VerbindungsMolekuel(restFormel);
            }
        }

        public List<(Kation wasserstoffIon, Anion saeurerestIon)> ErhalteIonisierteSaeurevarianten()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> ionisierteSaeurevarianten = new List<(Kation wasserstoffIon, Anion saeurerestIon)>();

            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            if (wasserstoff == null)
            {
                throw new Exception("Wasserstoff konnte im Periodensystem nicht gefunden werden");
            }

            for (int wasserstoffAtomeInEster = WasserstoffMolekuel.Anzahl - 1; wasserstoffAtomeInEster >= 0; wasserstoffAtomeInEster--)
            {
                Kation wasserstoffIon = new Kation(new ElementMolekuel(WasserstoffMolekuel.Anzahl - wasserstoffAtomeInEster, new Atom(wasserstoff)));
                
                Anion saeurerestIon = null;
                if(wasserstoffAtomeInEster == 0)
                {
                    saeurerestIon = new Anion(SaeurerestMolekuel, -(WasserstoffMolekuel.Anzahl - wasserstoffAtomeInEster));                  
                }
                else
                {
                    string neuesSaeurerestFormel = new ElementMolekuel(wasserstoffAtomeInEster, new Atom(wasserstoff)).Formel + SaeurerestMolekuel.Formel;
                    VerbindungsMolekuel neuesSaeurerest = new VerbindungsMolekuel(neuesSaeurerestFormel);

                    saeurerestIon = new Anion(neuesSaeurerest, -(WasserstoffMolekuel.Anzahl - wasserstoffAtomeInEster));
                }

                ionisierteSaeurevarianten.Add((wasserstoffIon, saeurerestIon));
            }

            return ionisierteSaeurevarianten;
        }
    }
}
