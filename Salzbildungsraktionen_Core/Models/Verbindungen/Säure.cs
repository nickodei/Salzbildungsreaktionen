using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Models.Elemente;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Säure : Verbindung
    {
        #region Säureformeln

        public const string Salzsäure = "HCl";
        public const string Schwefelsäure = "H₂SO₄";
        public const string PhosphorigeSäure = "";

        #endregion

        private int _AnzahlWasserstoff;
        public int AnzahlWasserstoff
        {
            get { return _AnzahlWasserstoff; }
            private set { _AnzahlWasserstoff = value; }
        }

        private SäureRestIon _Säurerestion;
        public SäureRestIon Säurerestion
        {
            get { return _Säurerestion; }
            set { _Säurerestion = value; }
        }

        public Säure(string chemischeFormel, string name, int anzahlWasserstoff, SäureRestIon säurerestion) : base(chemischeFormel, name)
        {
            AnzahlWasserstoff = anzahlWasserstoff;
            Säurerestion = säurerestion;
        }

        public static List<Säure> ErstelleSäure(string chemischeFormel)
        {
            List<Säure> säureVarianten = new List<Säure>();

            if(chemischeFormel[0].Equals('H'))
            {
                string säurerestionFormel = "";

                // Der erste Bestandteil ist ein Wasserstoffmolekühl
                // => Bereite alle Variationen auf, die diese Säure haben kann              
                int maximaleAnzahl = Unicodehelfer.GetNumberOfSubscript(chemischeFormel[1]);
                if(maximaleAnzahl == -1)
                {
                    // Nur ein Wasserstoffmolekühl gefunden, somit kann die Anzahl auf 1 gesetzt werden
                    maximaleAnzahl = 1;
                    säurerestionFormel = chemischeFormel.Substring(1);
                }
                else
                {
                    säurerestionFormel = chemischeFormel.Substring(2);
                }

                // Erstelle für jede Wasserstoffkombination ein Säurerestion, 
                // das für die verschiedenen Salzbildungen verwendet werden kann
                for(int aktuelleAnzahl = 1; aktuelleAnzahl <= maximaleAnzahl; aktuelleAnzahl++)
                {
                    SäureRestIon säurerestion = SäureRestIon.Create(säurerestionFormel, aktuelleAnzahl, aktuelleAnzahl - maximaleAnzahl - 1);
                    switch (chemischeFormel)
                    {
                        case Salzsäure:
                            säureVarianten.Add(new Säure(chemischeFormel: chemischeFormel, name: nameof(Salzsäure), anzahlWasserstoff: aktuelleAnzahl, säurerestion: säurerestion));
                            break;
                        case Schwefelsäure:
                            säureVarianten.Add(new Säure(chemischeFormel: chemischeFormel, name: nameof(Schwefelsäure), anzahlWasserstoff: aktuelleAnzahl, säurerestion: säurerestion));
                            break;
                        default:
                            säureVarianten.Add(new Säure(chemischeFormel: chemischeFormel, name: "Unbekannt", anzahlWasserstoff: aktuelleAnzahl, säurerestion: säurerestion));
                            break;
                    }
                }
            }

            return säureVarianten;
        }
    }
}
