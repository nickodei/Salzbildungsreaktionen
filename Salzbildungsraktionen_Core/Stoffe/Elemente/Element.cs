namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente
{
    public class Element : IStoff
    {
        public string Name { get; set; }
        public string Formel { get; set; }

        public string Wurzel { get; set; }
        public int Hauptgruppe { get; set; }
        public double Elektronegativitaet { get; set; }

        public Element(string symbol, string name, string wurzel, int hauptgruppe, double elektronegativitaet)
        {
            Name = name;
            Formel = symbol;

            Wurzel = wurzel;
            Hauptgruppe = hauptgruppe;
            Elektronegativitaet = elektronegativitaet;
        }
    }
}
