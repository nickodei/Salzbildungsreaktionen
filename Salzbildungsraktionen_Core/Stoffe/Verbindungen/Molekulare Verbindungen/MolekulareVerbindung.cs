using Salzbildungsreaktionen_Core.Bindungen;
using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen
{
    public class MolekulareVerbindung : Verbindung, IKovalenteBindung
    {
        IKovalenteBindung Kation { get; set; }
        IKovalenteBindung Anion { get; set; }

        public MolekulareVerbindung()
        {
        }

        public MolekulareVerbindung(string chemischeFormel, string trivialname = null)
        {
            ChemischeFormel = chemischeFormel;

            if(!String.IsNullOrEmpty(trivialname))
            {
                Name = trivialname;
            }
        }

        public MolekulareVerbindung(string chemischeFormel, IKovalenteBindung kation, IKovalenteBindung anion)
        {
            ChemischeFormel = chemischeFormel;
            Kation = kation;
            Anion = anion;

            Name = GeneriereName();
        }

        #region Molekuel

        public List<Molekuel> GeneriereMolekuele(params IKovalenteBindung[] bindungen)
        {
            List<Molekuel> molekuele = new List<Molekuel>();

            foreach(IKovalenteBindung bindung in bindungen)
            {
                int index = ChemischeFormel.IndexOf(bindung.ErhalteFormel());
                if(index != -1)
                {
                    if(ChemischeFormel.Length > (index + (bindung.ErhalteFormel().Length)))
                    {
                        // Überprüfe ob die Anzahl dieses Molekuel angegeben ist
                        int anzahl = UnicodeHelfer.GetNumberOfSubscript(ChemischeFormel[index + (bindung.ErhalteFormel().Length)]);
                        if (anzahl != -1)
                        {
                            molekuele.Add(new Molekuel(bindung, anzahl));
                            continue;
                        }
                    }

                    molekuele.Add(new Molekuel(bindung, 1));
                }
                else
                {
                    //TODO: Error
                    throw new Exception("Bindung konnte in der Formel nicht gefunden werden");
                }
            }

            return molekuele;
        }
        public List<Molekuel> GeneriereMolekuele()
        {
            List<Molekuel> bestandteile = new List<Molekuel>();

            string unterMolekuel = "";
            if (ChemischeFormel.Contains("("))
            {
                unterMolekuel = ChemischeFormel.Substring(ChemischeFormel.IndexOf("(") + 1, ChemischeFormel.IndexOf(")") - (ChemischeFormel.IndexOf("(") + 1));
                ChemischeFormel = ChemischeFormel.Substring(0, ChemischeFormel.IndexOf("("));
            }

            // Erhalte die einzelnen elementaren Bestandteile aus der Formel
            char[] buchstaben = ChemischeFormel.ToCharArray();
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
                            bestandteile.Add(new Molekuel(element, atomAnzahl));
                        }
                        else
                        {
                            bestandteile.Add(new Molekuel(element, 1));
                        }
                    }
                    else
                    {
                        bestandteile.Add(new Molekuel(element, 1));
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

                    bestandteile.Add(new Molekuel(element, 1));
                }
            }

            if (!string.IsNullOrEmpty(unterMolekuel))
            {
                //TODO: unterMolekuel hinzufügen
                MolekulareVerbindung verbindung = new MolekulareVerbindung(unterMolekuel);
                bestandteile.AddRange(verbindung.GeneriereMolekuele());
            }

            return bestandteile;
        }

        #endregion

        #region Name

        public void SetzeTrivialname(string name)
        {
            Name = name;
        }

        public string GeneriereName()
        {
            return GeneriereKationenname(Kation) + GeneriereAnionenname(Anion);
        }

        public string GeneriereKationenname(IKovalenteBindung bindung)
        {
            Molekuel molekuel = GeneriereMolekuele(bindung).FirstOrDefault();
            return (molekuel.Anzahl == 1) ? molekuel.Bindung.ErhalteName() : NomenklaturHelfer.Praefix(molekuel.Anzahl) + molekuel.Bindung.ErhalteName().ToLower();
        }

        public string GeneriereAnionenname(IKovalenteBindung bindung)
        {
            Molekuel molekuel = GeneriereMolekuele(bindung).FirstOrDefault();

            if(bindung is Element)
            {
                Element element = bindung as Element;
                if(String.IsNullOrEmpty(element.Wurzel))
                {
                    return NomenklaturHelfer.Praefix(molekuel.Anzahl) + element.Name.ToLower() + "id";
                }
                else
                {
                    return NomenklaturHelfer.Praefix(molekuel.Anzahl) + element.Wurzel.ToLower() + "id";
                }
            }
            else if(bindung is MolekulareVerbindung)
            {
                MolekulareVerbindung verbindung = bindung as MolekulareVerbindung;
                List<Molekuel> bestandteile = verbindung.GeneriereMolekuele();

                string anionenname = null;
                foreach(Molekuel bestandteil in bestandteile.OrderBy(x => x.Bindung.ErhalteFormel()))
                {
                    string name = GeneriereAnionenname(bestandteil.Bindung);
                    anionenname += name.Substring(name.Length - 2);
                }
                return anionenname + "at";
            }

            return "?";
        }

        #endregion

        public string ErhalteFormel()
        {
            return ChemischeFormel;
        }

        public virtual string ErhalteName()
        {
            if(!String.IsNullOrEmpty(Name))
            {
                return Name;
            }

            List<Molekuel> bestandteile = GeneriereMolekuele();
            for (int cnt = 0; cnt < bestandteile.Count; cnt++)
            {
                Molekuel molekuel = bestandteile[cnt];

                if (cnt != bestandteile.Count - 1)
                {
                    if (molekuel.Anzahl == 1)
                    {
                        Name += molekuel.Bindung.ErhalteName().ToLower();
                    }
                    else
                    {
                        Name += molekuel.Bindung.ErhalteName().ToLower();
                    }
                }
                else
                {
                    if(molekuel.Bindung.IstElementMolekuel())
                    {
                        Element element = molekuel.Bindung as Element;
                        if (molekuel.Anzahl == 1)
                        {
                            Name += element.Wurzel.ToLower() + "id";
                        }
                        else
                        {
                            Name += NomenklaturHelfer.Praefix(molekuel.Anzahl).ToLower() + element.Wurzel.ToLower() + "id";
                        }
                    }
                    else
                    {
                        Name += molekuel.Bindung.ErhalteName().ToLower();
                    }
                }
            }

            // Kapitalisierung des Namens
            Name = Name[0].ToString().ToUpper() + Name.Substring(1);

            return Name;
        }

        public bool IstElementMolekuel()
        {
            return true;
        }
    }
}
