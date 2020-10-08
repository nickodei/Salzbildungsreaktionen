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
        public const string Magnesiumchlorid = "MgCl2";
        public const string Aluminiumsulfat = "Al2(SO4)3";

        #endregion

        private Metall _Metall;
        public Metall m_Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
        }

        private Säurerestion _Säurerestion;
        public Säurerestion m_Säurerestion
        {
            get { return _Säurerestion; }
            set { _Säurerestion = value; }
        }

        public Salz(string formel, string name, Metall metall, Säurerestion säurerestion) : base(formel, name)
        {
            // Neues Objet muss erstellt werden, da das Salz eine eigene Instanz darstellt
            m_Metall = metall;
            m_Säurerestion = säurerestion;
        }

        private static void SetzeAnzahlDerIonen(Metall metall, Säurerestion säurerestion)
        {
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(metall.Wertigkeit), Math.Abs(säurerestion.Wertigkeit));

            // Setze jeweils die Anzahl der Reaktionspartner in Relation zum kgV
            metall.Anzahl = kgV / Math.Abs(metall.Wertigkeit);
            säurerestion.Anzahl = kgV / Math.Abs(säurerestion.Wertigkeit);
        }

        private static string SetzeFormel(Metall metall, Säurerestion säurerestion)
        {
            string formel = "";

            formel += (metall.Anzahl > 1) ? $"{metall.Symbol}{metall.Anzahl}" : $"{metall.Symbol}";
            formel += (int.TryParse(säurerestion.Formel.Last().ToString(), out int s)) ? $"({säurerestion.Formel})" : $"{säurerestion.Formel}";
            formel += (säurerestion.Anzahl > 1) ? $"{säurerestion.Anzahl}" : $"";

            return formel;
        }

        public static Salz Create(Metall metall, Säurerestion säurerestion)
        {
            Metall metallFürSäure = Metall.Create(metall.Symbol);
            Säurerestion säurerestionFürSäure = Säurerestion.Create(säurerestion.Formel);

            SetzeAnzahlDerIonen(metallFürSäure, säurerestionFürSäure);
            string formel = SetzeFormel(metallFürSäure, säurerestionFürSäure);

            switch (formel)
            {
                default:
                    return new Salz(formel, "Unbekannt", metallFürSäure, säurerestionFürSäure);
            }
        }
    }
}
