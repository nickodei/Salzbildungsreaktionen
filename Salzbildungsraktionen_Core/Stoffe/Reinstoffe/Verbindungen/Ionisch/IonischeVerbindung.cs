using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public abstract class IonischeVerbindung : Verbindung
    {
        private int _Ladung;
        public int Ladung
        {
            get { return _Ladung; }
            private set { _Ladung = value; }
        }

        public IonischeVerbindung(int ladung)
        {
            Ladung = ladung;
        }
    }
}
