using Salzbildungsreaktionen_Core.Stoffe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class Reaktionsstoff<T> where T : Stoff
    {
        private T _Stoff;
        public T Stoff
        {
            get { return _Stoff; }
            set { _Stoff = value; }
        }

        private int _Anzahl;
        public int Anzahl
        {
            get { return _Anzahl; }
            set { _Anzahl = value; }
        }

        public Reaktionsstoff(T stoff)
        {
            Stoff = stoff;
            Anzahl = 0;
        }
    }
}
