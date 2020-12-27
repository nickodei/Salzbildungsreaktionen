using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen
{
    public class VerbindungFactory
    {
        public VerbindungFactory()
        {
        }

        #region Ionische Verbindungen

        public Saeure ErstelleSaeure(string chemischeFormel)
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

            // Erstelle das Kation aus der Wasserstoffverbindung
            Elementarverbindung wasserstoffverbindung = new Elementarverbindung(wasserstoff, anzahlProtonen);
            Kation wasserstoffKation = new Kation(new ElementMolekuel(wasserstoffverbindung), anzahlProtonen);

            // Erhalte die Säurerest-Formel aus der Säure-Formel
            string saeureRestFormel = (anzahlProtonen > 1) ? chemischeFormel.Substring(2) : chemischeFormel.Substring(1);

            // Überprüfe, ob das Säurerest ein Nichtmetall oder ein Molekuel ist
            Anion saeurerestAnion = null;
            if (Periodensystem.Instance.UeberpruefeObNichtmetall(saeureRestFormel))
            {
                // Aufgrund dessen, dass Wasserstoff nur 1 Proton abgeben kann, muss nicht darauf geachtet werden
                // ob das Säurerest mehrmals vorhanden ist
                Elementarverbindung saeurerestverbindung = new Elementarverbindung(Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(saeureRestFormel), 1);
                saeurerestAnion = new Anion(new ElementMolekuel(saeurerestverbindung), -anzahlProtonen);
            }
            else
            {
                // Überprüfe, ob die Verbindung ein Oxid ist
                if (saeureRestFormel.Contains("O"))
                {
                    Oxid saeurerestverbindung = new Oxid(saeureRestFormel);
                    saeurerestAnion = new Anion(new MultiElementMolekuel(saeurerestverbindung), -anzahlProtonen);
                }
                else
                {


                    Molekularverbindung saeurerestverbindung = new Molekularverbindung(saeureRestFormel);
                    saeurerestAnion = new Anion(new MultiElementMolekuel(saeurerestverbindung), -anzahlProtonen);
                }
            }

            return new Saeure(chemischeFormel, wasserstoffKation, saeurerestAnion);
        }

        public Lauge ErstelleLauge(string chemischeFormel)
        {
            // Erhalte das Metall aus der Formel
            Metall metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString());
            if (metall == null)
            {
                metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString() + chemischeFormel[1].ToString());
                if (metall == null)
                {
                    throw new Exception("Metall konnte in der Lauge nicht ermittelt werden");
                }
            }

            return new Lauge(metall);
        }

        #endregion
    }
}
