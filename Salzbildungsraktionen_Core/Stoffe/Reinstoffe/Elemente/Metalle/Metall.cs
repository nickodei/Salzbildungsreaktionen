using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle
{
    public class Metall : Element
    {
        public const string Lithium = "Li";
        public const string Natrium = "Na";
        public const string Kalium = "K";
        public const string Magnesium = "Mg";

        public Metall(string symbol, string name, int valenzelektronen) : base(name, symbol, valenzelektronen)
        {
        }

        public Kation<Metall> ErhalteIon()
        {
            return new Kation<Metall>(this, Valenzelektronen);
        }

        public static Metall ErhalteMetall(string symbol)
        {
            switch(symbol)
            {
                case Lithium:
                    return new Metall(symbol, nameof(Lithium), 1);
                case Natrium:
                    return new Metall(symbol, nameof(Natrium), 1);
                case Kalium:
                    return new Metall(symbol, nameof(Kalium), 1);
                case Magnesium:
                    return new Metall(symbol, nameof(Magnesium), 2);
                default:
                    return null;
            }
        }
    }
}
