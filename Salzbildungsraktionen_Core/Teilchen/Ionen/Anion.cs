using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;

namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Anion : Ion
    {
        private int _NegativeLadung;
        public override int Ladung => _NegativeLadung;

        public Anion(Molekuel molekuel) : base(molekuel)
        {
            // Ladung kann aus dem Element herausgelesen werden
            if (molekuel.Bindung is Metall)
            {
                Metall metall = molekuel.Bindung as Metall;
                _NegativeLadung = -metall.Hauptgruppe;
            }
            else
            {
                Nichtmetall nichtmetall = molekuel.Bindung as Nichtmetall;
                if (nichtmetall.Symol.Equals("H"))
                {
                    _NegativeLadung = -1;
                }
                else
                {
                    _NegativeLadung = -(8 - nichtmetall.Hauptgruppe);
                }
            }
        }

        public Anion(Molekuel molekuel, int ladung) : base(molekuel)
        {
            // Ladung muss mit übergeben werden, da ein Molekül immer neutral geladen ist
            _NegativeLadung = ladung;
        }

        public string ErhalteAnionName()
        {
            return Molekuel.Bindung.ErhalteAnionName(Ladung);
        }
    }
}
