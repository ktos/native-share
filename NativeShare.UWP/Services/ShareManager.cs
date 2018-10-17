using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace NativeShare.UWP.Services
{
    internal enum DataType
    {
        Uri,
        Text
    }

    internal class ShareManager
    {
        public static DataType UriToDataType(string uri)
        {
            switch (uri)
            {
                case "uri": return DataType.Uri;
                case "text": return DataType.Text;
                default: return DataType.Text;
            }
        }

        public event EventHandler ShareTargetChosen;
        public event EventHandler InvalidData;

        private DataType dataType;
        private string data;

        private void Dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (dataType == DataType.Uri)
            {
                try
                {
                    args.Request.Data.Properties.Title = "Native Share URI";
                    args.Request.Data.SetWebLink(new Uri(data));
                }
                catch (UriFormatException)
                {
                    InvalidData?.Invoke(this, null);
                }
            }
            else if (dataType == DataType.Text)
            {
                args.Request.Data.Properties.Title = "Native Share Text";
                args.Request.Data.SetText(data);
            }
        }

        public void Share(string data, DataType type)
        {
            this.data = data;
            dataType = type;

            var dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += Dtm_DataRequested;
            dtm.TargetApplicationChosen += Dtm_TargetApplicationChosen;

            DataTransferManager.ShowShareUI(new ShareUIOptions() { Theme = ShareUITheme.Dark });
        }

        private void Dtm_TargetApplicationChosen(DataTransferManager sender, TargetApplicationChosenEventArgs args)
        {
            ShareTargetChosen?.Invoke(this, null);
        }
    }
}
