using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge
{
    public class Lauge : Molekularverbindung
    {
        public ElementMolekuel Metall { get; set; }
        public MultiElementMolekuel Hydroxid { get; set; }

        public Lauge(Metall metall)
        {
            Metall = new ElementMolekuel(new Elementarverbindung(metall, 1));

            // Erhalte das nichtmetall Saeuerstoff
            Hydroxid = new MultiElementMolekuel(new Oxid("OH"));

            // Erstelle die chemische Formel
            _ChemischeFormel = (metall.Hauptgruppe == 1) ? metall.Symol + Hydroxid.Verbindung.ChemischeFormel : $"{metall.Symol}({Hydroxid.Verbindung.ChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(metall.Hauptgruppe)}";
        }

        public Lauge(string chemischeFormel)
        {
            _ChemischeFormel = chemischeFormel;

            // Erhalte das Metall aus der Formel
            Metall metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString());
            if(metall == null)
            {
                metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString() + chemischeFormel[1].ToString());
                if(metall == null)
                {
                    throw new Exception("Metall konnte in der Lauge nicht ermittelt werden");
                }
            }

            Metall = new ElementMolekuel(new Elementarverbindung(metall, 1));
            Hydroxid = new MultiElementMolekuel(new Oxid("OH"));
        }

        protected override string GeneriereName()
        {
            return Metall.Verbindung.Name + Hydroxid.Verbindung.Name.ToLower();
        }
    }
}
