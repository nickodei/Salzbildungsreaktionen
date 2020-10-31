namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public abstract class Verbindung : Reinstoff
    {
        public string Verbindungsname { get; set; }
        public string ChemischeFormel { get; set; }

        public Verbindung() : base()
        {
        }

        public override string ErhalteName()
        {
            return Verbindungsname;
        }

        public override string ErhalteFormel()
        {
            return ChemischeFormel;
        }
    }
}
