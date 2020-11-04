using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;

namespace Salzbildungsreaktionen_Core.Teilchen
{
    /// <summary>
    /// Kleinstes, chemisch nicht weiter zerlegbares Teilchen
    /// </summary>
    public class Atom
    {
        public Element Element { get; private set; }

        public Atom(Element element)
        {
            Element = element;
        }
    }
}
