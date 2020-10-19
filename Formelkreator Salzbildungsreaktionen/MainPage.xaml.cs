using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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
        }

        private bool isSubscriptEnabled = false;
        private string subscriptText = "";

        private void RichEditBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            var box = sender as RichEditBox;
            if(e.Key == Windows.System.VirtualKey.Control)
            {
                isSubscriptEnabled = !isSubscriptEnabled;
            }

            if(isSubscriptEnabled)
            {
                e.Handled = true;
                switch (e.Key)
                {
                    case Windows.System.VirtualKey.Number1:
                        subscriptText = "\u2081";
                        break;
                    case Windows.System.VirtualKey.Number2:
                        subscriptText = "\u2082";
                        break;
                    case Windows.System.VirtualKey.Number3:
                        subscriptText = "\u2083";
                        break;
                    case Windows.System.VirtualKey.Number4:
                        subscriptText = "\u2084";
                        break;
                    case Windows.System.VirtualKey.Number5:
                        subscriptText = "\u2085";
                        break;
                    case Windows.System.VirtualKey.Number6:
                        subscriptText = "\u2086";
                        break;
                    case Windows.System.VirtualKey.Number7:
                        subscriptText = "\u2087";
                        break;
                    case Windows.System.VirtualKey.Number8:
                        subscriptText = "\u2088";
                        break;
                    case Windows.System.VirtualKey.Number9:
                        subscriptText = "\u2089";
                        break;
                }
            }
        }

        private void RichEditBox_TextChanging(RichEditBox sender, RichEditBoxTextChangingEventArgs args)
        {
            if(!String.IsNullOrEmpty(subscriptText))
            {
                sender.Document.GetText(Windows.UI.Text.TextGetOptions.None, out string text);
                text = text.Replace("\r", "").Remove(sender.Document.Selection.StartPosition - 1, 1);
                var startPosition = sender.Document.Selection.StartPosition;

                sender.Document.SetText(Windows.UI.Text.TextSetOptions.None, text + subscriptText);
                sender.Document.Selection.StartPosition = startPosition;

                subscriptText = "";
            }
        }

        private void GeneriereGleichungen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
