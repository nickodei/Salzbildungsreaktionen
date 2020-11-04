using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen.Molekuel;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Teilchen.Molekuele
{
    public class VerbindungsMolekuel : IMolekuel
    {
        public string Name { get; set; }
        public string Formel { get; set; }

        public int Anzahl { get; set; }
        public List<ElementMolekuel> Bestandteile { get; set; }

        public VerbindungsMolekuel(string chemischeFormel, int molekuelAnzahl): this(chemischeFormel)
        {
            Anzahl = molekuelAnzahl;
        }

        public VerbindungsMolekuel(string chemischeFormel)
        {
            Formel = chemischeFormel;
            List<ElementMolekuel> bestandteile = new List<ElementMolekuel>();

            string unterMolekuel = "";
            if (chemischeFormel.Contains("("))
            {
                unterMolekuel = chemischeFormel.Substring(chemischeFormel.IndexOf("(") + 1, chemischeFormel.IndexOf(")") - (chemischeFormel.IndexOf("(") + 1));
                chemischeFormel = chemischeFormel.Substring(0, chemischeFormel.IndexOf("("));
            }

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
                    if (element == null)
                    {
                        element = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol(elementSymbol);
                        if (element == null)
                        {
                            throw new System.Exception($"Konnte das Element[{elementSymbol}] im Periodensystem nicht finden.");
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
                            bestandteile.Add(new ElementMolekuel(atomAnzahl, new Atom(element)));
                        }
                        else
                        {
                            bestandteile.Add(new ElementMolekuel(1, new Atom(element)));
                        }
                    }
                    else
                    {
                        bestandteile.Add(new ElementMolekuel(1, new Atom(element)));
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

                    bestandteile.Add(new ElementMolekuel(1, new Atom(element)));
                }
            }

            if(!string.IsNullOrEmpty(unterMolekuel))
            {
                bestandteile.AddRange(new VerbindungsMolekuel(unterMolekuel).Bestandteile);
            }

            if (bestandteile.Count < 2)
                throw new System.Exception("");

            if (Anzahl == 0)
            {
                Anzahl = 1;
            }

            Bestandteile = bestandteile;

            for(int cnt = 0; cnt < Bestandteile.Count; cnt++)
            {
                ElementMolekuel elementMolekuel = Bestandteile[cnt];

                if(cnt != Bestandteile.Count - 1)
                {
                    if(elementMolekuel.Anzahl == 1)
                    {
                        Name += elementMolekuel.Atom.Element.Name.ToLower();
                    }
                    else
                    {
                        Name += elementMolekuel.Name.ToLower();
                    }
                }
                else
                {
                    if (elementMolekuel.Anzahl == 1)
                    {
                        Name += elementMolekuel.Atom.Element.Wurzel.ToLower() + "id";
                    }
                    else
                    {
                        Name += NomenklaturHelfer.Praefix(elementMolekuel.Anzahl).ToLower() + elementMolekuel.Atom.Element.Wurzel.ToLower() + "id";
                    }
                }
            }

            // Kapitalisierung des Namens
            Name = Name[0].ToString().ToUpper() + Name.Substring(1);
        }
    }
}
