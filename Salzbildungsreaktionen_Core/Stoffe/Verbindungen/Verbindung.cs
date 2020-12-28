using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;
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
       
        public Verbindung()
        {

        }

        public List<Element[]> ErhalteBestandteileSequentiell(string chemischeFormel = null)
        {
            List<Element[]> bestandteile = new List<Element[]>();

            if (chemischeFormel == null)
            {
                chemischeFormel = ChemischeFormel;
            }

            if (chemischeFormel.Contains("("))
            {
                string molekuelFormel = chemischeFormel.Substring(chemischeFormel.IndexOf("(") + 1, chemischeFormel.IndexOf(")") - (chemischeFormel.IndexOf("(") + 1));
                bestandteile.AddRange(ErhalteBestandteileSequentiell(molekuelFormel));

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
                            for(int cnt = 0; cnt < atomAnzahl; cnt++)
                            {
                                bestandteile.Add(new Element[] { element });
                            }
                        }
                        else
                        {
                            bestandteile.Add(new Element[] { element });
                        }
                    }
                    else
                    {
                        bestandteile.Add(new Element[] { element });
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

                    bestandteile.Add(new Element[] { element });
                }
            }

            return bestandteile;
        }              
    }
}
