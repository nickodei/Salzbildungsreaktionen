using Salzbildungsreaktionen_Core.Bindungen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente
{
    public class Element : Stoff, IKovalenteBindung
    {
        public string Name { get; set; }
        public string Symol { get; set; }
        public string Wurzel { get; set; }
        public int Hauptgruppe { get; set; }
        public double Elektronegativitaet { get; set; }

        public Element(string symbol, string name, string wurzel, int hauptgruppe, double elektronegativitaet)
        {
            Name = name;
            Symol = symbol;
            Wurzel = wurzel;
            Hauptgruppe = hauptgruppe;
            Elektronegativitaet = elektronegativitaet;
        }

        public override string ErhalteName()
        {
            return Name;
        }

        public override string ErhalteFormel()
        {
            return Symol;
        }

        public bool IstElementMolekuel()
        {
            return false;
        }

        public override string ErhalteAnionName(int ladung)
        {
            return (String.IsNullOrEmpty(Wurzel)) ? $"{Name}id" : $"{Wurzel}id";
        }
    }
}
