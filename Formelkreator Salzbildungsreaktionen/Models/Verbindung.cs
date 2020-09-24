using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formelkreator_Salzbildungsreaktionen.Models
{
    public class Verbindung
    {
        private string _FormelName;

        public string FormelName
        {
            get { return _FormelName; }
            set { _FormelName = value; }
        }

        public Verbindung(string formelName)
        {
            this.FormelName = formelName;
        }
    }
}
