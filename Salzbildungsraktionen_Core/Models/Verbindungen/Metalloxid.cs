using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Metalloxid : Verbindung
    {
        private Metall _Metall;
        public Metall m_Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
        }

        private NichtMetall _Sauerstoff;
        public NichtMetall m_Sauerstoff
        {
            get { return _Sauerstoff; }
            set { _Sauerstoff = value; }
        }

        public Metalloxid(string formel, string name, Metall metall, NichtMetall sauerstoff) : base(formel, name)
        {
            // Neues Objet muss erstellt werden, da das Salz eine eigene Instanz darstellt
            m_Metall = metall;
            m_Sauerstoff = sauerstoff;
        }

        private static void SetzeAnzahlDerIonen(Metall metall, NichtMetall sauerstoff)
        {
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(metall.Wertigkeit), Math.Abs(sauerstoff.Wertigkeit));

            // Setze jeweils die Anzahl der Reaktionspartner in Relation zum kgV
            metall.Anzahl = kgV / Math.Abs(metall.Wertigkeit);
            sauerstoff.Anzahl = kgV / Math.Abs(sauerstoff.Wertigkeit);
        }

        private static string SetzeFormel(Metall metall, NichtMetall sauerstoff)
        {
            string formel = "";

            if (metall.Anzahl > 1)
            {
                formel += $"{metall.Symbol}{Unicodehelfer.GetSubscriptOfNumber((int)metall.Anzahl)}";
            }
            else
            {
                formel += $"{metall.Symbol}";
            }

            if (sauerstoff.Anzahl > 1)
            {
                formel += $"{sauerstoff.Symbol}{Unicodehelfer.GetSubscriptOfNumber((int)sauerstoff.Anzahl)}";
            }
            else
            {
                formel += $"{sauerstoff.Symbol}";
            }

            return formel;
        }

        public static Metalloxid Create(Metall metall)
        {
            Metall metallFürMetalloxid = Metall.Create(metall.Symbol);
            NichtMetall sauerstoffFürMetalloxid = NichtMetall.Create(NichtMetall.Sauerstoff);

            SetzeAnzahlDerIonen(metallFürMetalloxid, sauerstoffFürMetalloxid);
            string formel = SetzeFormel(metallFürMetalloxid, sauerstoffFürMetalloxid);

            switch (formel)
            {
                default:
                    return new Metalloxid(formel, "Unbekannt", metallFürMetalloxid, sauerstoffFürMetalloxid);
            }
        }
    }
}
