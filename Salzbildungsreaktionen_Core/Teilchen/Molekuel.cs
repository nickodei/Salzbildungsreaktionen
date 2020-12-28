using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class Molekuel
    {
        public int Anzahl { get; set; }
        public Atombindung Atombindung { get; }

        public Molekuel(Atombindung atombindung, int anzahl)
        {
            Atombindung = atombindung;
            Anzahl = anzahl;
        }

        public int AnzahlAtomeInMolekuel()
        {
            return Atombindung.AnzahlAtome * Anzahl;
        }
    }
}
