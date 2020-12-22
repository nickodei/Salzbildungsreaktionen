using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure
{
    public class Saeure : Molekularverbindung
    {
        public Elementarverbindung Wasserstoffverbindung { get; }
        public Verbindung Saeurerestverbindung { get; set; }

        protected string _NameSaeurerest;
        public string NameSaeurerest
        {
            get
            {
                if (String.IsNullOrEmpty(_NameSaeurerest))
                {
                    GeneriereName();
                }

                return _NameSaeurerest;
            }
        }


        public Saeure(string chemischeFormel)
        {
            _ChemischeFormel = chemischeFormel;

            // Überprüfe, ob die Formel mit einem Wasserstoffatom beginnt
            if (chemischeFormel[0].Equals('H') == false)
            {
                throw new Exception("Die Säureformel muss mit mindestens einem Wasserstoffatom beginnen");
            }

            // Überprüfe, ob des den Stoff Wasserstoff im Periodensystem gibt
            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            if (wasserstoff == null)
            {
                throw new Exception("Wasserstoff konnte im Periodensystem nicht gefunden werden");
            }

            // Überprüfe, ob die Anzahl der Wasserstoffatome angegeben ist
            int anzahlProtonen;
            if (UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[1]) != -1)
            {
                anzahlProtonen = UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[1]);
            }
            else
            {
                anzahlProtonen = 1;
            }

            // Setze die Wasserstoffverbindung
            Wasserstoffverbindung = new Elementarverbindung(wasserstoff, anzahlProtonen);

            // Erhalte die Säurerest-Formel aus der Säure-Formel
            string saeureRestFormel = (anzahlProtonen > 1) ? chemischeFormel.Substring(2) : chemischeFormel.Substring(1);

            // Überprüfe, ob das Säurerest ein Nichtmetall oder ein Molekuel ist
            if(Periodensystem.Instance.UeberpruefeObNichtmetall(saeureRestFormel))
            {
                // Aufgrund dessen, dass Wasserstoff nur 1 Proton abgeben kann, muss nicht darauf geachtet werden
                // ob das Säurerest mehrmals vorhanden ist
                Saeurerestverbindung = new Elementarverbindung(Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(saeureRestFormel), 1);
            }
            else
            {
                // Überprüfe, ob die Verbindung ein Oxid ist
                if(saeureRestFormel.Contains("O"))
                {
                    Saeurerestverbindung = new Oxid(saeureRestFormel);
                }
                else
                {


                    Saeurerestverbindung = new Molekularverbindung(saeureRestFormel);
                }
            }

            GeneriereName();
        }

        protected override string GeneriereName()
        {
            if (Saeurerestverbindung is Oxid)
            {
                Oxid oxid = Saeurerestverbindung as Oxid;

                (string saurename, string oxidname) = GeneriereNameElementsauerstoffsaeure(Wasserstoffverbindung.AnzahlBindungspartner, oxid);

                _NameSaeurerest = oxidname;

                return saurename;
            }
            else if (Saeurerestverbindung is Elementarverbindung)
            {
                Elementarverbindung verbindung = Saeurerestverbindung as Elementarverbindung;
                _NameSaeurerest = verbindung.Name;
            }
            else
            {
                if (NomenklaturHelfer.UberpruefeObTrivialnameVorhanden(Saeurerestverbindung.ChemischeFormel))
                {
                    _NameSaeurerest = NomenklaturHelfer.ErhalteTrivialname(Saeurerestverbindung.ChemischeFormel);
                }
                else
                {
                    _NameSaeurerest = Saeurerestverbindung.Name;
                }               
            }

            return _NameSaeurerest + "wasserstoffsäure";
        }

        public List<(Kation wasserstoffIon, Anion saeurerestIon)> ErhalteIonisierteSaeurevarianten()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> ionisierteSaeurevarianten = new List<(Kation wasserstoffIon, Anion saeurerestIon)>();

            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            if (wasserstoff == null)
            {
                throw new Exception("Wasserstoff konnte im Periodensystem nicht gefunden werden");
            }

            for (int wasserstoffAtomeInEster = Wasserstoffverbindung.AnzahlBindungspartner - 1; wasserstoffAtomeInEster >= 0; wasserstoffAtomeInEster--)
            {
                // Kation
                Elementarverbindung wasserstoffverbindung = new Elementarverbindung(wasserstoff, Wasserstoffverbindung.AnzahlBindungspartner - wasserstoffAtomeInEster);
                Kation wasserstoffIon = new Kation(new ElementMolekuel(wasserstoffverbindung));

                // Anion
                Molekuel saeurerestmolekuel = null;
                if (wasserstoffAtomeInEster == 0)
                {
                    if (Saeurerestverbindung is Elementarverbindung)
                    {
                        var sauererestverbindung = Saeurerestverbindung as Elementarverbindung;
                        sauererestverbindung.SetzteTrivialname(NameSaeurerest);

                        saeurerestmolekuel = new ElementMolekuel(sauererestverbindung);
                    }
                    else
                    {
                        var sauererestverbindung = Saeurerestverbindung as Molekularverbindung;
                        sauererestverbindung.SetzteTrivialname(NameSaeurerest);

                        saeurerestmolekuel = new MultiElementMolekuel(sauererestverbindung);
                    }
                }
                else
                {
                    Elementarverbindung wasserstoffInSaeurerest = new Elementarverbindung(wasserstoff, wasserstoffAtomeInEster);

                    string saeurerestName = null;
                    if(wasserstoffAtomeInEster > 1)
                    {
                        saeurerestName = NomenklaturHelfer.Praefix(wasserstoffAtomeInEster) + "hydrogen" + NameSaeurerest;
                    }
                    else
                    {
                        saeurerestName = "Hydrogen" + NameSaeurerest;
                    }

                    Molekularverbindung saeurerest = new Molekularverbindung(wasserstoffInSaeurerest.ChemischeFormel + Saeurerestverbindung.ChemischeFormel, saeurerestName);
                    saeurerestmolekuel = new MultiElementMolekuel(saeurerest);
                }

                Anion saeurerestIon = new Anion(saeurerestmolekuel, -(Wasserstoffverbindung.AnzahlBindungspartner - wasserstoffAtomeInEster));
                ionisierteSaeurevarianten.Add((wasserstoffIon, saeurerestIon));
            }

            return ionisierteSaeurevarianten;
        }
    }
}
