using Salzbildungsreaktionen_Core.Models.Elemente;
using Salzbildungsreaktionen_Core.Models.Verbindungen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Models.Reaktionen
{
    public class MetallSäureReaktionsresultat
    {
        private Metall _Metall;
        public Metall m_Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
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

        private Verbindung _Wasserstoff;
        public Verbindung m_Wasserstoff
        {
            get { return _Wasserstoff; }
            set { _Wasserstoff = value; }
        }

        public MetallSäureReaktionsresultat(Metall metall, Säure säure, Salz salz, Verbindung wasserstoff)
        {
            m_Metall = metall;
            m_Säure = säure;
            m_Salz = salz;
            m_Wasserstoff = wasserstoff;
        }
    }
}
