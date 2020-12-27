using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen
{
    public class Atombindung : Verbindung
    {
        public int AnzahlAtome { get; set; }
        public List<Element> Elemente { get; set; }

        public Atombindung(Element element, int anzahlAtome)
        {
            if(anzahlAtome == 1)
            {
                throw new Exception("Die Anzahl der Atome in einer Bindung darf nicht 1 betragen");
            }

            Elemente = new List<Element>() { element };
            AnzahlAtome = anzahlAtome;

            _ChemischeFormel = element.Symol + UnicodeHelfer.GetSubscriptOfNumber(anzahlAtome);
        }

        public Atombindung(string chemischeFormel, params Element[] elemente)
        {
            _ChemischeFormel = chemischeFormel;

            Elemente = elemente.ToList();
            AnzahlAtome = Elemente.Count;
        }

        public Atombindung(string chemischeFormel, params Atombindung[] atombindungen)
        {
            _ChemischeFormel = chemischeFormel;

            foreach (Atombindung bindung in atombindungen)
            {
                Elemente.AddRange(bindung.Elemente);
            }

            AnzahlAtome = Elemente.Count;
        }

        public bool IstElementbindung()
        {
            return Elemente.Any(x => x.ChemischeFormel != Elemente[0].ChemischeFormel);
        }

        public List<(Element element, int anzahlAtome)> ErhalteBestandteile()
        {
            List<(Element element, int anzahlAtome)> result = new List<(Element element, int anzahlAtome)>();
            foreach(IGrouping<string, Element> gruppe in Elemente.GroupBy(x => x.ChemischeFormel))
            {
                result.Add((element: gruppe.First(), anzahlAtome: gruppe.Count()));
            }

            return result;
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
