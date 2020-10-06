namespace Salzbildungsreaktionen_Core.Models.Elemente
{
    public class NichtMetall : Element
    {
        #region

        public const string Chlor = "Cl";
        public const string Sauerstoff = "O";

        #endregion

        public NichtMetall(string symbol, string name, int wertigkeit, int anzahl): base(symbol, name, wertigkeit, anzahl)
        {
        }

        public static NichtMetall Create(string symbol, int anzahl)
        {
            switch (symbol)
            {
                case Sauerstoff:
                    return new NichtMetall(symbol: symbol, name: nameof(Sauerstoff), wertigkeit: -2, anzahl: anzahl);
                case Chlor:
                    return new NichtMetall(symbol: symbol, name: nameof(Chlor), wertigkeit: -1, anzahl: anzahl);
                default:
                    return null;
            }
        }
    }
}
