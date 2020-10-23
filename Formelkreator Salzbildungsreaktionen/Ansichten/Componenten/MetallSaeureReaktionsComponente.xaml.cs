﻿using Salzbildungsreaktionen_Core.Reaktionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Benutzersteuerelement" wird unter https://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.
namespace Formelkreator_Salzbildungsreaktionen.Ansichten.Componenten
{
    public sealed partial class MetallSaeureReaktionsComponente : UserControl
    {
        public Reaktionsstoff<Metall> MetallKomponente
        {
            get { return (Reaktionsstoff<Metall>)GetValue(MetallKomponenteProperty); }
            set { SetValue(MetallKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetallKomponenteProperty =
            DependencyProperty.Register("Metall", typeof(Reaktionsstoff<Metall>), typeof(MetallSaeureReaktionsComponente), null);

        public Reaktionsstoff<Saeure> SaeureKomponente
        {
            get { return (Reaktionsstoff<Saeure>)GetValue(SaeureKomponenteProperty); }
            set { SetValue(SaeureKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaeureKomponenteProperty =
            DependencyProperty.Register("Saeure", typeof(Reaktionsstoff<Saeure>), typeof(MetallSaeureReaktionsComponente), null);

        public Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> SalzKomponente
        {
            get { return (Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>>)GetValue(SalzKomponenteProperty); }
            set { SetValue(SalzKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalzKomponenteProperty =
            DependencyProperty.Register("Salz", typeof(Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>>), typeof(MetallSaeureReaktionsComponente), null);

        public Reaktionsstoff<ElementMolekuehl> WasserstoffKomponente
        {
            get { return (Reaktionsstoff<ElementMolekuehl>)GetValue(WasserstoffKomponenteProperty); }
            set { SetValue(WasserstoffKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WasserstoffKomponenteProperty =
            DependencyProperty.Register("Wasserstoff", typeof(Reaktionsstoff<ElementMolekuehl>), typeof(MetallSaeureReaktionsComponente), null);

        public MetallSaeureReaktionsComponente()
        {
            this.InitializeComponent();
        }
    }
}
