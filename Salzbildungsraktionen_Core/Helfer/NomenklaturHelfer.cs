using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using System;

namespace Salzbildungsreaktionen_Core.Helfer
{
    public static class NomenklaturHelfer
    {
        public static void GeneriereName(Nichtmetall nichtmetall1, Nichtmetall nichtmetall2)
        {
            
        }

        public static string Praefix(int anzahl)
        {
            if (anzahl <= 0)
                throw new Exception("Die Anzahl darf nicht kleiner als 1 sein");

            switch(anzahl)
            {
                case 1:
                    return "Mono";
                case 2:
                    return "Di";
                case 3:
                    return "Tri";
                case 4:
                    return "Tetra";
                default:
                    return "Poly";
            }
        }
    }
}
