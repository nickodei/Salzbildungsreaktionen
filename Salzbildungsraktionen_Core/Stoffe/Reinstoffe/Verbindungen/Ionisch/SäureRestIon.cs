using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch
{
    public class SäureRestIon : IonischeVerbindung
    {
        public const string Sulfat = "SO₄";

        private SäureRestIon(string name, string formel, int ladung): base(name, formel, ladung)
        {
        }

        public static SäureRestIon ErhalteSäurerest(string formel, int ladung)
        {
            switch(formel)
            {
                case Sulfat:
                    return new SäureRestIon(nameof(Sulfat), formel, ladung);
                default:
                    return null;
            }
        }
    }
}
