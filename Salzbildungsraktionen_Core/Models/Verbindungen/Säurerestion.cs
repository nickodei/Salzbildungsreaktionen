using Salzbildungsreaktionen_Core.Models.Elemente;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Säurerestion : Verbindung
    {
        #region Namen

        public const string Sulfat = "SO4";

        #endregion

        private int _Wertigkeit;
        public int Wertigkeit
        {
            get { return _Wertigkeit; }
            private set { _Wertigkeit = value; }
        }

        public Säurerestion(string formel, string name, int wertigkeit) : base(formel, name)
        {
            Wertigkeit = wertigkeit;
        }

        public static new Säurerestion Create(string formel)
        {
            switch (formel)
            {
                case Sulfat:
                    return new Säurerestion(formel: formel, name: nameof(Sulfat), wertigkeit: -2);
                default:
                    NichtMetall nichtMetall = NichtMetall.Create(formel);
                    if(nichtMetall == null)
                    {
                        return null;
                    }

                    return new Säurerestion(formel: nichtMetall.Symbol, name: nichtMetall.Name, wertigkeit: nichtMetall.Wertigkeit);
            }
        }
    }
}
