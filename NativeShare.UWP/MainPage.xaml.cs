using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeShare.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string data;

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.Properties.Title = "Native Share URI";
            args.Request.Data.SetWebLink(new Uri(data));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += Dtm_DataRequested;
            dtm.TargetApplicationChosen += Dtm_TargetApplicationChosen;

            DataTransferManager.ShowShareUI(new ShareUIOptions() { Theme = ShareUITheme.Dark });
        }

        private void Dtm_TargetApplicationChosen(DataTransferManager sender, TargetApplicationChosenEventArgs args)
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var args = e.Parameter as ProtocolActivatedEventArgs;
            if (args != null)
            {
                var w = new WwwFormUrlDecoder(args.Uri.Query);

                if (w.Count == 1 && w[0].Name == "value")
                {
                    data = w[0].Value;
                    Button_Click(null, null);
                }
            }
        }
    }
}
