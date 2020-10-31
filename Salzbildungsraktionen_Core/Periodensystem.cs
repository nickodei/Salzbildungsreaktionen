using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core
{
    public sealed class Periodensystem
    {
        private static Periodensystem instance = null;
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

        public List<Metall> Metalle { get; set; }
        public List<Nichtmetall> Nichtmetalle { get; set; }

        private Periodensystem()
        {
            ErstelleMetalle();
            ErstelleNichtmetalle();
        }

        private void ErstelleMetalle()
        {
            Metalle = new List<Metall>()
            {
                new Metall() { Symbol = "Li", Name = "Lithium", Wurzel="lith", Hauptgruppe = 1, Elektronegativitaet = 1.0 },
                new Metall() { Symbol = "Na", Name = "Natrium", Wurzel="natr", Hauptgruppe = 1, Elektronegativitaet = 0.9 },
                new Metall() { Symbol = "K", Name = "Kalium", Wurzel="kal", Hauptgruppe = 1, Elektronegativitaet = 0.8 },
                new Metall() { Symbol = "Rb", Name = "Rubidium", Wurzel="rubid",  Hauptgruppe = 1, Elektronegativitaet = 0.8 },
                new Metall() { Symbol = "Cs", Name = "Caesium", Wurzel="caes", Hauptgruppe = 1, Elektronegativitaet = 0.7 },
                new Metall() { Symbol = "Fr", Name = "Francium", Wurzel="franc", Hauptgruppe = 1, Elektronegativitaet = 0.7 },
                new Metall() { Symbol = "Be", Name = "Beryllium", Hauptgruppe = 2, Elektronegativitaet = 1.5 },
                new Metall() { Symbol = "Mg", Name = "Magnesium", Hauptgruppe = 2, Elektronegativitaet = 1.2 },
                new Metall() { Symbol = "Ca", Name = "Calcium", Hauptgruppe = 2, Elektronegativitaet = 1.0 },
                new Metall() { Symbol = "Sr", Name = "Strontium", Hauptgruppe = 2, Elektronegativitaet = 1.0 },
                new Metall() { Symbol = "Ba", Name = "Barium", Hauptgruppe = 2, Elektronegativitaet = 0.9 },
                new Metall() { Symbol = "Ra", Name = "Radium", Hauptgruppe = 2, Elektronegativitaet = 0.9 }
            };
        }

        public Metall FindeMetallNachAtomsymbol(string atomsymbol)
        {
            return Metalle.Where(x => x.Symbol.Equals(atomsymbol)).FirstOrDefault();
        }

        private void ErstelleNichtmetalle()
        {
            Nichtmetalle = new List<Nichtmetall>()
            {
                new Nichtmetall() { Symbol = "H", Name = "Wasserstoff", Wurzel="hydr", Hauptgruppe = 1, Elektronegativitaet = 2.1 },
                new Nichtmetall() { Symbol = "C", Name = "Kohlenstoff", Wurzel="carb", Hauptgruppe = 4, Elektronegativitaet = 2.5 },
                new Nichtmetall() { Symbol = "N", Name = "Stickstoff", Wurzel="nitr", Hauptgruppe = 5, Elektronegativitaet = 3.5 },
                new Nichtmetall() { Symbol = "P", Name = "Phosphor", Wurzel="phosph", Hauptgruppe = 5, Elektronegativitaet = 2.1 },
                new Nichtmetall() { Symbol = "O", Name = "Sauerstoff", Wurzel="ox", Hauptgruppe = 6, Elektronegativitaet = 3.5 },
                new Nichtmetall() { Symbol = "S", Name = "Schwefel", Wurzel="sulf", Hauptgruppe = 6, Elektronegativitaet = 2.5 },
                new Nichtmetall() { Symbol = "F", Name = "Flour", Wurzel="fluor", Hauptgruppe = 7, Elektronegativitaet = 4.0 },
                new Nichtmetall() { Symbol = "Cl", Name = "Chlor", Wurzel="chlor", Hauptgruppe = 7, Elektronegativitaet = 3.0 },
                new Nichtmetall() { Symbol = "Br", Name = "Brom", Wurzel="brom", Hauptgruppe = 7, Elektronegativitaet = 2.8 },
                new Nichtmetall() { Symbol = "I", Name = "Iod", Wurzel="iod", Hauptgruppe = 7, Elektronegativitaet = 2.5 },
            };
        }

        public Nichtmetall FindeNichtmetallNachAtomsymbol(string atomsymbol)
        {
            return Nichtmetalle.Where(x => x.Symbol.Equals(atomsymbol)).FirstOrDefault();
        }
    }
}
