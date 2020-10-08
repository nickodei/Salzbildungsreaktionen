using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Verbindung
    {
        #region

        public const string Wasserstoff = "H2";

        #endregion

        private string _Formel;
        public string Formel
        {
            get { return _Formel; }
            private set { _Formel = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            private set { _Name = value; }
        }

        private double _Anzahl;
        public double Anzahl
        {
            get { return _Anzahl; }
            set { _Anzahl = value; }
        }

        public Verbindung(string formel, string name)
        {
            Formel = formel;
            Name = name;
        }

        public static Verbindung Create(string formel)
        {
            switch (formel)
            {
                case Wasserstoff:
                    return new Verbindung(formel: formel, name: nameof(Wasserstoff));
                default:
                    return new Verbindung(formel: formel, name: "Unbekannt");
            }
        }
    }
}
