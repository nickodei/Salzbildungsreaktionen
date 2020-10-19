using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch
{
    public class SäurerestIon : IonischeVerbindung
    {
        private Verbindung _Säurerest;
        public Verbindung Säurerest
        {
            get { return _Säurerest; }
            set { _Säurerest = value; }
        }

        private SäurerestIon(Verbindung säurerest, int ladung): base(säurerest.Name, säurerest.Formel, ladung)
        {
            Säurerest = säurerest;
        }

        public static SäurerestIon ErhalteSäurerest(Verbindung säurerest, int ladung)
        {
            return new SäurerestIon(säurerest, ladung);
        }

        public static SäurerestIon ErhalteSäurerest(string formel, int ladung)
        {
            Verbindung säurerest = new Verbindung("", formel);
            return new SäurerestIon(säurerest, ladung);
        }
    }
}
