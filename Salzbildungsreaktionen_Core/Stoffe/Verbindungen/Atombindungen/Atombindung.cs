using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Teilchen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen
{
    public class Atombindung : Verbindung
    {
        private string[] SortierungNichtmetalle = new string[]
        {
            "Rn", "Xe", "Kr", "B", "Si", "C", "Sb", "As", "P", "N", "H", "Te", "Se", "S", "At", "I", "Br", "Cl", "O", "F"
        };

        public List<Element[]> Bestandteile { get; set; }
        public int AnzahlAtome { get; set; }

        public Atombindung()
        {
            Bestandteile = new List<Element[]>();
        }

        public Atombindung(string chemischeFormel, string trivialName = null)
        {
            Bestandteile = new List<Element[]>();

            ChemischeFormel = chemischeFormel;
            Bestandteile = ErhalteBestandteileSequentiell(chemischeFormel);

            if(!String.IsNullOrEmpty(trivialName))
            {
                Name = trivialName;
            }
            else
            {
                Name = GeneriereNameErsterOrdnung();
            }
        }

        public Atombindung(Element element, int anzahlAtome)
        {
            Bestandteile = new List<Element[]>();
            ChemischeFormel += (anzahlAtome == 1) ? element.Symol : element.Symol + UnicodeHelfer.GetSubscriptOfNumber(anzahlAtome);
            Name = (anzahlAtome == 1) ? element.Name : NomenklaturHelfer.Praefix(anzahlAtome) + element.Name.ToLower();

            AddBestandteil(element, anzahlAtome);
            AnzahlAtome = anzahlAtome;

            //Name = GeneriereNameErsterOrdnung();
        }

        public Atombindung(string chemischeFormel, params Atombindung[] atombindungen)
        {
            Bestandteile = new List<Element[]>();
            ChemischeFormel = chemischeFormel;

            foreach(Atombindung atombindung in atombindungen)
            {
                Bestandteile.AddRange(atombindung.ErhalteBestandteileSequentiell());
            }

            AnzahlAtome = Bestandteile.Count;
            Name = GeneriereNameErsterOrdnung();
        }

        #region Zugriff Bestandteile

        public void AddBestandteil(Element element, int anzahlAtome)
        {
            for (int cnt = 0; cnt < anzahlAtome; cnt++)
            {
                Bestandteile.Add(new Element[] { element });
            }
        }

        public void AddBestandteil(Atombindung atombindung, int anzahlAtome)
        {
            for (int cnt = 0; cnt < anzahlAtome; cnt++)
            {
                Bestandteile.Add(atombindung.Bestandteile.SelectMany(x => x).ToArray());
            }
        }

        public Molekuel ErhalteMolekuel(Element gesuchtesElement)
        {
            int anzahlAtome = 0;
            foreach (Element[] bestandteil in Bestandteile)
            {
                // Nur ein Element ist im Array vorhanden => Es handelt sich somit um ein Element
                if (bestandteil.Length == 1)
                {
                    Element element = bestandteil[0];

                    if (element.Symol.Equals(gesuchtesElement.Symol))
                    {
                        anzahlAtome++;
                    }
                }
            }

            if (anzahlAtome == 0)
                return null;

            return new Molekuel(new Atombindung(gesuchtesElement, anzahlAtome), 1);
        }

        public Molekuel ErhalteMolekuel(Atombindung gesuchteAtombindung)
        {
            int anzahlMolekuel = 0;
            foreach (Element[] bestandteil in Bestandteile)
            {
                // Mehr als nur ein Atom vorhanden => Es handelt sich somit um eine Atombindung
                if (bestandteil.Length > 1)
                {
                    // Überprüfe, ob die Sequenz übereinstimmt
                    Element[] atombindungBestandteile = gesuchteAtombindung.Bestandteile.SelectMany(x => x).ToArray();
                    if (bestandteil.Length == atombindungBestandteile.Length)
                    {
                        bool identisch = true;
                        for (int cnt = 0; cnt < bestandteil.Length; cnt++)
                        {
                            if (bestandteil[cnt].Symol.Equals(atombindungBestandteile[cnt].Symol) == false)
                            {
                                identisch = false;
                            }
                        }

                        if (identisch)
                        {
                            anzahlMolekuel++;
                        }
                    }
                }
            }

            if (anzahlMolekuel == 0)
                return null;

            return new Molekuel(gesuchteAtombindung, anzahlMolekuel);
        }

        public List<Molekuel> ErhalteAlleMolekuele()
        {
            List<Molekuel> molekuele = new List<Molekuel>();

            int anzahlMolekuel = 1;
            bool generateMolekuel = true;

            for (int zaehler = 0; zaehler < Bestandteile.Count; zaehler++)
            {
                Element[] aktuellerBestandteil = Bestandteile[zaehler];
                if (zaehler + 1 != Bestandteile.Count)
                {
                    Element[] naechsterBestandteil = Bestandteile[zaehler + 1];

                    // Überprüfe, ob die beiden Arrays die selbe länge haben
                    if (aktuellerBestandteil.Length == naechsterBestandteil.Length)
                    {
                        // Überprüfe, ob die beiden Arrays auch die selbe Sequenz besitzen
                        for (int zaehler2 = 0; zaehler2 < aktuellerBestandteil.Length; zaehler2++)
                        {
                            if (aktuellerBestandteil[zaehler2].Symol.Equals(naechsterBestandteil[zaehler2].Symol) == false)
                            {
                                break;
                            }

                            if (zaehler2 + 1 == aktuellerBestandteil.Length)
                            {
                                anzahlMolekuel++;
                                generateMolekuel = false;
                            }
                        }
                    }
                }

                if (generateMolekuel == true)
                {
                    if (aktuellerBestandteil.Length == 1)
                    {
                        // Es handelt sich um ein Element
                        molekuele.Add(new Molekuel(new Atombindung(aktuellerBestandteil[0], anzahlMolekuel), 1));
                    }
                    else
                    {
                        if(aktuellerBestandteil.Any(x => x.Symol.Equals("O")))
                        {
                            molekuele.Add(new Molekuel(new Oxid(GeneriereChemischeFormelAusBestandteilen(new List<Element[]> { aktuellerBestandteil }, fuerAnzeige: true)), anzahlMolekuel));
                        }
                        else
                        {
                            molekuele.Add(new Molekuel(new Atombindung(GeneriereChemischeFormelAusBestandteilen(new List<Element[]> { aktuellerBestandteil }, fuerAnzeige: true)), anzahlMolekuel));
                        }
                    }

                    anzahlMolekuel = 1;
                }

                generateMolekuel = true;
            }

            return molekuele;
        }

        #endregion

        public bool IstElementbindung()
        {
            return !Bestandteile.Any(x => x.Length > 1 || x.Any(y => !y.Symol.Equals(x[0].Symol)));
        }

        public Element ErhalteElement()
        {
            return Bestandteile[0][0];
        }

        public string GeneriereChemischeFormelAusBestandteilen(List<Element[]> bestandteile = null, bool fuerAnzeige = false)
        {
            string chemischeFormel = null;

            if(bestandteile == null)
            {
                bestandteile = Bestandteile;
            }

            int anzahlAktuellerBestandteil = 1;
            for(int zaehler = 0; zaehler < bestandteile.Count; zaehler++)
            {
                // Erhalte das aktuelle Bestandteil
                Element[] bestandteil = bestandteile[zaehler];

                // Überprüfe, ob es das letze Bestandteil in der Sequenz ist
                if(zaehler != bestandteile.Count - 1)
                {
                    // Es gibt noch weitere bestandteile. Überprüfe, ob es sich ums selbe Bestandteil handelt
                    if(bestandteil.Length == bestandteile[zaehler + 1].Length)
                    {
                        // Überprüfe, ob die sequenz identisch ist
                        bool identisch = true;
                        for (int cnt = 0; cnt < bestandteil.Length; cnt++)
                        {
                            if (bestandteil[cnt].Symol.Equals(bestandteile[zaehler + 1][cnt].Symol) == false)
                            {
                                identisch = false;
                            }
                        }

                        if (identisch)
                        {
                            anzahlAktuellerBestandteil++;
                            continue;
                        }
                    }
                }

                // Der nächste Bestandteil unterschiedet sich von diesem => Erstelle die Formel für dieses Molekül

                // Überprüfe, ob sich um eine Elementarbindung handelt
                if(bestandteil.Length == 1)
                {
                    chemischeFormel += (anzahlAktuellerBestandteil == 1) ? bestandteil[0].Symol : $"{bestandteil[0].Symol}{UnicodeHelfer.GetSubscriptOfNumber(anzahlAktuellerBestandteil)}";
                }
                else
                {
                    string subChemischeFormel = null;
                    int anzahlAktuellerSubBestandteil = 1;
                    for(int cnt = 0; cnt < bestandteil.Length; cnt++)
                    {
                        if(cnt + 1 != bestandteil.Length)
                        {
                            if(bestandteil[cnt].Symol.Equals(bestandteil[cnt + 1].Symol))
                            {
                                anzahlAktuellerSubBestandteil++;
                                continue;
                            }
                        }

                        subChemischeFormel += (anzahlAktuellerSubBestandteil == 1) ? bestandteil[cnt].Symol : $"{bestandteil[cnt].Symol}{UnicodeHelfer.GetSubscriptOfNumber(anzahlAktuellerSubBestandteil)}";
                    }

                    if(fuerAnzeige)
                    {
                        chemischeFormel += (anzahlAktuellerBestandteil == 1) ? subChemischeFormel : $"({subChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(anzahlAktuellerBestandteil)}";
                    }
                    else
                    {
                        chemischeFormel += $"({subChemischeFormel}){UnicodeHelfer.GetSubscriptOfNumber(anzahlAktuellerBestandteil)}";
                    }
                }

                // Bestandteile zurücksetzen
                anzahlAktuellerBestandteil = 1;
            }

            return chemischeFormel;
        }
    
        public List<Element[]> GeneriereBestandteileAusChemischerFormel(string chemischeFormel = null)
        {
            List<Element[]> bestandteile = new List<Element[]>();

            if (chemischeFormel == null)
            {
                chemischeFormel = ChemischeFormel;
            }

            string[] splittedArray = chemischeFormel.Split('(', ')');
            for(int cnt = 0; cnt < splittedArray.Length; cnt++)
            {
                if(cnt + 1 != splittedArray.Length && splittedArray[cnt + 1].Length == 1)
                {
                    int anzahlSubBestandteil = UnicodeHelfer.GetNumberOfSubscript(splittedArray[cnt + 1][0]);
                    if (anzahlSubBestandteil != -1)
                    {
                        Element[] subBestandteil = GeneriereBestandteileAusChemischerFormel(splittedArray[cnt]).SelectMany(x => x).ToArray();
                        for (int zaehler = 0; zaehler < anzahlSubBestandteil; zaehler++)
                        {
                            bestandteile.Add(subBestandteil);
                        }
                    }

                    // Um das Subscript zu überspringen
                    cnt++;
                }
                else
                {
                    // Erhalte die einzelnen elementaren Bestandteile aus der Formel
                    char[] formelzeichen = splittedArray[cnt].ToCharArray();
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
                                    for (int cnt2 = 0; cnt2 < atomAnzahl; cnt2++)
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
                }
            }

            return bestandteile;
        }

        public string GeneriereNameErsterOrdnung()
        {
            List<Molekuel> molekuele = ErhalteAlleMolekuele();

            // Sortiere die Liste nach Mtall/Nichtmetall, dann nach Elektronegativitaet
            molekuele.OrderByDescending(x => x.Atombindung.ErhalteElement() is Metall)
                .ThenBy(x => Array.IndexOf(SortierungNichtmetalle, x.Atombindung.ErhalteElement()?.Symol))
                .ToList();

            string name = null;
            for (int zaehler = 0; zaehler < molekuele.Count; zaehler++)
            {
                Molekuel molekuel = molekuele[zaehler];
                Element element = molekuel.Atombindung.ErhalteElement();

                if (element is Metall)
                {
                    if (molekuel.AnzahlAtomeInMolekuel() > 1)
                    {
                        name += NomenklaturHelfer.Praefix(molekuel.AnzahlAtomeInMolekuel()) + element.Name;
                    }
                    else
                    {
                        name += element.Name;
                    }
                }
                else
                {
                    // !Ausnahme: Wasserstoff nicht an letzer Stelle
                    if (element.Symol.Equals("H"))
                    {
                        if (zaehler != molekuele.Count - 1)
                        {
                            if (molekuel.AnzahlAtomeInMolekuel() > 1)
                            {
                                name += NomenklaturHelfer.Praefix(molekuel.AnzahlAtomeInMolekuel()) + "hydrogen";
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
                        if (molekuel.AnzahlAtomeInMolekuel() > 1)
                        {
                            name += NomenklaturHelfer.Praefix(molekuel.AnzahlAtomeInMolekuel()) + element.Name;
                        }
                        else
                        {
                            name += element.Name;
                        }
                    }
                    else
                    {
                        if (molekuel.AnzahlAtomeInMolekuel() > 1)
                        {
                            name += NomenklaturHelfer.Praefix(molekuel.AnzahlAtomeInMolekuel()) + element.Wurzel + "id";
                        }
                        else
                        {
                            name += element.Wurzel + "id";
                        }
                    }
                }
            }

            name = name.ToLower();
            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }

        public override string AnzuzeigendeChemischeFormel()
        {
            return GeneriereChemischeFormelAusBestandteilen(fuerAnzeige: true);
        }

        public override string AnzuzeigenderName()
        {
            if(String.IsNullOrEmpty(Name))
            {
                return GeneriereNameErsterOrdnung();
            }
            else
            {
                return Name;
            }
        }
    }
}
