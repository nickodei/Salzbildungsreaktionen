using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using System.Linq;

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
            return Periodensystem.Instance.Metalle.Values.Where(x => x.Symbol.Equals(symbol)).FirstOrDefault();
        }
    }
}
