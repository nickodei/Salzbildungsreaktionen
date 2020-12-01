namespace Salzbildungsreaktionen_Core.Stoffe
{
    public abstract class Stoff
    {




        public Stoff()
        {
        }

        public abstract string ErhalteName();
        public abstract string ErhalteAnionName(int molekuelLadung);
        public abstract string ErhalteFormel();
    }
}
