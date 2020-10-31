using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Beschreibt Stoffe, die eine positive Ladung haben
    /// </summary>
    /// <typeparam name="T">Stoff</typeparam>
    public class Kation<T> : Ion<T> where T : Stoff
    {
        public int PositiveLadung { get; set; }

        public Kation(T stoff) : base(stoff)
        {
            // Ist es ein Element, so kann die positive Ladung bestimmt werden
            Element element = stoff as Element;
            if (element != null)
            {
                if(element as Metall != null)
                {
                    // Es ist ein Metall, somit gibt die Hauptgruppe die Ladung an
                    PositiveLadung = element.Hauptgruppe;
                }
                else
                {
                    // Es ist ein Nichtmetall, somit muss von der Zahl 8 die Hauptgruppe subtrahiert werden
                    PositiveLadung = 8 - element.Hauptgruppe;
                }
            }
            else
            {
                // Es ist eine Verbindung uns es muss von einer neutralen Ladung ausgegangen werden
                PositiveLadung = 0;
            }
        }

        public Kation(T stoff, int positiveLadung) : base(stoff)
        {
            PositiveLadung = positiveLadung;
        }

        public override int ErhalteLadung()
        {
            return PositiveLadung;
        }

        public override string ErhalteName()
        {
            return Stoff.ErhalteName();
        }

        public override string ErhalteFormel()
        {
            return Stoff.ErhalteFormel();
        }
    }
}
