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

        public const string Wasserstoff = "H₂";

        #endregion

        private string _ChemischeFormel;
        public string ChemischeFormel
        {
            get { return _ChemischeFormel; }
            private set { _ChemischeFormel = value; }
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

        public Verbindung(string chemischeFormel, string name)
        {
            ChemischeFormel = chemischeFormel;
            Name = name;
            Anzahl = 1;
        }

        public static Verbindung Create(string formel)
        {
            switch (formel)
            {
                case Wasserstoff:
                    return new Verbindung(chemischeFormel: formel, name: nameof(Wasserstoff));
                default:
                    return new Verbindung(chemischeFormel: formel, name: "Unbekannt");
            }
        }


    }
}
