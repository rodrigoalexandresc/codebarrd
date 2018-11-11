using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile;
using ZXing.Net.Mobile.Forms;

namespace CodeBarR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OpenScanner(object sender, EventArgs e)
        {
            Scanner();
        }

        public async void Scanner()
        {
            var scannerPage = new ZXingScannerPage(new ZXing.Mobile.MobileBarcodeScanningOptions
            {                
            });

            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    DisplayAlert("Código escaneado", result.Text, "OK");
                });
            };

            await Navigation.PushAsync(scannerPage);
        }
    }
}
