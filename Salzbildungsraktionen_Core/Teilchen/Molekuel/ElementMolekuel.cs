using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Teilchen.Molekuel;

namespace Salzbildungsreaktionen_Core.Teilchen.Molekuele
{
    public class ElementMolekuel : IMolekuel
    {
        public string Name { get; set; }
        public string Formel { get; set; }

        public Atom Atom { get; set; }
        public int Anzahl { get; set; }

        public ElementMolekuel(int anzahlAtom, Atom atom)
        {
            Atom = atom;
            Anzahl = anzahlAtom;

            if(anzahlAtom == 1)
            {
                Name = atom.Element.Name;
                Formel = atom.Element.Formel;
            }
            else
            {
                Name = NomenklaturHelfer.Praefix(anzahlAtom) + atom.Element.Name.ToLower();
                Formel = atom.Element.Formel + UnicodeHelfer.GetSubscriptOfNumber(anzahlAtom);
            }
        }
    }
}
