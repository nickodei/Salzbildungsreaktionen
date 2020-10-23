namespace Salzbildungsreaktionen_Core.Stoffe
{
    public abstract class Stoff
    {
        /// <summary>
        /// Der Name des Stoffes
        /// Muss implementiert werden, aber nicht im Konstruktor
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Die Formel des Stoffes
        /// Muss implementiert werden, aber nicht im Konstruktor
        /// </summary>
        public abstract string Formel { get; }

        public Stoff()
        {
        }
    }
}
