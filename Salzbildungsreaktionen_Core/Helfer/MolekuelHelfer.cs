using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using System;

namespace Salzbildungsreaktionen_Core.Helfer
{
    public class MolekuelHelfer
    {
        public static (int anzahlMetall, int anzahlNichtmetall) BerechneAnzahlDerMolekuele(Metall metall, Nichtmetall nichtmetall)
        {
            // Berechne deren Ladungen (Elektronenabgabe sowie Elektronenaufnahme)
            int ladungMetall = metall.Hauptgruppe;
            int ladungNichtmetall = (nichtmetall.Symol.Equals("H")) ? nichtmetall.Hauptgruppe : 8 - nichtmetall.Hauptgruppe;

            // Berechne das kleinste gemeinsame Vielfache
            int kgV = GetLCM(Math.Abs(ladungMetall), Math.Abs(ladungNichtmetall));

            // Berechnen die jeweiligen Anzahlen
            int anzahlMetall = kgV / Math.Abs(ladungMetall);
            int anzahlNichtmetall = kgV / Math.Abs(ladungNichtmetall);

            return (anzahlMetall, anzahlNichtmetall);
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
