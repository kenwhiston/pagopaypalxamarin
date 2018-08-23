
using PagoPaypal.Pages;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;

namespace PagoPaypal
{
	public partial class MainPage : ContentPage
	{
        PayPalMakePaymentData infoPago;
        string Cantidad = "550";
        string Moneda = "MXN";
        public MainPage()
		{
			InitializeComponent();
            //inicializamos
            etMonto.Text = this.Cantidad;
            etMoneda.Text = this.Moneda;
        }
        public MainPage(string cantidad, string moneda)
        {
            cantidad = "550";
            moneda = "MXN";
            InitializeComponent();
            this.Cantidad = cantidad;
            this.Moneda = moneda;

            //inicializamos
            etMonto.Text = this.Cantidad;
            etMoneda.Text = this.Moneda;

        }
        async void HandlePayPalExpressCheckoutButtonClicked(object sender, EventArgs e)
        {
            paypalImage.Source = "paypalnow_clicked.png";
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
                                total = Cantidad,
                                currency = Moneda,
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
            paypalImage.Source = "paypalnow.png";
            Device.BeginInvokeOnMainThread(() => paypalImage.IsEnabled = false);
            
            await Resolver
                .Resolve<IPayPalApiClient>()
                .MakePayment(infoPago)
                .ContinueWith((r) => {
                    var result = r.Result;

                    Device.BeginInvokeOnMainThread(() => {
                        paypalImage.IsEnabled = true;

                        if (result.DisplayError == null)
                        {
                            Navigation.PushAsync(new PayPalWebView(result.Url, result.AccessToken));
                        }
                        else
                        {
                            //PopupNavigation.PushAsync(new SuccesPupUp());
                            // display executePaymentData.DisplayError
                        }
                    });
                });
        }

    }
}
