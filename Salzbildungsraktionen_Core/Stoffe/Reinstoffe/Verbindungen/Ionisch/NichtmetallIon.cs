using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public class NichtmetallIon : IonischeVerbindung
    {
        private Nichtmetall _Element;
        public Nichtmetall Element
        {
            get { return _Element; }
            set { _Element = value; }
        }

        private NichtmetallIon(Nichtmetall nichtmetall, int ladung) : base(nichtmetall.Name, nichtmetall.Symbol, ladung)
        {
            Element = nichtmetall;
        }

        public static NichtmetallIon ErhalteNichtmetallIon(Nichtmetall nichtmetall)
        {
            int ladung = nichtmetall.ErhalteLadung();
            return new NichtmetallIon(nichtmetall, ladung);
        }
    }
}
