using Salzbildungsreaktionen_Core.Models.Elemente;
using Salzbildungsreaktionen_Core.Models.Reaktionen;
using Salzbildungsreaktionen_Core.Models.Verbindungen;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Helper
{
    public class Reaktionshelfer
    {
        public static List<MetallSäureReaktionsresultat> SäureReagiertMirMetall(Säure säure, Metall metall)
        {
            // Erstelle das Salz
            Salz salz = Salz.Create(metall, säure.Säurerestion);
            
            // HACK: muss dann richtig berechnet werden, oder doch nicht ????????
            salz.Anzahl = 1;

            // Gleichung ausgleichen
            metall.Anzahl = salz.m_Metall.Anzahl;
            säure.Anzahl = salz.m_Säurerestion.Anzahl;

            Verbindung wasserstoff = Verbindung.Create(Verbindung.Wasserstoff);
            wasserstoff.Anzahl = (säure.Anzahl * säure.AnzahlWasserstoff) / 2;

            return new List<MetallSäureReaktionsresultat>() { new MetallSäureReaktionsresultat(metall, säure, salz, wasserstoff) };
        }

        public static List<MetalloxidSäureReaktionsresultat> SäureReagiertMirMetalloxid(Säure säure, Metalloxid metalloxid)
        {
            // Erstelle das Salz
            Salz salz = Salz.Create(metalloxid, säure.Säurerestion);

            // Gleichung ausgleichen
            if(metalloxid.m_Metall.Anzahl > salz.m_Metall.Anzahl)
            {
                // Es gibt somit nur ein Metalloxidion
                metalloxid.Anzahl = 1;

                // Anzahl meiner Salzionen anpassen
                salz.Anzahl = metalloxid.m_Metall.Anzahl;

                // Somit muss auch die Anzahl der Säureionen angepasst werden
                säure.Anzahl = salz.Anzahl;
            }
            else
            {
                salz.Anzahl = 1;
                metalloxid.Anzahl = salz.m_Metall.Anzahl;
                säure.Anzahl = salz.m_Säurerestion.Anzahl;
            }

            Wasser wasser = new Wasser();
            wasser.Anzahl = (säure.Anzahl * säure.AnzahlWasserstoff) / 2;

            return new List<MetalloxidSäureReaktionsresultat>() { new MetalloxidSäureReaktionsresultat(metalloxid, säure, salz, wasser) };
        }

        public static int GetGCD(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 = num1 - num2;

                if (num2 > num1)
                    num2 = num2 - num1;
            }
            return num1;
        }

        public static int GetLCM(int num1, int num2)
        {
            return (num1 * num2) / GetGCD(num1, num2);
        }
    }
}
