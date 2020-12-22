using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class MultiElementMolekuel : Molekuel
    {
        public Molekularverbindung Verbindung { get; }

        public MultiElementMolekuel(Molekularverbindung verbindung) : base(verbindung, 1)
        {
            Verbindung = verbindung;
        }

        public MultiElementMolekuel(Molekularverbindung verbindung, int anzahlMolekuel) : base(verbindung, anzahlMolekuel)
        {
            Verbindung = verbindung;
        }
    }
}
