using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen
{
    public class MolekularVerbindung : Verbindung
    {
        public string Name { get; }
        public string Formel { get; }
        public bool BestehtAusEinemElement { get; set; }
        public List<Reinstoff> Bestandteile { get; set; }

        public MolekularVerbindung(Nichtmetall nichtmetall, int anzahlAtome)
        {
            //Bestandteile = new List<Reinstoff>();
            //BestehtAusEinemElement = true;

            //for (int cnt = 1; cnt <= anzahlAtome; cnt++)
            //{
            //    Nichtmetall einzelNichtmetall = Nichtmetall.ErhalteNichtmetall(nichtmetall.Formel);
            //    Bestandteile.Add(einzelNichtmetall);
            //}

            //Name = ErhaltePraefix(anzahlAtome) + nichtmetall.Name.ToLower();
            //Formel = nichtmetall.Formel + UnicodeHelfer.GetSubscriptOfNumber(anzahlAtome);
        }

        public MolekularVerbindung(Nichtmetall nichtmetall1, Nichtmetall nichtmetall2)
        {
            //Bestandteile = new List<Reinstoff>();
            
            //if(nichtmetall1.Formel.Equals(nichtmetall2.Formel))
            //{
            //    BestehtAusEinemElement = true;
            //}
            //else
            //{
            //    BestehtAusEinemElement = false;
            //}

            //Bestandteile.Add(nichtmetall1);
            //Bestandteile.Add(nichtmetall2);

            //Name = nichtmetall1.Name + nichtmetall2.Wurzel + "id";
            //Formel = nichtmetall1.Formel + nichtmetall2.Formel;
        }

        public MolekularVerbindung(Nichtmetall nichtmetall, MolekularVerbindung verbindung)
        {
            //Bestandteile = new List<Reinstoff>();
            //BestehtAusEinemElement = false;

            //Bestandteile.Add(nichtmetall);
            //Bestandteile.Add(verbindung);

            //if(verbindung.BestehtAusEinemElement)
            //{
            //    Nichtmetall elementDerVerbindung = verbindung.Bestandteile[0] as Nichtmetall;

            //    Name = nichtmetall.Name + ErhaltePraefix(verbindung.Bestandteile.Count).ToLower() + elementDerVerbindung.Wurzel + "id";
            //    Formel = nichtmetall.Formel + verbindung.Formel;
            //}
            //else
            //{
            //    Name = GeneriereNameAusBestandteilen();
            //    Formel = GeneriereFormelAusBestandteilen();
            //}
        }

        private string GeneriereNameAusBestandteilen()
        {
            string name = "";

            //if (BestehtAusEinemElement)
            //{
            //    name += ErhaltePraefix(Bestandteile.Count) + Bestandteile[0].Name.ToLower();
            //    return name;
            //}

            //for (int cnt = 0; cnt < Bestandteile.Count; cnt++)
            //{
            //    Nichtmetall nichtmetall = Bestandteile[cnt] as Nichtmetall;
            //    if(nichtmetall != null)
            //    {
            //        if (cnt == 0)
            //        {
            //            // Übernehme den kompletten Names des Nichtmetalls
            //            name += nichtmetall.Name;
            //        }
            //        else
            //        {
            //            name += nichtmetall.Wurzel + "id";
            //        }

            //        continue;
            //    }

            //    MolekularVerbindung verbindung = Bestandteile[cnt] as MolekularVerbindung;
            //    if(verbindung != null)
            //    {
            //        // Übernehme den Namen der Verbindung
            //        name += verbindung.Name;

            //        continue;
            //    }
            //}

            return name;
        }

        private string GeneriereFormelAusBestandteilen()
        {
            string formel = "";

            //if (BestehtAusEinemElement)
            //{
            //    formel += Bestandteile[0].Formel + UnicodeHelfer.GetSubscriptOfNumber(Bestandteile.Count);
            //    return formel;
            //}

            //foreach (Reinstoff reinstoff in Bestandteile)
            //{
            //    formel += reinstoff.Formel;
            //}
            return formel;
        }

        private string ErhaltePraefix(int anzahl)
        {
            switch(anzahl)
            {
                case 1: return "Mono";
                case 2: return "Di";
                case 3: return "Tri";
                case 4: return "Tetra";
                default: return "?";
            }
        }
    }
}
