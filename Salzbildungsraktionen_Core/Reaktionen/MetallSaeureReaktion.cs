using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class MetallSaeureReaktion : Reaktion
    {
        private Metall _ReaktionsstoffMetall;
        public Metall ReaktionsstoffMetall
        {
            get { return _ReaktionsstoffMetall; }
            set { _ReaktionsstoffMetall = value; }
        }

        private Saeure _ReaktionsstoffSaeure;
        public Saeure ReaktionsstoffSaeure
        {
            get { return _ReaktionsstoffSaeure; }
            set { _ReaktionsstoffSaeure = value; }
        }

        private List<MetallSaeureReaktionsResultat> _ReaktionsResultat;
        public List<MetallSaeureReaktionsResultat> ReaktionsResultate
        {
            get { return _ReaktionsResultat; }
            set { _ReaktionsResultat = value; }
        }


        public MetallSaeureReaktion(Metall metall, Saeure saeure)
        {
            ReaktionsstoffMetall = metall;
            ReaktionsstoffSaeure = saeure;
            ReaktionsResultate = new List<MetallSaeureReaktionsResultat>();
        }

        /// <summary>
        /// Startet die Metall-Säure Reaktion
        /// </summary>
        public override void BeginneReaktion()
        {
            List<(Kation<MolekulareVerbindung>, Anion<Verbindung>)> saeureVariationen = ReaktionsstoffSaeure.ErhalteVariantenDerSaerebestandteile();
            foreach ((Kation<MolekulareVerbindung>, Anion<Verbindung>) saeureVariation in saeureVariationen)
            {
                // Ionisiere das Metall
                MetallIon metallIon = new MetallIon(ReaktionsstoffMetall);
                // Item1: Wasserstoff
                // Item2: Säurerest

                // Generie das Salz aus den Ionen
                Salz<Metall, Verbindung> salz = new Salz<Metall, Verbindung>(metallIon, saeureVariation.Item2);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff<Metall> metallKomponente = new Reaktionsstoff<Metall>(ReaktionsstoffMetall);
                Reaktionsstoff<Saeure> saeureKomponente = new Reaktionsstoff<Saeure>(ReaktionsstoffSaeure);
                Reaktionsstoff<Salz<Metall, Verbindung>> salzKomponente = new Reaktionsstoff<Salz<Metall, Verbindung>>(salz);

                // Metall ausgleichen
                metallKomponente.Anzahl = salz.AnzahlKatione;

                // Säure ausgleichen
                saeureKomponente.Anzahl = salz.AnzahlAnione;

                // Salz ausgleichen
                // TODO: noch implementieren
                salzKomponente.Anzahl = 1;

                // Erstelle das Wasserstoff
                Nichtmetall wasserstoff = Nichtmetall.ErhalteNichtmetall(Nichtmetall.Wasserstoff);
                MolekulareVerbindung wasserstoffMolekuehl = new MolekulareVerbindung(wasserstoff, 2);

                // Gleiche den Wasserstoff aus
                Reaktionsstoff<MolekulareVerbindung> wasserstoffKomponente = new Reaktionsstoff<MolekulareVerbindung>(wasserstoffMolekuehl);
                wasserstoffKomponente.Anzahl = (saeureKomponente.Anzahl * saeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome - salzKomponente.Stoff.AnzahlAnione * (ReaktionsstoffSaeure.WasserstoffIon.Stoff.AnzahlAtome - saeureVariation.Item1.Stoff.AnzahlAtome)) / wasserstoffMolekuehl.AnzahlAtome;

                ReaktionsResultate.Add(new MetallSaeureReaktionsResultat(metallKomponente, saeureKomponente, salzKomponente, wasserstoffKomponente));
            }
        }
    }
}
