using Salzbildungsreaktionen_UWP.Ansichten.Seiten;
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

            // Start Seite
            contentFrame.Navigate(typeof(MetallSaeurePage));
        }

        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                //contentFrame.Navigate(typeof(Views.SettingsPage));
            }
            else
            {              
                switch (args.InvokedItemContainer.Name)
                {
                    case "metallSaeureNavigation":
                        contentFrame.Navigate(typeof(MetallSaeurePage));
                        break;

                    case "metalloxdiSaeureNavigation":
                        contentFrame.Navigate(typeof(MetalloxidSaeurePage));
                        break;

                    case "saeureLaugeNavigation":
                        contentFrame.Navigate(typeof(SaeureLaugePage));
                        break;
                }
            }
        }
    }
}
