using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente
{
    public abstract class Element : Reinstoff
    {
        /// <summary>
        /// Gibt die Anzahl der Valenzelektronen des Elementes an
        /// Muss implementiert werden, aber nicht im Konstruktor
        /// </summary>
        public abstract int Valenzelektronen { get; }

        public abstract int BerechenLadungszahl();

        public Element() : base()
        {
        }
    }
}
