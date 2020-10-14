using Salzbildungsreaktionen_Core.Stoffe.Gemisch.Säuren;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class MetallSäureReaktion : Reaktion
    {
        private Reaktionsstoff<Metall> _Metall;
        public Reaktionsstoff<Metall> Metall
        {
            get { return _Metall; }
            set { _Metall = value; }
        }

        private Reaktionsstoff<Säure> _Säure;
        public Reaktionsstoff<Säure> Säure
        {
            get { return _Säure; }
            set { _Säure = value; }
        }

        public MetallSäureReaktion(Metall metall, Säure säure)
        {
            Metall = new Reaktionsstoff<Metall>(metall);
            Säure = new Reaktionsstoff<Säure>(säure);
        }

        /// <summary>
        /// Startet die Metall-Säure Reaktion
        /// </summary>
        public override void BeginneReaktion()
        {
            throw new System.NotImplementedException();
        }
    }
}
