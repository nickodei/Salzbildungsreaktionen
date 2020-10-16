using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente
{
    public class Element : Reinstoff
    {
        private string _Symbol;
        public string Symbol
        {
            get { return _Symbol; }
            private set { _Symbol = value; }
        }

        private int _Hauptgruppe;
        public int Hauptgruppe
        {
            get { return _Hauptgruppe; }
            private set { _Hauptgruppe = value; }
        }

        public Element(string name, string symbol, int hauptgruppe) : base(name)
        {
            Symbol = symbol;
            Hauptgruppe = hauptgruppe;
        }

        public int ErhalteLadung()
        {
            // Hauptgruppe entspricht den Außenelektronen
            if (Hauptgruppe <= 3)
            {
                // Gibt Elektronen ab
                return Hauptgruppe;
            }
            else
            {
                // Nimmt Elektronen auf
                return 8 - Hauptgruppe;
            }
        }
    }
}
