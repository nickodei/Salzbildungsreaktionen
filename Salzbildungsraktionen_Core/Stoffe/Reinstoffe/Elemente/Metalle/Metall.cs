using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle
{
    public class Metall : Element
    {
        public const string Lithium = "Li";
        public const string Natrium = "Na";
        public const string Kalium = "K";
        public const string Magnesium = "Mg";

        private Metall(string name, string symbol, int hauptgruppe) : base(name, symbol, hauptgruppe)
        {
        }

        public static Metall ErhalteMetall(string symbol)
        {
            switch(symbol)
            {
                case Lithium:
                    return new Metall(nameof(Lithium), symbol, 1);
                case Natrium:
                    return new Metall(nameof(Natrium), symbol, 1);
                case Kalium:
                    return new Metall(nameof(Kalium), symbol, 1);
                case Magnesium:
                    return new Metall(nameof(Magnesium), symbol, 2);
                default:
                    return null;
            }
        }
    }
}
