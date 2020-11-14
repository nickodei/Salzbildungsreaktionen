using Salzbildungsreaktionen_Core.Bindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class Molekuel
    {
        public int Anzahl { get; set; }
        public IKovalenteBindung Bindung { get; set; }

        public Molekuel(IKovalenteBindung bindung, int anzahl)
        {
            Anzahl = anzahl;
            Bindung = bindung;
        }
    }
}
