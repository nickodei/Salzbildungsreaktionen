using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen
{
    public class Molekularverbindung : Verbindung
    {
        public Molekularverbindung()
        {
        }

        public Molekularverbindung(string chemischeFormel, string trivialname = null)
        {
            _ChemischeFormel = chemischeFormel;

            if(!String.IsNullOrEmpty(trivialname))
            {
                _Name = trivialname;
            }
            else
            {
                _Name = "Unbekannt";
            }
        }     

        protected override string GeneriereName()
        {
            return GeneriereNameErsterOrdnung();
        }

        protected override string GeneriereChemischeFormel()
        {
            throw new NotImplementedException();
        }
    }
}
