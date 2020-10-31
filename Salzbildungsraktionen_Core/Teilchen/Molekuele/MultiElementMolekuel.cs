using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Teilchen.Molekuele
{
    public class MultiElementMolekuel : Molekuel
    {
        private string _Name;
        public override string Name => _Name;

        public List<Teilchen> _Bestandteile;
        public override List<Teilchen> Bestadteile => _Bestandteile;

        private double _ElektronegativitaetsDifferenz;
        public override double Elektronegativitaet => _ElektronegativitaetsDifferenz;

        private string _ChemischeFormel;
        public override string ChemischeFormel => _ChemischeFormel;

        public MultiElementMolekuel(Atom atom1, Atom atom2)
        {
            _Bestandteile = new List<Teilchen>();
            _Bestandteile.Add(atom1);
            _Bestandteile.Add(atom2);

            if(atom1.Elektronegativitaet > atom2.Elektronegativitaet)
            {
                _Name = atom2.Name + atom1.Element.Wurzel + "id";
                _ChemischeFormel = atom2.ChemischeFormel + atom1.ChemischeFormel.ToLower();
                _ElektronegativitaetsDifferenz = atom1.Elektronegativitaet - atom2.Elektronegativitaet;
            }
            else
            {
                _Name = atom1.Name + atom2.Element.Wurzel + "id";
                _ChemischeFormel = atom1.ChemischeFormel + atom2.ChemischeFormel.ToLower();
                _ElektronegativitaetsDifferenz = atom2.Elektronegativitaet - atom1.Elektronegativitaet;
            }           
        }

        public MultiElementMolekuel(Atom atom, ElementMolekuel elementMolekuel)
        {
            _Bestandteile = new List<Teilchen>();
            _Bestandteile.Add(atom);
            _Bestandteile.Add(elementMolekuel);

            if (atom.Elektronegativitaet > elementMolekuel.Elektronegativitaet)
            {
                _Name = elementMolekuel.Name + atom.Element.Wurzel.ToLower() + "id";
                _ChemischeFormel = elementMolekuel.ChemischeFormel + atom.ChemischeFormel;
                _ElektronegativitaetsDifferenz = atom.Elektronegativitaet - elementMolekuel.Elektronegativitaet;
            }
            else
            {
                _Name = atom.Name + elementMolekuel.AnionenName.ToLower();
                _ChemischeFormel = atom.ChemischeFormel + elementMolekuel.ChemischeFormel;
                _ElektronegativitaetsDifferenz = elementMolekuel.Elektronegativitaet - atom.Elektronegativitaet;
            }
        }

        public MultiElementMolekuel(ElementMolekuel elementMolekuel1, ElementMolekuel elementMolekuel2)
        {
            _Bestandteile = new List<Teilchen>();
            _Bestandteile.Add(elementMolekuel1);
            _Bestandteile.Add(elementMolekuel2);

            if (elementMolekuel1.Elektronegativitaet > elementMolekuel2.Elektronegativitaet)
            {
                _Name = elementMolekuel2.Name + elementMolekuel1.AnionenName.ToLower();
                _ChemischeFormel = elementMolekuel2.ChemischeFormel + elementMolekuel1.ChemischeFormel;
                _ElektronegativitaetsDifferenz = elementMolekuel1.Elektronegativitaet - elementMolekuel2.Elektronegativitaet;
            }
            else
            {
                _Name = elementMolekuel1.Name + elementMolekuel2.AnionenName.ToLower();
                _ChemischeFormel = elementMolekuel1.ChemischeFormel + elementMolekuel2.ChemischeFormel;
                _ElektronegativitaetsDifferenz = elementMolekuel2.Elektronegativitaet - elementMolekuel1.Elektronegativitaet;
            }
        }

        public MultiElementMolekuel(string chemischeFormel)
        {
            _Bestandteile = new List<Teilchen>();

            bool containsSauerstoff = false;
            int sauerstoffPosition = 0;

            // Erhalte die einzelnen elementaren Bestandteile aus der Formel
            char[] buchstaben = chemischeFormel.ToCharArray();
            for (int position = 0; position < buchstaben.Length; position++)
            {
                // Erhalte das aktuelle Symbol aus der Formel
                string elementSymbol = buchstaben[position].ToString();

                if (position + 1 < buchstaben.Length)
                {
                    // Überprüfe, ob das nächste Symbol zum selben Element gehört
                    if (char.IsLower(buchstaben[position + 1]))
                    {
                        // Erhöhe die Position um 1
                        position += 1;

                        // Erweitere das Symbol des Elementes
                        elementSymbol += buchstaben[position].ToString();
                    }

                    Element element = Periodensystem.Instance.FindeMetallNachAtomsymbol(elementSymbol);
                    if(element == null)
                    {
                        element = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(elementSymbol);
                        if(element != null)
                        {
                            if (element.Symbol.Equals("O"))
                            {
                                containsSauerstoff = true;
                                sauerstoffPosition = _Bestandteile.Count;
                            }
                        }
                    }

                    if (position + 1 < buchstaben.Length)
                    {
                        //Überprüfe, ob das nächste Symbol die Atomzahl des Elementes angibt
                        if (UnicodeHelfer.GetNumberOfSubscript(buchstaben[position + 1]) != -1)
                        {
                            // Erhöhe die Position um 1
                            position += 1;

                            // Erhalte die Atomzahl des Elementes
                            int atomAnzahl = UnicodeHelfer.GetNumberOfSubscript(buchstaben[position]);

                            // Ersetlle das Molekuel
                            ElementMolekuel elementMolekuel = new ElementMolekuel(element, atomAnzahl);
                            _Bestandteile.Add(elementMolekuel);
                        }
                        else
                        {
                            _Bestandteile.Add(new Atom(element));
                        }
                    }
                    else
                    {
                        _Bestandteile.Add(new Atom(element));
                    }
                }
                else
                {
                    Element element = Periodensystem.Instance.FindeMetallNachAtomsymbol(elementSymbol);
                    if (element == null)
                    {
                        element = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(elementSymbol);
                        if (element != null)
                        {
                            if (element.Symbol.Equals("O"))
                            {
                                containsSauerstoff = true;
                                sauerstoffPosition = _Bestandteile.Count;
                            }
                        }
                    }

                    _Bestandteile.Add(new Atom(element));
                }
            }

            if (_Bestandteile.Count > 3 && containsSauerstoff)
            {
                MultiElementMolekuel oxid = null;
                Teilchen reaktionsTeilchen = null;
                Teilchen sauerstoff = _Bestandteile[sauerstoffPosition];

                // Wenn das Teilchen vor ihm Flour ist, dann ist die Formel FO und nicht OF
                if (_Bestandteile[sauerstoffPosition - 1].Elektronegativitaet > sauerstoff.Elektronegativitaet)
                {
                    reaktionsTeilchen = _Bestandteile[sauerstoffPosition - 1];
                    _Bestandteile.RemoveRange(sauerstoffPosition - 2, 2);
                }
                else
                {
                    reaktionsTeilchen = _Bestandteile[sauerstoffPosition + 1];
                    _Bestandteile.RemoveRange(sauerstoffPosition - 1, 2);
                }

                if (reaktionsTeilchen is Atom)
                {
                    if (sauerstoff is Atom)
                    {
                        oxid = new MultiElementMolekuel(reaktionsTeilchen as Atom, sauerstoff as Atom);
                    }
                    else
                    {
                        oxid = new MultiElementMolekuel(reaktionsTeilchen as Atom, sauerstoff as ElementMolekuel);
                    }
                }
                else
                {
                    if (sauerstoff is Atom)
                    {
                        oxid = new MultiElementMolekuel(sauerstoff as Atom, reaktionsTeilchen as ElementMolekuel);
                    }
                    else
                    {
                        oxid = new MultiElementMolekuel(sauerstoff as ElementMolekuel, reaktionsTeilchen as ElementMolekuel);
                    }
                }

                _Bestandteile.Add(oxid);
            }

            if (_Bestandteile.Count <= 1)
                throw new Exception("Ein Molekül muss aus mehr als einem Element bestehen");

            if (_Bestandteile[0].Elektronegativitaet > _Bestandteile[1].Elektronegativitaet)
            {
                if(_Bestandteile[0] is ElementMolekuel)
                {
                    _Name = _Bestandteile[1].Name + ((ElementMolekuel)_Bestandteile[0]).AnionenName.ToLower();
                }
                else
                {
                    _Name = _Bestandteile[1].Name + ((Atom)_Bestandteile[0]).Element.Wurzel.ToLower() + "id";
                }

                _ChemischeFormel = _Bestandteile[1].ChemischeFormel + _Bestandteile[0].ChemischeFormel;
                _ElektronegativitaetsDifferenz = _Bestandteile[0].Elektronegativitaet - _Bestandteile[1].Elektronegativitaet;
            }
            else
            {
                if (_Bestandteile[1] is ElementMolekuel)
                {
                    _Name = _Bestandteile[0].Name + ((ElementMolekuel)_Bestandteile[1]).AnionenName.ToLower();
                }
                else
                {
                    _Name = _Bestandteile[0].Name + ((Atom)_Bestandteile[1]).Element.Wurzel.ToLower() + "id";
                }

                _ChemischeFormel = _Bestandteile[0].ChemischeFormel + _Bestandteile[1].ChemischeFormel;
                _ElektronegativitaetsDifferenz = _Bestandteile[1].Elektronegativitaet - _Bestandteile[0].Elektronegativitaet;
            }
        }
    }
}
