using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    public abstract class Ion
    {
        private int _Ladung;
        public int Ladung
        {
            get { return _Ladung; }
            set { _Ladung = value; }
        }

        public Ion(int ladung)
        {
            Ladung = ladung;
        }

        public abstract string GetName();
        public abstract string GetFormel();
    }
}
