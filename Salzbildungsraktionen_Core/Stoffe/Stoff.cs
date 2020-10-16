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
            private set { _Name = value; }
        }

        public Stoff(string name)
        {
            Name = name;
        }
    }
}
