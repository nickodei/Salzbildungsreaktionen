namespace Salzbildungsreaktionen_Core.Models.Elemente
{
    public class NichtMetall : Element
    {
        #region

        public const string Chlor = "Cl";
        public const string Sauerstoff = "O";

        #endregion

        public NichtMetall(string symbol, string name, int wertigkeit): base(symbol, name, wertigkeit)
        {
        }

        public static NichtMetall Create(string symbol)
        {
            switch (symbol)
            {
                case Sauerstoff:
                    return new NichtMetall(symbol: symbol, name: nameof(Sauerstoff), wertigkeit: -2);
                case Chlor:
                    return new NichtMetall(symbol: symbol, name: nameof(Chlor), wertigkeit: -1);
                default:
                    return null;
            }
        }
    }
}
