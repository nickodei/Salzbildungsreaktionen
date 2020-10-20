using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public abstract class IonischeVerbindung : Ion
    {
        private Verbindung _Verbindung;
        public Verbindung Verbindung
        {
            get { return _Verbindung; }
            set { _Verbindung = value; }
        }

        public IonischeVerbindung(Verbindung verbindung, int ladung) : base(ladung)
        {
            Verbindung = verbindung;
        }
    }
}
