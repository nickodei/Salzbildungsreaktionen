using Salzbildungsreaktionen_Core.Reaktionen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Benutzersteuerelement" wird unter https://go.microsoft.com/fwlink/?LinkId=234236 dokumentiert.

namespace Salzbildungsreaktionen_UWP.Ansichten.Komponenten
{
    public sealed partial class Reaktionskomponente : UserControl
    {
        public Reaktionsstoff Komponente1
        {
            get { return (Reaktionsstoff)GetValue(Komponente1Property); }
            set { SetValue(Komponente1Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Komponente1Property =
            DependencyProperty.Register("Komponente1", typeof(Reaktionsstoff), typeof(Reaktionskomponente), null);

        public Reaktionsstoff Komponente2
        {
            get { return (Reaktionsstoff)GetValue(Komponente2Property); }
            set { SetValue(Komponente2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Komponente2Property =
            DependencyProperty.Register("Komponente2", typeof(Reaktionsstoff), typeof(Reaktionskomponente), null);

        public Reaktionsstoff Resultat1
        {
            get { return (Reaktionsstoff)GetValue(Resultat1Property); }
            set { SetValue(Resultat1Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Resultat1Property =
            DependencyProperty.Register("Resultat1", typeof(Reaktionsstoff), typeof(Reaktionskomponente), null);

        public Reaktionsstoff Resultat2
        {
            get { return (Reaktionsstoff)GetValue(Resultat2Property); }
            set { SetValue(Resultat2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Resultat2Property =
            DependencyProperty.Register("Resultat2", typeof(Reaktionsstoff), typeof(Reaktionskomponente), null);

        public Reaktionskomponente()
        {
            this.InitializeComponent();
        }
    }
}
