namespace Salzbildungsreaktionen_Core.Teilchen.Ionen
{
    public class Ion<T> where T : Teilchen
    {
        public T Teilchen { get; set; }
        public int Ladungszahl { get; set; }

        public Ion(T teilchen, int ladungszahl)
        {
            Teilchen = teilchen;
            Ladungszahl = ladungszahl;
        }
    }
}
