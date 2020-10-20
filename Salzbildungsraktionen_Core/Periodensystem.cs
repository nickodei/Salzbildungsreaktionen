using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core
{
    public sealed class Periodensystem
    {
        private static Periodensystem instance = null;

        private Periodensystem()
        {
            StelleMetalleBereit();
            StelleNichtmetalleBereit();
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
            get { return _Metalle; }
            set { _Metalle = value; }
        }

        private Dictionary<string, Nichtmetall> _Nichtmetall;
        public Dictionary<string, Nichtmetall> Nichtmetalle
        {
            get { return _Nichtmetall; }
            set { _Nichtmetall = value; }
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
    }
}
