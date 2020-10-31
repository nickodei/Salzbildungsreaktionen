using NUnit.Framework;
using Salzbildungsreaktionen_Core;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Teilchen;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;

namespace Salzbildungsreaktionen_Test
{
    public class BenennungMolekuele
    {
        [Test]
        public void Schwefeldioxid()
        {
            Nichtmetall schwefel = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("S");
            Nichtmetall sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");

            Atom schwefelAtom = new Atom(schwefel);
            ElementMolekuel disauerstoff = new ElementMolekuel(sauerstoff, 2);
            MultiElementMolekuel schwefeldioxid = new MultiElementMolekuel(schwefelAtom, disauerstoff);

            Assert.AreEqual("SO₂", schwefeldioxid.ChemischeFormel);
            Assert.AreEqual("Schwefeldioxid", schwefeldioxid.Name);

            MultiElementMolekuel schwefeldioxid2 = new MultiElementMolekuel("SO₂");

            Assert.AreEqual("SO₂", schwefeldioxid2.ChemischeFormel);
            Assert.AreEqual("Schwefeldioxid", schwefeldioxid2.Name);
        }

        [Test]
        public void Diwasserstoffoxid()
        {
            Nichtmetall wasserstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("H");
            Nichtmetall sauerstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("O");

            Atom sauerstoffAtom = new Atom(sauerstoff);
            ElementMolekuel diwasserstoff = new ElementMolekuel(wasserstoff, 2);
            MultiElementMolekuel diwasserstoffoxid = new MultiElementMolekuel(sauerstoffAtom, diwasserstoff);

            Assert.AreEqual("H₂O", diwasserstoffoxid.ChemischeFormel);
            Assert.AreEqual("Diwasserstoffoxid", diwasserstoffoxid.Name);

            MultiElementMolekuel diwasserstoffoxid2 = new MultiElementMolekuel("H₂O");

            Assert.AreEqual("H₂O", diwasserstoffoxid2.ChemischeFormel);
            Assert.AreEqual("Diwasserstoffoxid", diwasserstoffoxid2.Name);
        }

        [Test]
        public void Trinatriumnitrid()
        {
            Metall natrium = Periodensystem.Instance.FindeMetallNachAtomsymbol("Na");
            Nichtmetall stickstoff = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("N");

            Atom stickstoffAtom = new Atom(stickstoff);
            ElementMolekuel trinatrium = new ElementMolekuel(natrium, 3);
            MultiElementMolekuel trinatriumnitrid = new MultiElementMolekuel(stickstoffAtom, trinatrium);

            Assert.AreEqual("Na₃N", trinatriumnitrid.ChemischeFormel);
            Assert.AreEqual("Trinatriumnitrid", trinatriumnitrid.Name);

            MultiElementMolekuel trinatriumnitrid2 = new MultiElementMolekuel("Na₃N");

            Assert.AreEqual("Na₃N", trinatriumnitrid2.ChemischeFormel);
            Assert.AreEqual("Trinatriumnitrid", trinatriumnitrid2.Name);
        }

        [Test]
        public void Dinatriumsulfid()
        {
            Metall natrium = Periodensystem.Instance.FindeMetallNachAtomsymbol("Na");
            Nichtmetall schwefel = Periodensystem.Instance.FindeNichtmetallNachAtomsymbol("S");

            Atom schwefelAtom = new Atom(schwefel);
            ElementMolekuel dinatrium = new ElementMolekuel(natrium, 2);
            MultiElementMolekuel dinatriumsulfid = new MultiElementMolekuel(schwefelAtom, dinatrium);

            Assert.AreEqual("Na₂S", dinatriumsulfid.ChemischeFormel);
            Assert.AreEqual("Dinatriumsulfid", dinatriumsulfid.Name);

            MultiElementMolekuel dinatriumsulfid2 = new MultiElementMolekuel("Na₂S");

            Assert.AreEqual("Na₂S", dinatriumsulfid2.ChemischeFormel);
            Assert.AreEqual("Dinatriumsulfid", dinatriumsulfid2.Name);
        }
    }
}
