namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Die theoretische Darstellung der chemischen Elemente
    /// </summary>
    public abstract class Stoff
    {
        public Stoff()
        {
        }

        public abstract string ErhalteName();
        public abstract string ErhalteFormel();
    }
}
