using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen
{
    public class Oxid : Molekularverbindung
    {
        public ElementMolekuel Sauerstoff { get; set; }
        public ElementMolekuel Bindungsmolekuel { get; set; }

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
            _ChemischeFormel += (anzahlMetall == 1) ? metall.Symol : metall.Symol + UnicodeHelfer.GetSubscriptOfNumber(anzahlMetall);
            _ChemischeFormel += (anzahlNichtmetall == 1) ? sauerstoff.Symol : sauerstoff.Symol + UnicodeHelfer.GetSubscriptOfNumber(anzahlNichtmetall);

            // Setze die Eigenschaften des Oxids
            Sauerstoff = new ElementMolekuel(new Elementarverbindung(sauerstoff, anzahlNichtmetall));
            Bindungsmolekuel = new ElementMolekuel(new Elementarverbindung(metall, anzahlMetall));
        }

        /// <summary>
        /// Erstellt ein Oxid aus der chemischen Formel
        /// </summary>
        /// <param name="chemischeFormel"></param>
        public Oxid(string chemischeFormel)
        {
            // Setze die chemische Formel
            _ChemischeFormel = chemischeFormel;

            // Erhalte die Bestandteile aus der chemischen Formel
            List<ElementMolekuel> bestandteile = ErhalteElementMolekueleAusFormel();

            // Das Molekuel darf aktuell nur aus zwei Bestandteile bestehen
            if (bestandteile.Count != 2)
            {
                throw new Exception("Das Oxid darf aktuell nur aus zwei Bestandteilen bestehen");
            }

            foreach (ElementMolekuel molekuele in bestandteile)
            {
                if (molekuele.Stoff.ChemischeFormel.Contains("O"))
                {
                    Sauerstoff = molekuele;
                }
                else
                {
                    Bindungsmolekuel = molekuele;
                }
            }
        }     

        public int ErhalteRestOxidationsstufe(int molekuelLadung)
        {
            // Sauerstoff hat eine Ladung von -2 bei einfachen Verbindungen
            int oxidationsstufeSauerstoff = -2;

            // Berechnung der Oxidationsstufe vom Restelement
            return -((Sauerstoff.Verbindung.AnzahlBindungspartner * oxidationsstufeSauerstoff - molekuelLadung) / Bindungsmolekuel.Verbindung.AnzahlBindungspartner);
        }   
    }
}
