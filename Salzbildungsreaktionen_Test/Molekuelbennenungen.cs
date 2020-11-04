using NUnit.Framework;
using Salzbildungsreaktionen_Core.Teilchen.Molekuele;

namespace Salzbildungsreaktionen_Test
{
    public class Molekuelbennenungen
    {
        [Test]
        public void Diwasserstoffoxid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("H₂O");
            Assert.AreEqual("Diwasserstoffoxid", verbindung.Name);
        }

        [Test]
        public void Stickstofftrihydrid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("NH₃");
            Assert.AreEqual("Stickstofftrihydrid", verbindung.Name);
        }

        [Test]
        public void Distickstoffoxid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("N₂O");
            Assert.AreEqual("Distickstoffoxid", verbindung.Name);
        }

        [Test]
        public void Kohlenstoffdisulfid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("CS₂");
            Assert.AreEqual("Kohlenstoffdisulfid", verbindung.Name);
        }

        [Test]
        public void Sauerstoffdifluorid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("OF₂");
            Assert.AreEqual("Sauerstoffdifluorid", verbindung.Name);
        }

        [Test]
        public void Natriumchlorid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("NaCl");
            Assert.AreEqual("Natriumchlorid", verbindung.Name);
        }

        [Test]
        public void Dialuminiumtrioxid()
        {
            VerbindungsMolekuel verbindung = new VerbindungsMolekuel("Al₂O₃");
            Assert.AreEqual("Dialuminiumtrioxid", verbindung.Name);
        }
    }
}
