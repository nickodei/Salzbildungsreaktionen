using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Beschreibt Stoffe, die eine Ladung haben
    /// </summary>
    /// <typeparam name="T">Stoff</typeparam>
    public abstract class Ion<T> where T : Stoff
    {
        private T _Stoff;
        public T Stoff
        {
            get { return _Stoff; }
            set { _Stoff = value; }
        }

        public Ion(T stoff)
        {
            Stoff = stoff;
        }

        public abstract int ErhalteLadung();
        public abstract string ErhalteName();
        public abstract string ErhalteFormel();
    }
}
