namespace Salzbildungsreaktionen_Core.Models.Elemente
{
    public class Metall : Element
    {
        #region

        public const string Lithium = "Li";
        public const string Natrium = "Na";
        public const string Kalium = "K";
        public const string Magnesium = "Mg";

        #endregion

        public Metall(string symbol, string name, int wertigkeit) : base(symbol, name, wertigkeit)
        {
        }

        public static Metall Create(string symbol)
        {
            switch(symbol)
            {
                case Lithium:
                    return new Metall(symbol: symbol, name: nameof(Lithium), wertigkeit: 1);
                case Natrium:
                    return new Metall(symbol: symbol, name: nameof(Natrium), wertigkeit: 1);
                case Kalium:
                    return new Metall(symbol: symbol, name: nameof(Kalium), wertigkeit: 1);
                case Magnesium:
                    return new Metall(symbol: symbol, name: nameof(Magnesium), wertigkeit: 2);
                default:
                    return null;
            }
        }    
    }
}
