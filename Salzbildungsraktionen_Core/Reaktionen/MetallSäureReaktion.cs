using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
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

        private Reaktionsstoff<Salz<Metall, Verbindung>> _SalzKomponente;
        public Reaktionsstoff<Salz<Metall, Verbindung>> SalzKomponente
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

        public MetallSäureReaktion(Metall metall, Saeure saeure)
        {
            MetallKomponente = new Reaktionsstoff<Metall>(metall);
            SaeureKomponente = new Reaktionsstoff<Saeure>(saeure);
        }

        /// <summary>
        /// Startet die Metall-Säure Reaktion
        /// </summary>
        public override void BeginneReaktion()
        {
            // Ionisiere das Metall
            MetallIon metallIon = new MetallIon(MetallKomponente.Stoff);

            // Erhalte das Säurerest-Ion der Säure
            Anion<Verbindung> saeurerestIon = SaeureKomponente.Stoff.SaeurerestIon;

            // Generie das Salz aus den Ionen
            Salz<Metall, Verbindung> salz = new Salz<Metall, Verbindung>(metallIon, saeurerestIon);
            SalzKomponente = new Reaktionsstoff<Salz<Metall, Verbindung>>(salz);

            // Metall ausgleichen
            MetallKomponente.Anzahl = salz.AnzahlKatione;

            // Säure ausgleichen
            SaeureKomponente.Anzahl = salz.AnzahlAnione;

            // Salz ausgleichen
            // TODO: noch implementieren
            SalzKomponente.Anzahl = 1;

            // Erstelle das Wasserstoff
            Nichtmetall wasserstoff = Nichtmetall.ErhalteNichtmetall(Nichtmetall.Wasserstoff);
            MolekulareVerbindung wasserstoffMolekuehl = new MolekulareVerbindung(wasserstoff, 2);
            WasserstoffKomponente = new Reaktionsstoff<MolekulareVerbindung>(wasserstoffMolekuehl);

            // Gleiche den Wasserstoff aus
            WasserstoffKomponente.Anzahl = (SaeureKomponente.Anzahl * SaeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome) / wasserstoffMolekuehl.AnzahlAtome;
        }
    }
}
