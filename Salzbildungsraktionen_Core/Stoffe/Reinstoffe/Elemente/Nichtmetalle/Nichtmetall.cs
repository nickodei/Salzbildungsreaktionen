using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle
{
    public class Nichtmetall : Element
    {
        public const string Wasserstoff = "H";
        public const string Kohlenstoff = "C";
        public const string Stickstoff = "N";
        public const string Phosphor = "P";
        public const string Sauerstoff = "S";

        public Nichtmetall(string symbol, string name, int valenzelektronen) : base(name, symbol, valenzelektronen)
        {
        }

        public Anion<Nichtmetall> ErhalteIon()
        {
            return new Anion<Nichtmetall>(this, Valenzelektronen);
        }

        public int ErhalteLadung()
        {
            return -(8 - Valenzelektronen);
        }

        public static Nichtmetall ErhalteNichtmetall(string symbol)
        {
            switch (symbol)
            {
                case Wasserstoff:
                    return new Nichtmetall(symbol, nameof(Wasserstoff), 1);
                case Kohlenstoff:
                    return new Nichtmetall(symbol, nameof(Kohlenstoff), 4);
                case Stickstoff:
                    return new Nichtmetall(symbol, nameof(Stickstoff), 5);
                case Phosphor:
                    return new Nichtmetall(symbol, nameof(Phosphor), 5);
                case Sauerstoff:
                    return new Nichtmetall(symbol, nameof(Sauerstoff), 6);
                default:
                    return null;
            }
        }
    }
}
