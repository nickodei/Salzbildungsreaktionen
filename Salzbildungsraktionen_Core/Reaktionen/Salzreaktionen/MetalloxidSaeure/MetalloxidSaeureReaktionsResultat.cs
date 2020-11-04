namespace Salzbildungsreaktionen_Core.Reaktionen.Salzreaktionen.MetalloxidSaeure
{
    public class MetalloxidSaeureReaktionsResultat
    {
        public Reaktionsstoff Metalloxid { get; set; }
        public Reaktionsstoff Saeure { get; set; }
        public Reaktionsstoff Salz { get; set; }
        public Reaktionsstoff Wasserstoff { get; set; }

        public MetalloxidSaeureReaktionsResultat(Reaktionsstoff metalloxid, Reaktionsstoff saeure, Reaktionsstoff salz, Reaktionsstoff wasserstoff)
        {
            Metalloxid = metalloxid;
            Saeure = saeure;
            Salz = salz;
            Wasserstoff = wasserstoff;
        }
    }
}
