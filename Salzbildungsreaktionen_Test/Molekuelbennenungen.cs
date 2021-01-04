using NUnit.Framework;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;

namespace Salzbildungsreaktionen_Test
{
    public class Molekuelbennenungen
    {
        [Test]
        public void Dihydrogenoxid()
        {
            Atombindung verbindung = new Atombindung("H₂O");
            Assert.AreEqual("Dihydrogenoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Stickstofftrihydrid()
        {
            Atombindung verbindung = new Atombindung("NH₃");
            Assert.AreEqual("Stickstofftrihydrid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Distickstoffoxid()
        {
            Atombindung verbindung = new Atombindung("N₂O");
            Assert.AreEqual("Distickstoffoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Kohlenstoffdisulfid()
        {
            Atombindung verbindung = new Atombindung("CS₂");
            Assert.AreEqual("Kohlenstoffdisulfid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Sauerstoffdifluorid()
        {
            Atombindung verbindung = new Atombindung("OF₂");
            Assert.AreEqual("Sauerstoffdifluorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Natriumchlorid()
        {
            Atombindung verbindung = new Atombindung("NaCl");
            Assert.AreEqual("Natriumchlorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Dialuminiumtrioxid()
        {
            Atombindung verbindung = new Atombindung("Al₂O₃");
            Assert.AreEqual("Dialuminiumtrioxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Kaliummagnesiumtrifluorid()
        {
            Atombindung verbindung = new Atombindung("KMgF₃");
            Assert.AreEqual("Kaliummagnesiumtrifluorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Magnesiumtitantrioxid()
        {
            Atombindung verbindung = new Atombindung("MgTiO₃");
            Assert.AreEqual("Magnesiumtitantrioxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Lithiumhydrogensulfid()
        {
            Atombindung verbindung = new Atombindung("LiHS");
            Assert.AreEqual("Lithiumhydrogensulfid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Schwefeldichloridoxid()
        {
            Atombindung verbindung = new Atombindung("SOCl₂");
            Assert.AreEqual("Schwefeldichloridoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Phosphorbromidchloridfluorid()
        {
            Atombindung verbindung = new Atombindung("PBrClF");
            Assert.AreEqual("Phosphorbromidchloridfluorid", verbindung.GeneriereNameErsterOrdnung());
        }
    }
}
