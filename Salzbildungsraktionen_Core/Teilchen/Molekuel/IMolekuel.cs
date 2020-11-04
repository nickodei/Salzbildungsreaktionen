using Salzbildungsreaktionen_Core.Stoffe;

namespace Salzbildungsreaktionen_Core.Teilchen.Molekuel
{
    public interface IMolekuel : IStoff
    {
        int Anzahl { get; }
    }
}
