using Salzbildungsreaktionen_Core.Bindungen;
using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure
{
    public class Saeure : MolekulareVerbindung
    {
        public Element Wasserstoff { get; set; }
        public IKovalenteBindung Saeurerest { get; set; }

        public Saeure(string chemischeFormel)
        {
            ChemischeFormel = chemischeFormel;

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

            // Setze den Wasserstoff
            Wasserstoff = wasserstoff;

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

            // Erhalte die Säurerest-Formel aus der Säure-Formel
            string saeureRestFormel = (anzahlProtonen > 1) ? chemischeFormel.Substring(2) : chemischeFormel.Substring(1);

            // Überprüfe, ob das Säurerest ein Nichtmetall oder ein Molekuel ist
            if(Periodensystem.Instance.UeberpruefeObNichtmetall(saeureRestFormel))
            {
                Saeurerest = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(saeureRestFormel);
            }
            else
            {
                // Überprüfe, ob die Verbindung ein Oxid ist
                if(saeureRestFormel.Contains("O"))
                {
                    Saeurerest = new Oxid(saeureRestFormel);
                }
                else
                {
                    Saeurerest = new MolekulareVerbindung(saeureRestFormel);
                }
            }

            Name = GeneriereSaeurename();
        }

        public Molekuel ErhalteWasserstoffMolekuel()
        {
            List<Molekuel> bestandteile = GeneriereMolekuele();
            return bestandteile.Where(x => x.Bindung.ErhalteFormel().Equals("H") == true).FirstOrDefault();
        }

        public Molekuel ErhalteSaeurerestMolekuel()
        {
            List<Molekuel> bestandteile = GeneriereMolekuele();
            return bestandteile.Where(x => x.Bindung.ErhalteFormel().Equals("H") == false).FirstOrDefault();
        }

        /// <summary>
        /// Generiert den Namen des Salzes
        /// </summary>
        /// <returns></returns>
        public string GeneriereSaeurename()
        {
            Molekuel wasserstoff = ErhalteWasserstoffMolekuel();

            if (Saeurerest is Oxid)
            {
                Oxid oxid = Saeurerest as Oxid;

                string oxidName = oxid.ErhalteAnionenName(-wasserstoff.Anzahl);
                if (oxidName.Substring(oxidName.Length - 2).Equals("at"))
                {
                    return oxid.Bindungselement.Name + "säure";
                }
                else if(oxidName.Substring(oxidName.Length - 2).Equals("it"))
                {
                    return oxid.Bindungselement.Name + "ige Säure";
                }
            }
            else if(Saeurerest is Molekuel)
            {
                Molekuel molekuel = Saeurerest as Molekuel;
                if(molekuel.Bindung.IstElementMolekuel())
                {
                    return molekuel.Bindung.ErhalteName() + "wasserstoffsäure";
                }
            }
            else if(Saeurerest is Element)
            {
                Element element = Saeurerest as Element;
                return element.Name + "wasserstoffsäure";
            }

            return "?";
        }

        public List<(Kation wasserstoffIon, Anion saeurerestIon)> ErhalteIonisierteSaeurevarianten()
        {
            List<(Kation wasserstoffIon, Anion saeurerestIon)> ionisierteSaeurevarianten = new List<(Kation wasserstoffIon, Anion saeurerestIon)>();

            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            if (wasserstoff == null)
            {
                throw new Exception("Wasserstoff konnte im Periodensystem nicht gefunden werden");
            }

            Molekuel wasserstoffMolekuel = ErhalteWasserstoffMolekuel();
            for (int wasserstoffAtomeInEster = wasserstoffMolekuel.Anzahl - 1; wasserstoffAtomeInEster >= 0; wasserstoffAtomeInEster--)
            {
                Kation wasserstoffIon = new Kation(new Molekuel(wasserstoff, wasserstoffMolekuel.Anzahl - wasserstoffAtomeInEster));
                
                Anion saeurerestIon = null;
                if(wasserstoffAtomeInEster == 0)
                {
                    saeurerestIon = new Anion(new Molekuel(Saeurerest, 1), -(wasserstoffMolekuel.Anzahl - wasserstoffAtomeInEster));                  
                }
                else
                {
                    string wasserstoffFormel = (wasserstoffAtomeInEster == 1) ? wasserstoff.Symol : wasserstoff.Symol + UnicodeHelfer.GetSubscriptOfNumber(wasserstoffAtomeInEster);
                    string saeurerestFormel = wasserstoffFormel + Saeurerest.ErhalteFormel();

                    MolekulareVerbindung verbindung = null;
                    if (Saeurerest is Oxid)
                    {
                        Oxid oxid = Saeurerest as Oxid;
                        string oxidName = oxid.ErhalteAnionenName(-wasserstoffMolekuel.Anzahl).ToLower();

                        string trivialname = (wasserstoffAtomeInEster == 1) ? $"hydrogen{oxidName}" : $"{NomenklaturHelfer.Praefix(wasserstoffAtomeInEster)}hydrogen{oxidName}";
                        verbindung = new MolekulareVerbindung(saeurerestFormel, trivialname);
                    }
                    else
                    {
                        verbindung = new MolekulareVerbindung(saeurerestFormel, wasserstoff, Saeurerest);
                    }

                    saeurerestIon = new Anion(new Molekuel(verbindung, 1), -(wasserstoffMolekuel.Anzahl - wasserstoffAtomeInEster));
                }

                ionisierteSaeurevarianten.Add((wasserstoffIon, saeurerestIon));
            }

            return ionisierteSaeurevarianten;
        }
    }
}
