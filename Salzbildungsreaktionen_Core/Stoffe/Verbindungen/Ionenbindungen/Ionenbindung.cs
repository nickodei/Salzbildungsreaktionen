using Salzbildungsreaktionen_Core.Teilchen.Ionen;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen
{
    public abstract class Ionenbindung : Verbindung
    {
        public Kation Kation { get; set; }
        public Anion Anion { get; set; }

        public Ionenbindung()
        {
        }
    }
}
