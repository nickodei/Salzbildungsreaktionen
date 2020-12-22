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
            return (Anzahl != 1) ? $"{Anzahl} {Molekuel.ChemischeFormel}" : Molekuel.ChemischeFormel;
        }

        public string ErhalteAnzeigename()
        {
            return Molekuel.Name;
        }
    }
}
