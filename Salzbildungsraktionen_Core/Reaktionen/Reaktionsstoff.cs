using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe;
using Salzbildungsreaktionen_Core.Teilchen.Molekuel;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class Reaktionsstoff
    {
        public double Anzahl { get; set; }
        public IMolekuel Molekuel { get; set; }

        public Reaktionsstoff(IMolekuel molekuel)
        {
            Molekuel = molekuel;
            Anzahl = 0;
        }

        public string GetFormel()
        {
            return (Anzahl != 1) ? $"{Anzahl} {Molekuel.Formel}" : Molekuel.Formel;
        }
    }
}
