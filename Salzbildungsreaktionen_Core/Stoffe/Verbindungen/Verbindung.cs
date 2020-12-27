using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen
{
    public abstract class Verbindung : Stoff
    {
        private string[] SortierungNichtmetalle = new string[] 
        { 
            "Rn", "Xe", "Kr", "B", "Si", "C", "Sb", "As", "P", "N", "H", "Te", "Se", "S", "At", "I", "Br", "Cl", "O", "F"
        };

        protected List<ElementMolekuel> _Bestandteile = new List<ElementMolekuel>();
        public List<ElementMolekuel> Bestandteile
        {
            get
            {
                if (_Bestandteile == null)
                {
                    _Bestandteile = ErhalteElementMolekueleAusFormel();
                }

                return _Bestandteile;
            }
        }

        public Verbindung()
        {

        }

        public List<ElementMolekuel> ErhalteElementMolekueleAusFormel(string chemischeFormel = null)
        {
            List<ElementMolekuel> elementMolekuele = new List<ElementMolekuel>();

            if(chemischeFormel == null)
            {
                chemischeFormel = ChemischeFormel;
            }

            if (chemischeFormel.Contains("("))
            {
                string molekuelFormel = chemischeFormel.Substring(chemischeFormel.IndexOf("(") + 1, chemischeFormel.IndexOf(")") - (chemischeFormel.IndexOf("(") + 1));
                elementMolekuele.AddRange(ErhalteElementMolekueleAusFormel(molekuelFormel));

                chemischeFormel = chemischeFormel.Substring(0, chemischeFormel.IndexOf("("));
            }

            // Erhalte die einzelnen elementaren Bestandteile aus der Formel
            char[] formelzeichen = chemischeFormel.ToCharArray();
            for (int position = 0; position < formelzeichen.Length; position++)
            {
                // Erhalte das aktuelle Symbol aus der Formel
                string elementSymbol = formelzeichen[position].ToString();

                if (position + 1 < formelzeichen.Length)
                {
                    // Überprüfe, ob das nächste Symbol zum selben Element gehört
                    if (char.IsLower(formelzeichen[position + 1]))
                    {
                        // Erhöhe die Position um 1
                        position += 1;

                        // Erweitere das Symbol des Elementes
                        elementSymbol += formelzeichen[position].ToString();
                    }

                    Element element = Periodensystem.Instance.FindeMetallNachAtomsymbol(elementSymbol);
                    if (element == null)
                    {
                        element = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(elementSymbol);
                        if (element == null)
                        {
                            throw new System.Exception($"Konnte das Element[{elementSymbol}] im Periodensystem nicht finden.");
                        }
                    }

                    if (position + 1 < formelzeichen.Length)
                    {
                        //Überprüfe, ob das nächste Symbol die Atomzahl des Elementes angibt
                        if (UnicodeHelfer.GetNumberOfSubscript(formelzeichen[position + 1]) != -1)
                        {
                            // Erhöhe die Position um 1
                            position += 1;

                            // Erhalte die Atomzahl des Elementes
                            int atomAnzahl = UnicodeHelfer.GetNumberOfSubscript(formelzeichen[position]);

                            // Ersetlle das Molekuel
                            elementMolekuele.Add(new ElementMolekuel(new Elementarverbindung(element, atomAnzahl)));
                        }
                        else
                        {
                            elementMolekuele.Add(new ElementMolekuel(new Elementarverbindung(element, 1)));
                        }
                    }
                    else
                    {
                        elementMolekuele.Add(new ElementMolekuel(new Elementarverbindung(element, 1)));
                    }
                }
                else
                {
                    Element element = Periodensystem.Instance.FindeMetallNachAtomsymbol(elementSymbol);
                    if (element == null)
                    {
                        element = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(elementSymbol);
                        if (element == null)
                        {
                            throw new System.Exception($"Konnte das Element[{elementSymbol}] im Periodensystem nicht finden.");
                        }
                    }

                    elementMolekuele.Add(new ElementMolekuel(new Elementarverbindung(element, 1)));
                }
            }

            return elementMolekuele;
        }

        public string GeneriereNameErsterOrdnung()
        {
            // Erhalte die einzelnen Molekuelbestandteile
            List<ElementMolekuel> elemente = ErhalteElementMolekueleAusFormel();

            // Sortiere die Liste nach Mtall/Nichtmetall, dann nach Elektronegativitaet
            elemente = elemente.OrderByDescending(element => element.Verbindung.Element is Metall) 
                               .ThenBy(element => Array.IndexOf(SortierungNichtmetalle, element.Verbindung.Element.Symol))
                               .ToList();

            string name = null;
            for(int zaehler = 0; zaehler < elemente.Count; zaehler++)
            {
                ElementMolekuel element = elemente[zaehler];

                if(element.Verbindung.Element is Metall)
                {
                    if (element.Verbindung.AnzahlBindungspartner > 1)
                    {
                        name += NomenklaturHelfer.Praefix(element.Verbindung.AnzahlBindungspartner) + element.Verbindung.Element.Name;
                    }
                    else
                    {
                        name += element.Verbindung.Element.Name;
                    }                  
                }
                else
                {
                    // !Ausnahme: Wasserstoff nicht an letzer Stelle
                    if(element.Verbindung.Element.Symol.Equals("H"))
                    {
                        if(zaehler != elemente.Count - 1)
                        {
                            if(element.Verbindung.AnzahlBindungspartner > 1)
                            {
                                name += NomenklaturHelfer.Praefix(element.Verbindung.AnzahlBindungspartner) + "hydrogen";
                            }
                            else
                            {
                                name += "hydrogen";
                            }

                            continue;
                        }
                    }

                    if (zaehler == 0)
                    {
                        if (element.Verbindung.AnzahlBindungspartner > 1)
                        {
                            name += NomenklaturHelfer.Praefix(element.Verbindung.AnzahlBindungspartner) + element.Verbindung.Element.Name;
                        }
                        else
                        {
                            name += element.Verbindung.Element.Name;
                        }                       
                    }
                    else
                    {
                        if (element.Verbindung.AnzahlBindungspartner > 1)
                        {
                            name += NomenklaturHelfer.Praefix(element.Verbindung.AnzahlBindungspartner) + element.Verbindung.Element.Wurzel + "id";
                        }
                        else
                        {
                            name += element.Verbindung.Element.Wurzel + "id";
                        }                       
                    }                    
                }               
            }

            name = name.ToLower();
            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }
    }
}
