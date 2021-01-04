using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core
{
    public sealed class Periodensystem
    {
        public static Periodensystem Instance = new Periodensystem();

        private List<Metall> _Metall;
        public List<Metall> Metalle 
        { 
            get
            {
                if(_Metall == null)
                {
                    ErstelleMetalle();
                }

                return _Metall;
            } 
        }

        private List<Nichtmetall> _Nichtmetalle;
        public List<Nichtmetall> Nichtmetalle
        {
            get
            {
                if (_Nichtmetalle == null)
                {
                    ErstelleNichtmetalle();
                }

                return _Nichtmetalle;
            }
        }

        private List<Saeure> _Saeuren;
        public List<Saeure> Saeuren
        {
            get
            {
                if (_Saeuren == null)
                {
                    ErstelleSaeuren();
                }

                return _Saeuren;
            }
        }

        private List<Lauge> _Laugen;
        public List<Lauge> Laugen
        {
            get
            {
                if (_Laugen == null)
                {
                    ErstelleLaugen();
                }

                return _Laugen;
            }
        }

        private List<Oxid> _Metalloxide;
        public List<Oxid> Metalloxide
        {
            get
            {
                if (_Metalloxide == null)
                {
                    ErstelleMetalloxide();
                }

                return _Metalloxide;
            }
        }


        private Periodensystem()
        {
        }

        private void ErstelleMetalle()
        {
            _Metall = new List<Metall>()
            {
                new Metall(symbol:"Li", elementname:"Lithium",   wurzel:"Lith",  hauptgruppe:1, elektronegativitaet:1.0),
                new Metall(symbol:"Na", elementname:"Natrium",   wurzel:"Natr",  hauptgruppe:1, elektronegativitaet:0.9),
                new Metall(symbol:"K",  elementname:"Kalium",    wurzel:"Kal",   hauptgruppe:1, elektronegativitaet:0.8),
                new Metall(symbol:"Rb", elementname:"Rubidium",  wurzel:"Rubid", hauptgruppe:1, elektronegativitaet:0.8),
                new Metall(symbol:"Cs", elementname:"Caesium",   wurzel:"Caes",  hauptgruppe:1, elektronegativitaet:0.7),
                new Metall(symbol:"Fr", elementname:"Francium",  wurzel:"Franc", hauptgruppe:1, elektronegativitaet:0.7),
                new Metall(symbol:"Be", elementname:"Beryllium", wurzel:"",      hauptgruppe:2, elektronegativitaet:1.5),
                new Metall(symbol:"Mg", elementname:"Magnesium", wurzel:"",      hauptgruppe:2, elektronegativitaet:1.2),
                new Metall(symbol:"Ca", elementname:"Calcium",   wurzel:"",      hauptgruppe:2, elektronegativitaet:1.0),
                new Metall(symbol:"Sr", elementname:"Strontium", wurzel:"",      hauptgruppe:2, elektronegativitaet:1.0),
                new Metall(symbol:"Ba", elementname:"Barium",    wurzel:"",      hauptgruppe:2, elektronegativitaet:0.9),
                new Metall(symbol:"Ra", elementname:"Radium",    wurzel:"",      hauptgruppe:2, elektronegativitaet:0.9),
                new Metall(symbol:"Al", elementname:"Aluminium", wurzel:"",      hauptgruppe:3, elektronegativitaet:1.61),
                new Metall(symbol:"Ti", elementname:"Titan",     wurzel:"",      hauptgruppe:3, elektronegativitaet:1.8)
            };                                                                       
        }

        public Metall FindeMetallNachAtomsymbol(string atomsymbol)
        {
            return Metalle.Where(x => x.Symol.Equals(atomsymbol)).FirstOrDefault();
        }

        private void ErstelleNichtmetalle()
        {
            _Nichtmetalle = new List<Nichtmetall>()
            {
                new Nichtmetall(symbol:"H",  elementname:"Wasserstoff", wurzel:"Hydr",   hauptgruppe:1, elektronegativitaet:2.1),
                new Nichtmetall(symbol:"C",  elementname:"Kohlenstoff", wurzel:"Carbon", hauptgruppe:4, elektronegativitaet:2.5),
                new Nichtmetall(symbol:"N",  elementname:"Stickstoff",  wurzel:"Nitr",   hauptgruppe:5, elektronegativitaet:3.5),
                new Nichtmetall(symbol:"P",  elementname:"Phosphor",    wurzel:"Phosph", hauptgruppe:5, elektronegativitaet:2.1),
                new Nichtmetall(symbol:"O",  elementname:"Sauerstoff",  wurzel:"Ox",     hauptgruppe:6, elektronegativitaet:3.5),
                new Nichtmetall(symbol:"S",  elementname:"Schwefel",    wurzel:"Sulf",   hauptgruppe:6, elektronegativitaet:2.5),
                new Nichtmetall(symbol:"F",  elementname:"Flour",       wurzel:"Fluor",  hauptgruppe:7, elektronegativitaet:4.0),
                new Nichtmetall(symbol:"Cl", elementname:"Chlor",       wurzel:"Chlor",  hauptgruppe:7, elektronegativitaet:3.0),
                new Nichtmetall(symbol:"Br", elementname:"Brom",        wurzel:"Brom",   hauptgruppe:7, elektronegativitaet:2.8),
                new Nichtmetall(symbol:"I",  elementname:"Iod",         wurzel:"Iod",    hauptgruppe:7, elektronegativitaet:2.5),
            };
        }

        public bool UeberpruefeObMetall(string symbol)
        {
            if (symbol.Length > 2 || String.IsNullOrEmpty(symbol))
            {
                // Symbol kann nicht mehr als zwei Zeichen beinhalten oder leer sein
                return false;
            }
            else if(symbol.Length == 2)
            {
                // Überprüfe, ob die zweite Stelle kleingeschrieben ist
                if(Char.IsLower(symbol[1]) == false)
                {
                    return false;
                }
            }

            if(FindeMetallNachAtomsymbol(symbol) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Nichtmetall FindeNichtmetallNachAtomsymbol(string atomsymbol)
        {
            return Nichtmetalle.Where(x => x.Symol.Equals(atomsymbol)).FirstOrDefault();
        }

        public bool UberpruefeObElement(string symbol)
        {
            return UeberpruefeObMetall(symbol) || UeberpruefeObNichtmetall(symbol);
        }

        public bool UeberpruefeObNichtmetall(string symbol)
        {
            if (symbol.Length > 2 || String.IsNullOrEmpty(symbol))
            {
                // Symbol kann nicht mehr als zwei Zeichen beinhalten oder leer sein
                return false;
            }
            else if (symbol.Length == 2)
            {
                // Überprüfe, ob die zweite Stelle kleingeschrieben ist
                if (Char.IsLower(symbol[1]) == false)
                {
                    return false;
                }
            }

            if (FindeNichtmetallNachAtomsymbol(symbol) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ErstelleSaeuren()
        {
            _Saeuren = new List<Saeure>()
            {
                new Saeure("HF"),
                new Saeure("H₂S"),
                new Saeure("HCl"),
                new Saeure("HCN"),
                new Saeure("HNO₂"),
                new Saeure("HNO₃"),
                new Saeure("H₂SO₄"),
                new Saeure("H₂SO₃"),
                new Saeure("H₃PO₄"),
                new Saeure("H₃PO₃"),
                new Saeure("H₂CO₃"),
            };
        }

        public void ErstelleMetalloxide()
        {
            _Metalloxide = new List<Oxid>();
            foreach(Metall metall in Metalle)
            {
                _Metalloxide.Add(new Oxid(metall));
            }
        }

        public void ErstelleLaugen()
        {
            _Laugen = new List<Lauge>();
            foreach (Metall metall in Metalle)
            {
                _Laugen.Add(new Lauge(metall));
            }

            // Füge den Ammoniak hinzu
            _Laugen.Add(new Ammoniak());
        }
    }
}
