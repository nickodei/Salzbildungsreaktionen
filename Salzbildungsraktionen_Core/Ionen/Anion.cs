namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Beschreibt Stoffe, die eine negative Ladung haben
    /// </summary>
    /// <typeparam name="T">Stoff</typeparam>
    public class Anion<T> : Ion<T> where T : Stoff
    {
        public Anion(T stoff, int positiveLadung) : base(stoff, positiveLadung)
        {
            Stoff = stoff;
        }

        public override string GetName()
        {
            switch(Stoff.Formel)
            {
                case "S":
                    return "Sulfid";
            }

            return $"{Stoff.Name}id";
        }

        public override string GetFormel()
        {
            return Stoff.Formel;
        }
    }
}