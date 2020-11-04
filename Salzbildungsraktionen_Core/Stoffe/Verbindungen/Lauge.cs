using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen.Molekuel;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge
{
    public class Lauge : IStoff
    {
        public string Name { get; set; }
        public string Formel { get; set; }

        public ElementMolekuel MetallMolekuel { get; set; }
        public IMolekuel HydroxidMolekuel { get; set; }

        public Lauge(string chemischeFormel)
        {
            Formel = chemischeFormel;

            Metall metall = null;
            int metallSymbolLenght = 0;
            // Erhalte das Metall aus der Formel
            metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString());
            if(metall == null)
            {
                metall = Periodensystem.Instance.FindeMetallNachAtomsymbol(chemischeFormel[0].ToString() + chemischeFormel[1].ToString());
                if(metall == null)
                {
                    throw new Exception("Metall konnte in der Lauge nicht ermittelt werden");
                }
                else
                {
                    metallSymbolLenght = 2;
                }
            }
            else
            {
                metallSymbolLenght = 1;
            }

            if (UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[metallSymbolLenght]) != -1)
            {
                int anzahlMetallatome = UnicodeHelfer.GetNumberOfSubscript(chemischeFormel[metallSymbolLenght]);
                MetallMolekuel = new ElementMolekuel(anzahlMetallatome, new Teilchen.Atom(metall));
                HydroxidMolekuel = new VerbindungsMolekuel(chemischeFormel.Substring(metallSymbolLenght + 1));
            }
            else
            {
                MetallMolekuel = new ElementMolekuel(1, new Teilchen.Atom(metall));
                HydroxidMolekuel = new VerbindungsMolekuel(chemischeFormel.Substring(metallSymbolLenght));
            }
        }
    }
}
