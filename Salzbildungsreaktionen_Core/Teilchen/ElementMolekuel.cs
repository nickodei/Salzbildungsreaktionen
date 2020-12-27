using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class ElementMolekuel : Molekuel
    {
        public Elementarverbindung Verbindung { get; }

        public ElementMolekuel(Elementarverbindung verbindung) : base(verbindung, verbindung.AnzahlBindungspartner)
        {
            Verbindung = verbindung;
        }
    }
}
