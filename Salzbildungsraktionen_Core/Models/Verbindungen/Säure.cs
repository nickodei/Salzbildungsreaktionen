using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using System;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Säure : Verbindung
    {
        #region Säureformeln

        public const string Salzsäure = "HCl";
        public const string Schwefelsäure = "H2SO4";

        #endregion

        private int _AnzahlWasserstoff;
        public int AnzahlWasserstoff
        {
            get { return _AnzahlWasserstoff; }
            private set { _AnzahlWasserstoff = value; }
        }

        private Säurerestion _Säurerestion;
        public Säurerestion Säurerestion
        {
            get { return _Säurerestion; }
            set { _Säurerestion = value; }
        }

        public Säure(string formel, string name, int anzahlWasserstoff, Säurerestion säurerestion) : base(formel, name)
        {
            AnzahlWasserstoff = anzahlWasserstoff;
            Säurerestion = säurerestion;
        }

        public static Säure Create(string formel)
        {
            switch (formel)
            {
                case Salzsäure:
                    return new Säure(formel: formel, name: nameof(Salzsäure), anzahlWasserstoff: 1, Säurerestion.Create(NichtMetall.Chlor, 1));
                case Schwefelsäure:
                    return new Säure(formel: formel, name: nameof(Schwefelsäure), anzahlWasserstoff: 2, Säurerestion.Create(Säurerestion.Sulfat, 1));
                default:
                    return null;
            }
        }

        public (Salz, Element) ReagiertMit(Metall metall)
        {
            // Berechne das kleinste gemeinsame Vielfache
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(metall.Wertigkeit), Math.Abs(Säurerestion.Wertigkeit));
            
            // Setze jeweils die Anzahl der Reaktionspartner in Relation zum kgV
            Säurerestion.Anzahl = kgV / Math.Abs(Säurerestion.Wertigkeit);
            metall.Anzahl = kgV / Math.Abs(metall.Wertigkeit);

            // Erstelle das Salz


            return (null, null);
        }
    }
}
