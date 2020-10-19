using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class MetallSäureReaktion : Reaktion
    {
        private Reaktionsstoff<Metall> _MetallKomponente;
        public Reaktionsstoff<Metall> MetallKomponente
        {
            get { return _MetallKomponente; }
            set { _MetallKomponente = value; }
        }

        private Reaktionsstoff<Saeure> _SaeureKomponente;
        public Reaktionsstoff<Saeure> SaeureKomponente
        {
            get { return _SaeureKomponente; }
            set { _SaeureKomponente = value; }
        }

        private Reaktionsstoff<Salz> _SalzKomponente;
        public Reaktionsstoff<Salz> SalzKomponente
        {
            get { return _SalzKomponente; }
            set { _SalzKomponente = value; }
        }

        private Reaktionsstoff<MolekulareVerbindung> _WasserstoffKomponente;
        public Reaktionsstoff<MolekulareVerbindung> WasserstoffKomponente
        {
            get { return _WasserstoffKomponente; }
            set { _WasserstoffKomponente = value; }
        }

        public MetallSäureReaktion(Metall metall, Saeure säure)
        {
            MetallKomponente = new Reaktionsstoff<Metall>(metall);
            SaeureKomponente = new Reaktionsstoff<Saeure>(säure);
        }

        /// <summary>
        /// Startet die Metall-Säure Reaktion
        /// </summary>
        public override void BeginneReaktion()
        {
            // Ionisiere das Metall
            MetallIon metallIon = MetallIon.ErhalteMetallIon(MetallKomponente.Stoff);

            // Das SäurerestIon kann von der Säure kopiert werden
            SäurerestIon säurerestIon = SaeureKomponente.Stoff.Säurerest;

            // Erstelle aus dem Metall und der Säure das Salz
            Salz salz = Salz.ErhalteSalz(metallIon, säurerestIon);
            SalzKomponente = new Reaktionsstoff<Salz>(salz);

            // Metall ausgleichen
            MetallKomponente.Anzahl = salz.MetallIonMolekühle;

            // Säure ausgleichen
            SaeureKomponente.Anzahl = salz.SäurerestIonMolekühle;

            // Salz ausgleichen
            // TODO: noch implementieren
            SalzKomponente.Anzahl = 1;

            // Erstelle das Wasserstoff
            Nichtmetall wasserstoff = Nichtmetall.ErhalteNichtmetall(Nichtmetall.Wasserstoff);
            MolekulareVerbindung WasserstoffMolekühl = MolekulareVerbindung.ErhalteVerbindung(wasserstoff, 2);
            WasserstoffKomponente = new Reaktionsstoff<MolekulareVerbindung>(WasserstoffMolekühl);

            // Gleiche den Wasserstoff aus
            WasserstoffKomponente.Anzahl = (SaeureKomponente.Anzahl * SaeureKomponente.Stoff.WasserstoffMolekühle) / WasserstoffMolekühl.AnzahlAtome;
        }
    }
}
