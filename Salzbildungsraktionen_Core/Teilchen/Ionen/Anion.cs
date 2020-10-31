using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Anion<T> : Ion<T> where T : Teilchen
    {
        public Anion(T teilchen, int ladungszahl) : base(teilchen, ladungszahl)
        {
        }
    }
}
