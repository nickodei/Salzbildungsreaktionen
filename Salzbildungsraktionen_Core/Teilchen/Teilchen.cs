namespace Salzbildungsreaktionen_Core.Teilchen
{
    public abstract class Teilchen
    {
        public abstract string Name { get; }
        public abstract string ChemischeFormel { get; }
        public abstract double Elektronegativitaet { get; }

        public Teilchen()
        {
        }
    }
}
