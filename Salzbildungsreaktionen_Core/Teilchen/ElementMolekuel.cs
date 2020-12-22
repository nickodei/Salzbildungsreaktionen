using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class ElementMolekuel : Molekuel
    {
        public Elementarverbindung Verbindung { get; }

        public ElementMolekuel(Elementarverbindung verbindung) : base(verbindung, 1)
        {
            Verbindung = verbindung;
        }

        public ElementMolekuel(Elementarverbindung verbindung, int anzahlMolekuel) : base(verbindung, anzahlMolekuel)
        {
            Verbindung = verbindung;
        }
    }
}
