using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
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
            //List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)> saeureVariationen = ReaktionsstoffSaeure.ErhalteVariantenDerSaerebestandteile();
            //foreach ((Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>) saeureVariation in saeureVariationen)
            //{
            //    // Ionisiere das Metall
            //    Kation<Metall> metallIon = new Kation<Metall>(ReaktionsstoffMetalloxid.MetallIon.Stoff, ReaktionsstoffMetalloxid.MetallIon.Stoff.BerechenLadungszahl());

            //    // Item1: Wasserstoff
            //    // Item2: Säurerest

            //    // Generie das Salz aus den Ionen
            //    Salz<Metall, MultiElementMolekuehl> salz = new Salz<Metall, MultiElementMolekuehl>(metallIon, saeureVariation.Item2);

            //    // Erstelle die Reaktionsstoffe
            //    Reaktionsstoff<Metalloxid> metalloxidKomponente = new Reaktionsstoff<Metalloxid>(ReaktionsstoffMetalloxid);
            //    Reaktionsstoff<Saeure> saeureKomponente = new Reaktionsstoff<Saeure>(ReaktionsstoffSaeure);
            //    Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> salzKomponente = new Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>>(salz);


            //    // Wenn das Metalloxid mehr Metall Atome besitze als das Salz
            //    if (metalloxidKomponente.Stoff.AnzahlMetall > salz.AnzahlKatione)
            //    {
            //        // Somit wissen wir, das es nur ein Metalloxdi Molekühl gibt
            //        metalloxidKomponente.Anzahl = 1;

            //        // Die Anzahl des Salzes muss so angepasst werden
            //        // sodass die Metallatom Anzahl übereinstimmt
            //        salzKomponente.Anzahl = metalloxidKomponente.Stoff.AnzahlMetall;
            //    }
            //    // Ansonsten
            //    else
            //    {
            //        // Somit wissen wir, das es nur ein Salz Molekühl gibt
            //        salzKomponente.Anzahl = 1;

            //        // Die Anzahl des Metalloxides muss so angepasst werden
            //        // sodass die Metallatom Anzahl übereinstimmt
            //        metalloxidKomponente.Anzahl = (salzKomponente.Anzahl * salz.AnzahlKatione) / metalloxidKomponente.Stoff.AnzahlMetall;
            //    }

            //    // Die Anzahl der Säure entspricht die Anzahl des Säurerestions
            //    // mulipliziert mit der Anzahl des Salzes
            //    saeureKomponente.Anzahl = salzKomponente.Anzahl * salz.AnzahlAnione;


            //    MultiElementMolekuehl wasser = new MultiElementMolekuehl("H₂O"); //MolekuehlHelfer.GeneriereWasser();
            //    Reaktionsstoff<MultiElementMolekuehl> wasserKomponente = new Reaktionsstoff<MultiElementMolekuehl>(wasser);
            //    // Berechne die Anzahl des Wasserstoffes um die Anzahl der 
            //    // Wasser Molekühle zu bekommen
            //    double maximaleWasserstoffAtome = saeureKomponente.Anzahl * saeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome;
            //    double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salzKomponente.Stoff.AnzahlAnione * (saeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome - saeureVariation.Item1.Stoff.AnzahlAtome));

            //    wasserKomponente.Anzahl = restlicheWasserstoffAtome / 2;

            //    // Überprüfe mit den vorhanden Sauerstoffatomem, ob die Gleichung
            //    // korrekt augeglichen wurde

            //    // TODO: implementieren

            //    ReaktionsResultate.Add(new MetalloxidSaeureReaktionsResultat(metalloxidKomponente, saeureKomponente, salzKomponente, wasserKomponente));
            //}
        }
    }
}
