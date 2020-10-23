namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Beschreibt Stoffe, die eine positive Ladung haben
    /// </summary>
    /// <typeparam name="T">Stoff</typeparam>
    public class Kation<T>: Ion<T> where T: Stoff
    {
        public Kation(T stoff, int positiveLadung) : base(stoff, positiveLadung)
        {
        }

        public override string GetName()
        {
            return Stoff.Name;
        }

        public override string GetFormel()
        {
            return Stoff.Formel;
        }
    }
}
