using System;

namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public abstract class Ion
    {
        public abstract int Ladung { get; }
        public Molekuel Molekuel { get; }

        public Ion(Molekuel molekuel)
        {
            Molekuel = molekuel;
        }

        public static (int anzahlKation, int anzahlAnionen) BerechneAnzahlDerMolekuehle(Kation kation, Anion anion)
        {
            // Berechne die Anzahl der benötigten Ionen
            int kgV = GetLCM(Math.Abs(kation.Ladung), Math.Abs(anion.Ladung));
            int anzahlKationen = kgV / Math.Abs(kation.Ladung);
            int anzahlAnionen = kgV / Math.Abs(anion.Ladung);

            return (anzahlKationen, anzahlAnionen);
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
