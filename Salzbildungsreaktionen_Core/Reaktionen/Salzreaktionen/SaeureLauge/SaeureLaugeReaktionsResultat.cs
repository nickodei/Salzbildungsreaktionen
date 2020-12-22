namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.SaeureLauge
{
    public class SaeureLaugeReaktionsResultat
    {
        public Reaktionsstoff Saeure { get; set; }
        public Reaktionsstoff Lauge { get; set; }
        public Reaktionsstoff Salz { get; set; }
        public Reaktionsstoff Wasser { get; set; }

        public SaeureLaugeReaktionsResultat(Reaktionsstoff saeure, Reaktionsstoff lauge, Reaktionsstoff salz, Reaktionsstoff wasser)
        {
            Saeure = saeure;
            Lauge = lauge;
            Salz = salz;
            Wasser = wasser;
        }
    }
}
