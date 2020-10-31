using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System.Collections.Generic;
using System.Linq;

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
            //List<(Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>)> saeureVariationen = ReaktionsstoffSaeure.ErhalteVariantenDerSaerebestandteile();
            //foreach ((Kation<ElementMolekuehl>, Anion<MultiElementMolekuehl>) saeureVariation in saeureVariationen)
            //{
            //    // Item1: Wasserstoff
            //    // Item2: Säurerest

            //    // Ionisiere das Metall
            //    Kation<Metall> metallIon = new Kation<Metall>(ReaktionsstoffMetall, ReaktionsstoffMetall.BerechenLadungszahl());

            //    // Generie das Salz aus den Ionen
            //    Salz<Metall, MultiElementMolekuehl> salz = new Salz<Metall, MultiElementMolekuehl>(metallIon, saeureVariation.Item2);

            //    // Erstelle die Reaktionsstoffe
            //    Reaktionsstoff<Metall> metallKomponente = new Reaktionsstoff<Metall>(ReaktionsstoffMetall);
            //    Reaktionsstoff<Saeure> saeureKomponente = new Reaktionsstoff<Saeure>(ReaktionsstoffSaeure);
            //    Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> salzKomponente = new Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>>(salz);

            //    // Metall ausgleichen
            //    metallKomponente.Anzahl = salz.AnzahlKatione;

            //    // Säure ausgleichen
            //    saeureKomponente.Anzahl = salz.AnzahlAnione;

            //    // Salz ausgleichen
            //    salzKomponente.Anzahl = 1;

            //    // Erstelle das Wasserstoff
            //    Nichtmetall wasserstoff = Periodensystem.Instance.Nichtmetalle.Values.Where(x => x.Formel.Equals("H")).FirstOrDefault();
            //    if (wasserstoff != null)
            //    {
            //        ElementMolekuehl wasserstoffMolekuehl = new ElementMolekuehl(wasserstoff, 2);
            //        Reaktionsstoff<ElementMolekuehl> wasserstoffKomponente = new Reaktionsstoff<ElementMolekuehl>(wasserstoffMolekuehl);

            //        // Gleiche den Wasserstoff aus
            //        double maximaleWasserstoffAtome = saeureKomponente.Anzahl * saeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome;
            //        double restlicheWasserstoffAtome = maximaleWasserstoffAtome - (salzKomponente.Anzahl * salzKomponente.Stoff.AnzahlAnione * (saeureKomponente.Stoff.WasserstoffIon.Stoff.AnzahlAtome - saeureVariation.Item1.Stoff.AnzahlAtome));

            //        wasserstoffKomponente.Anzahl = restlicheWasserstoffAtome / 2;
            //        ReaktionsResultate.Add(new MetallSaeureReaktionsResultat(metallKomponente, saeureKomponente, salzKomponente, wasserstoffKomponente));
            //    }
            //}
        }
    }
}
