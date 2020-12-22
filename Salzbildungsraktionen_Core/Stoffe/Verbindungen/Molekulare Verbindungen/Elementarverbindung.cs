using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen
{
    public class Elementarverbindung : Verbindung
    {
        public Element Element { get; }
        public int AnzahlBindungspartner { get; }

        public Elementarverbindung(Element element, int anzahlBindungspartner)
        {
            Element = element;
            AnzahlBindungspartner = anzahlBindungspartner;
        }

        protected override string GeneriereChemischeFormel()
        {
            if(AnzahlBindungspartner == 1)
            {
                return Element.Symol;
            }
            else
            {
                return Element.Symol + UnicodeHelfer.GetSubscriptOfNumber(AnzahlBindungspartner);
            }
        }

        protected override string GeneriereName()
        {
            if(AnzahlBindungspartner == 1)
            {
                return Element.Name;
            }
            else
            {
                return NomenklaturHelfer.Praefix(AnzahlBindungspartner) + Element.Name.ToLower();
            }
        }
    }
}
