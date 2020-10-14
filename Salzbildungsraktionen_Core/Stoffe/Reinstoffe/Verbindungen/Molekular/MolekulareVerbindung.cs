using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular
{
    public class MolekulareVerbindung : Verbindung
    {
        private Element _BasisElement;
        public Element BasisElement
        {
            get { return _BasisElement; }
            private set { _BasisElement = value; }
        }

        private int _AnzahlAtome;
        public int AnzahlAtome
        {
            get { return _AnzahlAtome; }
            private set { _AnzahlAtome = value; }
        }

        public MolekulareVerbindung(Element element, int anzahlAtome)
        {
            BasisElement = element;
            AnzahlAtome = anzahlAtome;
        }
    }
}
