using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen
{
    public class Oxid : MolekulareVerbindung
    {
        public Nichtmetall Sauerstoff { get; set; }
        public Element Bindungselement { get; set; }

        /// <summary>
        ///  Erstellt ein standart Metalloxid
        /// </summary>
        /// <param name="metall"></param>
        public Oxid(Metall metall)
        {
            // Erhalte das nichtmetall Saeuerstoff
            Nichtmetall sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");

            // Berechne die Anzahl der benötigen Atome
            (int anzahlMetall, int anzahlNichtmetall) = MolekuelHelfer.BerechneAnzahlDerMolekuele(metall, sauerstoff);

            // Erstelle die chemische Formel
            ChemischeFormel += (anzahlMetall == 1) ? metall.Symol : metall.Symol + UnicodeHelfer.GetSubscriptOfNumber(anzahlMetall);
            ChemischeFormel += (anzahlNichtmetall == 1) ? sauerstoff.Symol : sauerstoff.Symol + UnicodeHelfer.GetSubscriptOfNumber(anzahlNichtmetall);

            // Setze die Eigenschaften des Oxids
            Sauerstoff = sauerstoff;
            Bindungselement = metall;
        }

        /// <summary>
        /// Erstellt ein Oxid aus der chemischen Formel
        /// </summary>
        /// <param name="chemischeFormel"></param>
        public Oxid(string chemischeFormel)
        {
            // Setze die chemische Formel
            ChemischeFormel = chemischeFormel;

            // Erhalte die Bestandteile aus der chemischen Formel
            List<Molekuel> bestandteile = GeneriereMolekuele();

            // Das Molekuel darf aktuell nur aus zwei Bestandteile bestehen
            if (bestandteile.Count != 2)
            {
                throw new Exception("Das Oxid darf aktuell nur aus zwei Bestandteilen bestehen");
            }

            foreach (Molekuel molekuele in bestandteile)
            {
                if (molekuele.Bindung.ErhalteFormel().Equals("O"))
                {
                    Sauerstoff = molekuele.Bindung as Nichtmetall;
                }
                else
                {
                    Bindungselement = molekuele.Bindung as Element;
                }
            }
        }

        public Molekuel ErhalteSauerstoffMolekuel()
        {
            return GeneriereMolekuele(Sauerstoff).FirstOrDefault();
        }

        public Molekuel ErhalteBindungselementMolekuel()
        {
            return GeneriereMolekuele(Bindungselement).FirstOrDefault();
        }

        public override string ErhalteName()
        {
            if(String.IsNullOrEmpty(Name))
            {
                Molekuel sauerstoffMolekuel = ErhalteSauerstoffMolekuel();
                Molekuel bindungselementMolekuel = ErhalteBindungselementMolekuel();

                if (bindungselementMolekuel.Anzahl > 1)
                {
                    if (bindungselementMolekuel.Bindung.ErhalteFormel().Equals("H"))
                    {
                        Name += NomenklaturHelfer.Praefix(bindungselementMolekuel.Anzahl) + Bindungselement.Wurzel.ToLower();
                    }
                    else
                    {
                        Name += NomenklaturHelfer.Praefix(bindungselementMolekuel.Anzahl) + Bindungselement.Name.ToLower();
                    }
                }
                else
                {
                    if (bindungselementMolekuel.Bindung.ErhalteFormel().Equals("H"))
                    {
                        Name += Bindungselement.Wurzel;
                    }
                    else
                    {
                        Name += Bindungselement.Name;
                    }
                }

                if (sauerstoffMolekuel.Anzahl > 1)
                {
                    Name += NomenklaturHelfer.Praefix(sauerstoffMolekuel.Anzahl).ToLower() + "oxid";
                }
                else
                {
                    Name += "oxid";
                }
            }

            return Name;
        }

        public int ErhalteRestOxidationsstufe(int molekuelLadung)
        {
            Molekuel sauerstoffMolekuel = ErhalteSauerstoffMolekuel();
            Molekuel bindungselementMolekuel = ErhalteBindungselementMolekuel();

            // Sauerstoff hat eine Ladung von -2 bei einfachen Verbindungen
            int oxidationsstufeSauerstoff = -2;

            // Berechnung der Oxidationsstufe vom Restelement
            return -((sauerstoffMolekuel.Anzahl * oxidationsstufeSauerstoff - molekuelLadung) / bindungselementMolekuel.Anzahl);
        }

        public string ErhalteAnionenName(int molekuelLadung)
        {
            // Es handelt sich um Elemente im Periodensystem, somit geben die Valenzelektronen über
            // die stabile Oxidationsstufe eine Aussage
            int oxidationsstufeRestelement = ErhalteRestOxidationsstufe(molekuelLadung);
            if (Bindungselement.Hauptgruppe != 7 && Bindungselement.Hauptgruppe != 8)
            {
                if(oxidationsstufeRestelement == Bindungselement.Hauptgruppe)
                {
                    // Ist eine gebräuchliche Oxidationsstufe
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return Bindungselement.Name + "at";
                    }
                    else
                    {
                        return Bindungselement.Wurzel + "at";
                    }
                }
                else if(oxidationsstufeRestelement == Bindungselement.Hauptgruppe - 2)
                {
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return Bindungselement.Name + "it";
                    }
                    else
                    {
                        return Bindungselement.Wurzel + "it";
                    }
                }
                else if(oxidationsstufeRestelement == Bindungselement.Hauptgruppe - 4)
                {
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return "Hypo" + Bindungselement.Name.ToLower() + "it";
                    }
                    else
                    {
                        return "Hypo" + Bindungselement.Wurzel.ToLower() + "it";
                    }
                }
            }
            else
            {
                if (oxidationsstufeRestelement == Bindungselement.Hauptgruppe)
                {
                    // Ist eine gebräuchliche Oxidationsstufe
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return "Per" + Bindungselement.Name + "at";
                    }
                    else
                    {
                        return "Per" + Bindungselement.Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == Bindungselement.Hauptgruppe - 2)
                {
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return Bindungselement.Name + "at";
                    }
                    else
                    {
                        return Bindungselement.Wurzel + "at";
                    }
                }
                else if (oxidationsstufeRestelement == Bindungselement.Hauptgruppe - 4)
                {
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return Bindungselement.Name.ToLower() + "it";
                    }
                    else
                    {
                        return Bindungselement.Wurzel.ToLower() + "it";
                    }
                }
                else if (oxidationsstufeRestelement == Bindungselement.Hauptgruppe - 6)
                {
                    if (String.IsNullOrEmpty(Bindungselement.Wurzel))
                    {
                        return "Hypo" + Bindungselement.Name.ToLower() + "it";
                    }
                    else
                    {
                        return "Hypo" + Bindungselement.Wurzel.ToLower() + "it";
                    }
                }
            }

            return "?";
        }
    }
}
