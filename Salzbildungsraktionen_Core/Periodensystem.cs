using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core
{
    public sealed class Periodensystem
    {
        private static Periodensystem instance = null;

        private Periodensystem()
        {
        }

        public static Periodensystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Periodensystem();
                }
                return instance;
            }
        }

        private Dictionary<string, Metall> _Metalle;
        public Dictionary<string, Metall> Metalle
        {
            get 
            { 
                if(_Metalle == null)
                {
                    StelleMetalleBereit();
                }
                return _Metalle; 
            }
            set { _Metalle = value; }
        }

        private Dictionary<string, Nichtmetall> _Nichtmetall;
        public Dictionary<string, Nichtmetall> Nichtmetalle
        {
            get
            {
                if (_Nichtmetall == null)
                {
                    StelleNichtmetalleBereit();
                }
                return _Nichtmetall;
            }
            set { _Nichtmetall = value; }
        }

        private Dictionary<string, Saeure> _Saeure;
        public Dictionary<string, Saeure> Saeure
        {
            get
            {
                if (_Saeure == null)
                {
                    StelleSaeurenBereit();
                }
                return _Saeure;
            }
            set { _Saeure = value; }
        }

        private Dictionary<string, Metalloxid> _Metalloxide;
        public Dictionary<string, Metalloxid> Metalloxide
        {
            get
            {
                if (_Metalle == null)
                {
                    StelleMetalleBereit();
                }

                if(_Metalloxide == null)
                {
                    StelleMetalloxideBereit();
                }

                return _Metalloxide;
            }
            set { _Metalloxide = value; }
        }

        public void StelleMetalleBereit()
        {
            Metalle = new Dictionary<string, Metall>();
            Metalle.Add("Li", new Metall("Li", "Lithium", 1));
            Metalle.Add("Na", new Metall("Na", "Natrium", 1));
            Metalle.Add("Rb", new Metall("Rb", "Rubidium", 1));
            Metalle.Add("Cs", new Metall("Cs", "Caesium", 1));
            Metalle.Add("Fr", new Metall("Fr", "Francium", 1));
            Metalle.Add("Be", new Metall("Be", "Beryllium", 2));
            Metalle.Add("Ca", new Metall("Ca", "Calcium", 2));
            Metalle.Add("Sr", new Metall("Sr", "Strontium", 2));
            Metalle.Add("Ba", new Metall("Ba", "Barium", 2));
            Metalle.Add("Ra", new Metall("Ra", "Radium", 2));
            Metalle.Add("Al", new Metall("Al", "Aluminium", 3));
        }

        public void StelleNichtmetalleBereit()
        {
            Nichtmetalle = new Dictionary<string, Nichtmetall>();
            Nichtmetalle.Add("H", new Nichtmetall("H", "Wasserstoff", 1));
            Nichtmetalle.Add("C", new Nichtmetall("C", "Kohlenstoff", 4));
            Nichtmetalle.Add("N", new Nichtmetall("N", "Stickstoff", 5));
            Nichtmetalle.Add("P", new Nichtmetall("P", "Phosphor", 5));
            Nichtmetalle.Add("O", new Nichtmetall("O", "Sauerstoff", 6));
            Nichtmetalle.Add("S", new Nichtmetall("S", "Schwefel", 6));
            Nichtmetalle.Add("F", new Nichtmetall("F", "Fluor", 7));
            Nichtmetalle.Add("Cl", new Nichtmetall("Cl", "Chlor", 7));
            Nichtmetalle.Add("Br", new Nichtmetall("Br", "Brom", 7));
        }

        public void StelleSaeurenBereit()
        {
            Saeure = new Dictionary<string, Saeure>();
            Saeure.Add("HCl", new Saeure("HCl"));
            Saeure.Add("H₂SO₄", new Saeure("H₂SO₄"));
            Saeure.Add("H₂SO₃", new Saeure("H₂SO₃"));
            Saeure.Add("H₃PO₄", new Saeure("H₃PO₄"));
            Saeure.Add("H₃PO₃", new Saeure("H₃PO₃"));
            Saeure.Add("H₂S", new Saeure("H₂S"));
            Saeure.Add("HNO₃", new Saeure("HNO₃"));
            Saeure.Add("HNO₂", new Saeure("HNO₂"));
            Saeure.Add("HCN", new Saeure("HCN"));
            Saeure.Add("H₂CO₃", new Saeure("H₂CO₃"));
            Saeure.Add("HF", new Saeure("HF"));
        }

        public void StelleMetalloxideBereit()
        {
            Metalloxide = new Dictionary<string, Metalloxid>();
            foreach(Metall metall in Metalle.Values)
            {
                Metalloxid metalloxid = new Metalloxid(metall);
                Metalloxide.Add(metalloxid.Formel, metalloxid);
            }
        }
    }
}
