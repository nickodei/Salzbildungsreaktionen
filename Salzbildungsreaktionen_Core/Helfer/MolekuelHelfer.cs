using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using System;

namespace Salzbildungsreaktionen_Core.Helfer
{
    public class MolekuelHelfer
    {
        public static (int anzahlStoff1, int anzahlStoff2) BerechneAnzahlDerMolekuele(int ladungStoff1, int ladungStoff2)
        {
            // Berechne das kleinste gemeinsame Vielfache
            int kgV = GetLCM(Math.Abs(ladungStoff1), Math.Abs(ladungStoff2));

            // Berechnen die jeweiligen Anzahlen
            int anzahlStoff1 = kgV / Math.Abs(ladungStoff1);
            int anzahlStoff2 = kgV / Math.Abs(ladungStoff2);

            return (anzahlStoff1, anzahlStoff2);
        }

        public static (int anzahlMetall, int anzahlNichtmetall) BerechneAnzahlDerMolekuele(Metall metall, Nichtmetall nichtmetall)
        {
            // Berechne deren Ladungen (Elektronenabgabe sowie Elektronenaufnahme)
            int ladungMetall = metall.Hauptgruppe;
            int ladungNichtmetall = (nichtmetall.Symol.Equals("H")) ? nichtmetall.Hauptgruppe : 8 - nichtmetall.Hauptgruppe;

            return BerechneAnzahlDerMolekuele(ladungMetall, ladungNichtmetall);
        }

        private static int GetGCD(int num1, int num2)
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

        private static int GetLCM(int num1, int num2)
        {
            return (num1 * num2) / GetGCD(num1, num2);
        }
    }
}
