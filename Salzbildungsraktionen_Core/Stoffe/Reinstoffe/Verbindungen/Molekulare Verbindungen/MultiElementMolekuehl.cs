using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen
{
    public class MultiElementMolekuehl : Molekuehl
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
        }

        private string _Formel;
        public string Formel
        {
            get { return _Formel; }
        }

        private Reinstoff[] _Bestandteile;
        public Reinstoff[] Bestandteile
        {
            get { return _Bestandteile; }
            set { _Bestandteile = value; }
        }

        public MultiElementMolekuehl(string formel) : base()
        {
            _Formel = formel;

            Bestandteile = GeneriereElementMolekueleAusFormel().ToArray();
            //Bestandteile = GeneriereBestandteileAusElemente(elemente).ToArray();
        }

        public MultiElementMolekuehl(params Reinstoff[] bestandteile) : base()
        {
            Bestandteile = bestandteile;

            foreach(Reinstoff reinstoff in bestandteile)
            {

            }
        }

        private List<Reinstoff> GeneriereElementMolekueleAusFormel()
        {
            List<Reinstoff> bestandteile = new List<Reinstoff>();

            //bool containsSauerstoff = false;
            //int sauerstoffPosition = 0;

            //// Erhalte die einzelnen elementaren Bestandteile aus der Formel
            //char[] buchstaben = Formel.ToCharArray();
            //for (int position = 0; position < buchstaben.Length; position++)
            //{
            //    // Erhalte das aktuelle Symbol aus der Formel
            //    string elementSymbol = buchstaben[position].ToString();

            //    if(position + 1 < buchstaben.Length)
            //    {
            //        // Überprüfe, ob das nächste Symbol zum selben Element gehört
            //        if(char.IsLower(buchstaben[position + 1]))
            //        {
            //            // Erhöhe die Position um 1
            //            position += 1;

            //            // Erweitere das Symbol des Elementes
            //            elementSymbol += buchstaben[position].ToString();
            //        }

            //        Element element = null;

            //        // Finde heraus, ob es sich um ein Metall oder Nichtmetall handelt
            //        if (Periodensystem.Instance.Metalle.TryGetValue(elementSymbol, out Metall metall))
            //        {
            //            element = metall;
            //        }
            //        else if(Periodensystem.Instance.Nichtmetalle.TryGetValue(elementSymbol, out Nichtmetall nichtmetall))
            //        {
            //            element = nichtmetall;

            //            if(nichtmetall.Formel.Equals("O"))
            //            {
            //                containsSauerstoff = true;
            //                sauerstoffPosition = bestandteile.Count;
            //            }
            //        }

            //        if (position + 1 < buchstaben.Length)
            //        {
            //            //Überprüfe, ob das nächste Symbol die Atomzahl des Elementes angibt
            //            if (UnicodeHelfer.GetNumberOfSubscript(buchstaben[position + 1]) != -1)
            //            {
            //                // Erhöhe die Position um 1
            //                position += 1;

            //                // Erhalte die Atomzahl des Elementes
            //                int atomAnzahl = UnicodeHelfer.GetNumberOfSubscript(buchstaben[position]);

            //                // Ersetlle das Molekuel
            //                ElementMolekuehl elementMolekuel = new ElementMolekuehl(element, atomAnzahl);
            //                bestandteile.Add(elementMolekuel);
            //            }
            //            else
            //            {
            //                bestandteile.Add(element);
            //            }
            //        }
            //        else
            //        {
            //            bestandteile.Add(element);
            //        }
            //    }
            //}

            //if(containsSauerstoff)
            //{
            //    if(bestandteile.Count > 1)
            //    {
            //        MultiElementMolekuehl oxid = new MultiElementMolekuehl(bestandteile[sauerstoffPosition - 1], bestandteile[sauerstoffPosition]);
            //        bestandteile.RemoveRange(sauerstoffPosition - 1, 2);

            //        bestandteile.Add(oxid);
            //    }               
            //}

            return bestandteile;
        }

        protected void GeneriereBestandteileAusFormel(string formel)
        {
            List<Reinstoff> bestandteile = new List<Reinstoff>();

            //char[] buchstaben = formel.ToCharArray();
            //for (int position = 0; position < buchstaben.Length; position++)
            //{
            //    // Erhalte das aktuelle Symbol aus der Formel
            //    char symbol = buchstaben[position];
            //    if (position != buchstaben.Length - 1)
            //    {
            //        // Überprüfe, ob es nicht ein Element mit zwei Zeichen ist oder eine andere Atomzahl hat
            //        char nextSymbol = buchstaben[position + 1];

            //        if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "" + nextSymbol, out Metall metall2))
            //        {
            //            if (ÜberprüfeObAtomzahlAnders(nextSymbol))
            //            {
            //                // Es ist ein MetallMolekühl
            //                ElementMolekuehl metallMolekueel = new ElementMolekuehl(metall2, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
            //                bestandteile.Add(metallMolekueel);
            //                position += 1;
            //                continue;
            //            }

            //            // Es ist ein Metall
            //            bestandteile.Add(metall2);
            //            continue;
            //        }
            //        else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "" + nextSymbol, out Nichtmetall nichtmetall2))
            //        {
            //            if (ÜberprüfeObAtomzahlAnders(nextSymbol))
            //            {
            //                // Es ist ein MetallMolekühl
            //                ElementMolekuehl nichtmetallMolekueel = new ElementMolekuehl(nichtmetall2, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
            //                bestandteile.Add(nichtmetallMolekueel);
            //                position += 1;
            //                continue;
            //            }

            //            // Es ist ein Nichtmetall
            //            bestandteile.Add(nichtmetall2);
            //            continue;
            //        }
            //        // Erstmal in den Metallen
            //        else if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "", out Metall metall1))
            //        {
            //            if (ÜberprüfeObAtomzahlAnders(nextSymbol))
            //            {
            //                // Es ist ein MetallMolekühl
            //                ElementMolekuehl metallMolekueel = new ElementMolekuehl(metall1, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
            //                bestandteile.Add(metallMolekueel);
            //                continue;
            //            }

            //            // Es ist ein Metall
            //            bestandteile.Add(metall1);
            //            continue;
            //        }
            //        else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "", out Nichtmetall nichtmetall1))
            //        {
            //            if (ÜberprüfeObAtomzahlAnders(nextSymbol))
            //            {
            //                // Es ist ein MetallMolekühl
            //                ElementMolekuehl nichtmetallMolekueel = new ElementMolekuehl(nichtmetall1, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
            //                bestandteile.Add(nichtmetallMolekueel);
            //                continue;
            //            }

            //            // Es ist ein Nichtmetall
            //            bestandteile.Add(nichtmetall1);
            //            continue;
            //        }
            //    }

            //    // Überprüfe, ob es ein Element mit einem Zeichen ist
            //    // Erstmal in den Metallen
            //    if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "", out Metall metall))
            //    {
            //        // Es ist ein Metall
            //        bestandteile.Add(metall);
            //        continue;
            //    }
            //    else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "", out Nichtmetall nichtmetall))
            //    {
            //        // Es ist ein Nichtmetall
            //        bestandteile.Add(nichtmetall);
            //        continue;
            //    }
            //}

            Bestandteile = bestandteile.ToArray();
        }
    }
}
