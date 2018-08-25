using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Ioc;

namespace PagoPaypal.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
        PayPalMakePaymentData infoPago;

        String total = "550";
        String currency = "MXN";
        String subtotal = "500";
        String tax = "25";
        String shipping = "25";

        String quantity = "1";
        String name = "Booking reservation";
        String price = "500";
        String description = "Booking reservation at ABC hotel at 24/03/2015 from 1pm to 4pm.";
        public PaymentPage ()
		{
			InitializeComponent ();
            this.total = "550";
            this.currency = "MXN";
            this.subtotal = "500";
            this.tax = "25";
            this.shipping = "25";

            this.quantity = "1";
            this.name = "Booking reservation";
            this.price = "500";
            this.description = "Booking reservation at ABC hotel at 24/03/2015 from 1pm to 4pm.";

            //inicializamos
            etMonto.Text = this.total;
            etMoneda.Text = this.currency;
            Description.Text = this.description;
            Tax.Text = this.tax;
            Name.Text = this.name;
        }
        public PaymentPage(String total, String currency, String subtotal, String tax,
            String shipping, String quantity, String name, String price, String description)
        {

            InitializeComponent();

            this.total = total;
            this.currency = currency;
            this.subtotal = subtotal;
            this.tax = tax;
            this.shipping = shipping;
            this.quantity = quantity;
            this.name = name;
            this.price = price;
            this.description = description;

            //inicializamos
            etMonto.Text = this.total;
            etMoneda.Text = this.currency;
            Description.Text = this.description;
            Tax.Text = this.tax;
            Name.Text = this.name;
        }
        async void Hola(object sender, EventArgs e)
        {
            //await PopupNavigation.PushAsync(new SuccessPopUp());
        }
        async void HandlePayPalExpressCheckoutButtonClicked(object sender, EventArgs e)
        {
            paypalImage.Source = "paypalnow_clicked.png";
            await PopupNavigation.PushAsync(new LoadingPopup());
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
                                total = this.total,
                                currency = currency,
                                details = new PayPalAmountDetails {
                                    subtotal = this.subtotal,
                                    tax = this.tax,
                                    shipping = this.shipping
                                }
                            },
                            item_list = new PayPalItemList {
                                items = new [] {
                                    new PayPalItem {
                                        quantity = this.quantity,
                                        name = this.name,
                                        price = this.price,
                                        currency = this.currency,
                                        description = this.description,
                                        tax = this.tax
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

                    Device.BeginInvokeOnMainThread(async () => {
                        paypalImage.IsEnabled = true;

                        if (result.DisplayError == null)
                        {
                            await Navigation.PushAsync(new PayPalWebView(result.Url, result.AccessToken));
                            await PopupNavigation.PopAsync();
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