using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure
{
    public class Saeure : Ionenbindung
    {





        public Kation Wasserstoff => Kation;
        public Anion Saeurerest => Anion;
        public string NameSaeurerest { get; set; }

        public Saeure(string chemischeFormel, Kation wasserstoffKation, Anion saeurerestAnion)
        {
            _ChemischeFormel = chemischeFormel;
            Kation = wasserstoffKation;
            Anion = saeurerestAnion;

            // Falls die Säure ein Oxid als Säurerest besitzt
            if(Anion.Molekuel.Stoff is Oxid)
            {
                (string saureName, string oxidName) = GeneriereNameElementsauerstoffsaeure(Wasserstoff.Ladung, Anion.Molekuel.Stoff as Oxid);

                _Name = saureName;
                NameSaeurerest = oxidName;
            }
            else
            {
                // Normale Benennung der Säure
                if (Anion.Molekuel.Stoff is Elementarverbindung)
                {
                    Elementarverbindung verbindung = Anion.Molekuel.Stoff as Elementarverbindung;
                    NameSaeurerest = verbindung.Name;
                }
                else
                {
                    if (NomenklaturHelfer.UberpruefeObTrivialnameVorhanden(Anion.Molekuel.Stoff.ChemischeFormel))
                    {
                        NameSaeurerest = NomenklaturHelfer.ErhalteTrivialname(Anion.Molekuel.Stoff.ChemischeFormel);
                    }
                    else
                    {
                        NameSaeurerest = Anion.Molekuel.Stoff.Name;
                    }
                }

                _Name = NameSaeurerest + "wasserstoffsäure";
            }
        }

        private (string saureName, string oxidName) GeneriereNameElementsauerstoffsaeure(int anzahlWasserstoffAtome, Oxid oxid)
        {
            string oxidName = null;
            string saureName = null;

            // Es handelt sich um Elemente im Periodensystem, somit geben die 
            // Valenzelektronen über die stabile Oxidationsstufe eine Aussage
            int oxidationsstufeRestelement = oxid.ErhalteRestOxidationsstufe(-anzahlWasserstoffAtome);
            if (oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe != 7 && oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe != 8)
            {
                if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe)
                {
                    // Ist eine gebräuchliche Oxidationsstufe
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Name + "at";
                    }
                    else
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe - 2)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Name + "it";
                    }
                    else
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Wurzel + "it";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe - 4)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = "Hypo" + oxid.Bindungsmolekuel.Verbindung.Element.Name.ToLower() + "it";
                    }
                    else
                    {
                        oxidName = "Hypo" + oxid.Bindungsmolekuel.Verbindung.Element.Wurzel.ToLower() + "it";
                    }
                }
            }
            else
            {
                if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe)
                {
                    // Ist eine gebräuchliche Oxidationsstufe
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = "Per" + oxid.Bindungsmolekuel.Verbindung.Element.Name + "at";
                    }
                    else
                    {
                        oxidName = "Per" + oxid.Bindungsmolekuel.Verbindung.Element.Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe - 2)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Name + "at";
                    }
                    else
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe - 4)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Name.ToLower() + "it";
                    }
                    else
                    {
                        oxidName = oxid.Bindungsmolekuel.Verbindung.Element.Wurzel.ToLower() + "it";
                    }
                }
                else if (oxidationsstufeRestelement == oxid.Bindungsmolekuel.Verbindung.Element.Hauptgruppe - 6)
                {
                    if (String.IsNullOrEmpty(oxid.Bindungsmolekuel.Verbindung.Element.Wurzel))
                    {
                        oxidName = "Hypo" + oxid.Bindungsmolekuel.Verbindung.Element.Name.ToLower() + "it";
                    }
                    else
                    {
                        oxidName = "Hypo" + oxid.Bindungsmolekuel.Verbindung.Element.Wurzel.ToLower() + "it";
                    }
                }
            }

            if (String.IsNullOrEmpty(oxidName))
            {
                throw new Exception("Unbekannter Name des Oxids.");
            }

            if (oxidName.Substring(oxidName.Length - 2).Equals("at"))
            {
                saureName = oxid.Bindungsmolekuel.Verbindung.Element.Name + "säure";
            }
            else if (oxidName.Substring(oxidName.Length - 2).Equals("it"))
            {
                saureName = oxid.Bindungsmolekuel.Verbindung.Element.Name + "ige Säure";
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

            for (int wasserstoffInEster = Wasserstoff.Ladung - 1; wasserstoffInEster >= 0; wasserstoffInEster--)
            {
                // Kation
                Elementarverbindung abgabeWasserstoffVerbindung = new Elementarverbindung(wasserstoff, Wasserstoff.Ladung - wasserstoffInEster);
                Kation abgabeWasserstoff = new Kation(new ElementMolekuel(abgabeWasserstoffVerbindung), Wasserstoff.Ladung - wasserstoffInEster);

                // Anion
                if(wasserstoffInEster == 0)
                {
                    // Das Säurerest hat sich nicht verändert und wird identisch abgegeben
                    Anion abgabeSaeurerest = new Anion(Saeurerest.Molekuel, Saeurerest.Ladung);
                    abgabeSaeurerest.Molekuel.Stoff.SetzteTrivialname(NameSaeurerest);

                    ionisierteSaeurevarianten.Add((abgabeWasserstoff, abgabeSaeurerest));
                }
                else
                {
                    // Das Säurerest beinhaltet nun Wassserstoff Atome 
                    string saeurerestName = null;
                    if (wasserstoffInEster > 1)
                    {
                        saeurerestName = NomenklaturHelfer.Praefix(wasserstoffInEster) + "hydrogen" + NameSaeurerest;
                    }
                    else
                    {
                        saeurerestName = "Hydrogen" + NameSaeurerest;
                    }

                    Elementarverbindung wasserstoffInSaeurerest = new Elementarverbindung(wasserstoff, wasserstoffInEster);
                    Molekularverbindung saeurerest = new Molekularverbindung(wasserstoffInSaeurerest.ChemischeFormel + Saeurerest.Molekuel.Stoff.ChemischeFormel, saeurerestName);
                    MultiElementMolekuel saeurerestmolekuel = new MultiElementMolekuel(saeurerest);

                    Anion abgabeSaeurerest = new Anion(saeurerestmolekuel, -(Wasserstoff.Ladung - wasserstoffInEster));
                    ionisierteSaeurevarianten.Add((abgabeWasserstoff, abgabeSaeurerest));
                }
            }

            return ionisierteSaeurevarianten;
        }

        protected override string GeneriereName()
        {
            throw new NotImplementedException();
        }

        protected override string GeneriereChemischeFormel()
        {
            throw new NotImplementedException();
        }
    }
}
