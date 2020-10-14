using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch
{
    public class SäureRestIon : IonischeVerbindung
    {
        private Verbindung _BestehendeVerbindung;
        public Verbindung BestehendeVerbindung
        {
            get { return _BestehendeVerbindung; }
            set { _BestehendeVerbindung = value; }
        }

        public SäureRestIon(Verbindung verbindung, int ladung): base(ladung)
        {
            BestehendeVerbindung = verbindung;
        }
    }
}
