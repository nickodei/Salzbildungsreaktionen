using Salzbildungsreaktionen_Core.Stoffe;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Teilchen.Molekuele
{
    public abstract class Molekuel : Teilchen
    {
        public abstract List<Teilchen> Bestadteile { get; }

        public Molekuel()
        {
        }
    }
}
