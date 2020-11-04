using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;

namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Kation : Ion
    {
        private int _PositiveLadung;
        public override int Ladung => _PositiveLadung;

        public Kation(ElementMolekuel molekuel) : base(molekuel)
        {
            // Ladung kann aus dem Element herausgelesen werden
            if(molekuel.Atom.Element is Metall)
            {
                Metall metall = molekuel.Atom.Element as Metall;
                _PositiveLadung = metall.Hauptgruppe;
            }
            else
            {
                Nichtmetall nichtmetall = molekuel.Atom.Element as Nichtmetall;
                if(nichtmetall.Formel.Equals("H"))
                {
                    _PositiveLadung = 1;
                }
                else
                {
                    _PositiveLadung = 8 - nichtmetall.Hauptgruppe;
                }
            }
        }

        public Kation(VerbindungsMolekuel molekuel, int ladung) : base(molekuel)
        {
            // Ladung muss mit übergeben werden, da ein Molekül immer neutral geladen ist
            _PositiveLadung = ladung;
        }
    }
}
