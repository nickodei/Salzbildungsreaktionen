using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class MetallSaeureReaktionsResultat
    {
        private Reaktionsstoff<Metall> _Metall;
        public Reaktionsstoff<Metall> Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
        }

        private Reaktionsstoff<Saeure> _Saeure;
        public Reaktionsstoff<Saeure> Saeure
        {
            get { return _Saeure; }
            set { _Saeure = value; }
        }

        private Reaktionsstoff<Salz<Metall, Verbindung>> _Salz;
        public Reaktionsstoff<Salz<Metall, Verbindung>> Salz
        {
            get { return _Salz; }
            set { _Salz = value; }
        }

        private Reaktionsstoff<MolekulareVerbindung> _Wasserstoff;
        public Reaktionsstoff<MolekulareVerbindung> Wasserstoff
        {
            get { return _Wasserstoff; }
            set { _Wasserstoff = value; }
        }

        public MetallSaeureReaktionsResultat(Reaktionsstoff<Metall> metall, Reaktionsstoff<Saeure> saeure, Reaktionsstoff<Salz<Metall, Verbindung>> salz, Reaktionsstoff<MolekulareVerbindung> wasserstoff)
        {
            Metall = metall;
            Saeure = saeure;
            Salz = salz;
            Wasserstoff = wasserstoff;
        }
    }
}
