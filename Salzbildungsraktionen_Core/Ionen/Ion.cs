namespace Salzbildungsreaktionen_Core.Stoffe
{
    /// <summary>
    /// Beschreibt Stoffe, die eine Ladung haben
    /// </summary>
    /// <typeparam name="T">Stoff</typeparam>
    public abstract class Ion<T> where T : Stoff
    {
        private int _Ladung;
        public int Ladung
        {
            get { return _Ladung; }
            set { _Ladung = value; }
        }

        private T _Stoff;
        public T Stoff
        {
            get { return _Stoff; }
            set { _Stoff = value; }
        }

        public Ion(T stoff, int ladung)
        {
            Stoff = stoff;
            Ladung = ladung;
        }

        public abstract string GetName();

        public abstract string GetFormel();
    }
}
