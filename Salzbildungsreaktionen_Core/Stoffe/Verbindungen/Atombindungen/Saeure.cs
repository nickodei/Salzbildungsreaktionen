using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure
{
    public class Saeure : Atombindung
    {
        public Molekuel Wasserstoff { get; set; }
        public Molekuel Saeurerest { get; set; }
        public string NameSaurerestAnion { get; set; }

        public Saeure(string chemischeFormel)
        {
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

            if(chemischeFormel.Contains("(") == false)
            {
                // Muss präperiert werden
                if (UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[1]) != -1)
                {
                    if(chemischeFormel.Length > 3 && Periodensystem.Instance.UberpruefeObElement(chemischeFormel.Substring(2)) == false)
                    {
                        chemischeFormel = $"{chemischeFormel.Substring(0, 2)}({chemischeFormel.Substring(2)})₁";
                    }
                }
                else
                {
                    if(chemischeFormel.Length > 2 && Periodensystem.Instance.UberpruefeObElement(chemischeFormel.Substring(1)) == false)
                    {
                        chemischeFormel = $"{chemischeFormel.Substring(0, 1)}({chemischeFormel.Substring(1)})₁";
                    }
                }
            }

            // Generiere die Bestandteile aus der chemischen Formel
            Bestandteile = GeneriereBestandteileAusChemischerFormel(chemischeFormel);

            foreach (Molekuel molekuel in ErhalteAlleMolekuele())
            {
                if(molekuel.Atombindung.IstElementbindung())
                {
                    Element element = molekuel.Atombindung.ErhalteElement();
                    if(element.Symol.Equals("H"))
                    {
                        Wasserstoff = molekuel;
                        continue;
                    }
                }

                Saeurerest = molekuel;
            }

            // Generiere die chemische Formel
            GeneriereName();
            ChemischeFormel = GeneriereChemischeFormelAusBestandteilen(fuerAnzeige: false);
        }

        private (string saureName, string oxidName) GeneriereNameElementsauerstoffsaeure(int anzahlWasserstoffAtome, Oxid oxid)
        {
            string oxidName = null;
            string saureName = null;

            // Es handelt sich um Elemente im Periodensystem, somit geben die 
            // Valenzelektronen über die stabile Oxidationsstufe eine Aussage
            int oxidationsstufeRestelement = oxid.ErhalteRestOxidationsstufe(-anzahlWasserstoffAtome);
            if (oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe != 7 && oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe != 8)
            {
                if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe)
                {
                    // Ist eine gebräuchliche Oxidationsstufe
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Name + "at";
                    }
                    else
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe - 2)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Name + "it";
                    }
                    else
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel + "it";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe - 4)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = "Hypo" + oxid.Bindungspartner.Atombindung.ErhalteElement().Name.ToLower() + "it";
                    }
                    else
                    {
                        oxidName = "Hypo" + oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel.ToLower() + "it";
                    }
                }
            }
            else
            {
                if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe)
                {
                    // Ist eine gebräuchliche Oxidationsstufe
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = "Per" + oxid.Bindungspartner.Atombindung.ErhalteElement().Name + "at";
                    }
                    else
                    {
                        oxidName = "Per" + oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe - 2)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Name + "at";
                    }
                    else
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe - 4)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Name.ToLower() + "it";
                    }
                    else
                    {
                        oxidName = oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel.ToLower() + "it";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungspartner.Atombindung.ErhalteElement().Hauptgruppe - 6)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel))
                    {
                        oxidName = "Hypo" + oxid.Bindungspartner.Atombindung.ErhalteElement().Name.ToLower() + "it";
                    }
                    else
                    {
                        oxidName = "Hypo" + oxid.Bindungspartner.Atombindung.ErhalteElement().Wurzel.ToLower() + "it";
                    }
                }
            }

            if (String.IsNullOrEmpty(oxidName))
            {
                throw new Exception("Unbekannter Name des Oxids.");
            }

            if (oxidName.Substring(oxidName.Length - 2).Equals("at"))
            {
                saureName = oxid.Bindungspartner.Atombindung.ErhalteElement().Name + "säure";
            }
            else if (oxidName.Substring(oxidName.Length - 2).Equals("it"))
            {
                saureName = oxid.Bindungspartner.Atombindung.ErhalteElement().Name + "ige Säure";
            }
            else
            {
                throw new Exception("Name konnte nicht ermittelt werden. Unbekannte Endung des Oxids.");
            }

            return (saureName, oxidName);
        }

        public List<(Kation wasserstoffIon, Anion saeurerestIon)> ErhalteIonisierteSaeurevarianten()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> ionisierteSaeurevarianten = new List<(Kation wasserstoffIon, Anion saeurerestIon)>();

            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            if (wasserstoff == null)
            {
                throw new Exception("Wasserstoff konnte im Periodensystem nicht gefunden werden");
            }

            for (int wasserstoffInEster = Wasserstoff.Atombindung.AnzahlAtome - 1; wasserstoffInEster >= 0; wasserstoffInEster--)
            {
                // Kation
                Atombindung wasserstoffbindung = new Atombindung(wasserstoff, Wasserstoff.Atombindung.AnzahlAtome - wasserstoffInEster);
                Kation abgabeWasserstoff = new Kation(new Molekuel(wasserstoffbindung, 1), Wasserstoff.Atombindung.AnzahlAtome - wasserstoffInEster);

                // Anion
                if(wasserstoffInEster == 0)
                {
                    // Das Säurerest hat sich nicht verändert und wird identisch abgegeben
                    Anion abgabeSaeurerest = new Anion(Saeurerest, -(Wasserstoff.Atombindung.AnzahlAtome - wasserstoffInEster));
                    abgabeSaeurerest.Molekuel.Atombindung.SetzeTrivialname(NameSaurerestAnion);

                    ionisierteSaeurevarianten.Add((abgabeWasserstoff, abgabeSaeurerest));
                }
                else
                {
                    // Das Säurerest beinhaltet nun Wassserstoff Atome 
                    string saeurerestName = null;
                    if (wasserstoffInEster > 1)
                    {
                        saeurerestName = NomenklaturHelfer.Praefix(wasserstoffInEster) + "hydrogen" + NameSaurerestAnion;
                    }
                    else
                    {
                        saeurerestName = "Hydrogen" + NameSaurerestAnion;
                    }

                    Atombindung wasserstoffbindungInSaeurerest = new Atombindung(wasserstoff, wasserstoffInEster);
                    string saurerrestFormel = wasserstoffbindungInSaeurerest.ChemischeFormel + Saeurerest.Atombindung.ChemischeFormel;

                    Atombindung saeurerestbindung = new Atombindung(saurerrestFormel, wasserstoffbindungInSaeurerest, Saeurerest.Atombindung);
                    saeurerestbindung.SetzeTrivialname(saeurerestName);

                    Anion abgabeSaeurerest = new Anion(new Molekuel(saeurerestbindung, 1), -(Wasserstoff.Atombindung.AnzahlAtome - wasserstoffInEster));
                    ionisierteSaeurevarianten.Add((abgabeWasserstoff, abgabeSaeurerest));
                }
            }

            return ionisierteSaeurevarianten;
        }

        private void GeneriereName()
        {
            // Falls die Säure ein Oxid als Säurerest besitzt
            if (Saeurerest.Atombindung is Oxid)
            {
                (string saureName, string oxidName) = GeneriereNameElementsauerstoffsaeure(Wasserstoff.Atombindung.AnzahlAtome, Saeurerest.Atombindung as Oxid);

                Name = saureName;
                NameSaurerestAnion = oxidName;
            }
            else
            {
                // Normale Benennung der Säure
                if (Saeurerest.Atombindung.IstElementbindung())
                {
                    if(!String.IsNullOrEmpty(Saeurerest.Atombindung.ErhalteElement().Wurzel))
                    {
                        NameSaurerestAnion = Saeurerest.Atombindung.ErhalteElement().Wurzel + "id";
                    }
                    else
                    {
                        // Nimm den Namen des erstel Bestandteiles
                        NameSaurerestAnion = Saeurerest.Atombindung.ErhalteElement().Name + "id";
                    }
                }
                else
                {
                    if (NomenklaturHelfer.UberpruefeObTrivialnameVorhanden(Saeurerest.Atombindung.ChemischeFormel))
                    {
                        NameSaurerestAnion = NomenklaturHelfer.ErhalteTrivialname(Saeurerest.Atombindung.ChemischeFormel);
                    }
                    else
                    {
                        NameSaurerestAnion = Saeurerest.Atombindung.Name;
                    }
                }

                Name = NameSaurerestAnion + "wasserstoffsäure";
            }
        }
    }
}
