namespace Salzbildungsreaktionen_Core.Models.Elemente
{
    public class Metall : Element
    {
        #region

        public const string Lithium = "Li";
        public const string Natrium = "Na";
        public const string Kalium = "K";

        #endregion

        public Metall(string symbol, string name, int wertigkeit, int anzahl) : base(symbol, name, wertigkeit, anzahl)
        {
        }

        public static Metall Create(string symbol, int anzahl)
        {
            switch(symbol)
            {
                case Lithium:
                    return new Metall(symbol: symbol, name: nameof(Lithium), wertigkeit: 1, anzahl: anzahl);
                case Natrium:
                    return new Metall(symbol: symbol, name: nameof(Natrium), wertigkeit: 1, anzahl: anzahl);
                case Kalium:
                    return new Metall(symbol: symbol, name: nameof(Kalium), wertigkeit: 1, anzahl: anzahl);
                default:
                    return null;
            }
        }    
    }
}
