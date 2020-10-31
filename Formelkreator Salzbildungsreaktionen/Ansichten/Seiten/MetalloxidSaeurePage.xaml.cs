using Salzbildungsreaktionen_Core;
using Salzbildungsreaktionen_Core.Reaktionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Salzbildungsreaktionen_UWP.Ansichten.Seiten
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MetalloxidSaeurePage : Page
    {
        public MetalloxidSaeurePage()
        {
            this.InitializeComponent();

            //MetallAuswahlComboBox.ItemsSource = Periodensystem.Instance.Metalle.Values.OrderBy(x => x.Valenzelektronen).Select(x => new ComboBoxItem() { Content = $"{x.Formel} - {x.Name}", Tag = x.Formel });
            //SaeureAuswahlComboBox.ItemsSource = Periodensystem.Instance.Saeure.Values.Select(x => new ComboBoxItem() { Content = $"{x.Formel} - {x.Name}", Tag = x.Formel });
        }

        private bool isSubscriptEnabled = false;
        private string subscriptText = "";

        private void RichEditBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            var box = sender as RichEditBox;
            if (e.Key == Windows.System.VirtualKey.Control)
            {
                isSubscriptEnabled = !isSubscriptEnabled;
            }

            if (isSubscriptEnabled)
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
            if (!String.IsNullOrEmpty(subscriptText))
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
            //MetallEingabeTextBox.TextDocument.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out string metallSymbol);
            //if (String.IsNullOrEmpty(metallSymbol))
            //{
            //    // Suche nun in der DropDown
            //    if (MetallAuswahlComboBox.SelectedIndex == -1)
            //        return;

            //    metallSymbol = (string)((ComboBoxItem)MetallAuswahlComboBox.SelectedValue).Tag;
            //}

            //SaeureEingabeTextBox.TextDocument.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out string saeureFormel);
            //if (String.IsNullOrEmpty(saeureFormel))
            //{
            //    // Suche nun in der DropDown
            //    if (SaeureAuswahlComboBox.SelectedIndex == -1)
            //        return;

            //    saeureFormel = (string)((ComboBoxItem)SaeureAuswahlComboBox.SelectedValue).Tag;
            //}

            //Saeure säure = new Saeure(saeureFormel);

            //Metall metall = Metall.ErhalteMetall(metallSymbol);
            //Metalloxid metalloxid = new Metalloxid(metall);

            //MetalloxidSaeureReaktion reaktion = new MetalloxidSaeureReaktion(metalloxid, säure);
            //reaktion.BeginneReaktion();

            //ReaktionsgleichungenControl.ItemsSource = new List<Object>();
            //ReaktionsgleichungenControl.ItemsSource = reaktion.ReaktionsResultate;
        }
    }
}
