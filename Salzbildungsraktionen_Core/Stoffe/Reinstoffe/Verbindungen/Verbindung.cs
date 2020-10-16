using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Verbindung : Reinstoff
    {
        private string _Formel;
        public string Formel
        {
            get { return _Formel; }
            set { _Formel = value; }
        }

        public Verbindung(string name, string formel) : base(name)
        {
            Formel = formel;
        }
    }
}
