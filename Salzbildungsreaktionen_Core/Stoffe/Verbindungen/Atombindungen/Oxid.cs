using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen
{
    public class Oxid : Atombindung
    {
        public Molekuel Sauerstoff { get; set; }
        public Molekuel Bindungspartner { get; set; }

        /// <summary>
        ///  Erstellt ein standart Metalloxid
        /// </summary>
        /// <param name="metall"></param>
        public Oxid(Metall metall)
        {
            // Erhalte das Nichtmetall-Saeuerstoff
            Nichtmetall sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");
            if(sauerstoff != null)
            {
                // Berechne die Anzahl der benötigen Atome
                (int anzahlMetall, int anzahlSauerstoff) = MolekuelHelfer.BerechneAnzahlDerMolekuele(metall, sauerstoff);

                // Füge die Elemente den Bestandteilen hinzu
                AddBestandteil(metall, anzahlMetall);
                AddBestandteil(sauerstoff, anzahlSauerstoff);
            }

            Sauerstoff = ErhalteMolekuel(sauerstoff);
            Bindungspartner = ErhalteMolekuel(metall);

            Name = GeneriereNameErsterOrdnung();
            ChemischeFormel = GeneriereChemischeFormelAusBestandteilen();
        }

        /// <summary>
        /// Erstellt ein Oxid aus der chemischen Formel
        /// </summary>
        /// <param name="chemischeFormel"></param>
        public Oxid(string chemischeFormel)
        {
            // Setze die chemische Formel
            ChemischeFormel = chemischeFormel;

            // Generiert die Bestandteile aus der chemischen Formel
            Bestandteile = GeneriereBestandteileAusChemischerFormel();

            // Generiere den Namen aus den Bestandteilen
            Name = GeneriereNameErsterOrdnung();

            //// Das Molekuel darf aktuell nur aus zwei Bestandteile bestehen
            //if (Bestandteile.Count != 2)
            //{
            //    throw new Exception("Das Oxid darf aktuell nur aus zwei Bestandteilen bestehen");
            //}

            Nichtmetall sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");
            if(sauerstoff != null)
            {
                Sauerstoff = ErhalteMolekuel(sauerstoff);
            }

            foreach(Element[] bestandteil in Bestandteile)
            {
                if(bestandteil[0].Symol.Equals("O") == false)
                {
                    Bindungspartner = ErhalteMolekuel(bestandteil[0]);
                    break;
                }
            }
        }     

        public int ErhalteRestOxidationsstufe(int molekuelLadung)
        {
            // Sauerstoff hat eine Ladung von -2 bei einfachen Verbindungen
            int oxidationsstufeSauerstoff = -2;

            // Berechnung der Oxidationsstufe vom Restelement
            return -((Sauerstoff.Atombindung.AnzahlAtome * oxidationsstufeSauerstoff - molekuelLadung) / Bindungspartner.Atombindung.AnzahlAtome);
        }   
    }
}
