using Salzbildungsreaktionen_Core.Models.Elemente;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class SäureRestIon : Verbindung
    {
        #region Namen

        public const string Sulfat = "SO₄";

        #endregion

        private int _Ladung;
        public int Ladung
        {
            get { return _Ladung; }
            private set { _Ladung = value; }
        }

        private int _AnzahlWasserstoff;
        public int AnzahlWasserstoff
        {
            get { return _AnzahlWasserstoff; }
            private set { _AnzahlWasserstoff = value; }
        }

        public SäureRestIon(string chemischeFormel, string name, int anzahlWasserstoff, int ladung) : base(chemischeFormel, name)
        {
            Ladung = ladung;
            AnzahlWasserstoff = anzahlWasserstoff;
        }

        public static SäureRestIon Create(string chemischeFormel, int anzahlWasserstoff, int ladung)
        {
            switch (chemischeFormel)
            {
                case Sulfat:
                    return new SäureRestIon(chemischeFormel: chemischeFormel, name: nameof(Sulfat), anzahlWasserstoff: 0, ladung: -2);
                default:
                    return new SäureRestIon(chemischeFormel: chemischeFormel, name: "Unbekannt", anzahlWasserstoff: anzahlWasserstoff, ladung: ladung);
            }
        }
    }
}
