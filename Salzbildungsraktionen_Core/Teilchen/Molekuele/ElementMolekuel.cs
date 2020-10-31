using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Teilchen.Molekuele
{
    public class ElementMolekuel : Molekuel
    {
        public int AnzahlAtome { get; set; }
        public Element Element { get; set; }

        private string _Name;
        public override string Name => _Name;

        private string _AnionenName;
        public string AnionenName => _AnionenName;

        private string _ChemischeFormel;
        public override string ChemischeFormel => _ChemischeFormel;

        private List<Teilchen> _Bestandteile;
        public override List<Teilchen> Bestadteile => _Bestandteile;
        public override double Elektronegativitaet => Element.Elektronegativitaet;


        public ElementMolekuel(Element element, int anzahlAtome)
        {
            Element = element;

            if (anzahlAtome < 1)
                throw new Exception("Anzahl der Atome darf nicht kleiner 1 sein.");

            _Bestandteile = new List<Teilchen>();
            for (int cnt = 0; cnt < anzahlAtome; cnt++)
            {
                _Bestandteile.Add(new Atom(element));
            }

            _Name = MolekuehlHelfer.ErhaltePraefix(anzahlAtome) + element.Name.ToLower();
            _AnionenName = MolekuehlHelfer.ErhaltePraefix(anzahlAtome) + element.Wurzel.ToLower() + "id";
            _ChemischeFormel = element.Symbol + UnicodeHelfer.GetSubscriptOfNumber(anzahlAtome);
        }
    }
}
