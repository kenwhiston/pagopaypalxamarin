
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;

namespace PagoPaypal
{
	public partial class MainPage : ContentPage
	{

        public MainPage()
		{
			InitializeComponent();
		}

        async void HandlePayPalExpressCheckoutButtonClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => paypalButton.IsEnabled = false);

            await Resolver
                .Resolve<IPayPalApiClient>()
                .MakePayment()
                .ContinueWith((r) => {
                    var result = r.Result;

                    Device.BeginInvokeOnMainThread(() => {
                        paypalButton.IsEnabled = true;

                        if (result.DisplayError == null)
                        {
                            Navigation.PushAsync(new PayPalWebView(result.Url, result.AccessToken));
                        }
                        else
                        {
                            // display executePaymentData.DisplayError
                        }
                    });
                });
        }

    }
}
