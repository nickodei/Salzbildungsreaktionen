using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen
{
    public class MetallIon : Kation<Metall>
    {
        public MetallIon(Metall metall) : base(metall, metall.Valenzelektronen)
        {
        }
    }
}
