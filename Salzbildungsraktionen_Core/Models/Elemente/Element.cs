namespace Salzbildungsreaktionen_Core.Models.Elemente
{
    public class Element
    {
        private string _Symbol;
        public string Symbol
        {
            get { return _Symbol; }
            private set { _Symbol = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            private set { _Name = value; }
        }

        private int _Wertigkeit;
        public int Wertigkeit
        {
            get { return _Wertigkeit; }
            private set { _Wertigkeit = value; }
        }

        private int _Anzahl;
        public int Anzahl
        {
            get { return _Anzahl; }
            set { _Anzahl = value; }
        }

        public Element(string symbol, string name, int wertigkeit)
        {
            Wertigkeit = wertigkeit;
            Symbol = symbol;
            Name = name;
        }
    }
}
