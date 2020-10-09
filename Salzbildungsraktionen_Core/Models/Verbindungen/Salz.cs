using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Salz : Verbindung
    {
        #region

        public const string Natriumchlorid = "NaCl";
        public const string Magnesiumchlorid = "MgCl₂";
        public const string Aluminiumsulfat = "Al2(SO4)3";

        #endregion

        private Metall _Metall;
        public Metall m_Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
        }

        private SäureRestIon _Säurerestion;
        public SäureRestIon m_Säurerestion
        {
            get { return _Säurerestion; }
            set { _Säurerestion = value; }
        }

        public Salz(string formel, string name, Metall metall, SäureRestIon säurerestion) : base(formel, name)
        {
            // Neues Objet muss erstellt werden, da das Salz eine eigene Instanz darstellt
            m_Metall = metall;
            m_Säurerestion = säurerestion;
        }

        private static void SetzeAnzahlDerIonen(Metall metall, SäureRestIon säurerestion)
        {
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(metall.Wertigkeit), Math.Abs(säurerestion.Ladung));

            // Setze jeweils die Anzahl der Reaktionspartner in Relation zum kgV
            metall.Anzahl = kgV / Math.Abs(metall.Wertigkeit);
            säurerestion.Anzahl = kgV / Math.Abs(säurerestion.Ladung);
        }

        private static string SetzeFormel(Metall metall, SäureRestIon säurerestion)
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

            if (säurerestion.Anzahl > 1)
            {
                if (int.TryParse(säurerestion.ChemischeFormel.Last().ToString(), out int s))
                {
                    formel += $"({säurerestion.ChemischeFormel}){Unicodehelfer.GetSubscriptOfNumber((int)säurerestion.Anzahl)}";
                }
                else
                {
                    formel += $"{säurerestion.ChemischeFormel}{Unicodehelfer.GetSubscriptOfNumber((int)säurerestion.Anzahl)}";
                }
            }
            else
            {
                formel += $"{säurerestion.ChemischeFormel}";
            }

            return formel;
        }

        public static Salz Create(Metall metall, SäureRestIon säurerestion)
        {
            Metall metallFürSäure = Metall.Create(metall.Symbol);
            SäureRestIon säurerestionFürSäure = SäureRestIon.Create(säurerestion.ChemischeFormel, säurerestion.AnzahlWasserstoff, säurerestion.Ladung);

            SetzeAnzahlDerIonen(metallFürSäure, säurerestionFürSäure);
            string formel = SetzeFormel(metallFürSäure, säurerestionFürSäure);

            switch (formel)
            {
                default:
                    return new Salz(formel, "Unbekannt", metallFürSäure, säurerestionFürSäure);
            }
        }

        public static Salz Create(Metalloxid metalloxid, SäureRestIon säurerestion)
        {
            Metalloxid metalloxidFürSäure = Metalloxid.Create(metalloxid.m_Metall); // Kann optimiert werden
            SäureRestIon säurerestionFürSäure = SäureRestIon.Create(säurerestion.ChemischeFormel, säurerestion.AnzahlWasserstoff, säurerestion.Ladung);

            SetzeAnzahlDerIonen(metalloxidFürSäure.m_Metall, säurerestionFürSäure);
            string formel = SetzeFormel(metalloxidFürSäure.m_Metall, säurerestionFürSäure);

            switch (formel)
            {
                default:
                    return new Salz(formel, "Unbekannt", metalloxidFürSäure.m_Metall, säurerestionFürSäure);
            }
        }
    }
}
