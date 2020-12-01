namespace Salzbildungsreaktionen_Core.Bindungen
{
    public interface IKovalenteBindung
    {
        string ErhalteName();
        string ErhalteAnionName(int molekuelLadung);
        string ErhalteFormel();
        bool IstElementMolekuel();
    }
}
