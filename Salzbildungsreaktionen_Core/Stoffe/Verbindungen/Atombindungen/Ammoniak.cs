using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge;
using Salzbildungsreaktionen_Core.Teilchen;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen
{
    public class Ammoniak : Lauge
    {
        public Molekuel Wasserstoff { get; set; }
        public Molekuel Stickstoff { get; set; }

        public Ammoniak()
        {
            // Setzte den Namen
            Name = "Ammoniak";

            // Setzte die chemische Formel
            ChemischeFormel = "NH₃";

            // Generiere die Bestandteile aus der chemischen Formel
            Bestandteile = GeneriereBestandteileAusChemischerFormel();

            // Erhalte die Moleküle aus den Bestandteilen
            Stickstoff = ErhalteMolekuel(Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("N"));
            Wasserstoff = ErhalteMolekuel(Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H"));
        }
    }
}
