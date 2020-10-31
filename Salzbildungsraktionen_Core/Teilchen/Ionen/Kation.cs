namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Kation<T> : Ion<T> where T : Teilchen
    {
        public Kation(T teilchen, int ladungszahl) : base(teilchen, ladungszahl)
        {
        }
    }
}
