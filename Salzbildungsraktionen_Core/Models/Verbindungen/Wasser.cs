using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using System;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Wasser : Verbindung
    {
        private NichtMetall _Wasserstoff;
        public NichtMetall m_Wasserstoff
        {
            get { return _Wasserstoff; }
            set { _Wasserstoff = value; }
        }

        private NichtMetall _Sauerstoff;
        public NichtMetall m_Sauerstoff
        {
            get { return _Sauerstoff; }
            set { _Sauerstoff = value; }
        }

        public Wasser() : base("H₂O", "Wasserstoff")
        {
            // Neues Objet muss erstellt werden, da das Salz eine eigene Instanz darstellt
            m_Wasserstoff = NichtMetall.Create(NichtMetall.Wasserstoff);
            m_Sauerstoff = NichtMetall.Create(NichtMetall.Sauerstoff);

            // Berechne das kleinste gemeinsame Vielfache
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(m_Wasserstoff.Wertigkeit), Math.Abs(m_Sauerstoff.Wertigkeit));

            // Setze jeweils die Anzahl der Reaktionspartner in Relation zum kgV
            m_Wasserstoff.Anzahl = kgV / Math.Abs(m_Wasserstoff.Wertigkeit);
            m_Sauerstoff.Anzahl = kgV / Math.Abs(m_Sauerstoff.Wertigkeit);
        }
    }
}
