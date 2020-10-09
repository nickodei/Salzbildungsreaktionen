using Salzbildungsreaktionen_Core.Models.Verbindungen;

namespace Salzbildungsreaktionen_Core.Models.Reaktionen
{
    public class MetalloxidSäureReaktionsresultat
    {
        private Metalloxid _Metalloxid;
        public Metalloxid m_Metalloxid
        {
            get { return _Metalloxid; }
            set { _Metalloxid = value; }
        }

        private Säure _Säure;
        public Säure m_Säure
        {
            get { return _Säure; }
            set { _Säure = value; }
        }

        private Salz _Salz;
        public Salz m_Salz
        {
            get { return _Salz; }
            set { _Salz = value; }
        }

        private Wasser _Wasser;
        public Wasser m_Wasser
        {
            get { return _Wasser; }
            set { _Wasser = value; }
        }

        public MetalloxidSäureReaktionsresultat(Metalloxid metalloxid, Säure säure, Salz salz, Wasser wasser)
        {
            m_Metalloxid = metalloxid;
            m_Säure = säure;
            m_Salz = salz;
            m_Wasser = wasser;
        }
    }
}
