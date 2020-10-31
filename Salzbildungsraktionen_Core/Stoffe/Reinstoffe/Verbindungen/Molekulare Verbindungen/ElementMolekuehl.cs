using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen
{
    public class ElementMolekuehl : Molekuehl
    {
        private string _Name;
        public  string Name
        {
            get { return _Name; }
        }

        private string _Formel;
        public  string Formel
        {
            get { return _Formel; }
        }

        private Element _Element;
        public Element Element
        {
            get { return _Element; }
            set { _Element = value; }
        }

        private int _AnzahlAtome;
        public int AnzahlAtome
        {
            get { return _AnzahlAtome; }
            set { _AnzahlAtome = value; }
        }

        public ElementMolekuehl(Element element, int anzahlAtome) : base()
        {
            Element = element;
            AnzahlAtome = anzahlAtome;

            GeneriereName();
            GeneriereFormel();
        }

        private void GeneriereName()
        {
            switch (AnzahlAtome)
            {
                case 1:
                    _Name = Element.Name.ToLower();
                    break;
                case 2:
                    _Name = "Di" + Element.Name.ToLower();
                    break;
                case 3:
                    _Name = "Tri" + Element.Name.ToLower();
                    break;
                case 4:
                    _Name = "Tetra" + Element.Name.ToLower();
                    break;
                default:
                    _Name = "Unbekannt";
                    break;
            }
        }

        private void GeneriereFormel()
        {
            if (AnzahlAtome > 1)
            {
                _Formel = Element.Symbol + UnicodeHelfer.GetSubscriptOfNumber(AnzahlAtome);
            }
            else
            {
                _Formel = Element.Symbol;
            }
        }
    }
}
