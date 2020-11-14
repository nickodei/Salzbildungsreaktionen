using Salzbildungsreaktionen_Core.Bindungen;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente
{
    public class Element : Stoff, IKovalenteBindung
    {
        public string Symol { get; set; }

        public string Wurzel { get; set; }
        public int Hauptgruppe { get; set; }
        public double Elektronegativitaet { get; set; }

        public Element(string symbol, string name, string wurzel, int hauptgruppe, double elektronegativitaet)
        {
            Name = name;

            ChemischeFormel = symbol;
            Symol = symbol;

            Wurzel = wurzel;
            Hauptgruppe = hauptgruppe;
            Elektronegativitaet = elektronegativitaet;
        }

        public string ErhalteFormel()
        {
            return Symol;
        }

        public string ErhalteName()
        {
            return Name;
        }

        public bool IstElementMolekuel()
        {
            return false;
        }
    }
}
