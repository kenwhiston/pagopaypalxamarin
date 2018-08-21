
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
        PayPalMakePaymentData infoPago;

        public MainPage()
		{
			InitializeComponent();
		}

        async void HandlePayPalExpressCheckoutButtonClicked(object sender, EventArgs e)
        {


            infoPago = new PayPalMakePaymentData
            {
                intent = "sale",
                redirect_urls = new PayPalMakePaymentRedirectUrls
                {
                    return_url = Config.ReturnUrl,
                    cancel_url = Config.CancelUrl
                },
                payer = new PayPalPayer
                {
                    payment_method = "paypal"
                },
                transactions = new[] {
                        new PayPalTransaction {
                            amount = new PayPalAmount {
                                total = "550",
                                currency = "MXN",
                                details = new PayPalAmountDetails {
                                    subtotal = "500",
                                    tax = "25",
                                    shipping = "25"
                                }
                            },
                            item_list = new PayPalItemList {
                                items = new [] {
                                    new PayPalItem {
                                        quantity = "1",
                                        name = "Booking reservation",
                                        price = "500",
                                        currency = "MXN",
                                        description = "Booking reservation at ABC hotel at 24/03/2015 from 1pm to 4pm.",
                                        tax = "25"
                                    }
                                }
                            }
                        }
                    }
            };

            Device.BeginInvokeOnMainThread(() => paypalButton.IsEnabled = false);

            await Resolver
                .Resolve<IPayPalApiClient>()
                .MakePayment(infoPago)
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
