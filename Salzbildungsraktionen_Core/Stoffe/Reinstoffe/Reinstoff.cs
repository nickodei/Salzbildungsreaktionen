using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe
{
    public class Reinstoff : Stoff
    {
        public Reinstoff(string name) : base(name)
        {
        }

        public Reinstoff(string name, string formel) : base(name, formel)
        {
        }
    }
}
