using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle
{
    public class Metall : Element
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

        public Metall(string symbol, string name, int valenzelektronen) : base()
        {
            _Name = name;
            _Formel = symbol;
            _Valenzelektronen = valenzelektronen;
        }

        public static Metall ErhalteMetall(string symbol)
        {
            return Periodensystem.Instance.Metalle.Values.Where(x => x.Formel.Equals(symbol)).FirstOrDefault();
        }

        public override int BerechenLadungszahl()
        {
            return Valenzelektronen;
        }
    }
}
