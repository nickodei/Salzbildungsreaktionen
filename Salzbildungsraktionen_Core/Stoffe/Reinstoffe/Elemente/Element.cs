namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente
{
    public abstract class Element : Reinstoff
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Wurzel { get; set; }
        public int Hauptgruppe { get; set; }
        public double Elektronegativitaet { get; set; }

        public Element() : base()
        {
        }

        public override string ErhalteName()
        {
            return Name;
        }

        public override string ErhalteFormel()
        {
            return Symbol;
        }
    }
}
