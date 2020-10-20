using Salzbildungsreaktionen_Core.Reaktionen;
using Salzbildungsreaktionen_Core.Stoffe;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Benutzersteuerelement" wird unter https://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.
namespace Formelkreator_Salzbildungsreaktionen.Ansichten.Componenten
{
    public sealed partial class ReaktionsComponente : UserControl
    {
        public Reaktionsstoff<Metall> MetallKomponente
        {
            get { return (Reaktionsstoff<Metall>)GetValue(MetallKomponenteProperty); }
            set { SetValue(MetallKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetallKomponenteProperty =
            DependencyProperty.Register("Metall", typeof(Reaktionsstoff<Metall>), typeof(ReaktionsComponente), null);

        public Reaktionsstoff<Saeure> SaeureKomponente
        {
            get { return (Reaktionsstoff<Saeure>)GetValue(SaeureKomponenteProperty); }
            set { SetValue(SaeureKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaeureKomponenteProperty =
            DependencyProperty.Register("Saeure", typeof(Reaktionsstoff<Saeure>), typeof(ReaktionsComponente), null);

        public Reaktionsstoff<Salz<Metall, Verbindung>> SalzKomponente
        {
            get { return (Reaktionsstoff<Salz<Metall, Verbindung>>)GetValue(SalzKomponenteProperty); }
            set { SetValue(SalzKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalzKomponenteProperty =
            DependencyProperty.Register("Salz", typeof(Reaktionsstoff<Salz<Metall, Verbindung>>), typeof(ReaktionsComponente), null);

        public Reaktionsstoff<MolekulareVerbindung> WasserstoffKomponente
        {
            get { return (Reaktionsstoff<MolekulareVerbindung>)GetValue(WasserstoffKomponenteProperty); }
            set { SetValue(WasserstoffKomponenteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WasserstoffKomponenteProperty =
            DependencyProperty.Register("Wasserstoff", typeof(Reaktionsstoff<MolekulareVerbindung>), typeof(ReaktionsComponente), null);

        public ReaktionsComponente()
        {
            this.InitializeComponent();
        }
    }
}
