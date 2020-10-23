using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe
{
    public abstract class Reinstoff : Stoff
    {
        public Reinstoff() : base()
        {
        }

        protected bool ÜberprüfeObAtomzahlAnders(char nextSymbol)
        {
            return UnicodeHelfer.GetNumberOfSubscript(nextSymbol) != -1;
        }


        protected (int, int) BerechneAnzahlDerMolekuehle<K, A>(Kation<K> kation, Anion<A> anion) where K: Stoff where A: Stoff
        {
            // Berechne die Anzahl der benötigten Ionen
            int kgV = GetLCM(Math.Abs(kation.Ladung), Math.Abs(anion.Ladung));
            int anzahlElement1 = kgV / Math.Abs(kation.Ladung);
            int anzahlElement2 = kgV / Math.Abs(anion.Ladung);

            return (anzahlElement1, anzahlElement2);
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
