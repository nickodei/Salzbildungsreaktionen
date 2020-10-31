namespace Salzbildungsreaktionen_Core.Helfer
{
    public static class MolekuehlHelfer
    {
        public static string ErhaltePraefix(int teilchenAnzahl)
        {
            switch (teilchenAnzahl)
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
                    return "Unbekannt";
            }
        }
    }
}
