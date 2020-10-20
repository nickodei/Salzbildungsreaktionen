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

        private int _Valenzelektronen;
        public int Valenzelektronen
        {
            get { return _Valenzelektronen; }
            private set { _Valenzelektronen = value; }
        }

        public Element(string name, string symbol, int valenzelektronen) : base(name)
        {
            Symbol = symbol;
            Formel = symbol;
            Valenzelektronen = valenzelektronen;
        }
    }
}
