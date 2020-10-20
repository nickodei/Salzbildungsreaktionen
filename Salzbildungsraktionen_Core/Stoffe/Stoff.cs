using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    public class Stoff
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            protected set { _Name = value; }
        }

        private string _Formel;
        public string Formel
        {
            get { return _Formel; }
            set { _Formel = value; }
        }

        public Stoff(string name)
        {
            Name = name;
        }

        public Stoff(string name, string formel)
        {
            Name = name;
            Formel = formel;
        }
    }
}
