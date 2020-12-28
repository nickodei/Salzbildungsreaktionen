using NUnit.Framework;
using Salzbildungsreaktionen_Core;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Lauge;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen;

namespace Salzbildungsreaktionen_Test
{
    public class Laugen
    {
        [Test]
        public void Natriumhydroxid()
        {
            // Überprüfe, ob aus den Bestandteilen die chemische Formel generiert werden kann
            Metall natrium = Periodensystem.Instance.FindeMetallNachAtomsymbol("Na");

            // Kreiere die Lauge
            Lauge natriumhydroxid = new Lauge(natrium);

            // Überprüfe ob identisch
            Assert.AreEqual("NaOH", natriumhydroxid.GeneriereChemischeFormelAusBestandteilen(fuerAnzeige: true));

            natriumhydroxid = new Lauge("NaOH");
            natriumhydroxid.Bestandteile = natriumhydroxid.GeneriereBestandteileAusChemischerFormel();

            // Erhalte die Moleküle aus den Bestandteilen
            Molekuel aluminiumMolekuel = natriumhydroxid.ErhalteMolekuel(natrium);
            Molekuel hydroxidMolekuel = natriumhydroxid.ErhalteMolekuel(new Oxid("OH"));

            Assert.AreEqual(1, aluminiumMolekuel.AnzahlAtomeInMolekuel());
            Assert.AreEqual("Na", aluminiumMolekuel.Atombindung.ErhalteElement().Symol);

            Assert.AreEqual(1, hydroxidMolekuel.Anzahl);
            Assert.AreEqual("OH", hydroxidMolekuel.Atombindung.ChemischeFormel);
        }

        [Test]
        public void Bariumhydroxid()
        {
            // Überprüfe, ob aus den Bestandteilen die chemische Formel generiert werden kann
            Metall barium = Periodensystem.Instance.FindeMetallNachAtomsymbol("Ba");

            // Kreiere die Lauge
            Lauge bariumhydroxid = new Lauge(barium);

            // Überprüfe ob identisch
            Assert.AreEqual("Ba(OH)₂", bariumhydroxid.GeneriereChemischeFormelAusBestandteilen(fuerAnzeige: true));

            bariumhydroxid = new Lauge("Ba(OH)₂");
            bariumhydroxid.Bestandteile = bariumhydroxid.GeneriereBestandteileAusChemischerFormel();

            // Erhalte die Moleküle aus den Bestandteilen
            Molekuel aluminiumMolekuel = bariumhydroxid.ErhalteMolekuel(barium);
            Molekuel hydroxidMolekuel = bariumhydroxid.ErhalteMolekuel(new Oxid("OH"));

            Assert.AreEqual(1, aluminiumMolekuel.AnzahlAtomeInMolekuel());
            Assert.AreEqual("Ba", aluminiumMolekuel.Atombindung.ErhalteElement().Symol);

            Assert.AreEqual(2, hydroxidMolekuel.Anzahl);
            Assert.AreEqual("OH", hydroxidMolekuel.Atombindung.ChemischeFormel);
        }

        [Test]
        public void Aluminiumhydroxid()
        {
            // Überprüfe, ob aus den Bestandteilen die chemische Formel generiert werden kann
            Metall aluminium = Periodensystem.Instance.FindeMetallNachAtomsymbol("Al");

            // Kreiere die Lauge
            Lauge aluminiumhydroxid = new Lauge(aluminium);

            // Überprüfe ob identisch
            Assert.AreEqual("Al(OH)₃", aluminiumhydroxid.GeneriereChemischeFormelAusBestandteilen());

            aluminiumhydroxid = new Lauge("Al(OH)₃");
            aluminiumhydroxid.Bestandteile = aluminiumhydroxid.GeneriereBestandteileAusChemischerFormel();

            // Erhalte die Moleküle aus den Bestandteilen
            Molekuel aluminiumMolekuel = aluminiumhydroxid.ErhalteMolekuel(aluminium);
            Molekuel hydroxidMolekuel = aluminiumhydroxid.ErhalteMolekuel(new Oxid("OH"));

            Assert.AreEqual(1, aluminiumMolekuel.AnzahlAtomeInMolekuel());
            Assert.AreEqual("Al", aluminiumMolekuel.Atombindung.ErhalteElement().Symol);

            Assert.AreEqual(3, hydroxidMolekuel.Anzahl);
            Assert.AreEqual("OH", hydroxidMolekuel.Atombindung.ChemischeFormel);
        }
    }
}
