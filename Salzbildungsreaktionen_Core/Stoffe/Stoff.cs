using System;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    public abstract class Stoff
    {
        protected string _Name;
        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(_Name))
                {
                    _Name = GeneriereName();
                }

                return _Name;
            }
        }

        protected string _ChemischeFormel;
        public string ChemischeFormel
        {
            get
            {
                if (String.IsNullOrEmpty(_ChemischeFormel))
                {
                    _ChemischeFormel = GeneriereChemischeFormel();
                }

                return _ChemischeFormel;
            }
        }

        public Stoff()
        {
        }

        public void SetzteTrivialname(string trivialname)
        {
            if(String.IsNullOrEmpty(trivialname))
            {
                throw new Exception("Trivialname darf nicht Null oder Leer sein.");
            }

            _Name = trivialname;
        }

        protected abstract string GeneriereName();
        protected abstract string GeneriereChemischeFormel();
    }
}
