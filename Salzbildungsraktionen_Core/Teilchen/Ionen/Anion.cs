using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen.Molekuel;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;

namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Anion : Ion
    {
        private int _NegativeLadung;
        public override int Ladung => _NegativeLadung;

        public Anion(ElementMolekuel molekuel) : base(molekuel)
        {
            // Ladung kann aus dem Element herausgelesen werden
            if (molekuel.Atom.Element is Metall)
            {
                Metall metall = molekuel.Atom.Element as Metall;
                _NegativeLadung = -metall.Hauptgruppe;
            }
            else
            {
                Nichtmetall nichtmetall = molekuel.Atom.Element as Nichtmetall;
                if (nichtmetall.Formel.Equals("H"))
                {
                    _NegativeLadung = -1;
                }
                else
                {
                    _NegativeLadung = -(8 - nichtmetall.Hauptgruppe);
                }
            }
        }

        public Anion(VerbindungsMolekuel molekuel, int ladung) : base(molekuel)
        {
            // Ladung muss mit übergeben werden, da ein Molekül immer neutral geladen ist
            _NegativeLadung = ladung;
        }

        public Anion(IMolekuel molekuel, int ladung) : base(molekuel)
        {
            // Ladung muss mit übergeben werden, da ein Molekül immer neutral geladen ist
            _NegativeLadung = ladung;
        }
    }
}
