using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using System;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge
{
    public class Lauge : MolekulareVerbindung
    {
        public Metall Metall { get; set; }
        public Oxid Hydroxid { get; set; }

        public Lauge(Metall metall)
        {
            Metall = metall;

            // Erhalte das nichtmetall Saeuerstoff
            Hydroxid = new Oxid("OH");

            // Erstelle die chemische Formel
            ChemischeFormel = (Metall.Hauptgruppe == 1) ? Metall.Symol + Hydroxid.ChemischeFormel : $"{Metall.Symol}({Hydroxid.ChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(Metall.Hauptgruppe)}";
        }

        public Lauge(string chemischeFormel)
        {
            ChemischeFormel = chemischeFormel;

            // Erhalte das Metall aus der Formel
            Metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString());
            if(Metall == null)
            {
                Metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString() + chemischeFormel[1].ToString());
                if(Metall == null)
                {
                    throw new Exception("Metall konnte in der Lauge nicht ermittelt werden");
                }
            }

            Hydroxid = new Oxid("OH");
        }

        public Molekuel ErhalteMetallMolekuel()
        {
            return GeneriereMolekuele(Metall).FirstOrDefault();
        }

        public Molekuel ErhalteHydroxidMolekuel()
        {
            return GeneriereMolekuele(Hydroxid).FirstOrDefault();
        }

        public override string ErhalteName()
        {
            return Metall.ErhalteName() + Hydroxid.ErhalteName().ToLower();
        }
    }
}
