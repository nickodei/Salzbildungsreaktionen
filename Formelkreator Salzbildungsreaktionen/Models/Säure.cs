using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formelkreator_Salzbildungsreaktionen.Models
{
    public class Säure : Verbindung
    {
        #region Säureformeln

        public const string SALZSÄURE = "HCL";
        public const string SCHWEFELSÄURE = "H2SO4";

        #endregion

        private int _AnzahlWasserstoff;
        public int AnzahlWasserstoff
        {
            get { return _AnzahlWasserstoff; }
            set { _AnzahlWasserstoff = value; }
        }

        private Verbindung _SäureRest;
        public Verbindung SäureRest
        {
            get { return _SäureRest; }
            set { _SäureRest = value; }
        }

        public Säure(string formelName) : base(formelName)
        {
            InitialisiereSäure();
        }

        private void InitialisiereSäure()
        {
            int indexWasserstoff = this.FormelName.ToUpper().IndexOf('H');
            if(indexWasserstoff == -1)
            {
                // Error, kein Wasserstoff vorhanden
                return;
            }

            string charakterNachWasserstoff = this.FormelName.Substring(indexWasserstoff + 1, 1);
            if(int.TryParse(charakterNachWasserstoff, out int anzahlWasserstoff))
            {
                AnzahlWasserstoff = anzahlWasserstoff;
                SäureRest = new Verbindung(this.FormelName.Substring(indexWasserstoff + 2));
            }
            else
            {
                // Es befindet sich nur ein Wasserstoff in der Säure
                AnzahlWasserstoff = 1;
                SäureRest = new Verbindung(this.FormelName.Substring(indexWasserstoff + 1));
            }
        }

        public (Salz, Wasser) ReagiertMit (Lauge lauge)
        {
            return (null, null);
        }
    }
}
