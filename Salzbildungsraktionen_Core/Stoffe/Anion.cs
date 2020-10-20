namespace Salzbildungsreaktionen_Core.Stoffe
{
    public class Anion<T> : Ion where T : Stoff
    {
        private T _Stoff;
        public T Stoff
        {
            get { return _Stoff; }
            set { _Stoff = value; }
        }

        public Anion(T stoff, int positiveLadung) : base(positiveLadung)
        {
            Stoff = stoff;
        }

        public override string GetName()
        {
            return $"{Stoff.Name}id";
        }

        public override string GetFormel()
        {
            return Stoff.Formel;
        }
    }
}