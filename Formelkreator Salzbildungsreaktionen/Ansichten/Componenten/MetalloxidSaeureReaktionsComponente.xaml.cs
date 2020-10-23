using Salzbildungsreaktionen_Core.Reaktionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Benutzersteuerelement" wird unter https://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.
namespace Formelkreator_Salzbildungsreaktionen.Ansichten.Componenten
{
    public sealed partial class MetalloxidSaeureReaktionsComponente : UserControl
    {
        public Reaktionsstoff<Metalloxid> MetalloxidKomponente
        {
            get { return (Reaktionsstoff<Metalloxid>)GetValue(MetalloxidKomponenteProperty); }
            set { SetValue(MetalloxidKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetalloxidKomponenteProperty =
            DependencyProperty.Register("Metalloxid", typeof(Reaktionsstoff<Metalloxid>), typeof(MetalloxidSaeureReaktionsComponente), null);

        public Reaktionsstoff<Saeure> SaeureKomponente
        {
            get { return (Reaktionsstoff<Saeure>)GetValue(SaeureKomponenteProperty); }
            set { SetValue(SaeureKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaeureKomponenteProperty =
            DependencyProperty.Register("Saeure", typeof(Reaktionsstoff<Saeure>), typeof(MetalloxidSaeureReaktionsComponente), null);

        public Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>> SalzKomponente
        {
            get { return (Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>>)GetValue(SalzKomponenteProperty); }
            set { SetValue(SalzKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalzKomponenteProperty =
            DependencyProperty.Register("Salz", typeof(Reaktionsstoff<Salz<Metall, MultiElementMolekuehl>>), typeof(MetalloxidSaeureReaktionsComponente), null);

        public Reaktionsstoff<MultiElementMolekuehl> WasserKomponente
        {
            get { return (Reaktionsstoff<MultiElementMolekuehl>)GetValue(WasserKomponenteProperty); }
            set { SetValue(WasserKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WasserKomponenteProperty =
            DependencyProperty.Register("Wasser", typeof(Reaktionsstoff<MultiElementMolekuehl>), typeof(MetalloxidSaeureReaktionsComponente), null);

        public MetalloxidSaeureReaktionsComponente()
        {
            this.InitializeComponent();
        }
    }
}
