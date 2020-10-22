using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;

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

        public MolekulareVerbindung(Element element, int anzahlAtome) : base("")
        {
            BasisElement = element;
            AnzahlAtome = anzahlAtome;

            GeneriereDenName();
            GeneriereDieFormel();
        }

        private void GeneriereDenName()
        {
            switch (AnzahlAtome)
            {
                case 1:
                    Name = BasisElement.Name.ToLower();
                    break;
                case 2:
                    Name = "Di" + BasisElement.Name.ToLower();
                    break;
                case 3:
                    Name = "Tri" + BasisElement.Name.ToLower();
                    break;
                case 4:
                    Name = "Tetra" + BasisElement.Name.ToLower();
                    break;
                default:
                    Name = "Unbekannt";
                    break;
            }
        }

        private void GeneriereDieFormel()
        {
            if (AnzahlAtome > 1)
            {
                Formel = BasisElement.Symbol + Unicodehelfer.GetSubscriptOfNumber(AnzahlAtome);
            }
            else
            {
                Formel = BasisElement.Symbol;
            }
        }
    }
}
