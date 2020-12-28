using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;

namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Kation : Ion
    {
        private int _PositiveLadung;
        public override int Ladung => _PositiveLadung;

        public Kation(Molekuel molekuel) : base(molekuel)
        {
            // Ladung kann aus dem Element herausgelesen werden
            if(molekuel.Atombindung.IstElementbindung())
            {
                Element element = molekuel.Atombindung.ErhalteElement();
                if(element is Metall)
                {
                    Metall metall = element as Metall;
                    _PositiveLadung = metall.Hauptgruppe;
                }
                else
                {
                    Nichtmetall nichtmetall = element as Nichtmetall;
                    if(nichtmetall.Symol.Equals("H"))
                    {
                        _PositiveLadung = 1;
                    }
                    else
                    {
                        _PositiveLadung = 8 - nichtmetall.Hauptgruppe;
                    }
                }
            }
        }

        public Kation(Molekuel molekuel, int ladung) : base(molekuel)
        {
            // Ladung muss mit übergeben werden, da ein Molekül immer neutral geladen ist
            _PositiveLadung = ladung;
        }


    }
}
