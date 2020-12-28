using NUnit.Framework;
using Salzbildungsreaktionen_Core;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;
using Salzbildungsreaktionen_Core.Teilchen;

namespace Salzbildungsreaktionen_Test
{
    public class UndefinierteAtombindungen
    {
        [Test]
        public void Wasser()
        {
            // Überprüfe, ob aus den Bestandteilen die chemische Formel generiert werden kann
            Element wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            Element sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");

            // Füge den Bestandteilen dem Wasser hinzu
            Atombindung wasser = new Atombindung();
            wasser.AddBestandteil(wasserstoff, 2);
            wasser.AddBestandteil(sauerstoff, 1);

            // Überprüfe ob identisch
            Assert.AreEqual("H₂O", wasser.GeneriereChemischeFormelAusBestandteilen());

            wasser = new Atombindung("H₂O");
            wasser.Bestandteile = wasser.GeneriereBestandteileAusChemischerFormel();

            // Erhalte die Moleküle aus den Bestandteilen
            Molekuel wasserstoffMolekuel = wasser.ErhalteMolekuel(wasserstoff);
            Molekuel sauerstoffMolekuel = wasser.ErhalteMolekuel(sauerstoff);

            // Überprüfe ob identisch
            Assert.AreEqual(2, wasserstoffMolekuel.AnzahlAtomeInMolekuel());
            Assert.AreEqual("H", wasserstoffMolekuel.Atombindung.ErhalteElement().Symol);

            Assert.AreEqual(1, sauerstoffMolekuel.AnzahlAtomeInMolekuel());
            Assert.AreEqual("O", sauerstoffMolekuel.Atombindung.ErhalteElement().Symol);
        }
    }
}
