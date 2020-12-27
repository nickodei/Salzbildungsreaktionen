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

        public static (int anzahlKation, int anzahlAnionen) BerechneAnzahlMolekuele(Kation kation, Anion anion)
        {
            // Berechne die Anzahl der benötigten Ionen
            int kgV = ErhalteKgV(Math.Abs(kation.Ladung), Math.Abs(anion.Ladung));
            int anzahlKationen = kgV / Math.Abs(kation.Ladung);
            int anzahlAnionen = kgV / Math.Abs(anion.Ladung);

            return (anzahlKationen, anzahlAnionen);
        }

        private static int ErhalteGgD(int num1, int num2)
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

        private static int ErhalteKgV(int num1, int num2)
        {
            return (num1 * num2) / ErhalteGgD(num1, num2);
        }
    }
}
