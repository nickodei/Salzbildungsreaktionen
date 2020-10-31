using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Beschreibt Stoffe, die eine negative Ladung haben
    /// </summary>
    /// <typeparam name="T">Stoff</typeparam>
    public class Anion<T> : Ion<T> where T : Stoff
    {
        public int NegativeLadung { get; set; }

        public Anion(T stoff) : base(stoff)
        {
            // Ist es ein Element, so kann die positive Ladung bestimmt werden
            Element element = stoff as Element;
            if (element != null)
            {
                if (element as Metall != null)
                {
                    // Es ist ein Metall, somit gibt die Hauptgruppe die Ladung an
                    NegativeLadung = -element.Hauptgruppe;
                }
                else
                {
                    // Es ist ein Nichtmetall, somit muss von der Zahl 8 die Hauptgruppe subtrahiert werden
                    NegativeLadung = -(8 - element.Hauptgruppe);
                }
            }
            else
            {
                // Es ist eine Verbindung uns es muss von einer neutralen Ladung ausgegangen werden
                NegativeLadung = 0;
            }
        }

        public Anion(T stoff, int negativeLadung) : base(stoff)
        {
            NegativeLadung = negativeLadung;
        }

        public override int ErhalteLadung()
        {
            return NegativeLadung;
        }

        public override string ErhalteName()
        {
            return Stoff.ErhalteName();
        }

        public override string ErhalteFormel()
        {
            return Stoff.ErhalteFormel();
        }

        //public override string GetName()
        //{
        //    // Nomenklatur erfolgt nach der Binärnomenklatur

        //    // Für einatomige Anionen oder polymere Einheiten aus den gleichen Atomen wird an den Namensstamm die Endung -id angehängt.
        //    if (Stoff is MolekularVerbindung)
        //    {
        //        MolekularVerbindung molekularVerbindung = Stoff as MolekularVerbindung;
        //        if (molekularVerbindung.BestehtAusEinemElement)
        //        {
        //            Element element = molekularVerbindung.Bestandteile[0] as Element;
        //            if (String.IsNullOrEmpty(element.Wurzel))
        //            {
        //                return element.Name + "id";
        //            }
        //            else
        //            {
        //                return element.Wurzel + "id";
        //            }
        //        }
        //        else
        //        {
        //            // Koordinationseinheiten und polymere Einheiten mit verschiedenen Atomen erhalten die Endung -at, Beispiele Hexacyanidoferrat, Sulfat
        //            for(int cnt = 0; cnt <= molekularVerbindung.Bestandteile.Count; cnt++)
        //            {

        //            }
        //        }
        //    }
        //    else if (Stoff is Element)
        //    {
        //        Element element = Stoff as Element;
        //        if (String.IsNullOrEmpty(element.Wurzel))
        //        {
        //            return element.Name + "id";
        //        }
        //        else
        //        {
        //            return element.Wurzel + "id";
        //        }
        //    }

            
        //    MultiElementMolekuehl multiElement = Stoff as MultiElementMolekuehl;
        //    if(multiElement != null)
        //    {
        //        // Überprüfe, ob das MultiElementMolekuehl doch nicht 
        //        // nur aus einem Stoff besteht
        //        if(multiElement.Bestandteile.Length == 1)
        //        {
        //            Element element = multiElement.Bestandteile[0] as Element;
        //            if(element != null)
        //            {
        //                if(String.IsNullOrEmpty(element.Wurzel) == false)
        //                {
        //                    return $"{element.Wurzel}id";
        //                }
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }


        //    return $"{Stoff.Name}id";
        //}
    }
}