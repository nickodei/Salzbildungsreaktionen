using Salzbildungsreaktionen_Core.Bindungen;
using Salzbildungsreaktionen_Core.Stoffe;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class Molekuel
    {
        public int Anzahl { get; set; }
        public Stoff Stoff { get; }

        public Molekuel(Stoff stoff, int anzahl)
        {
            Stoff = stoff;
            Anzahl = anzahl;
        }
    }
}
