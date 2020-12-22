namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.MetallSaeure
{
    public class MetallSaeureReaktionsResultat
    {
        public Reaktionsstoff Metall { get; set; }
        public Reaktionsstoff Saeure {get; set;}
        public Reaktionsstoff Salz { get; set; }
        public Reaktionsstoff Wasserstoff { get; set; }

        public MetallSaeureReaktionsResultat(Reaktionsstoff metall, Reaktionsstoff saeure, Reaktionsstoff salz, Reaktionsstoff wasserstoff)
        {
            Metall = metall;
            Saeure = saeure;
            Salz = salz;
            Wasserstoff = wasserstoff;
        }
    }
}
