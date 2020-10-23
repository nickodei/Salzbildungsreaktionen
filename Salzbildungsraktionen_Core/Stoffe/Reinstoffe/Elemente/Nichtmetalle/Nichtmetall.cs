namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle
{
    public class Nichtmetall : Element
    {
        private string _Name;
        public override string Name
        {
            get { return _Name; }
        }

        private string _Formel;
        public override string Formel
        {
            get { return _Formel; }
        }

        private int _Valenzelektronen;
        public override int Valenzelektronen
        {
            get { return _Valenzelektronen; }
        }

        public Nichtmetall(string symbol, string name, int valenzelektronen) : base()
        {
            _Name = name;
            _Formel = symbol;
            _Valenzelektronen = valenzelektronen;
        }

        public override int BerechenLadungszahl()
        {
            return -(8 - Valenzelektronen);
        }
    }
}
