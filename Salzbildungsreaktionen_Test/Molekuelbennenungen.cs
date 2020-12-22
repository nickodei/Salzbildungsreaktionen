using NUnit.Framework;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Molekulare_Verbindungen;

namespace Salzbildungsreaktionen_Test
{
    public class Molekuelbennenungen
    {
        [Test]
        public void Dihydrogenoxid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("H₂O");
            Assert.AreEqual("Dihydrogenoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Stickstofftrihydrid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("NH₃");
            Assert.AreEqual("Stickstofftrihydrid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Distickstoffoxid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("N₂O");
            Assert.AreEqual("Distickstoffoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Kohlenstoffdisulfid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("CS₂");
            Assert.AreEqual("Kohlenstoffdisulfid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Sauerstoffdifluorid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("OF₂");
            Assert.AreEqual("Sauerstoffdifluorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Natriumchlorid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("NaCl");
            Assert.AreEqual("Natriumchlorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Dialuminiumtrioxid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("Al₂O₃");
            Assert.AreEqual("Dialuminiumtrioxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Kaliummagnesiumtrifluorid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("KMgF₃");
            Assert.AreEqual("Kaliummagnesiumtrifluorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Magnesiumtitantrioxid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("MgTiO₃");
            Assert.AreEqual("Magnesiumtitantrioxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Lithiumhydrogensulfid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("LiHS");
            Assert.AreEqual("Lithiumhydrogensulfid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Schwefeldichloridoxid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("SOCl₂");
            Assert.AreEqual("Schwefeldichloridoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Phosphorbromidchloridfluorid()
        {
            Molekularverbindung verbindung = new Molekularverbindung("PBrClF");
            Assert.AreEqual("Phosphorbromidchloridfluorid", verbindung.GeneriereNameErsterOrdnung());
        }
    }
}
