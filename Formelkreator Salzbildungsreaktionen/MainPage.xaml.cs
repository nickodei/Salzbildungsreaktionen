using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Formelkreator_Salzbildungsreaktionen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //Säure salzsäure = Säure.Create(formel: Säure.Salzsäure);
            //Metall natrium = Metall.Create(symbol: Metall.Natrium, anzahl: 1);

            //(Salz salz, Element element) = salzsäure.ReagiertMit(natrium);
        }
    }
}
