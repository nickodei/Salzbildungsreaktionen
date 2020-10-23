using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class MetalloxidSaeureReaktionsResultat
    {
        private Reaktionsstoff<Metalloxid> _Metalloxid;
        public Reaktionsstoff<Metalloxid> Metalloxid
        {
            get { return _Metalloxid; }
            set { _Metalloxid = value; }
        }

        private Reaktionsstoff<Saeure> _Saeure;
        public Reaktionsstoff<Saeure> Saeure
        {
            get { return _Saeure; }
            set { _Saeure = value; }
        }

        private Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> _Salz;
        public Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> Salz
        {
            get { return _Salz; }
            set { _Salz = value; }
        }

        private Reaktionsstoff<MultiElementMolekuehl> _Wasser;
        public Reaktionsstoff<MultiElementMolekuehl> Wasser
        {
            get { return _Wasser; }
            set { _Wasser = value; }
        }

        public MetalloxidSaeureReaktionsResultat(Reaktionsstoff<Metalloxid> metalloxid, Reaktionsstoff<Saeure> saeure, Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> salz, Reaktionsstoff<MultiElementMolekuehl> wasser)
        {
            Metalloxid = metalloxid;
            Saeure = saeure;
            Salz = salz;
            Wasser = wasser;
        }
    }
}
