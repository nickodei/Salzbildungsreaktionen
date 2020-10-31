using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    public class Atom : Teilchen
    {
        public Element Element { get; set; }

        public override string Name => Element.Name;
        public override string ChemischeFormel => Element.Symbol;
        public override double Elektronegativitaet => Element.Elektronegativitaet;


        public Atom(Element element)
        {
            Element = element;
        }
    }
}
