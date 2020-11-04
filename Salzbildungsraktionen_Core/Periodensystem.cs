using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
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

        private Periodensystem()
        {
        }

        private void ErstelleMetalle()
        {
            _Metall = new List<Metall>()
            {
                new Metall(symbol:"Li", elementname:"Lithium",   wurzel:"lith",  hauptgruppe:1, elektronegativitaet:1.0),
                new Metall(symbol:"Na", elementname:"Natrium",   wurzel:"natr",  hauptgruppe:1, elektronegativitaet:0.9),
                new Metall(symbol:"K",  elementname:"Kalium",    wurzel:"kal",   hauptgruppe:1, elektronegativitaet:0.8),
                new Metall(symbol:"Rb", elementname:"Rubidium",  wurzel:"rubid", hauptgruppe:1, elektronegativitaet:0.8),
                new Metall(symbol:"Cs", elementname:"Caesium",   wurzel:"caes",  hauptgruppe:1, elektronegativitaet:0.7),
                new Metall(symbol:"Fr", elementname:"Francium",  wurzel:"franc", hauptgruppe:1, elektronegativitaet:0.7),
                new Metall(symbol:"Be", elementname:"Beryllium", wurzel:"",      hauptgruppe:2, elektronegativitaet:1.5),
                new Metall(symbol:"Mg", elementname:"Magnesium", wurzel:"",      hauptgruppe:2, elektronegativitaet:1.2),
                new Metall(symbol:"Ca", elementname:"Calcium",   wurzel:"",      hauptgruppe:2, elektronegativitaet:1.0),
                new Metall(symbol:"Sr", elementname:"Strontium", wurzel:"",      hauptgruppe:2, elektronegativitaet:1.0),
                new Metall(symbol:"Ba", elementname:"Barium",    wurzel:"",      hauptgruppe:2, elektronegativitaet:0.9),
                new Metall(symbol:"Ra", elementname:"Radium",    wurzel:"",      hauptgruppe:2, elektronegativitaet:0.9),
                new Metall(symbol:"Al", elementname:"Aluminium", wurzel:"",      hauptgruppe:3, elektronegativitaet:1.61)
            };                                                                       
        }

        public Metall FindeMetallNachAtomsymbol(string atomsymbol)
        {
            return Metalle.Where(x => x.Formel.Equals(atomsymbol)).FirstOrDefault();
        }

        private void ErstelleNichtmetalle()
        {
            _Nichtmetalle = new List<Nichtmetall>()
            {
                new Nichtmetall(symbol:"H",  elementname:"Wasserstoff", wurzel:"hydr",   hauptgruppe:1, elektronegativitaet:2.1),
                new Nichtmetall(symbol:"C",  elementname:"Kohlenstoff", wurzel:"carb",   hauptgruppe:4, elektronegativitaet:2.5),
                new Nichtmetall(symbol:"N",  elementname:"Stickstoff",  wurzel:"nitr",   hauptgruppe:5, elektronegativitaet:3.5),
                new Nichtmetall(symbol:"P",  elementname:"Phosphor",    wurzel:"phosph", hauptgruppe:5, elektronegativitaet:2.1),
                new Nichtmetall(symbol:"O",  elementname:"Sauerstoff",  wurzel:"ox",     hauptgruppe:6, elektronegativitaet:3.5),
                new Nichtmetall(symbol:"S",  elementname:"Schwefel",    wurzel:"sulf",   hauptgruppe:6, elektronegativitaet:2.5),
                new Nichtmetall(symbol:"F",  elementname:"Flour",       wurzel:"fluor",  hauptgruppe:7, elektronegativitaet:4.0),
                new Nichtmetall(symbol:"Cl", elementname:"Chlor",       wurzel:"chlor",  hauptgruppe:7, elektronegativitaet:3.0),
                new Nichtmetall(symbol:"Br", elementname:"Brom",        wurzel:"brom",   hauptgruppe:7, elektronegativitaet:2.8),
                new Nichtmetall(symbol:"I",  elementname:"Iod",         wurzel:"iod",    hauptgruppe:7, elektronegativitaet:2.5),
            };
        }

        public Nichtmetall FindeNichtmetallNachAtomsymbol(string atomsymbol)
        {
            return Nichtmetalle.Where(x => x.Formel.Equals(atomsymbol)).FirstOrDefault();
        }

        public void ErstelleSaeuren()
        {
            _Saeuren = new List<Saeure>()
            {
                new Saeure("HCl"),
                new Saeure("H₂SO₄"),
                new Saeure("H₂SO₃"),
                new Saeure("H₃PO₄"),
                new Saeure("H₃PO₃"),
                new Saeure("H₂S"),
                new Saeure("HNO₃"),
                new Saeure("HNO₂"),
                new Saeure("HCN"),
                new Saeure("H₂CO₃"),
                new Saeure("HF"),
            };
        }
    }
}
