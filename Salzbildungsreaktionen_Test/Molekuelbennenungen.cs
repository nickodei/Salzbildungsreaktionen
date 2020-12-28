using NUnit.Framework;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen;

namespace Salzbildungsreaktionen_Test
{
    public class Molekuelbennenungen
    {
        [Test]
        public void Dihydrogenoxid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("H₂O");
            Assert.AreEqual("Dihydrogenoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Stickstofftrihydrid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("NH₃");
            Assert.AreEqual("Stickstofftrihydrid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Distickstoffoxid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("N₂O");
            Assert.AreEqual("Distickstoffoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Kohlenstoffdisulfid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("CS₂");
            Assert.AreEqual("Kohlenstoffdisulfid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Sauerstoffdifluorid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("OF₂");
            Assert.AreEqual("Sauerstoffdifluorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Natriumchlorid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("NaCl");
            Assert.AreEqual("Natriumchlorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Dialuminiumtrioxid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("Al₂O₃");
            Assert.AreEqual("Dialuminiumtrioxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Kaliummagnesiumtrifluorid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("KMgF₃");
            Assert.AreEqual("Kaliummagnesiumtrifluorid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Magnesiumtitantrioxid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("MgTiO₃");
            Assert.AreEqual("Magnesiumtitantrioxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Lithiumhydrogensulfid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("LiHS");
            Assert.AreEqual("Lithiumhydrogensulfid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Schwefeldichloridoxid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("SOCl₂");
            Assert.AreEqual("Schwefeldichloridoxid", verbindung.GeneriereNameErsterOrdnung());
        }

        [Test]
        public void Phosphorbromidchloridfluorid()
        {
            Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung verbindung = new Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Atombindungen.Atombindung("PBrClF");
            Assert.AreEqual("Phosphorbromidchloridfluorid", verbindung.GeneriereNameErsterOrdnung());
        }
    }
}
