using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public class MetallIon : IonischeVerbindung
    {
        private Metall _Element;
        public Metall Element
        {
            get { return _Element; }
            set { _Element = value; }
        }

        private MetallIon(Metall metall, int ladung) : base(metall.Name, metall.Symbol, ladung)
        {
            Element = metall;
        }

        public static MetallIon ErhalteMetallIon(Metall metall)
        {
            int ladung = metall.ErhalteLadung();
            return new MetallIon(metall, ladung);
        }
    }
}
