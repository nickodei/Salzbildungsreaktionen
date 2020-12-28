using System;

namespace Salzbildungsreaktionen_Core.Stoffe
{
    public abstract class Stoff
    {
        public string Name { get; set; }
        public string ChemischeFormel { get; set; }

        public Stoff()
        {
        }

        public void SetzeTrivialname(string trivialname)
        {
            if(String.IsNullOrEmpty(trivialname))
            {
                throw new Exception("Trivialname darf nicht Null oder Leer sein.");
            }

            Name = trivialname;
        }
        
        public virtual string AnzuzeigenderName()
        {
            return Name;
        }

        public virtual string AnzuzeigendeChemischeFormel()
        {
            return ChemischeFormel;
        }
    }
}
