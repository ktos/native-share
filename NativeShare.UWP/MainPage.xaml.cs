using NativeShare.UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.ViewManagement;
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
            ExtendAcrylicIntoTitleBar();
            shareManager = new ShareManager();
            shareManager.ShareTargetChosen += ShareManager_ShareTargetChosen;

            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void ShareManager_ShareTargetChosen(object sender, EventArgs e)
        {            
            var dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 4);
            dt.Tick += (_, __) => Application.Current.Exit();
            dt.Start();
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            ApplicationView.GetForCurrentView().TryResizeView(new Size(400, 700));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {            
            var args = e.Parameter as ProtocolActivatedEventArgs;
            if (args != null)
            {
                var w = new WwwFormUrlDecoder(args.Uri.Query);

                if (args.Uri.LocalPath == "uri" && w.Count == 1 && w[0].Name == "value")
                {
                    shareManager.Share(w[0].Value, ShareManager.UriToDataType(args.Uri.AbsolutePath));
                }

                if (args.Uri.LocalPath == "text" && w.Count == 1 && w[0].Name == "value")
                {
                    shareManager.Share(w[0].Value, ShareManager.UriToDataType(args.Uri.AbsolutePath));
                }

                help.Visibility = Visibility.Collapsed;
                shareFinish.Visibility = Visibility.Visible;
            }
        }

        // Extend acrylic into the title bar.
        private void ExtendAcrylicIntoTitleBar()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }
    }
}
