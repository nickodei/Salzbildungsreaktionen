using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public class NichtmetallIon : IonischeVerbindung
    {
        private NichtmetallIon(Nichtmetall nichtmetall) : base(nichtmetall.ErhalteLadung())
        {

        }
    }
}
