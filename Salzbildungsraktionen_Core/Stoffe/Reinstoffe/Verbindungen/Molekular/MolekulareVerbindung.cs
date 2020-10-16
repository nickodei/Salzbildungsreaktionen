using Salzbildungsreaktionen_Core.Helper;
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

        private MolekulareVerbindung(string name, string formel, Element element, int anzahlAtome) : base(name, formel)
        {
            BasisElement = element;
            AnzahlAtome = anzahlAtome;
        }

        public static MolekulareVerbindung ErhalteVerbindung(Element element, int anzahlAtome)
        {
            string formel;
            if(anzahlAtome > 1)
            {
                formel = element.Symbol + Unicodehelfer.GetSubscriptOfNumber(anzahlAtome);
            }
            else
            {
                formel = element.Symbol;
            }

            switch(anzahlAtome)
            {
                case 1:
                    return new MolekulareVerbindung(element.Name, formel, element, anzahlAtome);
                case 2:
                    return new MolekulareVerbindung("Di" + element.Name, formel, element, anzahlAtome);
                default:
                    return null;
            }
        }
    }
}
