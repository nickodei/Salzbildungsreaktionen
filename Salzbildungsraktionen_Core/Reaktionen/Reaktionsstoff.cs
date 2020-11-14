using Salzbildungsreaktionen_Core.Stoffe;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class Reaktionsstoff
    {
        public double Anzahl { get; set; }
        public Stoff Molekuel { get; set; }

        public Reaktionsstoff(Stoff molekuel)
        {
            Molekuel = molekuel;
            Anzahl = 0;
        }

        public string ErhalteAnzeigeformel()
        {
            return (Anzahl != 1) ? $"{Anzahl} {Molekuel.ErhalteFormel()}" : Molekuel.ErhalteFormel();
        }

        public string ErhalteAnzeigename()
        {
            return Molekuel.ErhalteName();
        }
    }
}
