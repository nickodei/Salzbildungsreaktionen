using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;
using System;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Reaktionen
{
    public class MetalloxidSaeureReaktion : Reaktion
    {
        private Metalloxid _ReaktionsstoffMetalloxid;
        public Metalloxid ReaktionsstoffMetalloxid
        {
            get { return _ReaktionsstoffMetalloxid; }
            set { _ReaktionsstoffMetalloxid = value; }
        }

        private Saeure _ReaktionsstoffSaeure;
        public Saeure ReaktionsstoffSaeure
        {
            get { return _ReaktionsstoffSaeure; }
            set { _ReaktionsstoffSaeure = value; }
        }

        private List<MetalloxidSaeureReaktionsResultat> _ReaktionsResultat;
        public List<MetalloxidSaeureReaktionsResultat> ReaktionsResultate
        {
            get { return _ReaktionsResultat; }
            set { _ReaktionsResultat = value; }
        }

        public MetalloxidSaeureReaktion(Metalloxid metalloxid, Saeure saeure)
        {
            ReaktionsstoffMetalloxid = metalloxid;
            ReaktionsstoffSaeure = saeure;
            ReaktionsResultate = new List<MetalloxidSaeureReaktionsResultat>();
        }

        public override void BeginneReaktion()
        {
            List<(Kation<MolekulareVerbindung>, Anion<Verbindung>)> saeureVariationen = ReaktionsstoffSaeure.ErhalteVariantenDerSaerebestandteile();
            foreach ((Kation<MolekulareVerbindung>, Anion<Verbindung>) saeureVariation in saeureVariationen)
            {
                // Ionisiere das Metall
                MetallIon metallIon = new MetallIon(ReaktionsstoffMetalloxid.Metall.Stoff);
                
                // Item1: Wasserstoff
                // Item2: Säurerest

                // Generie das Salz aus den Ionen
                Salz<Metall, Verbindung> salz = new Salz<Metall, Verbindung>(metallIon, saeureVariation.Item2);

                // Erstelle die Reaktionsstoffe
                Reaktionsstoff<Metalloxid> metalloxidKomponente = new Reaktionsstoff<Metalloxid>(ReaktionsstoffMetalloxid);
                Reaktionsstoff<Saeure> saeureKomponente = new Reaktionsstoff<Saeure>(ReaktionsstoffSaeure);
                Reaktionsstoff<Salz<Metall, Verbindung>> salzKomponente = new Reaktionsstoff<Salz<Metall, Verbindung>>(salz);

                // Gleichung ausgleichen
                if (metalloxidKomponente.Stoff.AnzahlMetall > salz.AnzahlKatione)
                {
                    // Es gibt somit nur ein Metalloxidion
                    metalloxidKomponente.Anzahl = 1;

                    // Anzahl meiner Salzionen anpassen
                    salzKomponente.Anzahl = metalloxidKomponente.Stoff.AnzahlMetall;

                    // Somit muss auch die Anzahl der Säureionen angepasst werden
                    saeureKomponente.Anzahl = salzKomponente.Anzahl;
                }
                else
                {
                    salzKomponente.Anzahl = 1;
                    metalloxidKomponente.Anzahl = salz.AnzahlKatione;
                    saeureKomponente.Anzahl = salz.AnzahlAnione;
                }

                // Erstelle das Wasserstoff
                Verbindung wasser = new Verbindung("H₂O");

                // Gleiche den Wasserstoff aus
                Reaktionsstoff<Verbindung> wasserKomponente = new Reaktionsstoff<Verbindung>(wasser);
                wasserKomponente.Anzahl = (saeureKomponente.Anzahl * saeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome - salzKomponente.Stoff.AnzahlAnione * (ReaktionsstoffSaeure.WasserstoffIon.Stoff.AnzahlAtome - saeureVariation.Item1.Stoff.AnzahlAtome)) / 2;

                ReaktionsResultate.Add(new MetalloxidSaeureReaktionsResultat(metalloxidKomponente, saeureKomponente, salzKomponente, wasserKomponente));
            }
        }
    }
}
