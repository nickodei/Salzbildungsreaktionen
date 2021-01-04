using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge
{
    public class Lauge : Atombindung
    {
        public Molekuel Metall { get; set; }
        public Molekuel Hydroxid { get; set; }

        /// <summary>
        /// Protected Konstruktor für das Ammoniak
        /// </summary>
        protected Lauge()
        {
        }

        public Lauge(string chemischeFormel)
        {
            // Präperier die chemische Formel so, dass sie korrekt geparsed werden kann
            int indexHydroxid = chemischeFormel.IndexOf("OH");
            if(indexHydroxid > 0)
            {
                // Das Hydroxid wurde gefunden
                if(chemischeFormel[indexHydroxid - 1].Equals('(') == false)
                {
                    // Die Klammern sind nicht angegeben, somit muss die Formel angepasst werden
                    chemischeFormel = chemischeFormel.Replace("OH", "(OH)₁");
                }

                // Generiere die Bestandteile aus der chemischen Formel
                Bestandteile = GeneriereBestandteileAusChemischerFormel(chemischeFormel);

                foreach(Molekuel molekuel in ErhalteAlleMolekuele())
                {
                    switch(molekuel.Atombindung.ChemischeFormel)
                    {
                        case "OH":
                            Hydroxid = molekuel;
                            break;
                        default:
                            Metall = molekuel;
                            break;
                    }
                }

                // Generiere die chemische Formel
                Name = Metall.Atombindung.ErhalteElement().Name + "hydroxid";
                ChemischeFormel = GeneriereChemischeFormelAusBestandteilen(fuerAnzeige: false);
            }
            else
            {
                throw new Exception($"Ungültige Formel für die Lauge [{chemischeFormel}]");
            }
        }

        public Lauge(Metall metall)
        {
            // Erstelle das Hydroxid
            Oxid hydroxid = new Oxid("OH");

            // Berechne die Anzahl der Moleküle
            (int anzahlMetall, int anzahlHydroxid) = MolekuelHelfer.BerechneAnzahlDerMolekuele(metall.Hauptgruppe, -1);

            // Füge die Moleküle als Bestandteil der Lauge hinzu
            AddBestandteil(metall, anzahlMetall);
            AddBestandteil(hydroxid, anzahlHydroxid);

            // Setze die Bestandteile
            Metall = ErhalteMolekuel(metall);
            Hydroxid = ErhalteMolekuel(hydroxid);

            // Generiere die chemische Formel und den Namen
            Name = Metall.Atombindung.ErhalteElement().Name + "hydroxid";
            ChemischeFormel = GeneriereChemischeFormelAusBestandteilen(fuerAnzeige: false);
        }
    }
}
