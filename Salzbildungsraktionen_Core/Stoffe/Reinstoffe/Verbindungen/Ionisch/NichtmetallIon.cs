using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public class NichtmetallIon : Anion<Nichtmetall>
    {
        public NichtmetallIon(Nichtmetall nichtmetall) : base(nichtmetall, (nichtmetall.Symbol != "H") ? -(8 - nichtmetall.Valenzelektronen): 1)
        {
        }
    }
}
