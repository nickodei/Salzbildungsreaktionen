using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente
{
    public class Element : Stoff
    {
        public string Symol => ChemischeFormel;
        public string Wurzel { get; set; }
        public int Hauptgruppe { get; set; }
        public double Elektronegativitaet { get; set; }

        public Element(string symbol, string name, string wurzel, int hauptgruppe, double elektronegativitaet)
        {
            Name = name;
            ChemischeFormel = symbol;

            Wurzel = wurzel;
            Hauptgruppe = hauptgruppe;
            Elektronegativitaet = elektronegativitaet;
        }
    }
}
