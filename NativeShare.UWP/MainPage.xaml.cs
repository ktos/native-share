using NativeShare.UWP.Services;
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
        private ShareManager shareManager;

        public MainPage()
        {
            this.InitializeComponent();
            shareManager = new ShareManager();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var args = e.Parameter as ProtocolActivatedEventArgs;
            if (args != null)
            {
                var w = new WwwFormUrlDecoder(args.Uri.Query);

                if (w.Count == 1 && w[0].Name == "value")
                {
                    shareManager.Share(w[0].Value, ShareManager.UriToDataType(args.Uri.AbsolutePath));
                }
            }
        }
    }
}
