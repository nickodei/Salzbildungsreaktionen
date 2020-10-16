namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle
{
    public class Nichtmetall : Element
    {
        public const string Wasserstoff = "H";
        public const string Kohlenstoff = "C";
        public const string Stickstoff = "N";
        public const string Phosphor = "P";
        public const string Sauerstoff = "S";

        public Nichtmetall(string name, string symbol, int hauptgruppe) : base(name, symbol, hauptgruppe)
        {
        }

        public static Nichtmetall ErhalteNichtmetall(string symbol)
        {
            switch (symbol)
            {
                case Wasserstoff:
                    return new Nichtmetall(nameof(Wasserstoff), symbol, 1);
                case Kohlenstoff:
                    return new Nichtmetall(nameof(Kohlenstoff), symbol, 4);
                case Stickstoff:
                    return new Nichtmetall(nameof(Stickstoff), symbol, 5);
                case Phosphor:
                    return new Nichtmetall(nameof(Phosphor), symbol, 5);
                case Sauerstoff:
                    return new Nichtmetall(nameof(Sauerstoff), symbol, 6);
                default:
                    return null;
            }
        }
    }
}
