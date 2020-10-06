using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salzbildungsreaktionen_Core.Models.Verbindungen
{
    public class Verbindung
    {
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

        private int _Anzahl;
        public int Anzahl
        {
            get { return _Anzahl; }
            set { _Anzahl = value; }
        }


        public Verbindung(string formel, string name)
        {
            Formel = formel;
            Name = name;
        }
    }
}
