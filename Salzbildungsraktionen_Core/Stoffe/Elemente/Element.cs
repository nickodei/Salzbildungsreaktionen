using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente
{
    public class Element : Stoff
    {
        public string Symol => ChemischeFormel;
        public string Wurzel { get; set; }
        public int Hauptgruppe { get; set; }
        public double Elektronegativitaet { get; set; }

        public Element(string symbol, string name, string wurzel, int hauptgruppe, double elektronegativitaet)
        {
            _Name = name;
            _ChemischeFormel = symbol;

            Wurzel = wurzel;
            Hauptgruppe = hauptgruppe;
            Elektronegativitaet = elektronegativitaet;
        }

        protected override string GeneriereName()
        {
            // Wird im Konstuktor gesetzt und sollte nie aufgerufen werden
            throw new NotImplementedException("Der Name des Elementes wurde nie initialisiert.");
        }

        protected override string GeneriereChemischeFormel()
        {
            // Wird im Konstuktor gesetzt und sollte nie aufgerufen werden
            throw new NotImplementedException("Die Formel des Elementes wurde nie initialisiert.");
        }
    }
}
